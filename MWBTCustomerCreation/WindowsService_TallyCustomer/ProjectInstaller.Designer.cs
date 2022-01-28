
namespace WindowsService_TallyCustomer
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.Cust_Tallysync = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // Cust_Tallysync
            // 
            this.Cust_Tallysync.Description = "Update Customer details to tally";
            this.Cust_Tallysync.DisplayName = "Cust_Tallysync";
            this.Cust_Tallysync.ServiceName = "WindowsService_TallyCustomer";
            this.Cust_Tallysync.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.Cust_Tallysync.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.Cust_Tallysync_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.Cust_Tallysync});

        }

        #endregion

        public System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        public System.ServiceProcess.ServiceInstaller Cust_Tallysync;
    }
}