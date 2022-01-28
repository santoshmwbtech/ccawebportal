namespace WindowsService_SalesOrder
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
            this.SalesOrder_TallySync = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // SalesOrder_TallySync
            // 
            this.SalesOrder_TallySync.Description = "Update Sales Order to tally";
            this.SalesOrder_TallySync.DisplayName = "SalesOrder_TallySync";
            this.SalesOrder_TallySync.ServiceName = "WindowsService_SalesOrder";
            this.SalesOrder_TallySync.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.SalesOrder_TallySync.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.SalesOrder_TallySync_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.SalesOrder_TallySync});

        }

        #endregion
        public System.ServiceProcess.ServiceInstaller SalesOrder_TallySync;
        public System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
    }
}