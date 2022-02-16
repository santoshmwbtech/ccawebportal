using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WBT.Common;
using WBT.DL.CCAplusSO;
using WBT.DLCustomerCreation;
using WBT.DLCustomerCreation.Reports;

namespace CCAPortal.Controllers
{
    public class ReceiptsController : Controller
    {
        // CustomerCreations customerCreations = new CustomerCreations();

        Receipts receipts = new Receipts();
        DLRouteMapping DLSalesman = new DLRouteMapping();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DLGetCustomerCreationReport DAL = new DLGetCustomerCreationReport();
        TallySync tallySync = new TallySync();
        // GET: Receipts
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Search()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                WBT.DLCustomerCreation.CustomerCreations customerCreations = new WBT.DLCustomerCreation.CustomerCreations();
                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["OrgID"].ToString(), Session["UserID"].ToString(), Session["RoleName"].ToString()), "BranchID", "Name");
                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.LedgerTypes = new SelectList(customerCreations.GetLedgerTypes(), "LedgerTypeID", "LedgerType");
                ViewBag.CustomerTypes = new SelectList(customerCreations.GetCustomerTypes(), "CustomerTypeID", "CustomerType");
                ViewBag.CompanyTypes = new SelectList(customerCreations.GetCompanyTypes(), "CompanyTypeID", "CompanyType");
                ViewBag.AreaList = new SelectList(DAL.GetAreas(Session["OrgID"].ToString()), "BillingArea", "BillingArea");
                string name = "salesman";
                ViewBag.SalesmanList = new SelectList(DLSalesman.GetSalesManList(name, Session["OrgID"].ToString()), "UserID", "Username");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult SearchReceipts(Receipts dlRececipts)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                Receipts searchItems = new Receipts();
                List<Receipts> Receiptslist = new List<Receipts>();

                searchItems.OrgID = Session["OrgID"].ToString();    //// search.OrgID; OrgID purpose
                searchItems.FromDate = dlRececipts.FromDate;
                searchItems.ToDate = dlRececipts.ToDate;
                searchItems.CustID = dlRececipts.CustID;
                searchItems.ReceiptID = dlRececipts.ReceiptID;

                searchItems.StateList = dlRececipts.StateList;
                searchItems.CityList = dlRececipts.CityList;
                searchItems.DistrictList = dlRececipts.DistrictList;
                searchItems.AreaList = dlRececipts.AreaList;
                searchItems.LedgerTypeID = dlRececipts.LedgerTypeID;
                searchItems.CustomerTypeList = dlRececipts.CustomerTypeList;
                searchItems.CompanyTypeList = dlRececipts.CompanyTypeList;
                searchItems.BranchList = dlRececipts.BranchList;
                searchItems.salesmanList = dlRececipts.salesmanList;
                searchItems.CustomerName = dlRececipts.CustomerName;

                Receiptslist = receipts.GetReceipts(searchItems);

                return PartialView("ReceiptsList", Receiptslist);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult ReceiptsList()
        {
            List<Receipts> result = new List<Receipts>();
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                try
                {
                    Receipts receipts = new Receipts();
                    receipts.OrgID = Session["OrgID"].ToString();
                    result = receipts.GetReceipts(receipts);
                }
                catch (Exception ex)
                {

                }
            }
            return PartialView(result);
        }

        public static string xmlFileString = string.Empty;
        static XmlDocument xmlDoc = new XmlDocument();
        static string mxmlRootPath = string.Empty;
        public static bool IsCompanyOpen = false;
        public static string Result = string.Empty;


        public void SyncReceiptToTally(string ReceiptID, string OrgID)
        {
            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            bool iswinservice = true;
            Receipts GetReceipts = new Receipts();
            GetReceipts = (Receipts)GetReceipts.GetReceiptsBillDetails_TallySync(ReceiptID, OrgID);

            //Get Receipt Details from Master Table
            Receipts tallyResult = SyncReceiptData(ReceiptID, OrgID, GetReceipts, iswinservice);


            if (tallyResult.DisplayMessage.Contains("<CREATED>1"))
            {
                tallyResult.DisplayMessage = "Tally Sync Successful!!";
                tallyResult.IsTallyUpdated = true;
                tallyResult.ModifiedDate = DateTimeNow;
                tallyResult.ID = GetReceipts.ID;
                tallyResult.ReceiptID = GetReceipts.ReceiptID;
                if (GetReceipts.UpdateTallyStatusFromService(tallyResult))
                {
                    Helper.LogError("Receipt - DataBase Updated Successfully", null, null, null);
                }
                else
                {
                    Helper.LogError("Receipt - Database Updation failed", null, null, null);
                }
            }
            else if (tallyResult.DisplayMessage.Contains("<ALTERED>1"))
            {
                tallyResult.DisplayMessage = "Tally Sync Successful!!";
                tallyResult.IsTallyUpdated = true;
                tallyResult.ModifiedDate = DateTimeNow;
                tallyResult.ID = GetReceipts.ID;
                tallyResult.ReceiptID = GetReceipts.ReceiptID;
                if (GetReceipts.UpdateTallyStatusFromService(tallyResult))
                {
                    Helper.LogError("Receipt - DataBase Updated Successfully", null, null, null);
                }
                else
                {
                    Helper.LogError("Receipt - Database Updation failed", null, null, null);
                }
            }
            else if (tallyResult.DisplayMessage.ToLower().Contains("please open company"))
            {
                tallyResult.DisplayMessage = tallyResult.DisplayMessage;
                GetReceipts.UpdateTallyStatusFromService(tallyResult, true);
                tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Receipts Sync", tallyResult.ReceiptID, tallyResult.DisplayMessage);
            }
            else if (tallyResult.DisplayMessage.Contains("<LINEERROR>"))
            {
                int pFrom = tallyResult.DisplayMessage.IndexOf("<LINEERROR>") + "<LINEERROR>".Length;
                int pTo = tallyResult.DisplayMessage.LastIndexOf("</LINEERROR>");
                tallyResult.DisplayMessage = tallyResult.DisplayMessage.Substring(pFrom, pTo - pFrom);
                GetReceipts.UpdateTallyStatusFromService(tallyResult, true);
                tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Receipts Sync", tallyResult.ReceiptID, tallyResult.DisplayMessage);
            }
            else
            {
                Helper.LogError("There is an error with Tally. Please try later..", null, null, null);
                GetReceipts.UpdateTallyStatusFromService(tallyResult, true);
                tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Receipts Sync", tallyResult.ReceiptID, tallyResult.DisplayMessage);
            }
        }

        public Receipts SyncReceiptData(string ReceiptID, string OrgID, Receipts GetReceipts, bool iswinservice)
        {
            IsTallyCompanyOpen(GetReceipts.OrgName, iswinservice);

            Receipts receiptss = new Receipts();
            receiptss.OrgID = OrgID;

            if (IsCompanyOpen == true)
            {
                string mXMLResult = string.Empty;
                try
                {
                    string xmlstc = string.Empty;
                    List<WBT.DL.CCAplusSO.DLReceiptsBillDetailsCreation> PartyWiseData = GetReceipts.DLReceiptsBillDetailsCreation.
                      GroupBy(ac => new { ac.CustID }).Select(g => new WBT.DL.CCAplusSO.DLReceiptsBillDetailsCreation()
                      {
                          CustID = g.Key.CustID,
                          LedgerName = g.Select(i => i.LedgerName).FirstOrDefault(),
                          Billamount = g.Sum(i => i.Credit),
                          BillType = g.Select(i => i.BillType).FirstOrDefault() == null ? "None" : g.Select(i => i.BillType).FirstOrDefault(),
                      }).ToList();

                    xmlstc = "<ENVELOPE>";
                    xmlstc = xmlstc + "<HEADER>";
                    xmlstc = xmlstc + "<TALLYREQUEST>Import Data</TALLYREQUEST>";
                    xmlstc = xmlstc + "</HEADER>";
                    xmlstc = xmlstc + "<BODY>";
                    xmlstc = xmlstc + "<IMPORTDATA>";
                    xmlstc = xmlstc + "<REQUESTDESC>";
                    xmlstc = xmlstc + "<REPORTNAME>Vouchers</REPORTNAME>";
                    xmlstc = xmlstc + "<STATICVARIABLES>";
                    xmlstc = xmlstc + "<SVCURRENTCOMPANY>" + GetReceipts.OrgName + "</SVCURRENTCOMPANY>";
                    xmlstc = xmlstc + "</STATICVARIABLES>";
                    xmlstc = xmlstc + "</REQUESTDESC>";
                    xmlstc = xmlstc + "<REQUESTDATA>";
                    xmlstc = xmlstc + "<TALLYMESSAGE >";

                    if(GetReceipts.IsEdited)
                    {
                        xmlstc = xmlstc + "<VOUCHER VCHTYPE=" + "\"" + GetReceipts.VoucherTypeName + "\" ACTION=" + "\"" + "Alter" + "\" OBJVIEW=" + "\"" + "Accounting Voucher View" + "\" >";
                    }
                    else
                    {
                        xmlstc = xmlstc + "<VOUCHER VCHTYPE=" + "\"" + GetReceipts.VoucherTypeName + "\" ACTION=" + "\"" + "Create" + "\" OBJVIEW=" + "\"" + "Accounting Voucher View" + "\" >";
                    }

                    xmlstc = xmlstc + "<VOUCHERNUMBER>" + GetReceipts.ReceiptID + "</VOUCHERNUMBER>";
                    xmlstc = xmlstc + "<DATE>" + GetReceipts.ReceiptDatetime.Value.ToString("dd/MM/yyyy") + "</DATE>";
                    xmlstc = xmlstc + "<EFFECTIVEDATE>" + GetReceipts.ReceiptDatetime.Value.ToString("dd/MM/yyyy") + "</EFFECTIVEDATE>";
                    xmlstc = xmlstc + "<NARRATION>" + GetReceipts.Comments + "</NARRATION>";
                    xmlstc = xmlstc + "<VOUCHERTYPENAME>" + GetReceipts.VoucherTypeName + "</VOUCHERTYPENAME>";
                    xmlstc = xmlstc + "<PARTYLEDGERNAME>" + GetReceipts.DLReceiptsBillDetailsCreation.FirstOrDefault().LedgerName + "</PARTYLEDGERNAME>";
           
                    foreach (var item in PartyWiseData)
                    {
                        xmlstc = xmlstc + "<ALLLEDGERENTRIES.LIST>";
                        xmlstc = xmlstc + "<LEDGERNAME>" + item.LedgerName + "</LEDGERNAME>"; //not comming
                        if (item.BillType == ModeOfPayments.Against_Reference.ToString() || item.BillType == ModeOfPayments.Advance.ToString() || item.BillType == ModeOfPayments.New_Reference.ToString() || item.BillType == ModeOfPayments.OnAccount.ToString())
                        {
                            //xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "Yes" + "</ISDEEMEDPOSITIVE>";
                            //xmlstc = xmlstc + "<ISPARTYLEDGER>" + "Yes" + "</ISPARTYLEDGER>";
                            //xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "Yes" + "</ISLASTDEEMEDPOSITIVE>";

                            xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "No" + "</ISDEEMEDPOSITIVE>";
                            xmlstc = xmlstc + "<LEDGERFROMITEM>" + "No" + "</LEDGERFROMITEM>";
                            xmlstc = xmlstc + "<REMOVEZEROENTRIES>" + "No" + "</REMOVEZEROENTRIES>";
                            xmlstc = xmlstc + "<ISPARTYLEDGER>" + "Yes" + "</ISPARTYLEDGER>";
                            xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "No" + "</ISLASTDEEMEDPOSITIVE>";
                        }
                        else
                        {
                            //xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "Yes" + "</ISDEEMEDPOSITIVE>";
                            //xmlstc = xmlstc + "<ISPARTYLEDGER>" + "No" + "</ISPARTYLEDGER>";
                            //xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "Yes" + "</ISLASTDEEMEDPOSITIVE>";

                            xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "No" + "</ISDEEMEDPOSITIVE>";
                            xmlstc = xmlstc + "<LEDGERFROMITEM>" + "No" + "</LEDGERFROMITEM>";
                            xmlstc = xmlstc + "<REMOVEZEROENTRIES>" + "No" + "</REMOVEZEROENTRIES>";
                            xmlstc = xmlstc + "<ISPARTYLEDGER>" + "Yes" + "</ISPARTYLEDGER>";
                            xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "No" + "</ISLASTDEEMEDPOSITIVE>";
                        }

                        xmlstc = xmlstc + "<AMOUNT>" + item.Billamount + "</AMOUNT>";


                        List<WBT.DLCustomerCreation.DLReceiptsBillDetailsCreation> CutDetails = GetReceipts.DLReceiptsBillDetailsCreation.Where(i => i.CustID == PartyWiseData.FirstOrDefault().CustID).ToList();

                        foreach (var bill in CutDetails)
                        {
                            if (bill.BillType == ModeOfPayments.Against_Reference.ToString() || bill.BillType == ModeOfPayments.Advance.ToString() || bill.BillType == ModeOfPayments.New_Reference.ToString() || bill.BillType == ModeOfPayments.OnAccount.ToString())
                            {
                                xmlstc = xmlstc + "<BILLALLOCATIONS.LIST>";
                                xmlstc = xmlstc + "<NAME>" + bill.BillNo + "</NAME>";

                                if (bill.BillType == ModeOfPayments.Against_Reference.ToString())
                                    xmlstc = xmlstc + "<BILLTYPE>" + "Agst Ref" + "</BILLTYPE>";
                                else if (bill.BillType == ModeOfPayments.Advance.ToString())
                                    xmlstc = xmlstc + "<BILLTYPE>" + "Advance" + "</BILLTYPE>";
                                else if (bill.BillType == ModeOfPayments.New_Reference.ToString())
                                    xmlstc = xmlstc + "<BILLTYPE>" + "New Ref" + "</BILLTYPE>";
                                else if (bill.BillType == ModeOfPayments.OnAccount.ToString())
                                    xmlstc = xmlstc + "<BILLTYPE>" + "On Account" + "</BILLTYPE>";

                                xmlstc = xmlstc + "<AMOUNT>" + Convert.ToDecimal(bill.Credit) + "</AMOUNT>";
                                xmlstc = xmlstc + "</BILLALLOCATIONS.LIST>";
                            }
                        }
                        xmlstc = xmlstc + "</ALLLEDGERENTRIES.LIST>";
                    }
                    if (GetReceipts.BankOrCash == "C")
                    {
                        #region insert cash or bank ledger details

                        xmlstc = xmlstc + "<ALLLEDGERENTRIES.LIST>";
                        xmlstc = xmlstc + "<LEDGERNAME>" + GetReceipts.BankOrCashName + "</LEDGERNAME>"; //cash ledger name
                        xmlstc = xmlstc + "<AMOUNT>" + GetReceipts.Amount + "</AMOUNT>"; //total bill amount                        
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "Yes" + "</ISDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<LEDGERFROMITEM>" + "NO" + "</LEDGERFROMITEM>";
                        xmlstc = xmlstc + "<REMOVEZEROENTRIES>" + "No" + "</REMOVEZEROENTRIES>";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>" + "No" + "</ISPARTYLEDGER>";
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "Yes" + "</ISLASTDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "</ALLLEDGERENTRIES.LIST>";

                        #endregion
                    }
                    else
                    {
                        #region bank account ledger details

                        xmlstc = xmlstc + "<ALLLEDGERENTRIES.LIST>";
                        xmlstc = xmlstc + "<LEDGERNAME>" + GetReceipts.BankOrCashName + "</LEDGERNAME>"; //Bank ledger name
                        xmlstc = xmlstc + "<AMOUNT>-" + GetReceipts.Amount + "</AMOUNT>"; //total pament amount
                        //xmlstc = xmlstc + "<VATEXPAMOUNT>" + lDLPaymentsCreation.Amount + "</VATEXPAMOUNT>";
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "Yes" + "</ISDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>" + "Yes" + "</ISPARTYLEDGER>";
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "Yes" + "</ISLASTDEEMEDPOSITIVE>";

                        #region Bank Details of party goes to first party in list

                        if (GetReceipts.PaymentType.ToLower() == "cheque")
                        {
                            xmlstc = xmlstc + "<BANKALLOCATIONS.LIST>";
                            xmlstc = xmlstc + "<BANKPARTYNAME> " + GetReceipts.LedgerName + "</BANKPARTYNAME>";
                            xmlstc = xmlstc + "<TRANSACTIONTYPE>" + GetReceipts.PaymentType + "</TRANSACTIONTYPE>";  //cheque/NEFt
                            xmlstc = xmlstc + "<INSTRUMENTNUMBER> " + GetReceipts.TransactionNumber + "</INSTRUMENTNUMBER>"; //cheque.neft/rtgs number
                            xmlstc = xmlstc + "<INSTRUMENTDATE>" + GetReceipts.CheckDate + "</INSTRUMENTDATE>"; //date
                            xmlstc = xmlstc + "<AMOUNT>" + GetReceipts.Amount + "</AMOUNT>"; //total payment amount
                            xmlstc = xmlstc + "</BANKALLOCATIONS.LIST>";
                        }
                        else
                        {
                            //if (lDLReceiptsCreation.BankName.Contains("&") && User.IsTallyErpRunning == true)
                            //    lDLReceiptsCreation.BankName = lDLReceiptsCreation.BankName.Replace("&", "&amp;");

                            xmlstc = xmlstc + "<BANKALLOCATIONS.LIST>";
                            xmlstc = xmlstc + "<DATE>" + GetReceipts.ReceiptDatetime.Value.ToString("dd/MM/yyyy") + "</DATE>";
                            xmlstc = xmlstc + "<BANKERSDATE> </BANKERSDATE>";
                            xmlstc = xmlstc + "<ACCOUNTNUMBER>" + GetReceipts.AccountNumber + "</ACCOUNTNUMBER>";
                            xmlstc = xmlstc + "<IFSCODE>" + GetReceipts.IFSC + "</IFSCODE>";
                            xmlstc = xmlstc + "<BANKNAME>" + GetReceipts.BankName + "</BANKNAME>";
                            xmlstc = xmlstc + "<TRANSFERMODE>" + GetReceipts.PaymentType + "</TRANSFERMODE>";
                            xmlstc = xmlstc + "<NAME></NAME>";
                            xmlstc = xmlstc + "<TRANSACTIONTYPE>" + "Inter Bank Transfer" + "</TRANSACTIONTYPE>";  //cheque/NEFt
                            xmlstc = xmlstc + "<PAYMENTFAVOURING> </PAYMENTFAVOURING>";
                            xmlstc = xmlstc + "<INSTRUMENTNUMBER> " + GetReceipts.TransactionNumber + "</INSTRUMENTNUMBER>"; //cheque.neft/rtgs number
                            xmlstc = xmlstc + "<INSTRUMENTDATE>" + GetReceipts.CheckDate + "</INSTRUMENTDATE>"; //date
                            xmlstc = xmlstc + "<UNIQUEREFERENCENUMBER></UNIQUEREFERENCENUMBER>";
                            xmlstc = xmlstc + "<STATUS></STATUS>";
                            xmlstc = xmlstc + "<PAYMENTMODE></PAYMENTMODE>"; //Transacted
                            xmlstc = xmlstc + "<BANKPARTYNAME> " + PartyWiseData.FirstOrDefault().LedgerName + "</BANKPARTYNAME>";  //bank party name i.e,Account holder name"++"
                            xmlstc = xmlstc + "<ISCONNECTEDPAYMENT>" + "No" + "</ISCONNECTEDPAYMENT>";
                            xmlstc = xmlstc + "<ISSPLIT>" + "No" + "</ISSPLIT>";
                            xmlstc = xmlstc + "<AMOUNT>" + GetReceipts.Amount + "</AMOUNT>"; //Party Total amount
                            xmlstc = xmlstc + "</BANKALLOCATIONS.LIST>";
                        }
                        #endregion

                        xmlstc = xmlstc + "</ALLLEDGERENTRIES.LIST>";

                        #endregion
                    }

                    xmlstc = xmlstc + "</VOUCHER>";
                    xmlstc = xmlstc + "</TALLYMESSAGE>";
                    xmlstc = xmlstc + "</REQUESTDATA>";
                    xmlstc = xmlstc + "</IMPORTDATA>";
                    xmlstc = xmlstc + "</BODY>";
                    xmlstc = xmlstc + "</ENVELOPE>";
                    string result = XMLGetData(xmlstc);
                    receiptss.DisplayMessage = result;
                    receiptss.ReceiptID = GetReceipts.ReceiptID;
                    return receiptss;
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex.Message, ex.Source, null, ex.StackTrace);
                    return null;
                }
            }
            else
            {
                receiptss.DisplayMessage = "Please open company";
                receiptss.ReceiptID = GetReceipts.ReceiptID;
                return receiptss;
            }
        }
        private static string XMLGetData(string XMLString)
        {
            //if (ConfigurationManager.AppSettings["TallyXMLEnable"].ToLower() == "true")
            //{
            //    Helper.TransactionLog(XMLString, true);
            //}
            string mXMLResult = string.Empty;
            try
            {
                XmlDocument XMLResponse = null;
                HttpWebResponse objHttpWebResponse = null;
                XmlTextReader objXMLReader = default(XmlTextReader);
                HttpWebRequest objHttpWebRequest = default(HttpWebRequest);
                objHttpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:9000");
                byte[] bytes = null;

                bytes = System.Text.Encoding.ASCII.GetBytes(XMLString);

                //Helper.LogError(XMLString, "", null, "");
                //Helper.LogError("Tally Sync2", "", null, "");

                objHttpWebRequest.Method = "POST";
                objHttpWebRequest.ContentLength = bytes.Length;
                objHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";


                Stream objRequestStream = null;
                Stream objResponseStream = null;
                objRequestStream = objHttpWebRequest.GetRequestStream();
                objRequestStream.Write(bytes, 0, bytes.Length);


                objHttpWebRequest.KeepAlive = true;
                objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();
                if (objHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {

                    objResponseStream = objHttpWebResponse.GetResponseStream();
                    objXMLReader = new XmlTextReader(objResponseStream);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(objXMLReader);
                    XMLResponse = xmldoc;
                    mXMLResult = XMLResponse.InnerXml;

                }
                objHttpWebResponse.Close();
            }
            catch (Exception ex)
            {
                mXMLResult = "Error : [ " + ex.Message + " ] ";
            }

            return mXMLResult;
        }
        private static void IsTallyCompanyOpen(string OrgName, bool iswinservice = false)
        {

            if (iswinservice == false)
            {
                xmlFileString = System.IO.File.ReadAllText(@"DataFiles\IsCurrentCompanyOpen.xml");
            }
            else
            {
                string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
                xmlFileString = Path.Combine(xmlfile, "IsCurrentCompanyOpen.xml");
            }

            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileString);

            try
            {
                mxmlRootPath = "ENVELOPE/BODY/";
                xmlDoc.SelectSingleNode(mxmlRootPath + "/DESC/STATICVARIABLES/SVCOMPANYCONNECTNAME").InnerText = OrgName;//User.UserOrganization;
                string tempLedger = xmlDoc.InnerXml;
                Result = XMLGetData(tempLedger);
                if (Result.Contains("<SERVERCOMPANYNAME>" + OrgName + "</SERVERCOMPANYNAME>"))   // User.UserOrganization
                {
                    IsCompanyOpen = true;
                    //Helper.LogError("Company open", "", null, "");
                }
                else if (Result.Contains("<DESC>Server company is not available!"))
                {
                    //Result = " Please Open Company " + User.UserOrganization + " In Tally";
                    IsCompanyOpen = false;

                }
            }
            catch (Exception ex)
            {
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
                Helper.LogError(ex.Message, ex.Source, null, ex.StackTrace);
                //return null;
                //return false;
            }
        }
    }
}