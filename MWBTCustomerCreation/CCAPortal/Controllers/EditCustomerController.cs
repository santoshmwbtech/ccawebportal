using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WBT.Common;
using WBT.DLCustomerCreation;
using System.Configuration;
using System.Diagnostics;

namespace CCAPortal.Controllers
{
    public class EditCustomerController : Controller
    {
        public static string xmlFileString = string.Empty;
        static XmlDocument xmlDoc = new XmlDocument();
        static string mxmlRootPath = string.Empty;
        bool IsCompanyOpen = false;
        CustomerCreations customerCreations = new CustomerCreations();
        DLDebtorsCreation dLDebtorsCreation = new DLDebtorsCreation();
        DLGetUserCreation dLGetUserCreation = new DLGetUserCreation();
        TallySync tallySync = new TallySync();
        // GET: EditCustomer
        public ActionResult Index(string route)
        {
            if (Session["UserID"] != null && !string.IsNullOrEmpty(route) && Session["OrgID"] != null)
            {
                string CustID = string.Empty;
                try
                {
                    CustID = Helper.Decrypt(route, "sblw-3hn8-sqoy19");
                }
                catch(Exception ex)
                {
                    Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                    return RedirectToAction("Index", "Login");
                }
                ViewBag.DebtorsList = new SelectList(dLDebtorsCreation.GetDebtorsList(Session["OrgID"].ToString()), "ID", "DebtorName");
                ViewBag.LedgerTypes = new SelectList(customerCreations.GetLedgerTypes(), "LedgerTypeID", "LedgerType");
                ViewBag.CreditTypes = new SelectList(customerCreations.GetCreditTypes(Session["OrgID"].ToString()), "CreditTypeID", "CreditTypeName");
                ViewBag.CustomerTypes = new SelectList(customerCreations.GetCustomerTypes(), "CustomerTypeID", "CustomerType");
                ViewBag.CompanyTypes = new SelectList(customerCreations.GetCompanyTypes(), "CompanyTypeID", "CompanyType");
                ViewBag.CategoryTypes = new SelectList(customerCreations.GetCategoryTypes(), "CategoryTypeID", "CategoryType");
                ViewBag.TaxationTypes = new SelectList(customerCreations.GetTaxationTypes(), "TaxationTypeID", "TaxationType");
                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.CountryList = new SelectList(customerCreations.GetCountryList(), "CountryID", "CountryName");

                CustomerCreation customer = customerCreations.GetCustomerDetails(CustID);
                var apiUrl = ConfigurationManager.AppSettings["APIUrl"].ToString();
                if(!string.IsNullOrEmpty(customer.ShopImage))
                    customer.ShopImage = apiUrl + customer.ShopImage;
                if (!string.IsNullOrEmpty(customer.OwnerPhoto))
                    customer.OwnerPhoto = apiUrl + customer.OwnerPhoto;
                if (!string.IsNullOrEmpty(customer.PANPhoto))
                    customer.PANPhoto = apiUrl + customer.PANPhoto;
                if (!string.IsNullOrEmpty(customer.AadhaarPhoto))
                    customer.AadhaarPhoto = apiUrl + customer.AadhaarPhoto;
                if (!string.IsNullOrEmpty(customer.GSTPhoto))
                    customer.GSTPhoto = apiUrl + customer.GSTPhoto;
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Update(CustomerCreation customerCreation)
        {
            if (Session["UserID"] != null)
            {
                if (ModelState.IsValid)
                {
                    customerCreation.ModifiedByID = Convert.ToInt32(Session["UserID"].ToString());
                    CustomerCreations customerCreations = new CustomerCreations();
                    customerCreations.UpdateCustomer(customerCreation);
                    return Json("1");
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
        [HttpPost]
        public JsonResult TallySync(string CustID)
        {
            if (Session["UserID"] != null)
            {
                CustomerCreation tallyResult = new CustomerCreation();
                tallyResult.CustID = CustID;
                tallyResult.ModifiedByID = Convert.ToInt32(Session["UserID"].ToString());
                string Result = string.Empty;
                bool IsTallyRunning = false;
                //Check tally service from database
                DLSystemDetails dLSystemDetails = new DLSystemDetails();
                var sysDetails = dLSystemDetails.GetSystemDetails(Session["OrgID"].ToString());
                if(sysDetails != null)
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
                    if (customerCreations.UpdateTallyStatus(tallyResult))
                    {
                        Helper.LogError("DataBase Updated Successfully", null, null, null);
                        Result = "Tally Sync Successful!!";
                    }
                    else
                    {
                        Helper.LogError("Database Updation failed", null, null, null);
                        Result = "Error! Please contact administrator";
                    }
                }
                
                return Json(Result);
            }
            else
            {
                return Json("0");
            }
        }
        public object AddCustomerSupplierToTally(CustomerCreation item, bool iswinservie = false)
        {
            IsTallyCompanyOpen(item, iswinservie);


            if (IsCompanyOpen == true)
            {
                if (iswinservie == false)
                {
                    xmlFileString = Server.MapPath("~/DataFiles/CreateLedgerTemplate.xml");
                }
                else
                {
                    //"C:\Users\wbtech1\Documents\SVN\CCA_V1\MWBTCustomerCreation\Test\bin\Debug\DataFiles\IsCurrentCompanyOpen.xml"
                    string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
                    //string xmlfile = Environment.CurrentDirectory + @"\DataFiles";
                    xmlFileString = Path.Combine(xmlfile, "CreateLedgerTemplate.xml");
                }

                //xmlFileString = System.IO.File.ReadAllText(@"DataFiles\CreateLedgerTemplate.xml");
                //    xmlFileString = Server.MapPath("~/DataFiles/CreateLedgerTemplate.xml");
                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFileString);
                try
                {
                    mxmlRootPath = "ENVELOPE/BODY/";
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/DESC/STATICVARIABLES/SVCURRENTCOMPANY").InnerText = item.CompanyName;
                    mxmlRootPath = mxmlRootPath + "/DATA/TALLYMESSAGE";
                    mxmlRootPath = mxmlRootPath + "/LEDGER";

                    if (item.Name.Contains("&"))
                    {
                        item.Name = item.Name.Replace("&", "and");
                    }
                    if (item.FirmName.Contains("&"))
                    {
                        item.FirmName = item.FirmName.Replace("&", "and");
                    }
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME.LIST/NAME").InnerText = item.FirmName.Trim();

                    //if (item.IsVendor == false)
                    //    //NA
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent1; //"Sundry Debtors";//item.SundryType.Trim();
                    //else
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = "Sundry Creditors";

                    if (item.IsVendor == false)

                        //Condition to check Parent data  hierarchey data ) --start
                        if ((string.IsNullOrEmpty(item.Parent1)) && (string.IsNullOrEmpty(item.Parent2)) && (string.IsNullOrEmpty(item.Parent3)) && (string.IsNullOrEmpty(item.Parent4)))
                        {
                            xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = "Sundry Debtors";
                        }
                        else if ((!string.IsNullOrEmpty(item.Parent1)) && (!string.IsNullOrEmpty(item.Parent2)) && (!string.IsNullOrEmpty(item.Parent3)) && (!string.IsNullOrEmpty(item.Parent4)))
                        {
                            xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent1;

                        }
                        else if ((string.IsNullOrEmpty(item.Parent1)) && (!string.IsNullOrEmpty(item.Parent2)))
                        {
                            xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent2;

                        }
                        else if ((string.IsNullOrEmpty(item.Parent1)) && (string.IsNullOrEmpty(item.Parent2)) && (!string.IsNullOrEmpty(item.Parent3)))
                        {
                            xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent3;
                        }
                        else if ((string.IsNullOrEmpty(item.Parent1)) && (string.IsNullOrEmpty(item.Parent2)) && (string.IsNullOrEmpty(item.Parent3)) && (!string.IsNullOrEmpty(item.Parent4)))
                        {
                            xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent4;

                        }



                    //if (!string.IsNullOrEmpty(item.Parent1))
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent1; //"Sundry Debtors";//item.SundryType.Trim();

                    //else if (!string.IsNullOrEmpty(item.Parent2))
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent2; //"Sundry Creditors";

                    //else if (!string.IsNullOrEmpty(item.Parent3))
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent3; //"Sundry Debtors";//item.SundryType.Trim();

                    //else if (!string.IsNullOrEmpty(item.Parent4))
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/PARENT").InnerText = item.Parent4; //"Sundry Debtors";//item.SundryType.Trim();


                    //xmlDoc.SelectSingleNode(mxmlRootPath + "/COUNTRYNAME").InnerText = !string.IsNullOrEmpty(item.Country) ? item.Country.Trim() : "India"; //item.Country.Trim();
                    if (!string.IsNullOrEmpty(item.ContactpersonName))
                        xmlDoc.SelectSingleNode(mxmlRootPath + "/LEDGERCONTACT").InnerText = item.ContactpersonName.Trim();

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/ISBILLWISEON").InnerText = !string.IsNullOrEmpty(item.BillWiseYesNo) ? item.BillWiseYesNo.Trim() : string.Empty;
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/ISCREDITDAYSCHKON").InnerText = !string.IsNullOrEmpty(item.Checkforcreditdaysduringvoucherentry) ? item.Checkforcreditdaysduringvoucherentry.Trim() : string.Empty;
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/OVERRIDECREDITLIMIT").InnerText = !string.IsNullOrEmpty(item.OverrideCreditlimit) ? item.OverrideCreditlimit.Trim() : string.Empty;
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/AFFECTSSTOCK").InnerText = !string.IsNullOrEmpty(item.Inventoryvaluesareaffected) ? item.Inventoryvaluesareaffected.Trim() : string.Empty;

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/PAYMENTDETAILS.LIST/BANKNAME").InnerText = !string.IsNullOrEmpty(item.BankName) ? item.BankName.Trim() : string.Empty;
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/PAYMENTDETAILS.LIST/ACCOUNTNUMBER").InnerText = !string.IsNullOrEmpty(item.AccountNumber) ? item.AccountNumber.Trim() : string.Empty;
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/PAYMENTDETAILS.LIST/IFSCODE").InnerText = !string.IsNullOrEmpty(item.IFSCCode) ? item.IFSCCode.Trim() : string.Empty;

                    //xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME.LIST/CALCULATEINTERESTTRANSACTION_BY_TRANSACTION").InnerText = item.CalculateInterestTransaction_by_Transaction.Trim();
                    //xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME.LIST/OVERRIDEPARAMETERSFOREACHTRANSACTION").InnerText = item.OverrideParametersforeachtransaction.Trim();
                    //xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME.LIST/INTRESTRATE").InnerText = item.IntrestRate.Trim();
                    //xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME.LIST/INTERESTDAYS").InnerText = item.CalculateInterestTransaction_by_Transaction.Trim();


                    //if (item.DLDebtorsPlaceDetailCreation != null)
                    //{
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME.LIST/NAME").InnerText = item.FirmName.Trim();    //Customer Name
                    //}
                    //else
                    //{
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME.LIST/NAME").InnerText = item.FirmName.Trim();    //Customer Name
                    //}



                    if (item.OpeningBalance != null)
                        xmlDoc.SelectSingleNode(mxmlRootPath + "/OPENINGBALANCE").InnerText = item.OpeningBalance.ToString();

                    //if we edit it from app then refering to this old name it gets altered in tally

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/EMAIL").InnerText = item.EmailID.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/LEDGERPHONE").InnerText = item.TelephoneNumber.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/LEDGERMOBILE").InnerText = item.MobileNumber.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/LEDGERCONTACT").InnerText = item.Name.Trim(); // mTelephone.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/LEDGERFAX").InnerText = "";
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/STATENAME").InnerText = item.BillingState.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/PINCODE").InnerText = item.BillingPincode.ToString();

                    //if (item.PANNumber.Trim() != null || item.PANNumber.Trim() != string.Empty)
                    if (!string.IsNullOrEmpty(item.PANNumber))
                        xmlDoc.SelectSingleNode(mxmlRootPath + "/INCOMETAXNUMBER").InnerText = item.PANNumber.Trim();

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/VATTINNUMBER").InnerText = "";

                    //if (item.PostDatedTransaction == true)
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/OVERRIDECREDITLIMIT").InnerText = item.PostDatedTransaction;
                    //else
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/OVERRIDECREDITLIMIT").InnerText = "No";

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/OVERRIDECREDITLIMIT").InnerText = item.PostDatedTransaction;

                    if (item.ActivateIntrest != null)
                        xmlDoc.SelectSingleNode(mxmlRootPath + "/ISCOSTCENTRESON").InnerText = item.ActivateIntrest.Value == true ? "Yes" : "No";
                    else
                        xmlDoc.SelectSingleNode(mxmlRootPath + "/ISCOSTCENTRESON").InnerText = "No";

                    //if (item.ActivateIntrest == true)
                    //    xmlDoc.SelectSingleNode(mxmlRootPath + "/ISCOSTCENTRESON").InnerText = "Yes";

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/ISBILLWISEON").InnerText = "Yes";// item.NoofOutstandingBill.ToString();

                    if (!string.IsNullOrEmpty(item.CrDays))
                        xmlDoc.SelectSingleNode(mxmlRootPath + "/BILLCREDITPERIOD").InnerText = item.CrDays.Trim();

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/ CREDITLIMIT ").InnerText = !string.IsNullOrEmpty(item.CrLimit) ? item.CrLimit.Trim() : string.Empty;    //Crredit Limit
                                                                                                                                                                      //xmlDoc.SelectSingleNode(mxmlRootPath + "/SALESTAXNUMBER").InnerText = //mSalesTaxNumber.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/NARRATION").InnerText = ""; //mNarration.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/ADDRESS.LIST/ADDRESS").InnerText = item.BillingLandmark.Trim();
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/ADDRESS.LIST/ADDRESS").InnerText = item.BillingAddress.Trim();// + "GST NO:" + item.TINNumber.Trim();

                    xmlDoc.SelectSingleNode(mxmlRootPath + "/MAILINGNAME.LIST/MAILINGNAME").InnerText = item.FirmName.Trim();//item.Name.Trim();

                    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["NAME"].InnerText = item.FirmName.Trim();

                    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["Action"].InnerText = "Create";

                    string CustomerName = string.Empty;
                    if (item.Name.Length > 4)
                    {
                        //CustomerName = item.Name.Trim().Substring(0, 3);
                    }
                    string tempLedger = xmlDoc.InnerXml;//.Replace("", "");

                    tempLedger = tempLedger.Replace("[GST]", "GST NO:" + item.GSTNumber.Trim());

                    if (!string.IsNullOrEmpty(item.CustomerType))
                        tempLedger = tempLedger.Replace("[PARTYTYPE]", "GST NO:" + item.CustomerType.Trim());

                    if (item.RegistrationType == "Registered")
                        tempLedger = tempLedger.Replace("[IsRegistered]", "Regular");
                    else if (item.RegistrationType == "Unregistered")
                        tempLedger = tempLedger.Replace("[IsRegistered]", "Unregistered");
                    //else if (item.RegistrationType == CustomerType.Composition.ToString())
                    //    tempLedger = tempLedger.Replace("[IsRegistered]", "Composition");
                    else
                        tempLedger = tempLedger.Replace("[IsRegistered]", "Consumer");

                    tempLedger = tempLedger.Replace("[Place]", "");

                    //if (item.DLDebtorsPlaceDetailCreation != null)
                    //{
                    //    tempLedger = tempLedger.Replace("[Place]", item.DLDebtorsPlaceDetailCreation.Place.ToString());
                    //}
                    //else
                    //{
                    //    tempLedger = tempLedger.Replace("[Place]", "");
                    //}


                    string Result = XMLGetData(tempLedger);

                    #region Status
                    //if (Result.Contains("<CREATED>1"))
                    //{
                    //    string getStatus = string.Empty;

                    //    Helper.TransactionLog("Tally Updated", true);
                    //    if (((WBT.Common.ApplicationActivate)customer).DisplayMessage == "Success")
                    //    {
                    //        Helper.TransactionLog("DataBase Updated Successfully", true);
                    //        Result = "Success" + " ID: " + item.CustID;
                    //        item.stringIsTallyUpdated = "Yes";
                    //    }
                    //    else
                    //    {
                    //        Helper.TransactionLog("Database Updation failed", true);
                    //        Result = ((WBT.Common.ApplicationActivate)customer).DisplayMessage + " ID: " + item.CustID;
                    //    }
                    //}
                    //else if (Result.Contains("<ALTERED>1"))
                    //{
                    //    try
                    //    {
                    //        if (((WBT.Common.ApplicationActivate)Items).DisplayMessage == "Success")
                    //        {
                    //            Helper.TransactionLog("DataBase Updated Successfully", true);
                    //            Result = "Item Altered Success" + " ID: " + item.CustID;
                    //            item.stringIsTallyUpdated = "Yes";
                    //        }
                    //        else
                    //        {
                    //            Helper.TransactionLog("Database Updation failed", true);
                    //            Result = ((WBT.Common.ApplicationActivate)Items).DisplayMessage + " ID: " + item.CustID;
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                    //    }
                    //}
                    //else
                    //{
                    //    item.stringIsTallyUpdated = "No";
                    //    if (Result.Trim().Contains(Messages.TallyCompanyCouldNotFind))
                    //    {
                    //        Result = Messages.TallyCompanyValidation;
                    //        item.DisplayMessage = "Tally Error :" + Result;
                    //        item.Remark = Result;

                    //    }
                    //    else if (Result.Trim().Contains(Messages.TallyNotOpended))
                    //    {
                    //        Result = Messages.TallyOpenValidation;
                    //        item.DisplayMessage = "Tally :" + Result;
                    //        item.Remark = Result;
                    //    }
                    //    else if (Result.Trim().Contains(Messages.TallyAlreadyExist))
                    //    {
                    //        Result = Messages.TallyAlreadyExist;
                    //        item.DisplayMessage = "This Data :" + Result + " ID:" + item.CustID;
                    //    }
                    //    else
                    //    {
                    //        item.DisplayMessage = "Tally Error :" + Result + "ID :" + item.CustID;
                    //        item.DataState = TransactionType.TallyError;
                    //    }
                    //}
                    item.Remark = Result;
                    return item;
                    #endregion
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                    item.Remark = "Error";
                    return item;
                }
            }
            else
            {
                return item;
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

        public bool IsTallyCompanyOpen(CustomerCreation item, bool iswinservice = false)
        {
            //xmlFileString = System.IO.File.ReadAllText(@"DataFiles\IsCurrentCompanyOpen.xml");

            if (iswinservice == false)
            {
                xmlFileString = Server.MapPath("~/DataFiles/IsCurrentCompanyOpen.xml");
            }
            else
            {
                //"C:\Users\wbtech1\Documents\SVN\CCA_V1\MWBTCustomerCreation\Test\bin\Debug\DataFiles\IsCurrentCompanyOpen.xml"               
                string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
                Helper.LogError("IsCurrentCompanyOpen", xmlfile, null, "");
                xmlFileString = Path.Combine(xmlfile, "IsCurrentCompanyOpen.xml");
            }

            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileString);
            try
            {
                mxmlRootPath = "ENVELOPE/BODY/";
                xmlDoc.SelectSingleNode(mxmlRootPath + "/DESC/STATICVARIABLES/SVCOMPANYCONNECTNAME").InnerText = item.CompanyName;
                string tempLedger = xmlDoc.InnerXml;
                string Result = XMLGetData(tempLedger);
                if (Result.Contains("<SERVERCOMPANYNAME>" + item.CompanyName + "</SERVERCOMPANYNAME>"))
                {
                    IsCompanyOpen = true;
                }
                else if (Result.Contains("<DESC>Server company is not available!"))
                {
                    //item.Remark = " Please Open Company " + User.UserOrganization + " In Tally";
                    item.Remark = " Please Open Company " + item.CompanyName + " In Tally";
                    IsCompanyOpen = false;
                }
                return IsCompanyOpen;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return false;
            }
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
        public JsonResult GetCities(int? StateID)
        {
            if (Session["UserID"] != null)
            {
                var jsonResult = Json(customerCreations.GetCities(StateID.Value).ToList(), JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return Json("0");
            }
        }
        public JsonResult GetCityName(string prefix)
        {
            var jsonResult = Json(dLGetUserCreation.GetCities(0, prefix), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public void SyncCustToTally(string CustID)
        {
            GetCustDetailsforTallyUpdate(CustID);
        }
        private JsonResult GetCustDetailsforTallyUpdate(string CustID)
        {
            if (IsTallyRunning())
            {
                CustomerCreations customerCreations = new CustomerCreations();
                CustomerCreation customerCreationtoTally = customerCreations.GetCustomerDetails(CustID);
                string FirmName = CustID + customerCreationtoTally.FirmName.ToString();
                bool iswinservie = true;
                CustomerCreation tallyResult = (CustomerCreation)AddCustomerSupplierToTally(customerCreationtoTally, iswinservie);
                if (tallyResult.Remark.Contains("<CREATED>1"))
                {                       
                    tallyResult.DisplayMessage = "Tally Sync Successful!!";
                    Helper.TransactionLog(tallyResult.DisplayMessage, true);
                    tallyResult.IsTallyUpdated = true;
                    
                    if (customerCreations.UpdateTallyStatusFromService(tallyResult))
                    {
                   
                        Helper.TransactionLog("Database Updation Successfully [" + FirmName + "]", true);
                    }
                    else
                    {
                        Helper.LogError("Database Updation failed", FirmName , null, null);                        
                    }
                    
                }
                else if (tallyResult.Remark.Contains("<ALTERED>1"))
                {
                    Helper.TransactionLog("Tally Updated", true);
                    tallyResult.DisplayMessage = "Tally Sync Successful!!";
                    if (customerCreations.UpdateTallyStatusFromService(tallyResult))
                    {
                        Helper.TransactionLog("Database Updation Successfully [" + FirmName + "]", true);
                    }
                    else
                    {
                        Helper.LogError("Database Updation failed", FirmName, null, null);

                    }
                }
                else if (tallyResult.Remark.ToLower().Contains("please open company"))
                {
                    tallyResult.DisplayMessage = tallyResult.Remark;
                    tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Customer Sync", tallyResult.FirmName, tallyResult.Remark);
                    customerCreations.UpdateTallyStatusFromService(tallyResult);
                }
                else if (tallyResult.Remark.Contains("<LINEERROR>"))
                {
                    int pFrom = tallyResult.Remark.IndexOf("<LINEERROR>") + "<LINEERROR>".Length;
                    int pTo = tallyResult.Remark.LastIndexOf("</LINEERROR>");
                    tallyResult.DisplayMessage = tallyResult.Remark.Substring(pFrom, pTo - pFrom);
                    tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Customer Sync", tallyResult.FirmName, tallyResult.Remark);
                    customerCreations.UpdateTallyStatusFromService(tallyResult);
                }
                else
                {
                    tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Customer Sync", tallyResult.FirmName, tallyResult.Remark);
                    Helper.LogError("There is an error with Tally. Please try later..", null, null, null);
                    customerCreations.UpdateTallyStatusFromService(tallyResult);
                }
                return Json(tallyResult.DisplayMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please Open Tally to sync your data", JsonRequestBehavior.AllowGet);
            }
        }
    }
}