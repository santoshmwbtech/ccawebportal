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
using WBT.DL.Transaction;
using WBT.DLCustomerCreation;
using WBT.Entity;

namespace CCAPortal.Controllers
{
    public class SalesOrderEditController : Controller
    {
        // GET: SalesOrderEdit
        DLSalesOrders sorders = new DLSalesOrders();
        MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        public static string xmlFileString = string.Empty;
        static XmlDocument xmlDoc = new XmlDocument();
        static string mxmlRootPath = string.Empty;
        bool IsCompanyOpen = false;
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public ActionResult Index(string route)
        {
            if (Session["UserID"] != null && !string.IsNullOrEmpty(route))
            {
                string OrderNumber = Helper.Decrypt(route, "sblw-3hn8-sqoy19");

                SalesOrders so = sorders.GetSalesOrderDetails(OrderNumber);
                
                var itemsList = (from a in Entities.tblSalesOrderWithItems
                                 join b in Entities.tblSalesOrders on a.SalesOrderNumber.ToLower().Trim() equals b.SalesOrderNumber.ToLower().Trim()
                                 join c in Entities.tblItems on a.ItemCode.ToLower().Trim() equals c.ItemCode.ToLower().Trim()
                                 where a.SalesOrderNumber == OrderNumber
                                 select new DLSalesOrderWithItemCreation
                                 {
                                     ItemName = c.ItemName,
                                     BagQTY = a.BagQTY,
                                     Value = a.Value,
                                     ItemCode = a.ItemCode,
                                     Rate = a.Rate,
                                     TotalQTY = a.TotalQTY,
                                     SalesOrderWithItemID = a.SalesOrderWithItemID,
                                     IsRateInQuantls = a.IsRateInQuantls,
                                     DiscountPercentage = a.DiscountPercentage,
                                     LoadingUnloadingCharge = a.LoadingUnloadingCharge,
                                     ItemRowNumber = a.ItemRowNumber,
                                     FrieghtCharge = a.FrieghtCharge,
                                     OtherExpense = a.OtherExpense
                                     

                                 }).Distinct().ToList();

                so.DLSalesOrderWithItemCreations = itemsList.ToList();

                return View(so);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public JsonResult Update(SalesOrders salesOrders)
        {
            if (Session["UserID"] != null)
            {
                DLSalesOrders dlSalesOrders = new DLSalesOrders();
                dlSalesOrders.updateSalesOrder(salesOrders);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }

        public bool IsTallyCompanyOpen(SalesOrders item, string BranchName)
        {
            //xmlFileString = System.IO.File.ReadAllText(@"DataFiles\IsCurrentCompanyOpen.xml");
            //xmlFileString = Server.MapPath("~/DataFiles/IsCurrentCompanyOpen.xml");
            //xmlDoc = new XmlDocument();
            //xmlDoc.Load(xmlFileString);

            if (BranchName.Contains("&"))
            {
                BranchName = BranchName.Replace("&", "&amp;");
            }

            string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
            Helper.LogError("IsCurrentCompanyOpen", xmlfile, null, "");
            xmlFileString = Path.Combine(xmlfile, "IsCurrentCompanyOpen.xml");
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
                    SalesOrders tallyResult = new SalesOrders();
                    var so = sorders.GetSalesOrderDetails(ID);
                    tallyResult.ModifiedByID = Convert.ToInt32(Session["UserID"].ToString());
                    tallyResult.ModifiedDate = DateTimeNow;
                    tallyResult.SalesOrderNumber = ID;
                    tallyResult.TransType = so.TransType;
                    tallyResult.SalesDateTime = so.SalesDateTime;
                    bool IsTallyRunning = false;
                    //Check tally service from database
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
                        if (sorders.UpdateTallyStatus(tallyResult))
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
                    string ErrorMessage = string.Empty;
                    foreach (ModelState modelState in ViewData.ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            ModelState.AddModelError("", error.ToString());
                            ErrorMessage += error.ToString() + ",br/>";
                        }
                    }
                    return Json(ErrorMessage);
                }
            }
            else
            {
                return Json("0");
            }
        }

        public void SyncReceiptToTally(SalesOrders salesOrders)
        {
            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);            

            //Get SO Details from Master Table
            SalesOrders tallyResult = SaveSalesOrderToTally(salesOrders);
            

            if (tallyResult.DisplayMessage.Contains("<CREATED>1"))
            {
                
                Helper.LogError("Tally Updated", null, null, null);
                tallyResult.ModifiedByID = Convert.ToInt32(salesOrders.UserID);// Convert.ToInt32(Session["UserID"].ToString());
                tallyResult.ModifiedDate = DateTimeNow;
                tallyResult.SalesDateTime = salesOrders.SalesDateTime;
                tallyResult.TransType = salesOrders.TransType;
                tallyResult.SalesOrderNumber = salesOrders.SalesOrderNumber;
                if (sorders.UpdateTallyStatusFromService(tallyResult))
                {
                    Helper.TallyServiceLog("Sales Order", tallyResult.SalesOrderNumber, tallyResult.CustomerName, Convert.ToDateTime(tallyResult.SalesDateTime), DateTimeNow, "Updated");
                    Helper.LogError("DataBase Updated Successfully", null, null, null);
                    //Helper.TransactionLog("Database Updation Successfully [" + DebtorName + "]", true);
                }
                else
                {
                    Helper.TallyServiceLog("Sales Order", tallyResult.SalesOrderNumber, tallyResult.CustomerName, Convert.ToDateTime(tallyResult.SalesDateTime), DateTimeNow, "Not Updated");
                    Helper.LogError("Database Updation failed", null, null, null);
                    //Helper.LogError("Database Updation failed", DebtorName, null, null);
                }
            }
            else if (tallyResult.DisplayMessage.Contains("<ALTERED>1"))
            {
                tallyResult.ModifiedByID = Convert.ToInt32(salesOrders.UserID);// Convert.ToInt32(Session["UserID"].ToString());
                tallyResult.ModifiedDate = DateTimeNow;
                tallyResult.SalesDateTime = salesOrders.SalesDateTime;
                tallyResult.TransType = salesOrders.TransType;
                tallyResult.OrderNumber = salesOrders.OrderNumber;
                if (sorders.UpdateTallyStatusFromService(tallyResult))
                {
                    Helper.TallyServiceLog("Sales Order", tallyResult.SalesOrderNumber, tallyResult.CustomerName, Convert.ToDateTime(tallyResult.SalesDateTime), DateTimeNow, "Updated");
                    Helper.LogError("DataBase Updated Successfully", null, null, null);
                    //  Helper.TransactionLog("Database Updation Successfully [" + DebtorName + "]", true);
                }
                else
                {
                    Helper.LogError("Database Updation failed", null, null, null);
                    Helper.TallyServiceLog("Sales Order", tallyResult.SalesOrderNumber, tallyResult.CustomerName, Convert.ToDateTime(tallyResult.SalesDateTime), DateTimeNow, "Not Updated");
                    //   Helper.TransactionLog("Database Updation Successfully [" + DebtorName + "]", true);
                }
            }
            else if (tallyResult.DisplayMessage.Contains("Please Open Company"))
            {
                tallyResult.DisplayMessage = tallyResult.DisplayMessage;
                Helper.LogError("Tally Company is not open", null, null, null);
            }
            else if (tallyResult.DisplayMessage.Contains("<LINEERROR>"))
            {
                int pFrom = tallyResult.DisplayMessage.IndexOf("<LINEERROR>") + "<LINEERROR>".Length;
                int pTo = tallyResult.DisplayMessage.LastIndexOf("</LINEERROR>");
                tallyResult.DisplayMessage = tallyResult.DisplayMessage.Substring(pFrom, pTo - pFrom);
                Helper.LogError(tallyResult.DisplayMessage, null, null, null);
                //MessageBox.Show(tallyResult.Remark.Substring(pFrom, pTo - pFrom), "Purchase Invoice", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Helper.LogError(tallyResult.DisplayMessage, null, null, null);
                //return Json(tallyResult.DisplayMessage, JsonRequestBehavior.AllowGet);
                //else
                // {
                //return Json("Please Open Tally to sync your data", JsonRequestBehavior.AllowGet);
            }

        }

        public SalesOrders SaveSalesOrderToTally(SalesOrders SalesOrder)
        {
            IsTallyCompanyOpen(SalesOrder, SalesOrder.BranchName);

            if (IsCompanyOpen == true)
            {
                SalesOrders IResult = new SalesOrders();

                //xmlFileString = Server.MapPath("~/DataFiles/SalesOrder.xml");
                //xmlDoc = new XmlDocument();
                //xmlDoc.Load(xmlFileString);

                string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
                Helper.LogError("IsCurrentCompanyOpen", xmlfile, null, "");
                xmlFileString = Path.Combine(xmlfile, "IsCurrentCompanyOpen.xml");
                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFileString);

                try
                {
                    string OrgName = SalesOrder.OrgName;//.Select(f => f.OrgName).FirstOrDefault();
                    string BranchName = SalesOrder.BranchName;//.Select(f => f.BranchName).FirstOrDefault();
                    string custName = SalesOrder.DLCustomerVendorDetail.FirmName;//.Select(cn => cn.CustName).FirstOrDefault();
                    if (custName.Contains("&"))
                    {
                        custName = custName.Replace("&", "&amp;");
                    }
                    string orderDate = Convert.ToDateTime(SalesOrder.OrderDate).ToString("dd/MM/yyyy");//
                    string orderNo = SalesOrder.OrderNumber;
                    string SalesOrderNo = SalesOrder.SalesOrderNumber;
                    decimal TotalQty = SalesOrder.DLSalesOrderWithItemCreations.Select(t => t.TotalQTY).Sum();
                    decimal OrderDiscountPer = SalesOrder.DiscountPercentage == null ? 0 : SalesOrder.DiscountPercentage.Value;
                    decimal TtlAmt = SalesOrder.DLSalesOrderWithItemCreations.Select(t => t.Value).Sum();
                    decimal OrderDiscountPerValue = Math.Round(TtlAmt * OrderDiscountPer / 100, 2);
                    decimal OrdDiscountAmount = SalesOrder.DiscountAmt == null ? 0 : SalesOrder.DiscountAmt.Value;
                    TtlAmt = TtlAmt - OrderDiscountPerValue;
                    decimal FreightAmt = 0;
                    decimal FreightGStValue = 0;

                    string SalesType = string.Empty;

                    SalesType = "Local State";
                    string VoucherType = "Sales";

                    string xmlstc = string.Empty;

                    #region Basic Enter
                    xmlstc = "<ENVELOPE>" + "\r\n";
                    xmlstc = xmlstc + "<HEADER>" + "\r\n";
                    xmlstc = xmlstc + "<TALLYREQUEST>Import Data</TALLYREQUEST>" + "\r\n";
                    xmlstc = xmlstc + "</HEADER>" + "\r\n";
                    xmlstc = xmlstc + "<BODY>" + "\r\n";
                    xmlstc = xmlstc + "<IMPORTDATA>" + "\r\n";
                    xmlstc = xmlstc + "<REQUESTDESC>" + "\r\n";
                    xmlstc = xmlstc + "<REPORTNAME>All Masters</REPORTNAME>" + "\r\n";
                    xmlstc = xmlstc + "<STATICVARIABLES>" + "\r\n";
                    xmlstc = xmlstc + "<SVCURRENTCOMPANY>" + (!string.IsNullOrEmpty(BranchName) ? BranchName : OrgName) + "</SVCURRENTCOMPANY>" + "\r\n";
                    xmlstc = xmlstc + "</STATICVARIABLES>" + "\r\n";
                    xmlstc = xmlstc + "</REQUESTDESC>" + "\r\n";
                    xmlstc = xmlstc + "<REQUESTDATA>" + "\r\n";
                    xmlstc = xmlstc + "<TALLYMESSAGE xmlns:UDF=" + "\"" + "TallyUDF" + "\" >" + "\r\n";
                    //xmlstc = xmlstc + "<VOUCHER VCHTYPE=" + "\"" + "Sales Invioce" + "\" ACTION=" + "\"" + "Create" + "\"  OBJVIEW =" + "\"" + "Sales Order" + "\" >" + "\r\n";
                    xmlstc = xmlstc + "<VOUCHER VCHTYPE=" + "\"" + VoucherType + "\" ACTION=" + "\"" + "Create" + "\"  OBJVIEW =" + "\"" + "Sales Order" + "\" >" + "\r\n";
                    xmlstc = xmlstc + "<ADDRESS.LIST TYPE=" + "\"" + "String" + "\" >" + "\r\n";
                    string BillingAddress = SalesOrder.DLCustomerVendorDetail.BillingAddress.Trim();
                    BillingAddress = BillingAddress.Replace("&", "&amp;");
                    xmlstc = xmlstc + "<ADDRESS>" + BillingAddress + "</ADDRESS>" + "\r\n";
                    xmlstc = xmlstc + "<ADDRESS>" + SalesOrder.DLCustomerVendorDetail.BillingCity + "</ADDRESS>" + "\r\n";
                    xmlstc = xmlstc + "<ADDRESS>" + "Sales Order" + "</ADDRESS>" + "\r\n";//Need to the value
                    xmlstc = xmlstc + "</ADDRESS.LIST>" + "\r\n";

                    xmlstc = xmlstc + "<BASICBUYERADDRESS.LIST TYPE=" + "\"" + "String" + "\" >" + "\r\n";
                    string ShippingAddress = SalesOrder.DLCustomerVendorDetail.ShippingAddress;
                    ShippingAddress = ShippingAddress.Replace("&", "&amp;");
                    xmlstc = xmlstc + "<BASICBUYERADDRESS>" + ShippingAddress + "</BASICBUYERADDRESS>" + "\r\n";//Need to the value
                    xmlstc = xmlstc + "<BASICBUYERADDRESS>" + SalesOrder.DLCustomerVendorDetail.BillingCity + "</BASICBUYERADDRESS>" + "\r\n";//Need to the value
                    xmlstc = xmlstc + "<BASICBUYERADDRESS>" + "Sales Order" + "</BASICBUYERADDRESS>" + "\r\n";//Need to the value
                    xmlstc = xmlstc + "</BASICBUYERADDRESS.LIST>" + "\r\n";

                    xmlstc = xmlstc + "<DATE>" + orderDate + "</DATE>" + "\r\n";
                    xmlstc = xmlstc + "<BILLOFLADINGDATE>" + orderDate + "</BILLOFLADINGDATE>" + "\r\n";
                    xmlstc = xmlstc + "<PERSISTEDVIEW> Invoice Voucher View</PERSISTEDVIEW>" + "\r\n";  /*added new*/
                    xmlstc = xmlstc + "<STATENAME>" + SalesOrder.DLCustomerVendorDetail.BillingState + "</STATENAME>" + "\r\n";  /*added new*/

                    //if (!string.IsNullOrEmpty(policyNumber) && !string.IsNullOrEmpty(ApmcNo) && !string.IsNullOrEmpty(ewayNumber))
                    //    xmlstc = xmlstc + "<NARRATION>" + "Invoice Number :" + InvNo + " " + "Vehical Number :" + VehicalNumber + " " + "APMC No." + ApmcNo + " " + "Insurance Number : " + policyNumber + "  " + "Eway Number : " + ewayNumber + "  " + "Total Quantity : " + TotalQty + "   " + Narration + (!string.IsNullOrEmpty(MultipleOrderNo) ? Environment.NewLine + "Order Numbers  : " + MultipleOrderNo : "") + "</NARRATION>" + "\r\n";
                    //else if (!string.IsNullOrEmpty(policyNumber))
                    //    xmlstc = xmlstc + "<NARRATION>" + "Invoice Number :" + InvNo + " " + "Vehical Number :" + VehicalNumber + " " + "Insurance Number : " + policyNumber + "  " + "Total Quantity : " + TotalQty + "   " + Narration + (!string.IsNullOrEmpty(MultipleOrderNo) ? Environment.NewLine + "Order Numbers : " + MultipleOrderNo : "") + "</NARRATION>" + "\r\n";
                    //else if (!string.IsNullOrEmpty(ApmcNo))
                    //    xmlstc = xmlstc + "<NARRATION>" + "Invoice Number :" + InvNo + " " + "Vehical Number :" + VehicalNumber + " " + "APMC Number : " + ApmcNo + "  " + "Total Quantity : " + TotalQty + "   " + Narration + (!string.IsNullOrEmpty(MultipleOrderNo) ? Environment.NewLine + "Order Numbers : " + MultipleOrderNo : "") + "</NARRATION>" + "\r\n";
                    //else if (!string.IsNullOrEmpty(ewayNumber))
                    //    xmlstc = xmlstc + "<NARRATION>" + "Invoice Number :" + InvNo + " " + "Vehical Number :" + VehicalNumber + " " + "Eway Number : " + ewayNumber + "  " + "Total Quantity : " + TotalQty + "   " + Narration + (!string.IsNullOrEmpty(MultipleOrderNo) ? Environment.NewLine + "Order Numbers : " + MultipleOrderNo : "") + "</NARRATION>" + "\r\n";
                    //else
                    //    xmlstc = xmlstc + "<NARRATION>" + "Invoice Number :" + InvNo + " " + "Vehical Number :" + VehicalNumber + " " + "Total Quantity : " + TotalQty + "   " + Narration + (!string.IsNullOrEmpty(MultipleOrderNo) ? Environment.NewLine + "Order Numbers : " + MultipleOrderNo : "") + "</NARRATION>" + "\r\n";

                    xmlstc = xmlstc + "<NARRATION>" + "Order Number :" + orderNo + " " + "Total Quantity : " + TotalQty + "</NARRATION>" + "\r\n";

                    xmlstc = xmlstc + "<COUNTRYOFRESIDENCE>" + "India" + "</COUNTRYOFRESIDENCE>" + "\r\n";  /*added new*/
                    xmlstc = xmlstc + "<PARTYGSTIN>" + SalesOrder.DLCustomerVendorDetail.GSTNumber + "</PARTYGSTIN>" + "\r\n";
                    xmlstc = xmlstc + "<PARTYNAME>" + custName + " </PARTYNAME >" + "\r\n";
                    xmlstc = xmlstc + "<VOUCHERTYPENAME>" + VoucherType + "</VOUCHERTYPENAME>" + "\r\n";
                    //xmlstc = xmlstc + "<VOUCHERTYPENAME>" + "Sales Order" + " </VOUCHERTYPENAME>" + "\r\n";
                    xmlstc = xmlstc + "<VOUCHERNUMBER>" + orderNo + "</VOUCHERNUMBER>" + "\r\n";
                    xmlstc = xmlstc + "<PARTYLEDGERNAME>" + custName + " </PARTYLEDGERNAME >" + "\r\n";
                    xmlstc = xmlstc + "<BASICBASEPARTYNAME>" + custName + "</BASICBASEPARTYNAME >" + "\r\n";
                    xmlstc = xmlstc + "<FBTPAYMENTTYPE>" + "Default" + "</FBTPAYMENTTYPE>" + "\r\n";
                    xmlstc = xmlstc + "<PERSISTEDVIEW>" + "Invoice Voucher View" + "</PERSISTEDVIEW>" + "\r\n";
                    xmlstc = xmlstc + "<PLACEOFSUPPLY>" + "" + "</PLACEOFSUPPLY>" + "\r\n"; //Karnataka
                    xmlstc = xmlstc + "<CONSIGNEEGSTIN>" + SalesOrder.DLCustomerVendorDetail.GSTNumber + "</CONSIGNEEGSTIN>" + "\r\n";
                    xmlstc = xmlstc + "<BASICSHIPPEDBY>" + SalesOrder.DLCustomerVendorDetail.GSTNumber + "</BASICSHIPPEDBY>" + "\r\n";
                    xmlstc = xmlstc + "<BASICBUYERNAME>" + custName + " </BASICBUYERNAME >" + "\r\n";
                    xmlstc = xmlstc + "<BASICSHIPDOCUMENTNO>" + orderNo + " </BASICSHIPDOCUMENTNO >" + "\r\n";
                    xmlstc = xmlstc + "<BASICFINALDESTINATION>" + SalesOrder.DLCustomerVendorDetail.BillingCity + "</BASICFINALDESTINATION >" + "\r\n"; //Need to the value (Place of shipping)
                    xmlstc = xmlstc + "<BASICORDERREF>" + "SB" + "</BASICORDERREF >" + "\r\n";
                    xmlstc = xmlstc + "<BASICSHIPVESSELNO>" + string.Empty + "</BASICSHIPVESSELNO >" + "\r\n";
                    xmlstc = xmlstc + "<BASICDUEDATEOFPYMT>" + "NEFT/RTGS" + "</BASICDUEDATEOFPYMT >" + "\r\n";
                    xmlstc = xmlstc + "<BASICDATETIMEOFINVOICE>" + orderDate + "</BASICDATETIMEOFINVOICE>" + "\r\n";
                    xmlstc = xmlstc + "<BASICDATETIMEOFREMOVAL>" + orderDate + "</BASICDATETIMEOFREMOVAL>" + "\r\n";
                    xmlstc = xmlstc + "<CONSIGNEESTATENAME>" + SalesOrder.DLCustomerVendorDetail.BillingState + "</CONSIGNEESTATENAME>" + "\r\n";
                    xmlstc = xmlstc + "<ENTEREDBY>" + SalesOrder.UserName + "</ENTEREDBY>" + "\r\n";
                    xmlstc = xmlstc + "<EFFECTIVEDATE>" + orderDate + "</EFFECTIVEDATE>" + "\r\n";
                    xmlstc = xmlstc + "<ISINVOICE>Yes</ISINVOICE>" + "\r\n";
                    xmlstc = xmlstc + "<REFERENCE>" + SalesOrderNo + "</REFERENCE>" + "\r\n";

                    xmlstc = xmlstc + "<INVOICEORDERLIST.LIST>" + "\r\n";
                    xmlstc = xmlstc + "<BASICORDERDATE>" + orderDate + "</BASICORDERDATE>" + "\r\n";
                    xmlstc = xmlstc + "<BASICPURCHASEORDERNO>" + SalesOrderNo + "</BASICPURCHASEORDERNO>" + "\r\n";
                    xmlstc = xmlstc + "</INVOICEORDERLIST.LIST>" + "\r\n";
                    #endregion

                    #region Party Ledger 
                    xmlstc = xmlstc + "<LEDGERENTRIES.LIST>" + "\r\n";
                    xmlstc = xmlstc + "<LEDGERNAME>" + custName + "</LEDGERNAME>" + "\r\n";
                    xmlstc = xmlstc + "<GSTCLASS/>" + "\r\n";
                    xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + "\r\n";
                    xmlstc = xmlstc + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + "\r\n";
                    xmlstc = xmlstc + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + "\r\n";
                    xmlstc = xmlstc + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + "\r\n";
                    xmlstc = xmlstc + "<AMOUNT>-" + (TtlAmt) + " </AMOUNT> " + "\r\n";
                    xmlstc = xmlstc + "<BILLALLOCATIONS.LIST>" + "\r\n";
                    xmlstc = xmlstc + "<NAME>" + orderNo + "</NAME>" + "\r\n";
                    xmlstc = xmlstc + "<BILLCREDITPERIOD>30 Days</BILLCREDITPERIOD>" + "\r\n";
                    xmlstc = xmlstc + "<BILLTYPE>New Ref</BILLTYPE>" + "\r\n";
                    xmlstc = xmlstc + "<AMOUNT>-" + (TtlAmt) + " </AMOUNT> " + "\r\n";
                    xmlstc = xmlstc + "</BILLALLOCATIONS.LIST>" + "\r\n";
                    xmlstc = xmlstc + "</LEDGERENTRIES.LIST>" + "\r\n";
                    #endregion

                    #region Discount Ledger & Freight Ledger
                    if (OrdDiscountAmount > 0 || OrderDiscountPer > 0)
                    {
                        xmlstc = xmlstc + "<LEDGERENTRIES.LIST>" + "\r\n";
                        xmlstc = xmlstc + "<LEDGERNAME>Discount on Sales</LEDGERNAME>" + "\r\n";
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + "\r\n";
                        xmlstc = xmlstc + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + "\r\n";
                        xmlstc = xmlstc + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + "\r\n";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + "\r\n";
                        if (OrdDiscountAmount > 0)
                            xmlstc = xmlstc + "<AMOUNT>-" + OrdDiscountAmount + "</AMOUNT>" + "\r\n";
                        else
                            xmlstc = xmlstc + "<AMOUNT>-" + OrderDiscountPerValue + "</AMOUNT>" + "\r\n";
                        xmlstc = xmlstc + " </LEDGERENTRIES.LIST>" + "\r\n";
                    }
                    if (FreightAmt > 0 || FreightAmt < 0)
                    {
                        xmlstc = xmlstc + "<LEDGERENTRIES.LIST>" + "\r\n";
                        xmlstc = xmlstc + "<LEDGERNAME>Freight On Sales</LEDGERNAME>" + "\r\n"; //these ledgers to be credted in tally
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + "\r\n";
                        xmlstc = xmlstc + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + "\r\n";
                        xmlstc = xmlstc + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + "\r\n";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + "\r\n";
                        xmlstc = xmlstc + "<AMOUNT>" + FreightAmt + "</AMOUNT>" + "\r\n";
                        xmlstc = xmlstc + "</LEDGERENTRIES.LIST>" + "\r\n";

                        //freight gst on other ledger added
                        xmlstc = xmlstc + " <LEDGERENTRIES.LIST>" + "\r\n";
                        xmlstc = xmlstc + "<LEDGERNAME>GST On Freight</LEDGERNAME>" + "\r\n"; //these ledgers to be credted in tally
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE> No </ISDEEMEDPOSITIVE>" + "\r\n";
                        xmlstc = xmlstc + "<AMOUNT>" + FreightGStValue + "</AMOUNT>" + "\r\n";
                        xmlstc = xmlstc + "</LEDGERENTRIES.LIST>" + "\r\n";
                    }
                    #endregion

                    List<DLSalesOrderWithItemCreation> dLSalesOrderCreationItems = SalesOrder.DLSalesOrderWithItemCreations.OrderBy(i => i.ItemName).ToList();

                    List<DLSalesOrderWithItemCreation> local = dLSalesOrderCreationItems;
                    var ItemGrp = local.GroupBy(x => new { x.ItemCode }).ToList();
                    List<DLSalesOrderWithItemCreation> TallyListOfitems = new List<DLSalesOrderWithItemCreation>();

                    foreach (var item in ItemGrp)
                    {
                        DLSalesOrderWithItemCreation dLo = new DLSalesOrderWithItemCreation();
                        dLo = local.Where(i => i.ItemCode == item.Key.ItemCode).FirstOrDefault();

                        DLSalesOrderWithItemCreation dL = new DLSalesOrderWithItemCreation();
                        dL.ItemCode = dLo.ItemCode;
                        dL.ItemName = dLo.ItemName;
                        dL.Rate = dLo.Rate;
                        dL.Unit = dLo.Unit;
                        dL.Value = dLo.Value;
                        dL.TotalQTY = local.Where(i => i.ItemCode == item.Key.ItemCode).Sum(i => i.TotalQTY);
                        TallyListOfitems.Add(dL);
                    }

                    #region bind details

                    List<OutPutLedgersLst> lstOutPutLedgers = new List<OutPutLedgersLst>();
                    //foreach (DLSalesInvoiceCreationItem dLSales in dLSalesInvoiceCreationItems)
                    foreach (DLSalesOrderWithItemCreation dLSales in TallyListOfitems)
                    {

                        #region TAX DETAILS
                        decimal taxValue = 0;
                        decimal TaxAmount = 0;
                        var lSalPurchAccountName = string.Empty;

                        if (SalesOrder.DLCustomerVendorDetail != null)
                        {
                            decimal temptax = 0;
                            string SalesOrPurchase = string.Empty;
                            string saleType = string.Empty;
                            if (SalesType == "Local State" || SalesType == "Branch Local State")
                            {
                                saleType = "Local";
                                if (taxValue == 5)
                                    temptax = Math.Round(Convert.ToDecimal(taxValue) / 2, 1);
                                else
                                    temptax = Math.Round(taxValue / 2, 0);
                                SalesOrPurchase = "sales";
                            }
                            else
                            {
                                saleType = "Inter";
                                temptax = Math.Round(taxValue, 0);
                                SalesOrPurchase = "sales";
                            }

                            lSalPurchAccountName = "Cash Sales";

                            //TaxInputOutputAccountNameList = AccountsDetails.Where(a => a.AccountLedgerName.ToLower().Trim().StartsWith(
                            //                     ConfigurationManager.AppSettings[SalesOrPurchase].Trim().ToLower()) && a.AccountLedgerName.Contains(temptax.ToString())).ToList();

                        }

                        string SalesAccountLEDGERNAME = lSalPurchAccountName;
                        string IGST_LEDGERNAME = "Cash Ledger";
                        string SGST_LEDGERNAME = "Cash Ledger";
                        string CGST_LEDGERNAME = "Cash Ledger";
                        //if (SalesType == "Inter State" || SalesType == "Branch Inter State")
                        //{
                        //    if (TaxInputOutputAccountNameList != null && TaxInputOutputAccountNameList.Count > 0)
                        //        IGST_LEDGERNAME = TaxInputOutputAccountNameList[0].AccountLedgerName;
                        //}
                        //else
                        //{
                        //    if (TaxInputOutputAccountNameList != null && TaxInputOutputAccountNameList.Count > 0)
                        //    {
                        //        CGST_LEDGERNAME = TaxInputOutputAccountNameList.Where(i => i.AccountLedgerName.ToLower().Contains("cgst")).FirstOrDefault().AccountLedgerName;
                        //        SGST_LEDGERNAME = TaxInputOutputAccountNameList.Where(i => i.AccountLedgerName.ToLower().Contains("sgst")).FirstOrDefault().AccountLedgerName;
                        //    }
                        //}

                        #endregion

                        #region StockItems
                        xmlstc = xmlstc + "<ALLINVENTORYENTRIES.LIST>";
                        xmlstc = xmlstc + "<STOCKITEMNAME>" + dLSales.ItemName + "</STOCKITEMNAME>";
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE> No </ISDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE> No </ISLASTDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<ISAUTONEGATE> No </ISAUTONEGATE>";
                        xmlstc = xmlstc + "<ISCUSTOMSCLEARANCE> No </ISCUSTOMSCLEARANCE>";
                        xmlstc = xmlstc + "<ISTRACKCOMPONENT> No </ISTRACKCOMPONENT>";
                        xmlstc = xmlstc + "<ISTRACKPRODUCTION> No </ISTRACKPRODUCTION>";
                        xmlstc = xmlstc + "<ISPRIMARYITEM> No </ISPRIMARYITEM>";
                        xmlstc = xmlstc + "<RATE>" + dLSales.Rate + "</RATE>";
                        //xmlstc = xmlstc + "<AMOUNT>" + Math.Round((dLSales.TotalAmountAfrDiscount * dLSales.BilledQuantity), 2).ToString() + "</AMOUNT>";
                        xmlstc = xmlstc + "<AMOUNT>" + Math.Round(dLSales.Value, 2).ToString() + "</AMOUNT>";
                        xmlstc = xmlstc + "<ACTUALQTY>" + dLSales.TotalQTY.ToString() + "</ACTUALQTY>"; /**/
                        xmlstc = xmlstc + "<BILLEDQTY>" + dLSales.TotalQTY.ToString() + dLSales.Unit + "</BILLEDQTY>";
                        xmlstc = xmlstc + "<DISCOUNT>" + dLSales.DiscountPercentage + "</DISCOUNT>";

                        #endregion

                        #region WAREHOUSE DETAILS
                        //foreach (DLSalesInvoiceCreationItem dlwrhs in TallyListOfitemsWrhsbatch.FindAll(i => i.ItemCode == dLSales.ItemCode))
                        //{
                            xmlstc = xmlstc + "<BATCHALLOCATIONS.LIST>";
                        //    //xmlstc = xmlstc + "<TRACKINGNUMBER/>";
                        //    //xmlstc = xmlstc + "<GODOWNNAME>" + dLSales.WarehouseName + "</GODOWNNAME>"; // Main Location
                        //    //xmlstc = xmlstc + "<BATCHNAME>" + dLSales.BatchNumber + "</BATCHNAME>"; //Primary Batch
                        //    //xmlstc = xmlstc + "<DESTINATIONGODOWNNAME>" + dLSales.WarehouseName + "</DESTINATIONGODOWNNAME>";
                        //    //xmlstc = xmlstc + "<MFDON>" + "20070401" + "</MFDON>";
                        //    //xmlstc = xmlstc + "<EXPIRYPERIOD/>";
                        //    //xmlstc = xmlstc + "<AMOUNT>" + Math.Round((dLSales.TotalAmountAfrDiscount * dLSales.BilledQuantity), 2).ToString() + "</AMOUNT>";
                        //    //xmlstc = xmlstc + "<ACTUALQTY>" + dLSales.Quantity + "</ACTUALQTY>";
                        //    //xmlstc = xmlstc + "<BILLEDQTY>" + dLSales.BilledQuantity + dLSales.RateUnit + "</BILLEDQTY>";
                        //    //xmlstc = xmlstc + "<ORDERNO/>";
                        //    //xmlstc = xmlstc + "</BATCHALLOCATIONS.LIST>";


                        //    xmlstc = xmlstc + "<BATCHALLOCATIONS.LIST>";
                        //    xmlstc = xmlstc + "<TRACKINGNUMBER/>";
                        //    xmlstc = xmlstc + "<GODOWNNAME>" + dlwrhs.WarehouseName + "</GODOWNNAME>"; // Main Location
                        //    xmlstc = xmlstc + "<BATCHNAME>" + dlwrhs.BatchNumber + "</BATCHNAME>"; //Primary Batch
                        //    xmlstc = xmlstc + "<DESTINATIONGODOWNNAME>" + dlwrhs.WarehouseName + "</DESTINATIONGODOWNNAME>";
                        //    //xmlstc = xmlstc + "<MFDON>" + "20070401" + "</MFDON>";
                        //    xmlstc = xmlstc + "<MFDON/>";
                        //    xmlstc = xmlstc + "<EXPIRYPERIOD/>";
                        //    xmlstc = xmlstc + "<AMOUNT>" + Math.Round((dlwrhs.TotalAmountAfrDiscount * dlwrhs.BilledQuantity), 2).ToString() + "</AMOUNT>";
                        //    xmlstc = xmlstc + "<ACTUALQTY>" + dlwrhs.Quantity + "</ACTUALQTY>";
                        //    xmlstc = xmlstc + "<BILLEDQTY>" + dlwrhs.BilledQuantity + dlwrhs.BilledUnit + "</BILLEDQTY>";
                        //    xmlstc = xmlstc + "<ORDERNO/>";
                            xmlstc = xmlstc + "</BATCHALLOCATIONS.LIST>";
                        //}
                        #endregion

                        #region ACCOUNTING DETAILS

                        xmlstc = xmlstc + "<ACCOUNTINGALLOCATIONS.LIST>";
                        xmlstc = xmlstc + "<LEDGERNAME>" + SalesAccountLEDGERNAME + "</LEDGERNAME>"; /*INTERSTATE GST SALES @ 12 %*/
                        xmlstc = xmlstc + "<CLASSRATE></CLASSRATE>"; //100
                        xmlstc = xmlstc + "<GSTCLASS></GSTCLASS>";
                        xmlstc = xmlstc + "<GSTOVRDNNATURE>" + "Sales Taxable" + "</GSTOVRDNNATURE>";
                        xmlstc = xmlstc + "<GSTOVRDNTAXABILITY>" + "Taxable" + "</GSTOVRDNTAXABILITY>";
                        xmlstc = xmlstc + "<REMOVEZEROENTRIES> No </REMOVEZEROENTRIES>";
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>";
                        xmlstc = xmlstc + "<ISCAPVATTAXALTERED>No</ISCAPVATTAXALTERED>";
                        xmlstc = xmlstc + "<ISCAPVATNOTCLAIMED>No</ISCAPVATNOTCLAIMED>";
                        xmlstc = xmlstc + "<TAXCLASSIFICATIONNAME/>";
                        //xmlstc = xmlstc + "<AMOUNT>" + Math.Round((dLSales.TotalAmountAfrDiscount * dLSales.BilledQuantity), 2).ToString() + "</AMOUNT>";
                        xmlstc = xmlstc + "<AMOUNT>" + Math.Round(dLSales.Value, 2).ToString() + "</AMOUNT>";
                        xmlstc = xmlstc + "</ACCOUNTINGALLOCATIONS.LIST>";
                        xmlstc = xmlstc + "</ALLINVENTORYENTRIES.LIST>";

                        #endregion

                        #region sgST CGST
                        if (SalesType.Trim().ToLower() == "local state" || SalesType.Trim().ToLower() == "branch local state") //0,5,12,18,24
                        {
                            if (taxValue > 0.0M)
                            {
                                OutPutLedgersLst CGSTLedger = new OutPutLedgersLst();
                                //CGSTLedger.Amount = Math.Round((TaxAmount / 2), 2);
                                CGSTLedger.Amount = (TaxAmount / 2);
                                CGSTLedger.LedgerName = CGST_LEDGERNAME;
                                lstOutPutLedgers.Add(CGSTLedger);

                                OutPutLedgersLst SGSTledger = new OutPutLedgersLst();
                                SGSTledger.Amount = (TaxAmount / 2);
                                SGSTledger.LedgerName = SGST_LEDGERNAME;
                                lstOutPutLedgers.Add(SGSTledger);

                                xmlstc = xmlstc + "<LEDGERENTRIES.LIST> " + "\r\n";
                                xmlstc = xmlstc + "<LEDGERNAME> " + CGST_LEDGERNAME + " </LEDGERNAME>" + "\r\n";
                                xmlstc = xmlstc + "<ISDEEMEDPOSITIVE> No </ISDEEMEDPOSITIVE>" + "\r\n";
                                xmlstc = xmlstc + "<AMOUNT> " + Math.Round((TaxAmount / 2), 2) + " </AMOUNT>" + "\r\n";
                                xmlstc = xmlstc + "</LEDGERENTRIES.LIST> " + "\r\n";

                                //xmlstc = xmlstc + "<LEDGERENTRIES.LIST> " + "\r\n";
                                //xmlstc = xmlstc + "<LEDGERNAME> " + SGST_LEDGERNAME + " </LEDGERNAME>" + "\r\n";
                                //xmlstc = xmlstc + "<ISDEEMEDPOSITIVE > No </ISDEEMEDPOSITIVE>" + "\r\n";
                                //xmlstc = xmlstc + "<AMOUNT> " + Math.Round((TaxAmount / 2), 2) + " </AMOUNT> " + "\r\n";
                                //xmlstc = xmlstc + "</LEDGERENTRIES.LIST> " + "\r\n";
                            }
                        }
                        else if (SalesType.Trim().ToLower() == "inter state" || SalesType.Trim().ToLower() == "branch inter state") //0,5,12,18,24
                        {
                            OutPutLedgersLst CGSTLedger = new OutPutLedgersLst();
                            //CGSTLedger.Amount = Math.Round(TaxAmount, 2);
                            CGSTLedger.Amount = TaxAmount;
                            CGSTLedger.LedgerName = IGST_LEDGERNAME;
                            lstOutPutLedgers.Add(CGSTLedger);

                            //xmlstc = xmlstc + "<LEDGERENTRIES.LIST> " + "\r\n";
                            //xmlstc = xmlstc + "<LEDGERNAME> " + IGST_LEDGERNAME + " </LEDGERNAME>" + "\r\n";
                            //xmlstc = xmlstc + "<ISDEEMEDPOSITIVE> No </ISDEEMEDPOSITIVE>" + "\r\n";
                            //xmlstc = xmlstc + "<AMOUNT> " + Math.Round(TaxAmount, 2) + " </AMOUNT> " + "\r\n";
                            //xmlstc = xmlstc + "</LEDGERENTRIES.LIST> " + "\r\n";
                        }
                        #endregion
                    }
                    #endregion

                    #region combining the gst outputs 10th-11th aug aug 2021 by sneha
                    if (lstOutPutLedgers != null && lstOutPutLedgers.Count() > 0)
                    {
                        lstOutPutLedgers = lstOutPutLedgers.GroupBy(ac => new { ac.LedgerName }).Select(i => new OutPutLedgersLst
                        {
                            LedgerName = i.Key.LedgerName,
                            Amount = i.Sum(j => j.Amount)
                        }).ToList();

                        #region sgST CGST
                        foreach (var gstHead in lstOutPutLedgers)
                        {
                            xmlstc = xmlstc + "<LEDGERENTRIES.LIST> " + "\r\n";
                            xmlstc = xmlstc + "<LEDGERNAME> " + gstHead.LedgerName + " </LEDGERNAME>" + "\r\n";
                            xmlstc = xmlstc + "<ISDEEMEDPOSITIVE> No </ISDEEMEDPOSITIVE>" + "\r\n";
                            xmlstc = xmlstc + "<AMOUNT> " + gstHead.Amount + " </AMOUNT>" + "\r\n";
                            xmlstc = xmlstc + "</LEDGERENTRIES.LIST> " + "\r\n";
                        }
                        #endregion
                    }
                    #endregion

                    xmlstc = xmlstc + "</VOUCHER>" + "\r\n";
                    xmlstc = xmlstc + "</TALLYMESSAGE>" + "\r\n";
                    xmlstc = xmlstc + "</REQUESTDATA>" + "\r\n";
                    xmlstc = xmlstc + "</IMPORTDATA>" + "\r\n";
                    xmlstc = xmlstc + "</BODY>" + "\r\n";
                    xmlstc = xmlstc + "</ENVELOPE>" + "\r\n";

                    IResult.DisplayMessage = XMLGetData(xmlstc);

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
                return SalesOrder;
            }
        }
        private class OutPutLedgersLst
        {
            public string LedgerName { get; set; }
            public decimal Amount { get; set; }
        }
    }
}

