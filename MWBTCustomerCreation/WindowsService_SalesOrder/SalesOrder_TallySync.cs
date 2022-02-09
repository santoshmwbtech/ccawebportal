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
using WBT.Common;
using WBT.DLCustomerCreation;
using CCAPortal.Controllers;
using System.Configuration;
using WBT.DL.CCAplusSO;

namespace WindowsService_SalesOrder
{
    public partial class SalesOrder_TallySync : ServiceBase
    {
        public static Helper helper = new Helper();
        Timer tm = new Timer();
        public SalesOrder_TallySync()
        {
            InitializeComponent();
            helper.SetTimer.Interval = 5000;// Convert.ToDouble(WBTApplicationLevelSettings.TimeInterval);//helper.GetTimeInterval);
            helper.SetTimer.AutoReset = true;
            helper.SetTimer.Enabled = true;

            helper.SetTimer.Elapsed += new System.Timers.ElapsedEventHandler(SetTimer_Elapsed);
        }
        private void SetTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //WriteToFile("Service Recalls at" + DateTime.Now);
            GetSOListForTallySync();
        }

        protected override void OnStart(string[] args)
        {
            helper.SetTimer.Start();
            tm.Elapsed += new ElapsedEventHandler(OnElapsedTime);
        }

        private void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service Recalls at" + DateTime.Now);
            GetSOListForTallySync();
        }
        protected override void OnStop()
        {
            helper.SetTimer.Enabled = false;
            helper.SetTimer.Stop();
        }
        private void GetSOListForTallySync()
        {
            try
            {
                Helper.TransactionLog("Inside Method call System health check ", true);

                List<SalesOrders> salesOrders = new List<SalesOrders>();

                DLSalesOrders dLSalesOrders = new DLSalesOrders();
                string OrgID = ConfigurationManager.AppSettings["OrgID"].ToString();

                salesOrders = dLSalesOrders.GetSOListForTally(OrgID);

                if (salesOrders.Count() > 0)
                {

                    SalesOrderEditController salesOrderEditController = new SalesOrderEditController();
                    foreach (var i in salesOrders)
                    {
                        salesOrderEditController.SyncSOToTally(i);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                //Helper.EventLogWriteEntry("system health check", ex.Message);]
                Helper.TransactionLog("Exception", true);
            }
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
    }
}
