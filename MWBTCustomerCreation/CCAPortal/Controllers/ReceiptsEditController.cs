using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WBT.Common;
using WBT.DLCustomerCreation;
using WBT.Entity;

namespace CCAPortal.Controllers
{
    public class ReceiptsEditController : Controller
    {
        Receipts dlReceipts = new Receipts();
        MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        public static string xmlFileString = string.Empty;
        static XmlDocument xmlDoc = new XmlDocument();
        static string mxmlRootPath = string.Empty;
        bool IsCompanyOpen = false;
        public static string Result = string.Empty;
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TallySync tallySync = new TallySync();
        // GET: ReceiptsEdit
        public ActionResult Index(string route)
        {
            if (Session["UserID"] != null && !string.IsNullOrEmpty(route))
            {
                string ReceiptNumber = Helper.Decrypt(route, "sblw-3hn8-sqoy19");
                Receipts rlists = dlReceipts.GetReceiptDetails(ReceiptNumber);
                return View(rlists);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult updateValues(Receipts receipts)
        {
            if (Session["UserID"] != null)
            {
                DLReceipts dlReceipts = new DLReceipts();
                var result = dlReceipts.EditData(receipts);
                return Json(result.DisplayMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }

        public bool IsTallyCompanyOpen(Receipts item, string BranchName)
        {
            //xmlFileString = System.IO.File.ReadAllText(@"DataFiles\IsCurrentCompanyOpen.xml");
            xmlFileString = Server.MapPath("~/DataFiles/IsCurrentCompanyOpen.xml");
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileString);
            try
            {
                mxmlRootPath = "ENVELOPE/BODY/";
                xmlDoc.SelectSingleNode(mxmlRootPath + "/DESC/STATICVARIABLES/SVCOMPANYCONNECTNAME").InnerText = BranchName;
                string tempLedger = xmlDoc.InnerXml;
                string Result = XMLGetData(tempLedger);
                if (Result.Contains("<SERVERCOMPANYNAME>" + BranchName + "</SERVERCOMPANYNAME>"))
                {
                    IsCompanyOpen = true;
                }
                else if (Result.Contains("<DESC>Server company is not available!"))
                {
                    item.DisplayMessage = " Please Open Company " + BranchName + " In Tally";
                    IsCompanyOpen = false;
                }
                else
                {
                    item.DisplayMessage = Result;
                }
                return IsCompanyOpen;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, null, ex.StackTrace);
                return false;
            }
        }
        public string XMLGetData(string XMLString)
        {
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
        public static bool IsTallyRunning()
        {
            string processName = ConfigurationManager.AppSettings["TallyProcessName"];
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                return true;
            }
            return false;
        }
        [HttpPost]
        public JsonResult TallySync(string ID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                if (ModelState.IsValid)
                {
                    string Result = string.Empty;
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    Receipts tallyResult = new Receipts();
                    tallyResult.DisplayMessage = "Tally Sync Successful!!";
                    tallyResult.ModifiedByID = Convert.ToInt32(Session["UserID"].ToString());
                    tallyResult.ModifiedDate = DateTimeNow;
                    tallyResult.ReceiptID = ID;
                    //Check tally service from database
                    bool IsTallyRunning = false;
                    DLSystemDetails dLSystemDetails = new DLSystemDetails();
                    var sysDetails = dLSystemDetails.GetSystemDetails(Session["OrgID"].ToString());
                    if (sysDetails != null)
                    {
                        IsTallyRunning = sysDetails.IsTallyRunning.Value;
                        if (sysDetails.IsTallyRunning.Value != true)
                            Result = "1";
                    }
                    else
                    {
                        Result = "1";
                    }
                    if (IsTallyRunning)
                    {
                        if (dlReceipts.UpdateTallyStatus(tallyResult))
                        {
                            Result = "Tally Sync Successful!!";
                            Helper.LogError("DataBase Updated Successfully", null, null, null);
                        }
                        else
                        {
                            Result = "Error!! Please contact administrator";
                            Helper.LogError("Database Updation failed", null, null, null);
                        }
                    }
                    return Json(Result);
                }
                else
                {
                    return Json("0");
                }
            }
            else
            {
                return Json("0");
            }
        }

        public Receipts SaveReceiptToTally(Receipts item)
        {
            IsTallyCompanyOpen(item, item.BranchName);

            if (IsCompanyOpen == true)
            {

                Receipts IResult = new Receipts();
                string VoucherType = item.VoucherTypeName;
                string result = "";
                string mXMLResult = string.Empty;
                try
                {
                    string xmlstc = string.Empty;
                    List<DLReceiptsBillDetailsCreation> PartyWiseData = item.DLReceiptsBillDetailsCreation.
                      GroupBy(ac => new { ac.CustID }).Select(g => new DLReceiptsBillDetailsCreation()
                      {
                          CustID = g.Key.CustID,
                          LedgerName = g.Select(i => i.LedgerName).FirstOrDefault(),
                          Billamount = g.Sum(i => i.Billamount),
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
                    xmlstc = xmlstc + "<SVCURRENTCOMPANY>" + item.BranchName + "</SVCURRENTCOMPANY>";
                    xmlstc = xmlstc + "</STATICVARIABLES>";
                    xmlstc = xmlstc + "</REQUESTDESC>";
                    xmlstc = xmlstc + "<REQUESTDATA>";
                    xmlstc = xmlstc + "<TALLYMESSAGE >";
                    xmlstc = xmlstc + "<VOUCHER VCHTYPE=" + "\"" + VoucherType + "\" ACTION=" + "\"" + "Create" + "\" OBJVIEW=" + "\"" + "Accounting Voucher View" + "\" >";
                    xmlstc = xmlstc + "<VOUCHERNUMBER>" + item.ReceiptID + "</VOUCHERNUMBER>";
                    xmlstc = xmlstc + "<DATE>" + item.ReceiptDatetime.Value.ToString("dd/MM/yyyy") + "</DATE>";
                    xmlstc = xmlstc + "<EFFECTIVEDATE>" + item.ReceiptDatetime.Value.ToString("dd/MM/yyyy") + "</EFFECTIVEDATE>";
                    xmlstc = xmlstc + "<NARRATION>" + item.Comments + "</NARRATION>";
                    xmlstc = xmlstc + "<VOUCHERTYPENAME>" + VoucherType + "</VOUCHERTYPENAME>";

                    if (item.BankOrCash == "C")
                    {
                        #region insert cash or bank ledger details

                        xmlstc = xmlstc + "<ALLLEDGERENTRIES.LIST>";
                        xmlstc = xmlstc + "<LEDGERNAME>" + item.BankOrCashName + "</LEDGERNAME>"; //cash ledger name
                        xmlstc = xmlstc + "<AMOUNT>" + item.Amount + "</AMOUNT>"; //total bill amount                        
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "Yes" + "</ISDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<LEDGERFROMITEM>" + "NO" + "</LEDGERFROMITEM>";
                        xmlstc = xmlstc + "<REMOVEZEROENTRIES>" + "No" + "</REMOVEZEROENTRIES>";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>" + "Yes" + "</ISPARTYLEDGER>";
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "Yes" + "</ISLASTDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "</ALLLEDGERENTRIES.LIST>";

                        #endregion
                    }
                    else
                    {
                        #region bank account ledger details

                        xmlstc = xmlstc + "<ALLLEDGERENTRIES.LIST>";
                        xmlstc = xmlstc + "<LEDGERNAME>" + item.BankOrCashName + "</LEDGERNAME>"; //Bank ledger name

                        xmlstc = xmlstc + "<AMOUNT>" + item.Amount + "</AMOUNT>"; //total pament amount
                                                                                  //xmlstc = xmlstc + "<VATEXPAMOUNT>" + lDLPaymentsCreation.Amount + "</VATEXPAMOUNT>";
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "No" + "</ISDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>" + "Yes" + "</ISPARTYLEDGER>";
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "No" + "</ISLASTDEEMEDPOSITIVE>";

                        #region Bank Details of party goes to first party in list

                        if (item.PaymentType.ToLower() == "cheque")
                        {
                            xmlstc = xmlstc + "<BANKALLOCATIONS.LIST>";
                            xmlstc = xmlstc + "<BANKPARTYNAME> " + PartyWiseData.FirstOrDefault().LedgerName + "</BANKPARTYNAME>";
                            xmlstc = xmlstc + "<TRANSACTIONTYPE>" + item.PaymentType + "</TRANSACTIONTYPE>";  //cheque/NEFt
                            xmlstc = xmlstc + "<INSTRUMENTNUMBER> " + item.TransactionNumber + "</INSTRUMENTNUMBER>"; //cheque.neft/rtgs number
                            xmlstc = xmlstc + "<INSTRUMENTDATE>" + item.CheckDate + "</INSTRUMENTDATE>"; //date
                            xmlstc = xmlstc + "<AMOUNT>" + item.Amount + "</AMOUNT>"; //total payment amount
                            xmlstc = xmlstc + "</BANKALLOCATIONS.LIST>";
                        }
                        else
                        {
                            xmlstc = xmlstc + "<BANKALLOCATIONS.LIST>";
                            xmlstc = xmlstc + "<DATE>" + item.ReceiptDatetime.Value.ToString("dd/MM/yyyy") + "</DATE>";
                            xmlstc = xmlstc + "<BANKERSDATE> </BANKERSDATE>";
                            xmlstc = xmlstc + "<ACCOUNTNUMBER>" + item.AccountNumber + "</ACCOUNTNUMBER>";
                            xmlstc = xmlstc + "<IFSCODE>" + item.IFSC + "</IFSCODE>";
                            xmlstc = xmlstc + "<BANKNAME>" + item.BankName + "</BANKNAME>";
                            xmlstc = xmlstc + "<TRANSFERMODE>" + item.PaymentType + "</TRANSFERMODE>";
                            xmlstc = xmlstc + "<NAME></NAME>";
                            xmlstc = xmlstc + "<TRANSACTIONTYPE>" + "Inter Bank Transfer" + "</TRANSACTIONTYPE>";  //cheque/NEFt
                            xmlstc = xmlstc + "<PAYMENTFAVOURING> </PAYMENTFAVOURING>";
                            xmlstc = xmlstc + "<INSTRUMENTNUMBER> " + item.TransactionNumber + "</INSTRUMENTNUMBER>"; //cheque.neft/rtgs number
                            xmlstc = xmlstc + "<INSTRUMENTDATE>" + item.CheckDate + "</INSTRUMENTDATE>"; //date
                            xmlstc = xmlstc + "<UNIQUEREFERENCENUMBER></UNIQUEREFERENCENUMBER>";
                            xmlstc = xmlstc + "<STATUS></STATUS>";
                            xmlstc = xmlstc + "<PAYMENTMODE></PAYMENTMODE>"; //Transacted
                            xmlstc = xmlstc + "<BANKPARTYNAME> " + PartyWiseData.FirstOrDefault().LedgerName + "</BANKPARTYNAME>";  //bank party name i.e,Account holder name"++"
                            xmlstc = xmlstc + "<ISCONNECTEDPAYMENT>" + "No" + "</ISCONNECTEDPAYMENT>";
                            xmlstc = xmlstc + "<ISSPLIT>" + "No" + "</ISSPLIT>";
                            xmlstc = xmlstc + "<AMOUNT>" + item.Amount + "</AMOUNT>"; //Party Total amount
                            xmlstc = xmlstc + "</BANKALLOCATIONS.LIST>";
                        }
                        #endregion
                        xmlstc = xmlstc + "</ALLLEDGERENTRIES.LIST>";

                        #endregion
                    }

                    foreach (var item1 in PartyWiseData)
                    {
                        xmlstc = xmlstc + "<ALLLEDGERENTRIES.LIST>";
                        xmlstc = xmlstc + "<LEDGERNAME>" + item1.LedgerName + "</LEDGERNAME>"; //
                                                                                               //if (item1.BillType == ModeOfPayments.Against_Reference.ToString() || item1.BillType == ModeOfPayments.Advance.ToString() || item1.BillType == ModeOfPayments.New_Reference.ToString() || item1.BillType == ModeOfPayments.OnAccount.ToString())
                                                                                               //{
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "" + "</ISDEEMEDPOSITIVE>"; //"Yes"
                        xmlstc = xmlstc + "<ISPARTYLEDGER>" + "" + "</ISPARTYLEDGER>";  //"Yes"
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "" + "</ISLASTDEEMEDPOSITIVE>"; //"Yes"
                                                                                                     //}
                                                                                                     //else
                                                                                                     //{
                                                                                                     //    xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>" + "Yes" + "</ISDEEMEDPOSITIVE>";
                                                                                                     //    xmlstc = xmlstc + "<ISPARTYLEDGER>" + "No" + "</ISPARTYLEDGER>";
                                                                                                     //    xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>" + "Yes" + "</ISLASTDEEMEDPOSITIVE>";
                                                                                                     //}

                        xmlstc = xmlstc + "<AMOUNT>-" + item1.Billamount + "</AMOUNT>";

                        List<DLReceiptsBillDetailsCreation> CutDetails = item.DLReceiptsBillDetailsCreation.Where(i => i.CustID == item.CustID).ToList();
                        foreach (var bill in CutDetails)
                        {
                            //if (bill.BillType == ModeOfPayments.Against_Reference.ToString() || bill.BillType == ModeOfPayments.Advance.ToString() || bill.BillType == ModeOfPayments.New_Reference.ToString() || bill.BillType == ModeOfPayments.OnAccount.ToString())
                            //{
                            xmlstc = xmlstc + "<BILLALLOCATIONS.LIST>";
                            xmlstc = xmlstc + "<NAME>" + bill.BillNo + "</NAME>";

                            //if (bill.BillType == ModeOfPayments.Against_Reference.ToString())
                            xmlstc = xmlstc + "<BILLTYPE>" + "" + "</BILLTYPE>";    //Agst Ref
                                                                                    //else if (bill.BillType == ModeOfPayments.Advance.ToString())
                                                                                    //    xmlstc = xmlstc + "<BILLTYPE>" + "Advance" + "</BILLTYPE>";
                                                                                    //else if (bill.BillType == ModeOfPayments.New_Reference.ToString())
                                                                                    //    xmlstc = xmlstc + "<BILLTYPE>" + "New Ref" + "</BILLTYPE>";
                                                                                    //else if (bill.BillType == ModeOfPayments.OnAccount.ToString())
                                                                                    //    xmlstc = xmlstc + "<BILLTYPE>" + "On Account" + "</BILLTYPE>";
                            xmlstc = xmlstc + "<AMOUNT>-" + Convert.ToDecimal(bill.Billamount) + "</AMOUNT>";
                            xmlstc = xmlstc + "</BILLALLOCATIONS.LIST>";
                            //}
                        }
                        xmlstc = xmlstc + "</ALLLEDGERENTRIES.LIST>";
                    }

                    xmlstc = xmlstc + "</VOUCHER>";
                    xmlstc = xmlstc + "</TALLYMESSAGE>";
                    xmlstc = xmlstc + "</REQUESTDATA>";
                    xmlstc = xmlstc + "</IMPORTDATA>";
                    xmlstc = xmlstc + "</BODY>";
                    xmlstc = xmlstc + "</ENVELOPE>";

                    result = XMLGetData(xmlstc);

                    //return result;
                    IResult.DisplayMessage = result;
                    IResult.ID = item.ID;
                    return IResult;

                }
                catch (Exception ex)
                {
                    Helper.LogError(ex.Message, ex.Source, null, ex.StackTrace);
                    return null;
                }
            }
            else
            {
                return item;
            }
        }
    }

    public class BillAllocation
    {
        string mBillnumber = string.Empty;
        string mBilldate = string.Empty;
        string mBillamount = string.Empty;
        string mBilldiscount = string.Empty;

        public string Billdiscount
        {
            get { return mBilldiscount; }
            set { mBilldiscount = value; }
        }

        public string Billnumber
        {
            get { return mBillnumber; }
            set { mBillnumber = value; }
        }

        public string Billdate
        {
            get { return mBilldate; }
            set { mBilldate = value; }
        }

        public string Billamount
        {
            get { return mBillamount; }
            set { mBillamount = value; }
        }
    }
}


//Receipts IResult = new Receipts();
//xmlFileString = Server.MapPath("~/DataFiles/CreateVoucherTemplate.xml");
//xmlDoc = new XmlDocument();
//xmlDoc.Load(xmlFileString);
//try
//{
//    mxmlRootPath = "ENVELOPE/BODY/";
//    xmlDoc.SelectSingleNode(mxmlRootPath + "/DESC/STATICVARIABLES/SVCURRENTCOMPANY").InnerText = item.BranchName;
//    mxmlRootPath = mxmlRootPath + "/DATA/TALLYMESSAGE";
//    mxmlRootPath = mxmlRootPath + "/GROUPS";
//    xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME").InnerText = item.ReceiptID.Trim();//item.SundryType.Trim();  
//    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["NAME"].InnerText = item.ReceiptID;
//    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["Action"].InnerText = "Create";
//    string tempLedger = xmlDoc.InnerXml.Replace("[Alias]", "<NAME>" + "" + "</NAME>");

//    //if (item.ReceiptWithBillID == "Primary")
//    //    tempLedger = tempLedger.Replace("[Parent]", "" + item.ParentDebtorName);
//    //else
//    //    tempLedger = tempLedger.Replace("[Parent]", item.ParentDebtorName);

//    //Alies Name
//    string Result = XMLGetData(tempLedger);
//    IResult.DisplayMessage = Result;
//    IResult.ID = item.ID;
//    return IResult;
//}
//catch (Exception ex)
//{
//    Helper.LogError(ex.Message, ex.Source, null, ex.StackTrace);
//    return null;
//}