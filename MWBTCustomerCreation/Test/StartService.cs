using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WBT.Common;
using WBT.DLCustomerCreation;

namespace Test
{
    public partial class StartService : Form
    {
        List<Process> processlist = new List<Process>();
        public StartService()
        {            
            InitializeComponent();
            //btnStopService.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();
            Login login = new Login();
            login.EmailID = UserName;
            login.Password = Helper.Encrypt(Password);
            string message = string.Empty;
            string title = string.Empty;

            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                CustomerCreations M_customerCreations = new CustomerCreations();
                var result = M_customerCreations.Login(login);
                if (result != null)
                {
                    string OrgID = result.OrgID;
                    //write orgid to webconfig file
                    bool SR = InstallService();
                    //WriteToFile(Helper.GetSystemFilePath());
                    if (SR)
                    {
                        InsertOrgID(OrgID);
                        M_customerCreations.UpdateTallyServiceStatus(OrgID);
                        lblMessage.Visible = true;
                        lblMessage.Text = "Services installed successfully.. Now you can sync your data to tally!!";
                        txtPassword.Visible = false;
                        txtUsername.Visible = false;
                        //btnSubmit.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        //btnStopService.Visible = true;
                        message = "Services Installed Successfully!! Now you can use tally sync from the web portal";
                        title = "Success";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        message = "Unable to install the services.. Please contact administrator";
                        title = "Fail";
                        MessageBox.Show(message, title);
                    }
                }
                else
                {
                    message = "Invalid Credentials";
                    title = "Invalid Credentials";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                    MessageBox.Show(message, title);
                }
            }
            else
            {
                message = "Please enter username and password";
                title = "All fields required";
                MessageBox.Show(message, title);
            }
        }
        private bool InstallService()
        {
            try
            {
                //System.Diagnostics.Process.Start("Cmd.exe");
                processlist = new List<Process>();
                string filename = Helper.GetSystemFilePath() + "MWBTInstallService.bat";
                //@"E:\TestBatch\InstallService.bat";
                using (StreamWriter writer = File.CreateText(filename))
                {
                    // write "ping" into the file
                    writer.WriteLine("ping " + " -t");
                    //writer.WriteLine(@"Cd\");
                    //writer.WriteLine("E:");
                    Helper.LogError(Helper.GetSystemFilePath(), null, null, null);
                    string WindowsPath = Helper.GetSystemFilePath() + "InstallUtil.exe";

                    string CustomersService = Helper.GetSystemFilePath() + "WindowsService_TallyCustomer.exe";
                    string DebtorsService = Helper.GetSystemFilePath() + "WindowsService_TallyDebtors.exe";
                    string ReceiptsService = Helper.GetSystemFilePath() + "WindowsService_TallyReceipts.exe";
                    string SOService = Helper.GetSystemFilePath() + "WindowsService_SalesOrder.exe";
                    //string TallyStatus = Helper.GetSystemFilePath() + "WBT.WindowServiceForTallyStatus.exe";

                    //writer.WriteLine(@"WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe " + servicePath1);
                    //writer.WriteLine(@"WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe " +md servicePath2);

                     writer.WriteLine(WindowsPath + " " + CustomersService);
                    writer.WriteLine(WindowsPath + " " + DebtorsService);
                    writer.WriteLine(WindowsPath + " " + ReceiptsService);
                    writer.WriteLine(WindowsPath + " " + SOService);

                }

                Process ps = new Process();
                ps.StartInfo.UseShellExecute = true;
                ps.StartInfo.FileName = filename;
                ps.StartInfo.WorkingDirectory = @"";
                ps.StartInfo.Verb = "runas";
                processlist.Add(ps);
                ps.Start();

                //int val = ProgressBarData("Running", "Installing Services...", "Services Installed");
                Helper.TransactionLog("Services Installed", true);

                //if (val > 30)
                //    return true;
                //else
                //    return false;
                return true;
                //ps.Close();
                // add process to list
                //ServiceInstaller.InstallAndStart("Service1", "Service1", Assembly.GetExecutingAssembly().Location);
                //BLSalesOrderCreation bLSalesOrderCreation = new BLSalesOrderCreation();
                //bLSalesOrderCreation.AutoSOExpiryFromService();
            }
            catch (Exception ex)
            {
                WBT.Common.Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }
        private bool UninstallService()
        {
            try
            {
                processlist = new List<Process>();
                string filename = Helper.GetSystemFilePath() + "MWBTUninstallService.bat";//  @"E:\TestBatch\UnInstallService.bat";
                using (StreamWriter writer = File.CreateText(filename))
                {
                    //writer.WriteLine(@"Cd\");
                    //writer.WriteLine("E:");
                    //string servicePath = Helper.GetSystemFilePath() + "WBT.WindowsServices.exe";
                    //string servicePath2 = Helper.GetSystemFilePath() + "WBT.WindowServiceForBusinessAndCreditTypes.exe";

                    //writer.WriteLine(@"WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u " + servicePath);
                    //writer.WriteLine(@"WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u " + servicePath2);

                    string WindowsPath = Helper.GetSystemFilePath() + "InstallUtil.exe";

                    string CustomersService = Helper.GetSystemFilePath() + "WindowsService_TallyCustomer.exe";
                    string DebtorsService = Helper.GetSystemFilePath() + "WindowsService_TallyDebtors.exe";
                    string ReceiptsService = Helper.GetSystemFilePath() + "WindowsService_TallyReceipts.exe";
                    string SOService = Helper.GetSystemFilePath() + "WindowsService_SalesOrder.exe";

                    writer.WriteLine(WindowsPath + @" /u " + CustomersService);
                    writer.WriteLine(WindowsPath + @" /u " + DebtorsService);
                    writer.WriteLine(WindowsPath + @" /u " + ReceiptsService);
                    writer.WriteLine(WindowsPath + @" /u " + SOService);

                }
                Process ps = new Process();
                ps.StartInfo.UseShellExecute = true;
                ps.StartInfo.FileName = filename;
                ps.StartInfo.WorkingDirectory = @"";
                ps.StartInfo.Verb = "runas";
                //ps.StartInfo.Password = ConvertToSecureString(Password);
                // add process to list
                processlist.Add(ps);
                ps.Start();
                Helper.TransactionLog("Uninstalled Service", true);
                return true;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UninstallService();
            label1.Visible = true;
            label2.Visible = true;
            txtUsername.Visible = true;
            txtPassword.Visible = true;
            btnSubmit.Visible = true;
            lblMessage.Visible = false;
        }
        private void InsertOrgID(string OrgID)
        {
            #region added on 6th Sept 2021 setting db details in Dl app config key

            string dlAppConfig = Helper.GetSystemFilePath() + @"WindowsService_TallyCustomer.exe";
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(dlAppConfig);
            AppSettingsSection dlSetting = (AppSettingsSection)configuration.GetSection("appSettings");

            //encrypt and assign
            dlSetting.Settings["OrgID"].Value = OrgID;
            configuration.Save(ConfigurationSaveMode.Modified);

            dlAppConfig = Helper.GetSystemFilePath() + @"WindowsService_TallyDebtors.exe";
            Configuration dlConfig2 = ConfigurationManager.OpenExeConfiguration(dlAppConfig);
            dlSetting = (AppSettingsSection)dlConfig2.GetSection("appSettings");
            dlSetting.Settings["OrgID"].Value = OrgID;
            dlConfig2.Save(ConfigurationSaveMode.Modified);


            dlAppConfig = Helper.GetSystemFilePath() + @"WindowsService_TallyReceipts.exe";
            Configuration dlConfig3 = ConfigurationManager.OpenExeConfiguration(dlAppConfig);
            dlSetting = (AppSettingsSection)dlConfig3.GetSection("appSettings");
            dlSetting.Settings["OrgID"].Value = OrgID;
            dlConfig3.Save(ConfigurationSaveMode.Modified);

            dlAppConfig = Helper.GetSystemFilePath() + @"WindowsService_SalesOrder.exe";
            Configuration dlConfig4 = ConfigurationManager.OpenExeConfiguration(dlAppConfig);
            dlSetting = (AppSettingsSection)dlConfig4.GetSection("appSettings");
            dlSetting.Settings["OrgID"].Value = OrgID;
            dlConfig4.Save(ConfigurationSaveMode.Modified);

            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
