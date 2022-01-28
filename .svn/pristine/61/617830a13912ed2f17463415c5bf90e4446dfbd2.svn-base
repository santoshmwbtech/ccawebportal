namespace WindowsService_TallyReceipts
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
            this.Receipts_TallySyncs = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // Receipts_TallySyncs
            // 
            this.Receipts_TallySyncs.Description = "Update Receipts details to tally";
            this.Receipts_TallySyncs.DisplayName = "Receipts_TallySyncs";
            this.Receipts_TallySyncs.ServiceName = "Receipts_TallySyncs";
            this.Receipts_TallySyncs.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.Receipts_TallySyncs.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.Receipts_TallySyncs_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.Receipts_TallySyncs});

        }

        #endregion
        public System.ServiceProcess.ServiceInstaller Receipts_TallySyncs;
        public System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
    }
}