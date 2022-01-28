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

namespace WindowsService_TallyCustomer
{

    public partial class Customer_Tallysync : ServiceBase
    {
        public static Helper helper = new Helper();

        Timer tm = new Timer();
        WBT.BL.CustomerCreation customerCreation;
        public Customer_Tallysync()
        {
            InitializeComponent();
            helper.SetTimer.Interval = 1000;// Convert.ToDouble(WBTApplicationLevelSettings.TimeInterval);//helper.GetTimeInterval);
            helper.SetTimer.AutoReset = true;
            helper.SetTimer.Enabled = true;

            helper.SetTimer.Elapsed += new System.Timers.ElapsedEventHandler(SetTimer_Elapsed);
        }

        private void SetTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //WriteToFile("Service Recalls at" + DateTime.Now);
            GetTallyCustomerdetails();
        }

        protected override void OnStart(string[] args)
        {



            //WriteToFile("Services start at" + DateTime.Now);
            //tm.Enabled = true;
            //tm.Interval = 1000;

            helper.SetTimer.Start();
            tm.Elapsed += new ElapsedEventHandler(OnElapsedTime);
         
           
            
        }

        private void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service Recalls at" + DateTime.Now);
            GetTallyCustomerdetails();
            
            

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

        private void GetTallyCustomerdetails()
        {
            try
            {
                Helper.TransactionLog("Inside Method call System health check ", true);
           
                List<WBT.DLCustomerCreation.CustomerCreation> custCreation = new List<WBT.DLCustomerCreation.CustomerCreation>();
         
                CustomerCreations M_customerCreations = new CustomerCreations();
                string OrgID = ConfigurationManager.AppSettings["OrgID"].ToString();
           
                custCreation = (List<WBT.DLCustomerCreation.CustomerCreation>)M_customerCreations.GetTallysyncCustomerData(OrgID);
         
                if (custCreation.Count() > 0)
                {
                    
                    EditCustomerController editCustomerController = new EditCustomerController();
                    foreach (var i in custCreation)
                    {                        
                        editCustomerController.SyncCustToTally(i.CustID);                        
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

    }
}
