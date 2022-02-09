using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Timers;
using WBT.DL;
using WBT.BL;
using WBT.Common;
using WBT.DLCustomerCreation;
using CCAPortal.Controllers;




namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTallyCustomerdetails();

        }

        private void GetTallyCustomerdetails()
        {

            try
            {
                Helper.TransactionLog("Inside Method call System health check ", true);

                List<WBT.DLCustomerCreation.CustomerCreation> custCreation = new List<WBT.DLCustomerCreation.CustomerCreation>();

                CustomerCreations M_customerCreations = new CustomerCreations();
                string OrgID = "2";
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
                //Helper.EventLogWriteEntry("system health check", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            GetTallyDebtorsdetails();
        }

        private void GetTallyDebtorsdetails()
        {
            try
            {
                //Helper.LogError("S1", "", null, "");
                List<WBT.DLCustomerCreation.DebtorsDetails> lstdebtorsDetails = new List<WBT.DLCustomerCreation.DebtorsDetails>();
                DLDebtorsCreation M_DebtorsCreation = new DLDebtorsCreation();
                string OrgID = "2";
                lstdebtorsDetails = (List<WBT.DLCustomerCreation.DebtorsDetails>)M_DebtorsCreation.GetDebtorsListForTallySync(OrgID);
                //Helper.LogError("S2", "", null, "");
                //lstdebtorsDetails = M_DebtorsCreation.GetDebtorsListForTallySync(OrgID);
                if (lstdebtorsDetails.Count() > 0)
                {
                    DebtorsController debtorsController = new DebtorsController();
                    foreach (var i in lstdebtorsDetails)
                    {
                        //Helper.LogError("S3", "", null, "");
                        debtorsController.Debtor_TallySync(i.ID);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetTallyReceiptdDetails();
        }
        private void GetTallyReceiptdDetails()
        {
            try
            {
                List<WBT.DLCustomerCreation.Receipts> GetReceipts = new List<WBT.DLCustomerCreation.Receipts>();
                Receipts m_receipts = new Receipts();
                string OrgId = "2";
                GetReceipts = (List<WBT.DLCustomerCreation.Receipts>)m_receipts.GetReceiptDetailTally(OrgId);
                if (GetReceipts.Count() > 0)
                {
                    ReceiptsController receiptsController = new ReceiptsController();
                    foreach (var i in GetReceipts)
                    {
                       receiptsController.SyncReceiptToTally(i.ReceiptID, i.OrgID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
            }
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            GetSOListForTallySync();
        }
        private void GetSOListForTallySync()
        {
            try
            {
                Helper.TransactionLog("Inside Method call System health check ", true);

                List<SalesOrders> salesOrders = new List<SalesOrders>();

                DLSalesOrders dLSalesOrders = new DLSalesOrders();
                string OrgID = "2";

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
    }
}
