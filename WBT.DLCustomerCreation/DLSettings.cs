using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLSettings
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public Settings GetSettings(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    Settings settings = new Settings();
                    settings = (from s in Entities.tblAdminSettings
                                where s.OrgID == OrgID
                                select new Settings
                                {
                                    ID = s.ID,
                                    AutoSyncTally = s.AutoSyncTally,
                                    EnableSsl = s.EnableSSL.Value,
                                    MailHost = s.MailHost,
                                    MarketingEmailID = s.MarketingEmailID,
                                    Password = s.Password,
                                    PromotionalBaseURL = s.PromotionalBaseURL,
                                    PromotionalSenderID = s.PromotionSenderID,
                                    SendingPort = s.SendingPort,
                                    SMSAPIKey = s.SMSAPIKey,
                                    TansactionalSenderID = s.TansactionalSenderID,
                                    TransactionalBaseURL = s.TransactionalBaseURL,
                                    CreatedBy = s.CreatedBy,
                                    CreatedDate = s.CreatedDate,
                                    ModifiedBy = s.ModifiedBy,
                                    ModifiedDate = s.ModifiedDate,
                                }).FirstOrDefault();
                    if(settings == null)
                    {
                        settings = new Settings();
                        settings.ID = 0;
                    }
                    return settings;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Settings Update(Settings settings, string OrgID, int LoginUserID)
        {
            try
            {
                Settings Result = new Settings();
                DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if(settings.ID == 0)
                    {
                        tblAdminSetting tblAdminSetting = new tblAdminSetting();
                        tblAdminSetting.PromotionalBaseURL = settings.PromotionalBaseURL;
                        tblAdminSetting.TransactionalBaseURL = settings.TransactionalBaseURL;
                        tblAdminSetting.AutoSyncTally = settings.AutoSyncTally;
                        tblAdminSetting.MailHost = settings.MailHost;
                        tblAdminSetting.EnableSSL = settings.EnableSsl;
                        tblAdminSetting.MarketingEmailID = settings.MarketingEmailID;
                        tblAdminSetting.Password = settings.Password;
                        tblAdminSetting.PromotionSenderID = settings.PromotionalSenderID;
                        tblAdminSetting.SendingPort = settings.SendingPort;
                        tblAdminSetting.SMSAPIKey = settings.SMSAPIKey;
                        tblAdminSetting.TansactionalSenderID = settings.TansactionalSenderID;
                        tblAdminSetting.CreatedBy = LoginUserID;
                        tblAdminSetting.OrgID = OrgID;
                        tblAdminSetting.CreatedDate = DateTimeNow;

                        Entities.tblAdminSettings.Add(tblAdminSetting);
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Success!! Your settings have been updated.";
                        return Result;
                    }
                    else
                    {
                        tblAdminSetting tblAdminSetting = new tblAdminSetting();
                        tblAdminSetting.ID = settings.ID;
                        tblAdminSetting.PromotionalBaseURL = settings.PromotionalBaseURL;
                        tblAdminSetting.TransactionalBaseURL = settings.TransactionalBaseURL;
                        tblAdminSetting.AutoSyncTally = settings.AutoSyncTally;
                        tblAdminSetting.MailHost = settings.MailHost;
                        tblAdminSetting.EnableSSL = settings.EnableSsl;
                        tblAdminSetting.MarketingEmailID = settings.MarketingEmailID;
                        tblAdminSetting.Password = settings.Password;
                        tblAdminSetting.PromotionSenderID = settings.PromotionalSenderID;
                        tblAdminSetting.SendingPort = settings.SendingPort;
                        tblAdminSetting.SMSAPIKey = settings.SMSAPIKey;
                        tblAdminSetting.TansactionalSenderID = settings.TansactionalSenderID;
                        tblAdminSetting.ModifiedBy = LoginUserID;
                        tblAdminSetting.OrgID = OrgID;
                        tblAdminSetting.ModifiedDate = DateTimeNow;
                        tblAdminSetting.CreatedBy = settings.CreatedBy;
                        tblAdminSetting.CreatedDate = settings.CreatedDate;
                        Entities.tblAdminSettings.Add(tblAdminSetting);
                        Entities.Entry(tblAdminSetting).State = EntityState.Modified;
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Success!! Your settings have been updated.";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Settings Result = new Settings();
                Result.DisplayMessage = "Error!! Please try again later";
                return Result;
            }
        }
    }
    public class Settings
    {
        public int ID { get; set; }
        public string MarketingEmailID { get; set; }
        public string Password { get; set; }
        public bool AutoSyncTally { get; set; }
        public string MailHost { get; set; }
        public string SendingPort { get; set; }
        public bool EnableSsl { get; set; }
        public string SMSAPIKey { get; set; }
        public string TransactionalBaseURL { get; set; }
        public string PromotionalBaseURL { get; set; }
        public string TansactionalSenderID { get; set; }
        public string PromotionalSenderID { get; set; }
        public string DisplayMessage { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

    }
}
