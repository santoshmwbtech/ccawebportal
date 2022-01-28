using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.DL.Master;
using WBT.Entity;

namespace WBT.DL.Transaction
{
    public class DLItemSupplierMapCreation
    {
        public int ID { get; set; }
        public int ItemSupMappingID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Select { get; set; }
        public string CustID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsMapped { get; set; }

        public virtual DLCustomerVendorDetailCreation DLCustomerVendorDetail { get; set; }
        //public virtual DLItemCreation DLItem { get; set; }
        //public virtual DLUserCreation DLSysUser { get; set; }
    }
    public class DLItemSupplierMap : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();

        private tblItemSupplierMapping lItemSupplierMapping = new tblItemSupplierMapping();

        private List<DLItemSupplierMapCreation> lstItemSupplierMapCreation = new List<DLItemSupplierMapCreation>();

        private DLItemSupplierMapCreation mItemSupplierMapCreation = new DLItemSupplierMapCreation();


        public List<DLItemSupplierMapCreation> ItemSupplierMapCreation 
        {
            get { return lstItemSupplierMapCreation; }
            set { lstItemSupplierMapCreation = value; }
        }

        public override object DataActivate(object Context)
        {
            try
            {
                object lResult = null;
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Load:
                        lResult = GetData(Context.ToString());
                        break;

                    case Common.TransactionType.Save:
                        lResult = SaveData(Context);
                        break;
                }
                return lResult;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        private object GetData(string SearchValue)
        {
            lstItemSupplierMapCreation = new List<DLItemSupplierMapCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed


                    foreach (var drow in from gItemsupplier in Entities.tblItemSupplierMappings.AsNoTracking().ToList()
                             select gItemsupplier)
                    {
                        mItemSupplierMapCreation = new DLItemSupplierMapCreation();
                        mItemSupplierMapCreation.ItemSupMappingID = drow.ItemSupMappingID;
                        mItemSupplierMapCreation.ItemCode = drow.ItemCode;
                        mItemSupplierMapCreation.Select = string.Empty;
                        mItemSupplierMapCreation.CustID = drow.CustID;
                        mItemSupplierMapCreation.IsMapped = drow.IsMapped;
                        mItemSupplierMapCreation.DLCustomerVendorDetail = new DLCustomerVendorDetailCreation();
                       // mItemSupplierMapCreation.DLCustomerVendorDetail.Name= drow.tblCustomerVendorDetail.Name;
                        lstItemSupplierMapCreation.Add(mItemSupplierMapCreation);
                    }

                    if (!string.IsNullOrEmpty(SearchValue))
                        lstItemSupplierMapCreation = lstItemSupplierMapCreation.Where(c => c.ItemName.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim())).ToList();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return lstItemSupplierMapCreation;
        }
        public object GetDataSingleRow(object Context)
        {
            lstItemSupplierMapCreation = new List<DLItemSupplierMapCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed


                    var drow = from gItemsupplier in Entities.tblItemSupplierMappings.AsNoTracking().ToList()
                               select gItemsupplier;
                    {
                        mItemSupplierMapCreation = new DLItemSupplierMapCreation();

                        lstItemSupplierMapCreation.Add(mItemSupplierMapCreation);
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return lstItemSupplierMapCreation;
        }

        private object SaveData(object Context)
        {

            lstItemSupplierMapCreation = ((List<DLItemSupplierMapCreation>)Context);
            try
            {
                foreach (DLItemSupplierMapCreation mItemSupplierMapping in lstItemSupplierMapCreation)
                {

                    using (Entities = new Entity.MWBTCustomerAppEntities())
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                //lItemSupplierMapping.ItemSupMappingID = WBT.Common.Helper.GetUniqueNumber;
                                lItemSupplierMapping.ItemCode = mItemSupplierMapping.ItemCode;
                                lItemSupplierMapping.CustID = mItemSupplierMapping.CustID;
                                //lItemSupplierMapping.CreatedByID = Common.User.UserID;
                                lItemSupplierMapping.CreatedDate = DateTime.Now;
                                lItemSupplierMapping.ModifiedDate = DateTime.Now;
                                lItemSupplierMapping.IsMapped = true;

                                Entities.tblItemSupplierMappings.Add(lItemSupplierMapping);

                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                this.GetApplicationActivate.GetErrormessages = ex.Message;
                                this.GetApplicationActivate.GetErrorSource = ex.Source;
                                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return this.GetApplicationActivate;
        }
    }
}
