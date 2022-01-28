namespace WindowsService_TallyDebtors
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
            this.Debtor_TallySync = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // Debtor_TallySync
            // 
            this.Debtor_TallySync.Description = "Debtor_TallySync Update";
            this.Debtor_TallySync.DisplayName = "Debtor_TallySync";
            this.Debtor_TallySync.ServiceName = "Debtor_TallySync";
            this.Debtor_TallySync.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.Debtor_TallySync.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.Debtor_TallySync_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.Debtor_TallySync});

        }

        #endregion

        public System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        public System.ServiceProcess.ServiceInstaller Debtor_TallySync;
    }
}