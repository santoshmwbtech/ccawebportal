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
using WBT.DLCustomerCreation.DTOs;

namespace CCAPortal.Controllers
{
    public class TaxLegdersMasterController : Controller
    {
        // GET: TaxLegdersMaster
        DLTaxLedgers dLLedgerCreation = new DLTaxLedgers();
        CustomerCreations customerCreations = new CustomerCreations();
        public static string xmlFileString = string.Empty;
        static XmlDocument xmlDoc = new XmlDocument();
        static string mxmlRootPath = string.Empty;
        bool IsCompanyOpen = false;
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TallySync tallySync = new TallySync();
        // GET: Debtors
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.TaxLedgerList = new SelectList(dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()), "ID", "Name");
                return View(dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Create()
        {
            ViewBag.TaxList = new SelectList(dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()), "OrgID", "Name");
            ViewBag.TaxTypeList = new SelectList(dLLedgerCreation.GetTaxTypesList(Session["OrgID"].ToString()), "TaxType", "TaxType");

            //CGST: Central Goods and Services Tax
            //SGST: State Goods and Services Tax
            //IGST: Integrated Goods and Services Tax

            return PartialView();
        }
        public ActionResult TaxLedgerList()
        {
            return PartialView(dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TaxLedgersDTO taxLedgers)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                int ID = dLLedgerCreation.SaveTaxLedger(taxLedgers, Session["UserID"].ToString(), Session["OrgID"].ToString());
                if (ID > 0)
                {
                    ModelState.Clear();
                    return Json(new
                    {
                        ID = ID,
                        Message = "success",
                        AjaxReturn = PartialView("TaxLedgerList", dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList()).RenderToString()
                    });
                }
                else
                {
                    return Json(new
                    {
                        ID = 0,
                        Message = "TaxLedger Name already exists",
                        AjaxReturn = PartialView("TaxLedgerList", dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList()).RenderToString()
                    });
                }
            }
            else
            {
                return Json(new
                {
                    Status = 0,
                    Message = "error",
                    AjaxReturn = PartialView("TaxLedgerList", dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }
        public ActionResult Edit(int? ID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.TaxLedgerList = new SelectList(dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()), "ID", "Name");
            ViewBag.TaxTypeList = new SelectList(dLLedgerCreation.GetTaxTypesList(Session["OrgID"].ToString()), "TaxType", "TaxType");
            TaxLedgersDTO obj = dLLedgerCreation.GetTaxLedgerDetail(ID);

            if (obj == null)
            {
                return HttpNotFound();
            }

            return PartialView("Edit", obj);
        }
        public ActionResult Delete(int ID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLRoleCreation Result = dLLedgerCreation.DeleteTaxLedger(ID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        }       
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TaxLedgersDTO Ledgers)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                int ID = dLLedgerCreation.SaveTaxLedger(Ledgers, Session["UserID"].ToString(), Session["OrgID"].ToString());
                if (ID > 0)
                {
                    ModelState.Clear();
                    return Json(new
                    {
                        ID = ID,
                        Message = "success",
                        AjaxReturn = PartialView("TaxLedgerList", dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList()).RenderToString()
                    });
                }
                else
                {
                    return Json(new
                    {
                        ID = 0,
                        Message = "TaxLedger Name already exists",
                        AjaxReturn = PartialView("TaxLedgerList", dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList()).RenderToString()
                    });
                }
            }
            else
            {
                return Json(new
                {
                    Status = 0,
                    Message = "error",
                    AjaxReturn = PartialView("TaxLedgerList", dLLedgerCreation.GetTaxLedgers(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }

        public bool IsTallyCompanyOpen(TaxLedgersDTO item, string BranchName, bool iswinservice = false)
        {
            //xmlFileString = System.IO.File.ReadAllText(@"DataFiles\IsCurrentCompanyOpen.xml");
            if (iswinservice == false)
            {
                xmlFileString = Server.MapPath("~/DataFiles/IsCurrentCompanyOpen.xml");
            }
            else
            {
                string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
                Helper.LogError("IsCurrentCompanyOpen", xmlfile, null, "");
                xmlFileString = Path.Combine(xmlfile, "IsCurrentCompanyOpen.xml");
            }
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
                    Helper.LogError("S7", "", null, "");
                }
                else if (Result.Contains("<DESC>Server company is not available!"))
                {
                    item.DisplayMsg = " Please Open Company " + BranchName + " In Tally";
                    IsCompanyOpen = false;
                }
                else
                {
                    item.DisplayMsg = Result;
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
        public JsonResult TallySync(int? ID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                TaxLedgersDTO TaxLedgerTally = new TaxLedgersDTO();
                TaxLedgerTally.ModifiedBy = Convert.ToInt32(Session["UserID"].ToString());
                TaxLedgerTally.ModifiedDate = DateTimeNow;
                TaxLedgerTally.ID = ID.Value;
                string Result = string.Empty;
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
                    if (dLLedgerCreation.UpdateTallyStatus(TaxLedgerTally))
                    {
                        Helper.LogError("database updated successfully", null, null, null);
                        Result = "Tally Sync Successful!!";
                    }
                    else
                    {
                        Helper.LogError("database updation failed", null, null, null);
                        Result = "error!! please contact administrator";
                    }
                }
                return Json(Result);
            }
            else
            {
                return Json("0");
            }
        }

        public TaxLedgersDTO SaveTaxLedgerToTally(TaxLedgersDTO item, bool iswinservie = false)
        {

            IsTallyCompanyOpen(item, item.BranchName, iswinservie);

            if (IsCompanyOpen == true)
            {
                if (iswinservie == false)
                {
                    xmlFileString = Server.MapPath("~/DataFiles/GroupDebtorDetails.xml");
                }
                else
                {
                    string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
                    //string xmlfile = Environment.CurrentDirectory + @"\DataFiles";
                    xmlFileString = Path.Combine(xmlfile, "GroupDebtorDetails.xml");
                }

                TaxLedgersDTO IResult = new TaxLedgersDTO();

                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFileString);
                try
                {
                    mxmlRootPath = "ENVELOPE/BODY/";
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/DESC/STATICVARIABLES/SVCURRENTCOMPANY").InnerText = item.BranchName;
                    mxmlRootPath = mxmlRootPath + "/DATA/TALLYMESSAGE";
                    mxmlRootPath = mxmlRootPath + "/GROUPS";
                    xmlDoc.SelectSingleNode(mxmlRootPath + "/NAME").InnerText = item.Name.Trim();//item.SundryType.Trim();  
                    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["NAME"].InnerText = item.Name;

                    //if (item.IsEdited)
                    //{
                    //    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["Action"].InnerText = "Alter";
                    //}
                    //else
                    //{
                    //    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["Action"].InnerText = "Create";
                    //}
                    xmlDoc.SelectSingleNode(mxmlRootPath).Attributes["Action"].InnerText = "Create";

                    string tempLedger = xmlDoc.InnerXml.Replace("[Alias]", "<NAME>" + "" + "</NAME>");

                    if (item.Under == "Duties and Taxes")
                        tempLedger = tempLedger.Replace("[Parent]", "" + item.Under);
                    else
                        tempLedger = tempLedger.Replace("[Parent]", item.Under);

                    //Alies Name
                    string Result = XMLGetData(tempLedger);

                    IResult.DisplayMsg = Result;
                    IResult.ID = item.ID;
                    IResult.OrgID = item.OrgID;
                    IResult.Name = item.Name;
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

        //public void Debtor_TallySync(int? ID)
        //{
        //    GetDebtorsDetailsforTallyUpdate((int)ID);
        //}
        //private JsonResult GetDebtorsDetailsforTallyUpdate(int ID)
        //{
        //    if (IsTallyRunning())
        //    {
        //        DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        //        bool iswinservie = true;
        //        DebtorsDetails debtorsTally = dLLedgerCreation.GetTaxLedgers(ID);
        //        string DebtorName = debtorsTally.DebtorName.ToString();
        //        DebtorsDetails tallyResult = SaveDebtorToTally(debtorsTally, iswinservie);

        //        if (tallyResult.DisplayMessage.Contains("<CREATED>1"))
        //        {
        //            Helper.LogError("Tally Updated", null, null, null);
        //            tallyResult.DisplayMessage = "Tally Sync Successful!!";
        //            tallyResult.IsTallyUpdated = true;
        //            tallyResult.ModifiedDate = DateTimeNow;
        //            tallyResult.ID = debtorsTally.ID;
        //            //if (dLLedgerCreation.UpdateTallyStatusFromService(tallyResult))
        //            //{
        //            //    Helper.TransactionLog("Database Updation Successfully [" + DebtorName + "]", true);
        //            //}
        //            //else
        //            //{
        //            //    Helper.LogError("Database Updation failed", DebtorName, null, null);
        //            //}
        //        }
        //        else if (tallyResult.DisplayMessage.Contains("<ALTERED>1"))
        //        {
        //            tallyResult.DisplayMessage = "Tally Sync Successful!!";
        //            tallyResult.IsTallyUpdated = true;
        //            tallyResult.ModifiedDate = DateTimeNow;
        //            tallyResult.ID = debtorsTally.ID;
        //            //if (dLLedgerCreation.UpdateTallyStatusFromService(tallyResult))
        //            //{
        //            //    Helper.TransactionLog("Database Updation Successfully [" + DebtorName + "]", true);
        //            //}
        //            //else
        //            //{
        //            //    Helper.TransactionLog("Database Updation Successfully [" + DebtorName + "]", true);
        //            //}
        //        }
        //        else if (tallyResult.DisplayMessage.ToLower().Contains("please open company"))
        //        {
        //            tallyResult.DisplayMessage = tallyResult.DisplayMessage;
        //           // dLLedgerCreation.UpdateTallyStatusFromService(debtorsTally, true);
        //            tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Debtor Group Sync", tallyResult.DebtorName, tallyResult.DisplayMessage);
        //        }
        //        else if (tallyResult.DisplayMessage.Contains("<LINEERROR>"))
        //        {
        //            int pFrom = tallyResult.DisplayMessage.IndexOf("<LINEERROR>") + "<LINEERROR>".Length;
        //            int pTo = tallyResult.DisplayMessage.LastIndexOf("</LINEERROR>");
        //            tallyResult.DisplayMessage = tallyResult.DisplayMessage.Substring(pFrom, pTo - pFrom);
        //            //dLLedgerCreation.UpdateTallyStatusFromService(debtorsTally, true);
        //            tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Debtor Group Sync", tallyResult.DebtorName, tallyResult.DisplayMessage);
        //        }
        //        else
        //        {
        //            Helper.LogError(tallyResult.DisplayMessage, null, null, null);
        //            //dLLedgerCreation.UpdateTallyStatusFromService(debtorsTally, true);
        //            tallySync.InsertTallySyncErrors(tallyResult.OrgID, "Debtor Group Sync", tallyResult.DebtorName, tallyResult.DisplayMessage);
        //        }
        //        return Json(tallyResult.DisplayMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please Open Tally to sync your data", JsonRequestBehavior.AllowGet);
        //    }

        //}
    }
}

//A tax ledger provides a space to record information relevant to taxes, for ease of record keeping throughout the year. It can include fields for income, deductions, payments to tax agencies, and other data that may be important for tax accounting.