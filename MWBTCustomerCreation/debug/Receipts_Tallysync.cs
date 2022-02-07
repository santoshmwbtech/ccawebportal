using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using WBT.DLCustomerCreation;
using WBT.Common;
using CCAPortal.Controllers;
using System.Configuration;

namespace WindowsService_TallyReceipts
{
    public partial class Service1 : ServiceBase
    {
        public static Helper helper = new Helper();
        Timer tm = new Timer();
        public Service1()
        {
            InitializeComponent();
            helper.SetTimer.Interval = 60000;// Convert.ToDouble(WBTApplicationLevelSettings.TimeInterval);//helper.GetTimeInterval);
            helper.SetTimer.AutoReset = true;
            helper.SetTimer.Enabled = true;
            helper.SetTimer.Elapsed += new System.Timers.ElapsedEventHandler(SetTimer_Elapsed);
        }

        private void SetTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //WriteToFile("Service Recalls at" + DateTime.Now);
            GetTallyReceiptdDetails();
          
        }

        protected override void OnStart(string[] args)
        {
            //WriteToFile("Services start at" + DateTime.Now);
            //tm.Enabled = true;
            //tm.Interval = 1000;
            helper.SetTimer.Start();
            //tm.Elapsed += new ElapsedEventHandler(OnElapsedTime);
        }

        //private void OnElapsedTime(object sender, ElapsedEventArgs e)
        //{
        //    WriteToFile("Service Recalls at" + DateTime.Now);
        //    GetTallyReceiptdDetails();
        //}
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

        private void GetTallyReceiptdDetails()
        {
            try
            {                
                List<WBT.DLCustomerCreation.Receipts> GetReceipts = new List<WBT.DLCustomerCreation.Receipts>();
                Receipts m_receipts = new Receipts();
                string OrgID = ConfigurationManager.AppSettings["OrgID"].ToString();
                GetReceipts = (List<WBT.DLCustomerCreation.Receipts>)m_receipts.GetReceiptDetailTally(OrgID);
                int Receiptscount = GetReceipts.Count();
                if (GetReceipts.Count() > 0)
                {
                    int iCount = 1;
                    ReceiptsController receiptsController = new ReceiptsController();
                    foreach (var getReceiptDetL in GetReceipts)
                    {
                        //Helper.LogError("Receipts START Recored Count [ " + iCount + " ]", "", null, "");
                        //Add Tally Insert method from Gangadha    
                        //string ReceiptID = "R00000001";
                        //receiptsController.SyncCustToTally(ReceiptID, OrgId);

                        receiptsController.SyncReceiptToTally(getReceiptDetL.ReceiptID, getReceiptDetL.OrgID);
                        //iCount = iCount + 1;
                        //System.Threading.Thread.Sleep(10000);
                        //break;                        
                    }                                    
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
            }

        }

    }
}
