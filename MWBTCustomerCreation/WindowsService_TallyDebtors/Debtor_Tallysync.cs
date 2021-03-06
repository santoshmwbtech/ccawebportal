using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WBT.DL;
using WBT.BL;
using WBT.Common;
using WBT.DLCustomerCreation;
using CCAPortal.Controllers;
using System.Configuration;
using System.Xml;
using System.Net;

namespace WindowsService_TallyDebtors
{
    public partial class Debtor_Tallysync : ServiceBase
    {
        public static Helper helper = new Helper();
        string CompanyName = string.Empty;
        string xmlFileString = string.Empty;
        XmlDocument xmlDoc = new XmlDocument();
        string mxmlRootPath = string.Empty;
        string Result = string.Empty;
        ReceiptsController receiptsController = new ReceiptsController();

        Timer tm = new Timer();
        public Debtor_Tallysync()
        {
            InitializeComponent();
            helper.SetTimer.Interval = 1000;// Convert.ToDouble(WBTApplicationLevelSettings.TimeInterval);//
            helper.SetTimer.AutoReset = true;
            helper.SetTimer.Enabled = true;

            helper.SetTimer.Elapsed += new System.Timers.ElapsedEventHandler(SetTimer_Elapsed);
        }

        private void SetTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Insert is tally open and tally company name to the database to access it from web portal
            InsertTallyStatus();
            GetTallyDebtorsdetails();
        }

        protected override void OnStart(string[] args)
        {
            helper.SetTimer.Start();
            tm.Elapsed += new ElapsedEventHandler(OnElapsedTime);
        }

        private void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service Recalls at" + DateTime.Now);
            GetTallyDebtorsdetails();

        }

        void WriteToFile(string message)
        {
            string Folderpath = AppDomain.CurrentDomain.BaseDirectory + "ServiceLogpath";
            if (!Directory.Exists(Folderpath))
            {
                Directory.CreateDirectory(Folderpath);
            }

            string filepath = Folderpath + @"\" + "logfile" + ".txt";

            //Check from New file Create 
            if (File.Exists(filepath))
            {
                using (StreamWriter SW = File.CreateText(filepath))
                {

                    SW.WriteLine(message);
                }
            }
            //if file exist append file which alrady creaded in base directory path
            else
            {
                using (StreamWriter SW = File.AppendText(filepath))
                {
                    SW.WriteLine(message);
                }
            }
        }

        protected override void OnStop()
        {
            WriteToFile("Services Stop  at" + DateTime.Now);
            helper.SetTimer.Enabled = false;
            helper.SetTimer.Stop();
        }


        private void GetTallyDebtorsdetails()
        {
            try
            {
                var _taxLedgerRepository = new DLTaxLedgers();
                //Helper.TransactionLog("Step 1", true);
                List<DebtorsDetails> lstdebtorsDetails = new List<DebtorsDetails>();
                DLDebtorsCreation M_DebtorsCreation = new DLDebtorsCreation();
                string OrgID = ConfigurationManager.AppSettings["OrgID"].ToString();
                lstdebtorsDetails = M_DebtorsCreation.GetDebtorsListForTallySync(OrgID);
                if (lstdebtorsDetails.Count() > 0)
                {
                    DebtorsController debtorsController = new DebtorsController();
                    foreach (var i in lstdebtorsDetails)
                    {
                        debtorsController.Debtor_TallySync(i.ID);
                    }
                }
                //Sync Tax Ledgers
                var taxLedgers = _taxLedgerRepository.GetTaxLedgers(OrgID);
                if (taxLedgers.Count() > 0)
                {
                    var taxledgersMaster = new TaxLegdersMasterController();
                    foreach (var i in taxLedgers)
                    {
                        taxledgersMaster.SaveTaxLedgerToTally(i, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
            }
        }

        private void InsertTallyStatus()
        {
            try
            {
                bool IsTallyServiceRunning = IsTallyRunning();
                string OrgID = ConfigurationManager.AppSettings["OrgID"].ToString();
                string TallyCompanyName = string.Empty;
                DLSystemDetails dLSystemDetails = new DLSystemDetails();
                if (IsTallyServiceRunning)
                {
                    //TallyCompanyName = GetTallyCompanyName();
                    dLSystemDetails.SaveSystemDetails(OrgID, IsTallyServiceRunning);
                }
                else
                {
                    dLSystemDetails.SaveSystemDetails(OrgID, IsTallyServiceRunning);
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
            }
        }

        private static bool IsTallyRunning()
        {
            string processName = ConfigurationManager.AppSettings["TallyProcessName"];
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                return true;
            }
            return false;
        }
        private string GetTallyCompanyName()
        {
            
            string xmlfile = Helper.GetSystemFilePath() + @"\DataFiles";
            xmlFileString = Path.Combine(xmlfile, "IsCurrentCompanyOpen.xml");

            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileString);

            try
            {
                mxmlRootPath = "ENVELOPE/BODY/";
                //xmlDoc.SelectSingleNode(mxmlRootPath + "/DESC/STATICVARIABLES/SVCOMPANYCONNECTNAME").InnerText = OrgName;//User.UserOrganization;
                string tempLedger = xmlDoc.InnerXml;
                Result = XMLGetData(tempLedger);                
                if (Result.Contains("<SERVERCOMPANYNAME>"))   // User.UserOrganization
                {
                    xmlDoc.LoadXml(Result);
                    XmlNodeList nodeList = xmlDoc.GetElementsByTagName("SERVERCOMPANYNAME");
                    foreach (XmlNode node in nodeList)
                    {
                        CompanyName = node.InnerText;
                    }
                }
                else if (Result.Contains("<DESC>Server company is not available!"))
                {
                    CompanyName = "No Company Open";
                }
                return CompanyName;
            }
            catch (Exception ex)
            {
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
                Helper.LogError(ex.Message, ex.Source, null, ex.StackTrace);
                return "No Company Open";
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
    }
}
