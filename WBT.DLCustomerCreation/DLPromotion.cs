using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class CustomerPromotion
    {
        public int TotalCategories { get; set; }
        public int TotalStates { get; set; }
        public int TotalCities { get; set; }
        public int TotalCustomers { get; set; }
        public List<CustomerCreation> customerList { get; set; }
        public IPagedList<CustomerCreation> allList { get; set; }
        public bool IsEmail { get; set; }
        public bool IsSMS { get; set; }
        public bool IsWhatsApp { get; set; }
        [Required(ErrorMessage = "Enter SMS body")]
        public string SMSBody { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Enter your message")]
        public string MailBody { get; set; }
        [Required(ErrorMessage = "Enter Mail Subject")]
        public string MailSubject { get; set; }
        public string RoleID { get; set; }
        public string OrgID { get; set; }
        public int SMSTemplateID { get; set; }
        public int EmailTemplateID { get; set; }
    }
    public class DLPromotion
    {
        public string Promotion(CustomerPromotion promo, List<Attachment> MailAttachments)
        {
            try
            {
                promo.customerList = promo.customerList.Where(c => c.IsChecked == true).ToList();
                string Result = string.Empty;
                using (var Entities = new MWBTCustomerAppEntities())
                {
                    tblAdminSetting tblAdmin = new tblAdminSetting();
                    tblAdmin = Entities.tblAdminSettings.FirstOrDefault();
                    if (tblAdmin != null)
                    {
                        if (promo.IsEmail == true)
                        {

                            string Bcc = string.Empty;
                            List<string> bccList = new List<string>();

                            foreach (var item in promo.customerList)
                            {
                                if (!string.IsNullOrEmpty(item.EmailID))
                                {
                                    if (item.IsChecked == true)
                                    {
                                        string EmailID = item.EmailID;
                                        bccList.Add(EmailID);
                                    }
                                }
                            }

                            string ToEmailID = tblAdmin.MarketingEmailID.Trim();//ConfigurationManager.AppSettings["FromMailID"].ToString();
                            string FromMailID = tblAdmin.MarketingEmailID.Trim();
                            string MailPassword = tblAdmin.Password.Trim();
                            string MailServerHost = tblAdmin.MailHost.Trim();
                            string SendingPort = tblAdmin.SendingPort.Trim();
                            bool EnableSSL = tblAdmin.EnableSSL == null ? false : tblAdmin.EnableSSL.Value;

                            //string APKPath = ConfigurationManager.AppSettings["APKPath"].ToString();
                            string MailSubject = promo.MailSubject;

                            Helper.SendMail(ToEmailID, FromMailID, promo.MailBody, MailSubject, MailServerHost, MailPassword, SendingPort, bccList, MailAttachments, EnableSSL);
                            Result = "Email Sent Successfully!!";
                        }
                        else if (promo.IsSMS == true)
                        {
                            string BaseURL = tblAdmin.PromotionalBaseURL;
                            string APIKEY = tblAdmin.SMSAPIKey;
                            string SenderID = tblAdmin.PromotionSenderID;

                            string mobileNumbers = string.Join(",", promo.customerList.Where(b => b.IsChecked == true).Select(c => c.MobileNumber));
                            Result = Helper.SendMessage(BaseURL, APIKEY, mobileNumbers, promo.SMSBody, SenderID);
                            //foreach (var item in promo.customerList)
                            //{
                            //    if (item.IsChecked == true)
                            //    {
                                    
                            //        //string Message = "Welcome to MWB Technology New customer details name Your OTP is : 123456.ID Test Ph Tets";
                            //        //Helper.SendSMS(SMSUserName, SMSPassword, item.MobileNumber, Message, "N");
                            //    }
                            //}
                        }
                    }
                    else
                    {
                        Result = "Please add credentials in settings page, then start promoting";
                    }

                }
                return Result;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return "Error!! Please contact administrator";
            }
        }

        //Send Promotion
        public string AllCustomersPromotion(CustomerPromotion promo, List<Attachment> MailAttachments, string ImageURL, int UserID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var customers = dbContext.tblCustomerVendorDetails.Where(c => c.OrgID == promo.OrgID && c.MobileNumber != null && c.EmailID != null);
                    string Result = string.Empty;
                    if (promo.IsEmail == true)
                    {
                        string Bcc = string.Empty;
                        List<string> bccList = new List<string>();
                        bccList = customers.Select(c => c.EmailID).ToList();

                        string ToEmailID = ConfigurationManager.AppSettings["FromMailID"].ToString();
                        string FromMailID = ConfigurationManager.AppSettings["FromMailID"].ToString();
                        string MailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString();
                        string MailServerHost = ConfigurationManager.AppSettings["MailServerHost"].ToString();
                        string SendingPort = ConfigurationManager.AppSettings["SendingPort"].ToString();
                        string MailSubject = promo.MailSubject;

                        Helper.SendMail(ToEmailID, FromMailID, promo.MailBody, MailSubject, MailServerHost, MailPassword, SendingPort, bccList, MailAttachments);
                        Result = "Email Sent Successfully!!";
                    }
                    else if (promo.IsSMS == true)
                    {
                        string MobileNumbers = string.Join(",", customers.Select(c => c.MobileNumber));

                        string BaseURL = ConfigurationManager.AppSettings["PromoBaseURL"];
                        string APIKey = ConfigurationManager.AppSettings["PromoAPIKey"];
                        string SenderID = ConfigurationManager.AppSettings["PromotionalSenderID"];
                        Result = Helper.SendMessage(BaseURL, APIKey, MobileNumbers, promo.SMSBody, SenderID);
                    }
                    Result = "Success";
                    return Result;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return "Error!! Please contact administrator";
            }
        }
    }
}
