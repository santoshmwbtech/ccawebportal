using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WBT.Common;
using WBT.Entity;
using WBT.DLCustomerCreation.Reports;
using System.Linq.Expressions;
using System.Data.Entity;

using WBT.DLCustomerCreation;
using WBT.DL.Transaction;
using static WBT.DL.Master.DLItemWarehouseMap;
using System.Globalization;

namespace WBT.DLCustomerCreation
{

    //public class DLGetAllSOBindData
    //{
    //    public List<DLBranchList> DLBranchList { get; set; } = new List<DLBranchList>();
    //    public List<DLBusinessTypes> DLBusinessTypes { get; set; } = new List<DLBusinessTypes>();
    //    public List<DLCreditTypes> DLCreditTypes { get; set; } = new List<DLCreditTypes>();
    //    public List<DLSalesmanList> DLSalesPersonList { get; set; } = new List<DLSalesmanList>();
    //    public List<DLSalesmanList> DLBrokerList { get; set; } = new List<DLSalesmanList>();
    //    public List<DLVoucherTypes> DLVoucherTypesList { get; set; } = new List<DLVoucherTypes>();
    //}

    public class SalesOrders
    {
        public int ID { get; set; }
        public string SalesOrderNumber { get; set; }
        public string SalesDateTime { get; set; }
        public string OrgID { get; set; }
        public string CustID { get; set; }
        //public Nullable<int> SalesmanID { get; set; }
        public string SalesType { get; set; }
        public string Status { get; set; }
        public string FirmName { get; set; }
        public string BranchID { get; set; }
        public int[] BranchList { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int[] salesmanList { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string caddress { get; set; }
        public string cstate { get; set; }
        public string ccity { get; set; }
        public string cdistrict { get; set; }
        //public string salesmanName { get; set; }
        public string UserID { get; set; }
        public int createdByID { get; set; }
        public string BranchName { get; set; }
        //public string ItemCode { get; set; }
        //public string ItemName { get; set; }
        //public string BagQty { get; set; }
        //public decimal value { get; set; }
        //public List<DLSalesOrderWithItemCreation> ItemsList { get; set; }

        //public string SalesOrderWithItemID { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string VoucherTypeID { get; set; }
        //public int UserID { get; set; }
        public string SearchText { get; set; }
        public string CashRegistrationType { get; set; }
        public string OrderNumberCustName { get; set; }
        //public int ID { get; set; }
        public string OrgName { get; set; }
        //public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        //public string SalesDatetime { get; set; }
        //public string CustID { get; set; }
        public int? SalesmanID { get; set; }
        public string SignatureImage { get; set; }
        public bool TallySync { get; set; }
        public bool IsTallyUpdated { get; set; }
        public decimal TotalItemCount { get; set; }
        public decimal TotalValue { get; set; }
        public string TransType { get; set; }
        public string Comments { get; set; }
        //public int CreatedByID { get; set; }
        public DateTime CreationDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? RSalesDatetime { get; set; }
        public string Location { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public string ReferenceNumber { get; set; }
        //public string Status { get; set; }
        public string ShippingAdddress { get; set; }
        public string URDNumber { get; set; }
        public string ApprovalStatus { get; set; }
        public string RejectionRemark { get; set; }
        public Nullable<bool> IsDelivaryNote { get; set; }
        public Nullable<bool> IsGatePassEntered { get; set; }
        public Nullable<bool> IsActive { get; set; }
        //public string BranchID { get; set; }
        public string RegistrationType { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<bool> IsDirectSale { get; set; }
        public string TallyStatus { get; set; }
        public virtual DLCustomerVendorDetailCreation DLCustomerVendorDetail { get; set; }

        //public List<SalesOrderItemWarehouseMapResult> SalesOrderItemWarehouseMapResult { get; set; } // Need to chk
        public Nullable<DateTime> SalesDateInDateFormat { get; set; }
        //public string CustomerName { get; set; }
        //public string ItemCode { get; set; }
        //public string ItemName { get; set; }
        public decimal TotalQTY { get; set; }
        public Nullable<bool> IsCreditLimitExceeded { get; set; }
        public Nullable<bool> IsCreditDaysExceeded { get; set; }
        public Nullable<bool> IsBillsExceeded { get; set; }
        public bool IsSelected { get; set; } // Created for GP screen order selection
        public string SourceOfUpdate { get; set; }
        public Nullable<bool> IsBulkSale { get; set; }
        //public string SalesType { get; set; }
        public string PANNumber { get; set; }

        public string CmpCity { get; set; }
        //public string OrgID { get; set; }
        public Nullable<bool> IsDiscountRangeExceeded { get; set; }
        public Nullable<decimal> DiscountAmt { get; set; }
        public Nullable<bool> IsDirectSO { get; set; }

        public bool SOSelected { get; set; }//Added for Multiso selection  for SO on 12032021
        public string SOWarehouseID { get; set; }//Added for Multiso selection  for SO on 12032021
        public string SOOrgID { get; set; }//Added for Multiso selection  for SO on 12032021
        public string SOBranchID { get; set; }//Added for Multiso selection  for SO on 12032021

        #region used for so dashboard 8/1/2020
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AvgBillAmount { get; set; }
        public DateTime VisitedDate { get; set; }
        public int Quantity { get; set; }
        public DateTime FinancialYearStart { get; set; }
        public Nullable<System.DateTime> FinancialYearEnd { get; set; }
        #endregion

        #region DEVIKA
        //added on 17 aug
        public int? dcid { get; set; }
        public string RequisitionNumber { get; set; }
        public string ConvertToPO { get; set; }
        public string ViewSO { get; set; }
        //public string BranchName { get; set; }
        public string emailID { get; set; }
        public string SalesmanName { get; set; }

        #endregion

        public string BusinessTypeName { get; set; }
        public Nullable<int> BusinessTypeId { get; set; }
        public Nullable<decimal> BusinessTypeValue { get; set; }
        public Nullable<int> CreditTypeId { get; set; }
        public Nullable<decimal> CreditTypeValue { get; set; }

        //added on 29 AUG Devika
        public Nullable<int> DeliverycenterID { get; set; }
        public decimal TotalQtyAllocatedItems { get; set; }
        //added on 2 NOV for GST of SO number
        public string GSTPR { get; set; }
        public Nullable<int> BrokerID { get; set; }
        //for print needed added by sneha 5thNov2020
        public string OrgDetails { get; set; }
        //NEEDED FOR PRINT IN 7TH DeC 2020
        public string CmpDeclaration { get; set; }
        public string CmpTermsAndConditions { get; set; }
        public string CmpPANNumber { get; set; }
        public string CmpAccNumber { get; set; }
        public string CmpBankName { get; set; }
        public string CmpIFSCODE { get; set; }
        //public List<ItemNameDetail> itemlist { get; set; }
        public string BillingAddress { get; set; }

        public string VoucherTypeNo { get; set; }
        public string DisplayMessage { get; set; }
        public bool IsChecked { get; set; }
        public string UserName { get; set; }

        public List<DLSalesOrderWithItemCreation> DLSalesOrderWithItemCreations { get; set; }
        public List<DLSalesOrderWithItemCreation> CorrectedList { get; set; }
        public List<SalesOrderItemWarehouseMapResult> SalesOrderItemWarehouseMapResult { get; set; }

        public int[] StateList { get; set; }
        public int[] DistrictList { get; set; }
        public int[] CityList { get; set; }
        public string[] AreaList { get; set; }
        public int[] CustomerTypeList { get; set; }
        public int[] CompanyTypeList { get; set; }
        public int[] TaxationTypeList { get; set; }
        public int? LedgerTypeID { get; set; }

        public int? stateID { get; set; }
        public int? cityID { get; set; }
        public int? districtID { get; set; }
        public string area { get; set; }
        public int? companyTypeID { get; set; }
        public int? customerType { get; set; }

    }

    public class DLSalesOrders
    {
        public MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();

        public List<SalesOrders> SOList = new List<SalesOrders>();

        //private WBT.Entity.tblSalesOrderWithItem lsalesOrderWithItem = new WBT.Entity.tblSalesOrderWithItem();
        //public DLSalesOrders msalesOrders = new DLSalesOrders();

        //public List<SelectListItem> Branches { get; set; }
        //public List<SelectListItem> SalesmnList { get; set; }

        public List<tblSysUser> GetSalesmanList()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblSysUser> salesmanusers = new List<tblSysUser>();
                        salesmanusers = (from d in Entities.tblSysUsers
                                         join
          e in Entities.tblSysRoles on d.RoleID equals e.RoleID
                                         where e.RoleName.ToLower() == "salesman"
                                         select new tblSysUser
                                         {
                                             UserID = d.UserID,
                                             FName = d.FName
                                         }).ToList();

                        return salesmanusers;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        ////public class SalesManList
        ////{
        ////    public string BranchID { get; set; }
        ////    public int SalesmanID { get; set; }
        ////    public string UserName { get; set; }
        ////}

        public List<tblSysUser> GetSalesmanListWithBranch(List<tblSysBranch> BranchList)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblSysUser> salesmanusers = new List<tblSysUser>();

                        if (BranchList != null && BranchList.Count() > 0)
                        {
                            salesmanusers = (from d in Entities.tblSysUsers
                                             join e in Entities.tblSysRoles on d.RoleID equals e.RoleID
                                             join b in BranchList on d.BranchID equals b.BranchID
                                             where e.RoleName.ToLower() == "salesman" && d.BranchID == b.BranchID
                                             select new tblSysUser
                                             {
                                                 BranchID = d.BranchID,
                                                 UserID = d.UserID,
                                                 Username = d.Username
                                             }).Distinct().ToList();
                        }
                        return salesmanusers;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public List<SalesOrders> GetData(string Name = "")
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    if (!string.IsNullOrEmpty(Name))
                    {
                        SOList = (from so in Entities.tblSalesOrders
                                  join
cust in Entities.tblCustomerVendorDetails on so.CustID equals cust.CustID
                                  where so.BranchID.ToLower().Contains(Name)
                                  select new SalesOrders
                                  {
                                      ID = so.ID,
                                      SalesOrderNumber = so.SalesOrderNumber,
                                      FirmName = cust.FirmName,
                                      OrderNumber = so.SalesOrderNumber,
                                      BranchName = Entities.tblSysBranches.Where(r => r.BranchID == so.BranchID).FirstOrDefault().Name,
                                      OrderDate = so.SalesDatetime,

                                  }).OrderByDescending(i => i.ID).ToList();
                    }
                    else
                    {
                        SOList = (from so in Entities.tblSalesOrders
                                  join cust in Entities.tblCustomerVendorDetails on so.CustID equals cust.CustID
                                  where so.BranchID.ToLower().Contains(Name)
                                  select new SalesOrders
                                  {
                                      ID = so.ID,
                                      SalesOrderNumber = so.SalesOrderNumber,
                                      FirmName = cust.FirmName,
                                      OrderNumber = so.SalesOrderNumber,
                                      BranchName = Entities.tblSysBranches.Where(r => r.BranchID == so.BranchID).FirstOrDefault().Name,
                                      OrderDate = so.SalesDatetime,
                                  }).OrderByDescending(i => i.ID).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return SOList;
        }

        public List<SalesOrders> GetSOList(SalesOrders search)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    //int TallyUserID = Entities.tblSysUsers.Where(s => s.FName.ToLower() == "tally upload").FirstOrDefault().UserID;
                    //List<tblSysUser> UserList = Entities.tblSysUsers.Where(u => u.RoleID == 3).ToList();

                    List<SalesOrders> soLists = (from so in Entities.tblSalesOrders
                                                 join cust in Entities.tblCustomerVendorDetails on so.CustID equals cust.CustID
                                                 where so.OrgID == search.OrgID
                                                 select new SalesOrders
                                                 {
                                                     CustID = so.CustID,
                                                     OrgID = so.OrgID,
                                                     BranchID = so.BranchID,
                                                     SalesmanID = so.SalesmanID,
                                                     SalesOrderNumber = so.SalesOrderNumber,
                                                     FirmName = cust.FirmName,
                                                     OrderNumber = so.SalesOrderNumber,
                                                     BranchName = Entities.tblSysBranches.Where(r => r.BranchID == so.BranchID).FirstOrDefault().Name,
                                                     OrderDate = so.SalesDatetime,
                                                     createdByID = so.CreatedByID,
                                                     SalesDateTime = so.SalesDatetime,

                                                     CustomerName = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().FirmName,

                                                     stateID = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().StateID,
                                                     cityID = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().CityID,
                                                     districtID = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().DistrictID,
                                                     CreationDate = so.CreationDate,
                                                     companyTypeID = cust.CompanyTypeID,
                                                     customerType = cust.CustomerTypeID,
                                                     area = cust.BillingArea,
                                                     IsTallyUpdated = so.IsTallyUpdated,
                                                     TallyStatus = so.IsTallyUpdated == true ? "Yes" : "No",
                                                     TallySync = so.TallySync == null ? false : so.TallySync.Value
                                                 }).ToList();

                    if (!string.IsNullOrEmpty(search.SalesOrderNumber) && !string.IsNullOrEmpty(search.SalesOrderNumber))
                    {
                        soLists = soLists.Where(m => m.SalesOrderNumber.ToString().ToLower() == search.SalesOrderNumber.ToLower()).ToList();
                    }

                    if (!string.IsNullOrEmpty(search.CustomerName) && !string.IsNullOrEmpty(search.CustomerName))
                    {
                        soLists = soLists.Where(m => m.CustomerName == search.CustomerName).ToList();
                    }

                    if (search.BranchList != null && search.BranchList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.BranchList.Contains(Convert.ToInt32(m.BranchID))).ToList();
                    }

                    if (search.salesmanList != null && search.salesmanList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.salesmanList.Contains(Convert.ToInt32(m.SalesmanID))).ToList();
                    }


                    if (search.StateList != null && search.StateList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.StateList.Contains(Convert.ToInt32(m.stateID))).ToList();
                    }

                    if (search.DistrictList != null && search.DistrictList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.DistrictList.Contains(Convert.ToInt32(m.districtID))).ToList();
                    }

                    if (search.CityList != null && search.CityList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.CityList.Contains(Convert.ToInt32(m.cityID))).ToList();
                    }

                    if (search.CompanyTypeList != null && search.CompanyTypeList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.CompanyTypeList.Contains(Convert.ToInt32(m.companyTypeID))).ToList();
                    }

                    if (search.CustomerTypeList != null && search.CustomerTypeList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.CustomerTypeList.Contains(Convert.ToInt32(m.customerType))).ToList();
                    }

                    if (search.AreaList != null && search.AreaList.Count() > 0)
                    {
                        soLists = soLists.Where(m => search.AreaList.Contains(m.area)).ToList();
                    }

                    #region date filter
                    if (!string.IsNullOrEmpty(search.FromDate) && !string.IsNullOrEmpty(search.ToDate))
                    {
                        DateTime FromDateTime = Convert.ToDateTime(search.FromDate);
                        DateTime ToDateTime = Convert.ToDateTime(search.ToDate);

                        //created list
                        soLists = soLists.Where(c => Convert.ToDateTime(c.SalesDateTime.ToString()).Date >= FromDateTime.Date && Convert.ToDateTime(c.SalesDateTime.ToString()).Date <= ToDateTime.Date).ToList(); //"yyyy-MM-dd"                        
                    }
                    #endregion
                    soLists = soLists.OrderByDescending(so => so.CreationDate).ToList();
                    return soLists;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<SalesOrders> GetSOListForTally(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<SalesOrders> soLists = (from so in Entities.tblSalesOrders
                                                 join cust in Entities.tblCustomerVendorDetails on so.CustID equals cust.CustID
                                                 where so.OrgID == OrgID && so.TallySync == true && so.IsTallyUpdated == false
                                                 select new SalesOrders
                                                 {
                                                     CustID = so.CustID,
                                                     OrgID = so.OrgID,
                                                     BranchID = so.BranchID,
                                                     SalesmanID = so.SalesmanID,
                                                     SalesOrderNumber = so.SalesOrderNumber,
                                                     FirmName = cust.FirmName,
                                                     OrderNumber = so.SalesOrderNumber,
                                                     BranchName = so.BranchID == null ? string.Empty : Entities.tblSysBranches.Where(r => r.BranchID == so.BranchID).FirstOrDefault().Name,
                                                     OrderDate = so.SalesDatetime,
                                                     createdByID = so.CreatedByID,
                                                     SalesDateTime = so.SalesDatetime,
                                                     CustomerName = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().FirmName,
                                                     stateID = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().StateID,
                                                     cityID = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().CityID,
                                                     districtID = Entities.tblCustomerVendorDetails.Where(r => r.CustID == so.CustID).FirstOrDefault().DistrictID,
                                                     CreationDate = so.CreationDate,
                                                     companyTypeID = cust.CompanyTypeID,
                                                     customerType = cust.CustomerTypeID,
                                                     area = cust.BillingArea,
                                                     IsTallyUpdated = so.IsTallyUpdated,
                                                     TallyStatus = so.IsTallyUpdated == true ? "Yes" : "No",
                                                     TallySync = so.TallySync == null ? false : so.TallySync.Value,
                                                     UserName = so.ModifiedByID == null ? "Admin" : Entities.tblSysUsers.Where(c => c.UserID == so.ModifiedByID).FirstOrDefault().FName,
                                                     UserID = so.ModifiedByID.Value.ToString(),
                                                     TransType = so.TransType,
                                                     DLSalesOrderWithItemCreations = so.tblSalesOrderWithItems
                                               .Select(i => new DLSalesOrderWithItemCreation()
                                               {
                                                   SalesOrderNumber = i.SalesOrderNumber,
                                                   BagQTY = i.BagQTY,
                                                   TotalQTY = i.TotalQTY,
                                                   Rate = i.Rate,
                                                   Value = i.Value,
                                                   DiscountPercentage = i.DiscountPercentage,
                                                   ItemName = i.tblItem.ItemName,
                                                   ItemCode = i.ItemCode,
                                               }).ToList(),
                                                     DLCustomerVendorDetail = new DLCustomerVendorDetailCreation()
                                                     {
                                                         CustID = so.tblCustomerVendorDetail.CustID,
                                                         FirmName = so.tblCustomerVendorDetail.FirmName,
                                                         GSTNumber = so.tblCustomerVendorDetail.TINNumber,
                                                         BillingAddress = so.tblCustomerVendorDetail.BillingAddress,
                                                         ShippingAddress = so.tblCustomerVendorDetail.ShippingAddress,
                                                         BillingCity = so.tblCustomerVendorDetail.BillingCity,
                                                         ShippingCity = so.tblCustomerVendorDetail.ShippingCity,
                                                         BillingState = so.tblCustomerVendorDetail.BillingState,
                                                         ShippingState = so.tblCustomerVendorDetail.ShippingState,
                                                         BillingPincode = so.tblCustomerVendorDetail.BillingPincode,
                                                         ShippingPincode = so.tblCustomerVendorDetail.ShippingPincode,
                                                     }
                                                 }).ToList();

                    soLists = soLists.OrderByDescending(so => so.CreationDate).ToList();
                    return soLists;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public SalesOrders GetSalesOrderDetails(string OrderNumber)
        {
            SalesOrders SsalesOrders = new SalesOrders();
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        tblSalesOrder tblsalesorders = Entities.tblSalesOrders.AsNoTracking().Where(c => c.SalesOrderNumber == OrderNumber.Trim()).FirstOrDefault();

                        SsalesOrders.CustID = tblsalesorders.CustID;
                        SsalesOrders.OrderNumber = tblsalesorders.SalesOrderNumber;
                        SsalesOrders.SalesOrderNumber = tblsalesorders.SalesOrderNumber;
                        SsalesOrders.OrgID = tblsalesorders.OrgID;
                        SsalesOrders.BranchID = tblsalesorders.BranchID;
                        SsalesOrders.SalesmanID = tblsalesorders.SalesmanID;
                        SsalesOrders.createdByID = tblsalesorders.CreatedByID;

                        SsalesOrders.IsDirectSO = tblsalesorders.IsDirectSO;
                        SsalesOrders.IsDirectSale = tblsalesorders.IsDirectSale;
                        SsalesOrders.Photo1 = tblsalesorders.Photo1;
                        SsalesOrders.Photo2 = tblsalesorders.Photo2;
                        SsalesOrders.BrokerID = tblsalesorders.BrokerID;
                        SsalesOrders.VoucherTypeNo = tblsalesorders.VoucherTypeNo;
                        SsalesOrders.SignatureImage = tblsalesorders.SignatureImage;
                        SsalesOrders.IsBulkSale = tblsalesorders.IsBulkSale;
                        SsalesOrders.SalesType = tblsalesorders.SalesType;
                        SsalesOrders.IsTallyUpdated = tblsalesorders.IsTallyUpdated;
                        SsalesOrders.Status = tblsalesorders.Status;
                        SsalesOrders.DiscountPercentage = tblsalesorders.DiscountPercentage;
                        SsalesOrders.DiscountAmt = tblsalesorders.DiscountAmt;
                        SsalesOrders.ApprovalStatus = tblsalesorders.ApprovalStatus;
                        SsalesOrders.RegistrationType = tblsalesorders.RegistrationType;
                        SsalesOrders.TransType = tblsalesorders.TransType;
                        SsalesOrders.Comments = tblsalesorders.Comments;
                        SsalesOrders.Location = tblsalesorders.Location;
                        SsalesOrders.PANNumber = tblsalesorders.PANNumber;
                        SsalesOrders.IsActive = tblsalesorders.IsActive;
                        SsalesOrders.IsDelivaryNote = tblsalesorders.IsDelivaryNote;
                        SsalesOrders.URDNumber = tblsalesorders.URDNumber;
                        SsalesOrders.IsGatePassEntered = tblsalesorders.IsGatePassEntered;
                        SsalesOrders.CreditTypeId = tblsalesorders.CreditTypeId;
                        SsalesOrders.BillingAddress = tblsalesorders.BillingAddress;

                        SsalesOrders.BranchName = Entities.tblSysBranches.Where(r => r.BranchID == SsalesOrders.BranchID).FirstOrDefault().Name;
                        SsalesOrders.CustomerName = Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().FirmName;
                        SsalesOrders.MobileNumber = Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().MobileNumber;
                        SsalesOrders.caddress = !string.IsNullOrEmpty(Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingAddress) ? Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingAddress : "NA";
                        SsalesOrders.cstate = !string.IsNullOrEmpty(Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingState) ? Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingState : "NA";
                        SsalesOrders.ccity = !string.IsNullOrEmpty(Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingCity) ? Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingCity : "NA";
                        //SsalesOrders.salesmanName = !string.IsNullOrEmpty(Entities.tblSalesmanDetails.Where(r => r.SalesManID == SsalesOrders.SalesmanID).FirstOrDefault().Fname) ? Entities.tblSalesmanDetails.Where(r => r.SalesManID == SsalesOrders.SalesmanID).FirstOrDefault().Fname : "NA";
                        SsalesOrders.SalesDateTime = tblsalesorders.SalesDatetime;

                        return SsalesOrders;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;

            }
        }

        public SalesOrders GetSalesOrderItems(string OrderNumber)
        {
            SalesOrders SsalesOrders = new SalesOrders();
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        tblSalesOrder tblsalesorders = Entities.tblSalesOrders.AsNoTracking().Where(c => c.SalesOrderNumber == OrderNumber.Trim()).FirstOrDefault();

                        SsalesOrders.CustID = tblsalesorders.CustID;
                        SsalesOrders.OrderNumber = tblsalesorders.SalesOrderNumber;

                        SsalesOrders.SalesOrderNumber = tblsalesorders.SalesOrderNumber;

                        SsalesOrders.OrgID = tblsalesorders.OrgID;
                        SsalesOrders.BranchID = tblsalesorders.BranchID;
                        SsalesOrders.SalesmanID = tblsalesorders.SalesmanID;
                        SsalesOrders.BranchName = Entities.tblSysBranches.Where(r => r.BranchID == SsalesOrders.BranchID).FirstOrDefault().Name;
                        SsalesOrders.CustomerName = Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().FirmName;
                        SsalesOrders.MobileNumber = Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().MobileNumber;
                        SsalesOrders.caddress = !string.IsNullOrEmpty(Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingAddress) ? Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingAddress : "NA";
                        SsalesOrders.cstate = !string.IsNullOrEmpty(Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingState) ? Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingState : "NA";
                        SsalesOrders.ccity = !string.IsNullOrEmpty(Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingCity) ? Entities.tblCustomerVendorDetails.Where(r => r.CustID == SsalesOrders.CustID).FirstOrDefault().ShippingCity : "NA";
                        //SsalesOrders.salesmanName = !string.IsNullOrEmpty(Entities.tblSalesmanDetails.Where(r => r.SalesManID == SsalesOrders.SalesmanID).FirstOrDefault().Fname) ? Entities.tblSalesmanDetails.Where(r => r.SalesManID == SsalesOrders.SalesmanID).FirstOrDefault().Fname : "NA";
                        SsalesOrders.SalesDateTime = tblsalesorders.SalesDatetime;



                        return SsalesOrders;
                    }
                }
            }
            catch (Exception ex)
            {
                //!string.IsNullOrEmpty(tblCustomerVendorDetail.BillingState) ? Entities.tblStates.Where(st => st.StateName.ToLower() == tblCustomerVendorDetail.BillingState.ToLower()).FirstOrDefault().StateID : 0;
                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public bool UpdateTallyStatus(SalesOrders sOrders)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            tblSalesOrder tblSalesOrders = new tblSalesOrder();
                            tblSalesOrders.SalesOrderNumber = sOrders.SalesOrderNumber;
                            tblSalesOrders.ModifiedByID = sOrders.ModifiedByID;
                            tblSalesOrders.UpdateDate = sOrders.ModifiedDate;
                            tblSalesOrders.IsTallyUpdated = false;
                            tblSalesOrders.TallySync = true;
                            tblSalesOrders.TransType = sOrders.TransType;
                            tblSalesOrders.SalesDatetime = sOrders.SalesDateTime;
                            Entities.tblSalesOrders.Attach(tblSalesOrders);
                            Entities.Entry(tblSalesOrders).Property(c => c.ModifiedByID).IsModified = true;
                            Entities.Entry(tblSalesOrders).Property(c => c.UpdateDate).IsModified = true;
                            Entities.Entry(tblSalesOrders).Property(c => c.IsTallyUpdated).IsModified = true;
                            Entities.Entry(tblSalesOrders).Property(c => c.TallySync).IsModified = true;
                            Entities.SaveChanges();
                            dbcxtransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }

        public bool UpdateTallyStatusFromService(SalesOrders sOrders)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            tblSalesOrder tblSalesOrders = new tblSalesOrder();
                            tblSalesOrders.SalesOrderNumber = sOrders.SalesOrderNumber;
                            tblSalesOrders.ModifiedByID = sOrders.ModifiedByID;
                            tblSalesOrders.UpdateDate = sOrders.ModifiedDate;
                            tblSalesOrders.IsTallyUpdated = true;
                            tblSalesOrders.TallySync = false;
                            tblSalesOrders.TransType = sOrders.TransType;
                            tblSalesOrders.SalesDatetime = sOrders.SalesDateTime;
                            Entities.tblSalesOrders.Attach(tblSalesOrders);
                            Entities.Entry(tblSalesOrders).Property(c => c.ModifiedByID).IsModified = true;
                            Entities.Entry(tblSalesOrders).Property(c => c.UpdateDate).IsModified = true;
                            Entities.Entry(tblSalesOrders).Property(c => c.IsTallyUpdated).IsModified = true;
                            Entities.Entry(tblSalesOrders).Property(c => c.TallySync).IsModified = true;
                            Entities.SaveChanges();
                            dbcxtransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }

        //public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        //DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

        //public bool UpdateSalesOrders(DLSalesOrders salesOrders)
        //{          
        //    DLSalesOrders msalesOrders = new DLSalesOrders();
        //    try
        //    {
        //        using (Entities = new MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();                    
        //            using (var dbcxtransaction = Entities.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    //var updateContacts = from x in obj.Contacts
        //                    //                     where x.ContactID == ContactID && x.SecondColumn == SecondValue
        //                    //                     select x;
        //                    //// now use First or a loop if you expect multiple
        //                    //foreach (var contact in updateContacts)
        //                    //    contact.ContactName = ContactName;
        //                    //obj.SubmitChanges();
        //                    tblSalesOrderWithItem obj = new tblSalesOrderWithItem();
        //                    obj.ItemCode = salesOrders.ItemCode;                            
        //                    obj.SalesOrderNumber = salesOrders.SalesOrderNumber;
        //                    obj.BagQTY = salesOrders.BagQty;
        //                    obj.Value = salesOrders.value;
        //                    Entities.tblSalesOrderWithItems.Attach(obj);
        //                    //Entities.Entry(obj).Property(x => x.Password).IsModified = true;
        //                    Entities.SaveChanges();
        //                    dbcxtransaction.Commit();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    dbcxtransaction.Rollback();
        //                    Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
        //        return false;
        //    }
        //}

        private SalesOrders mSalesOrder = new SalesOrders();
        private tblSalesOrder lSalesOrder = new tblSalesOrder();
        public SalesOrders updateSalesOrder(SalesOrders salesOders)
        {
            mSalesOrder = ((SalesOrders)salesOders);
            try
            {

                var IsValueexists = (from so in Entities.tblSalesOrders.AsNoTracking()
                                     where so.SalesOrderNumber.ToLower().Trim().Equals(mSalesOrder.SalesOrderNumber.ToLower().Trim())
                                      && so.ID != mSalesOrder.ID && so.IsActive == true
                                     select so.SalesOrderNumber).FirstOrDefault();

                if (IsValueexists != null && IsValueexists.Count() != 0)
                {
                    //this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                }
                else
                {
                    lSalesOrder = (from so in Entities.tblSalesOrders.AsNoTracking()
                                   where so.SalesOrderNumber.ToLower().Trim() == mSalesOrder.SalesOrderNumber.ToLower().Trim()
                                   select so).FirstOrDefault();

                    if (lSalesOrder != null)
                    {
                        using (Entities = new Entity.MWBTCustomerAppEntities())
                        {
                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    #region SalesOrder
                                    lSalesOrder.VoucherTypeNo = mSalesOrder.VoucherTypeID;
                                    lSalesOrder.BrokerID = mSalesOrder.BrokerID;
                                    lSalesOrder.ModifiedByID = mSalesOrder.ModifiedByID;
                                    lSalesOrder.TotalItemCount = mSalesOrder.DLSalesOrderWithItemCreations.Count;

                                    lSalesOrder.UpdateDate = Common.Helper.GetCurrentDate;
                                    lSalesOrder.DueDate = mSalesOrder.DueDate;
                                    lSalesOrder.Status = mSalesOrder.Status;
                                    lSalesOrder.SalesType = mSalesOrder.SalesType;
                                    lSalesOrder.IsBulkSale = mSalesOrder.IsBulkSale;
                                    lSalesOrder.PANNumber = mSalesOrder.PANNumber;
                                    lSalesOrder.DiscountAmt = mSalesOrder.DiscountAmt;
                                    lSalesOrder.DiscountPercentage = mSalesOrder.DiscountPercentage;
                                    lSalesOrder.IsDiscountRangeExceeded = mSalesOrder.IsDiscountRangeExceeded;
                                    lSalesOrder.BusinessTypeId = mSalesOrder.BusinessTypeId;
                                    lSalesOrder.BusinessTypeValue = mSalesOrder.BusinessTypeValue;
                                    lSalesOrder.CreditTypeValue = mSalesOrder.CreditTypeValue;
                                    lSalesOrder.CreditTypeId = mSalesOrder.CreditTypeId;
                                    lSalesOrder.BillingAddress = mSalesOrder.ShippingAdddress;
                                    lSalesOrder.BranchID = lSalesOrder.BranchID;


                                    #endregion

                                    #region Edit Credit/cash Customer Shipping Address 12/12/2019
                                    if (mSalesOrder.DLCustomerVendorDetail != null)
                                    {
                                        tblCustomerVendorDetail customer = Entities.tblCustomerVendorDetails.Where(i => i.CustID == mSalesOrder.CustID).FirstOrDefault();
                                        customer.ShippingAddress = mSalesOrder.DLCustomerVendorDetail.ShippingAddress;
                                        Entities.tblCustomerVendorDetails.Attach(customer);
                                        Entities.Entry(customer).State = EntityState.Modified;
                                    }
                                    #endregion

                                    #region LineItem
                                    foreach (DLSalesOrderWithItemCreation item in mSalesOrder.DLSalesOrderWithItemCreations)
                                    {
                                        item.ModifiedByID = mSalesOrder.ModifiedByID;// Convert.ToInt32(UserID);
                                        item.CreatedByID = mSalesOrder.createdByID;
                                        item.SalesOrderNumber = mSalesOrder.SalesOrderNumber;

                                        //List<SalesOrderItemWarehouseMapResult> SalesOrderItemWarehouseMapForCurrentLineItem = mSalesOrder.SalesOrderItemWarehouseMapResult.Where(salesOrderItemWarehouseMap => salesOrderItemWarehouseMap.ItemCode == item.ItemCode && salesOrderItemWarehouseMap.LineItemID == item.SalesOrderWithItemID).ToList<SalesOrderItemWarehouseMapResult>(); //&& salesOrderItemWarehouseMap.LineItemID == item.SalesOrderWithItemID
                                        //item.SalesOrderItemWarehouseMaps = new List<DLSalesOrderItemWarehouseMapCreation>();

                                        //foreach (SalesOrderItemWarehouseMapResult s in SalesOrderItemWarehouseMapForCurrentLineItem)
                                        //{
                                        //    DLSalesOrderItemWarehouseMapCreation warehouseMap = new DLSalesOrderItemWarehouseMapCreation()
                                        //    {
                                        //        ID = s.ID,
                                        //        ItemCode = s.ItemCode,
                                        //        QuantityOrdered = s.Quantity,
                                        //        TotalLinItemQuantity = s.QuantityAvailable,
                                        //        SalesOrderNumber = item.SalesOrderNumber,
                                        //        WarehouseID = s.WarehouseID,
                                        //        ModifiedByID = item.ModifiedByID,
                                        //        CreatedByID = item.CreatedByID,
                                        //        UpdateDate = DateTime.Now,
                                        //        SalesOrderWithItemID = item.SalesOrderWithItemID,
                                        //        IsNegativeStock = s.IsNegativeStock,  // s.Quantity > s.QuantityAvailable,
                                        //        IsFIFOSkipped = s.IsFiFOSkipped,   //26_12_2019
                                        //        BatchID = s.BatchID,
                                        //        OrgID = s.OrgID
                                        //    };
                                        //    item.SalesOrderItemWarehouseMaps.Add(warehouseMap);
                                        //}


                                        //////Get Line Item from DB
                                        //////If only QTY changed
                                        var SOLWithOldQTY = Entities.tblSalesOrderWithItems.AsNoTracking()
                                                   .Where(e => e.SalesOrderWithItemID == item.SalesOrderWithItemID && e.ItemCode == item.ItemCode).FirstOrDefault();
                                        //If ItemCode has changed
                                        var SOLWithOldItemCode = Entities.tblSalesOrderWithItems.AsNoTracking()
                                                   .Where(e => e.SalesOrderWithItemID == item.SalesOrderWithItemID && e.ItemCode != item.ItemCode).FirstOrDefault();

                                        #region If in existing QTY Changed
                                        if (SOLWithOldQTY != null)
                                        {
                                            //SOLWithOldQTY.tblSalesOrderItemWarehouseMaps = new List<tblSalesOrderItemWarehouseMap>();
                                            //SOLWithOldQTY.BagQTY = 
                                            //Increase/Decrease/Add entries to tblSalesOrderItemWarehouseMaps
                                            //AdjustStockDetail(item, SOLWithOldQTY);
                                            //Update Line Item i.e.. tblsalesorderwithitem
                                            UpdateLineItem(item, SOLWithOldQTY);
                                        }
                                        #endregion
                                        #region If existing ItemCodeChanged
                                        if (SOLWithOldItemCode != null)
                                        {
                                            //if (item.SalesOrderItemWarehouseMaps != null && SOLWithOldItemCode.tblSalesOrderItemWarehouseMaps.Count > 0)
                                            //{
                                            //Delete the SalesOrderItemWarehouseMap  entries for the old item code
                                            //DeleteWarehouseMapForOldLineItem(SOLWithOldItemCode);
                                            //Insert the SalesOrderItemWarehouseMap  entries for the new item code
                                            //AddWarehouseMapForUpdatedLineItem(item);
                                            //}
                                            //Update Line Item related data for the old Record
                                            //UpdateLineItem(item, SOLWithOldItemCode);
                                        }
                                        #endregion
                                        #region If new LineItemAdded
                                        else if (SOLWithOldQTY == null && SOLWithOldItemCode == null)
                                        {
                                            //Insert the records to the Table
                                            //tblSalesOrderWithItem lineItem = CreateSalesOrderLineItemAndUpdateStock(item);
                                            //Add to SalesOrderWithItems so that it will be saved to DB
                                            //Entities.tblSalesOrderWithItems.Add(lineItem);
                                        }
                                        #endregion
                                    }
                                    #endregion
                                    Entities.Entry(lSalesOrder).State = EntityState.Modified;
                                    Entities.SaveChanges();
                                    dbcxtransaction.Commit();
                                    //this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                }
                                catch (Exception ex)
                                {
                                    dbcxtransaction.Rollback();
                                    //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                    //this.GetApplicationActivate.GetErrormessages = ex.Message;
                                    //this.GetApplicationActivate.GetErrorSource = ex.Source;
                                    //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                    throw;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return new SalesOrders();
        }

        //private tblSalesOrderWithItem CreateSalesOrderLineItemAndUpdateStock(DLSalesOrderWithItemCreation item)
        //{
        //    tblSalesOrderWithItem lineItem = new tblSalesOrderWithItem
        //    {
        //        SalesOrderWithItemID = item.SalesOrderWithItemID,
        //        ItemCode = item.ItemCode,
        //        IsTallyUpdated = item.IsTallyUpdated,
        //        BagQTY = item.BagQTY,
        //        Rate = item.Rate,
        //        SalesOrderNumber = item.SalesOrderNumber,
        //        CreationDate = Common.Helper.GetCurrentDate,
        //        CreatedByID = item.CreatedByID,
        //        UpdateDate = Common.Helper.GetCurrentDate,
        //        TotalQTY = item.TotalQTY,
        //        Value = item.Value,
        //        DiscountPercentage = item.DiscountPercentage,
        //        IsDiscountRangeExceeded = item.IsDiscountRangeExceeded,
        //        ModifiedByID = item.ModifiedByID,
        //        FrieghtCharge = item.FrieghtCharge,
        //        LoadingUnloadingCharge = item.LoadingUnloadingCharge,
        //        OtherExpense = item.OtherExpense,
        //        IsRateInQuantls = item.IsRateInQuantls
        //    };
        //    if (mSalesOrder.SalesOrderItemWarehouseMapResult == null)
        //    {
        //        return lineItem;
        //    }
        //    List<SalesOrderItemWarehouseMapResult> SalesOrderItemWarehouseMapForCurrentLineItem = mSalesOrder.SalesOrderItemWarehouseMapResult.Where(salesOrderItemWarehouseMap => salesOrderItemWarehouseMap.ItemCode == lineItem.ItemCode && salesOrderItemWarehouseMap.LineItemID == lineItem.SalesOrderWithItemID).ToList<SalesOrderItemWarehouseMapResult>();
        //    item.SalesOrderItemWarehouseMaps = new List<DLSalesOrderItemWarehouseMapCreation>();
        //    foreach (SalesOrderItemWarehouseMapResult s in SalesOrderItemWarehouseMapForCurrentLineItem)
        //    {
        //        DLSalesOrderItemWarehouseMapCreation warehouseMap = new DLSalesOrderItemWarehouseMapCreation()
        //        {
        //            ID = s.ID,
        //            ItemCode = s.ItemCode,
        //            QuantityOrdered = s.IsPrimaryWarehouse == true ? s.Quantity : (s.IsNegativeStock == true ? s.NegativestockQty : s.Quantity), //to take negative qty
        //            TotalLinItemQuantity = s.QuantityAvailable,
        //            SalesOrderNumber = lineItem.SalesOrderNumber,
        //            WarehouseID = s.WarehouseID,
        //            CreatedByID = lineItem.CreatedByID,
        //            CreationDate = Common.Helper.GetCurrentDate,
        //            ModifiedByID = lineItem.ModifiedByID.Value,
        //            UpdateDate = lineItem.UpdateDate,
        //            SalesOrderWithItemID = lineItem.SalesOrderWithItemID,
        //            IsNegativeStock = s.IsNegativeStock,    // s.Quantity > s.QuantityAvailable,
        //            IsFIFOSkipped = s.IsFiFOSkipped,
        //            BatchID = s.BatchID,
        //            OrgID = s.OrgID,
        //        };
        //        item.SalesOrderItemWarehouseMaps.Add(warehouseMap);
        //    }

        //    foreach (DLSalesOrderItemWarehouseMapCreation w2 in item.SalesOrderItemWarehouseMaps)
        //    {
        //        //Insert the entries to the Line Item which will be saved to the table 
        //        tblSalesOrderItemWarehouseMap wm = createLineItemWarehouseMap(w2);
        //        lineItem.tblSalesOrderItemWarehouseMaps.Add(wm);

        //        //Increment SaleQuantity
        //        //var stock = Entities.ItemWarehouseMaps.AsNoTracking()
        //        //           .Where(e => e.WarehouseID == w2.WarehouseID
        //        //            && e.BatchID == w2.BatchID
        //        //            && e.ItemCode == w2.ItemCode
        //        //            && e.OrgID == w2.OrgID).FirstOrDefault();
        //        //if (stock != null)
        //        //{
        //        //    if (stock.SaleQuantity != null)
        //        //        stock.SaleQuantity = stock.SaleQuantity.Value + w2.QuantityOrdered;
        //        //    else
        //        //        stock.SaleQuantity = w2.QuantityOrdered;
        //        //    stock.ModifiedDate = DateTime.Now;
        //        //    stock.UserID = mSalesOrder.UserID;
        //        //    // Entities.ItemWarehouseMaps.Attach(stock);
        //        //    Entities.Entry(stock).State = EntityState.Modified;
        //        //}
        //    }
        //    return lineItem;
        //}

        //private void AdjustStockDetail(DLSalesOrderWithItemCreation updatedLineItem, tblSalesOrderWithItem oldLineItem)
        //{
        //    if (updatedLineItem.SalesOrderItemWarehouseMaps != null && updatedLineItem.SalesOrderItemWarehouseMaps.Count > 0)
        //    {
        //        foreach (DLSalesOrderItemWarehouseMapCreation warehouseMapCreation in updatedLineItem.SalesOrderItemWarehouseMaps)
        //        {
        //            var SOItemWarehouseMapFromDB = Entities.tblSalesOrderItemWarehouseMaps.AsNoTracking()
        //                .Where(e => (e.WarehouseID == warehouseMapCreation.WarehouseID
        //               && e.BatchID == warehouseMapCreation.BatchID
        //               && e.ItemCode == warehouseMapCreation.ItemCode
        //               && e.SalesOrderWithItemID == warehouseMapCreation.SalesOrderWithItemID
        //               && e.OrgID == warehouseMapCreation.OrgID)
        //                || e.ID == warehouseMapCreation.ID).FirstOrDefault();  //23/12/2019 bc of this cudnt edit

        //            ////If the record already exists in the SalesOrderItemWarehouseMap table
        //            if (SOItemWarehouseMapFromDB != null)
        //            {
        //                //to delete roq if edit existing to 0 qty
        //                if (warehouseMapCreation.QuantityOrdered == 0)  //26_12_2019 so as to remove old entry from table during edit
        //                    DeleteWarehouseMapDuringEdit(SOItemWarehouseMapFromDB);
        //                else
        //                {
        //                    //not editing qty 21stSep2020 by sneha
        //                    //     SalesOrderItemWarehouseMap oldData = oldLineItem.tblSalesOrderItemWarehouseMaps
        //                    //         .Where(e => (e.WarehouseID == warehouseMapCreation.WarehouseID
        //                    //&& e.BatchID == warehouseMapCreation.BatchID
        //                    //&& e.ItemCode == warehouseMapCreation.ItemCode
        //                    //&& e.SalesOrderWithItemID == warehouseMapCreation.SalesOrderWithItemID
        //                    //&& e.OrgID == warehouseMapCreation.OrgID)
        //                    // || e.ID == warehouseMapCreation.ID).FirstOrDefault();
        //                    UpdateItemWarehouseMap(warehouseMapCreation, SOItemWarehouseMapFromDB);// SOItemWarehouseMapFromDB);
        //                }
        //            }
        //            ////Insert the entries to the Line Item which will be saved to the table 
        //            else
        //            {
        //                tblSalesOrderItemWarehouseMap salesOrderItemWarehouseMap = createLineItemWarehouseMap(warehouseMapCreation);
        //                Entities.tblSalesOrderItemWarehouseMaps.Add(salesOrderItemWarehouseMap);
        //            }
        //        }
        //    }
        //}

        //private void UpdateLineItem(DLSalesOrderWithItemCreation updatedLineItem, tblSalesOrderWithItem oldLineItem)
        //{
        //    oldLineItem.SalesOrderWithItemID = updatedLineItem.SalesOrderWithItemID;
        //    oldLineItem.ItemCode = updatedLineItem.ItemCode;
        //    //oldLineItem.PacketSizeID = updatedLineItem.PacketSizeID;
        //    oldLineItem.BagQTY = updatedLineItem.BagQTY;
        //    oldLineItem.Rate = updatedLineItem.Rate;
        //    oldLineItem.CreatedByID = updatedLineItem.CreatedByID;
        //    oldLineItem.ModifiedByID = updatedLineItem.ModifiedByID;
        //    oldLineItem.UpdateDate = Common.Helper.GetCurrentDate;
        //    oldLineItem.TotalQTY = updatedLineItem.TotalQTY;
        //    oldLineItem.Value = updatedLineItem.Value;
        //    oldLineItem.DiscountPercentage = updatedLineItem.DiscountPercentage;
        //    oldLineItem.IsDiscountRangeExceeded = updatedLineItem.IsDiscountRangeExceeded;
        //    oldLineItem.IsRateInQuantls = updatedLineItem.IsRateInQuantls;
        //    oldLineItem.tblSalesOrderItemWarehouseMaps.Clear();
        //    Entities.Entry(oldLineItem).State = EntityState.Modified;
        //}

        //private void UpdateItemWarehouseMap(DLSalesOrderItemWarehouseMapCreation warehouseMapCreation, tblSalesOrderItemWarehouseMap SOItemWarehouseMapFromDB)
        //{
        //    SOItemWarehouseMapFromDB.IsFIFOSkipped = warehouseMapCreation.IsFIFOSkipped;  //26_12_19
        //    SOItemWarehouseMapFromDB.IsNegativeStock = warehouseMapCreation.IsNegativeStock;
        //    SOItemWarehouseMapFromDB.QuantityOrdered = warehouseMapCreation.QuantityOrdered;
        //    SOItemWarehouseMapFromDB.TotalQuantity = warehouseMapCreation.TotalLinItemQuantity;
        //    SOItemWarehouseMapFromDB.ModifiedByID = warehouseMapCreation.ModifiedByID;
        //    SOItemWarehouseMapFromDB.UpdateDate = warehouseMapCreation.UpdateDate;
        //    SOItemWarehouseMapFromDB.WarehouseID = warehouseMapCreation.WarehouseID;
        //    SOItemWarehouseMapFromDB.BatchID = warehouseMapCreation.BatchID;
        //    //Entities.SalesOrderItemWarehouseMaps.Add(SOItemWarehouseMapFromDB); //21stSep2020
        //    Entities.Entry(SOItemWarehouseMapFromDB).State = EntityState.Modified;
        //}

        //private void AddWarehouseMapForUpdatedLineItem(DLSalesOrderWithItemCreation updatedLineItem)
        //{
        //    foreach (DLSalesOrderItemWarehouseMapCreation warehouseMapCreation in updatedLineItem.SalesOrderItemWarehouseMaps)
        //    {
        //        tblSalesOrderItemWarehouseMap salesOrderItemWarehouseMap = createLineItemWarehouseMap(warehouseMapCreation);
        //        // Reduce Stock for Updated Item
        //        var stock = Entities.tblItemWarehouseMaps.AsNoTracking()
        //                   .Where(e => e.WarehouseID == salesOrderItemWarehouseMap.WarehouseID
        //                    && e.BatchID == salesOrderItemWarehouseMap.BatchID
        //                    && e.ItemCode == salesOrderItemWarehouseMap.ItemCode
        //                    && e.OrgID == salesOrderItemWarehouseMap.OrgID).FirstOrDefault();

        //        if (stock != null)
        //        {
        //            if (stock.SaleQuantity != null)
        //                stock.SaleQuantity = stock.SaleQuantity.Value + salesOrderItemWarehouseMap.QuantityOrdered;
        //            else
        //                stock.SaleQuantity = salesOrderItemWarehouseMap.QuantityOrdered;

        //            stock.ModifiedDate = Common.Helper.GetCurrentDate;
        //            stock.CreatedByID = mSalesOrder.CreatedByID;
        //            Entities.Entry(stock).State = EntityState.Modified;
        //        }
        //        Entities.tblSalesOrderItemWarehouseMaps.Add(salesOrderItemWarehouseMap);
        //    }
        //}

        //private static tblSalesOrderItemWarehouseMap createLineItemWarehouseMap(DLSalesOrderItemWarehouseMapCreation salesOrderItemWarehouseMap)
        //{
        //    return new tblSalesOrderItemWarehouseMap()
        //    {
        //        ItemCode = salesOrderItemWarehouseMap.ItemCode,
        //        IsNegativeStock = salesOrderItemWarehouseMap.IsNegativeStock,
        //        IsFIFOSkipped = salesOrderItemWarehouseMap.IsFIFOSkipped,
        //        SalesOrderNumber = salesOrderItemWarehouseMap.SalesOrderNumber,
        //        SalesOrderWithItemID = salesOrderItemWarehouseMap.SalesOrderWithItemID,
        //        QuantityOrdered = salesOrderItemWarehouseMap.QuantityOrdered,
        //        TotalQuantity = salesOrderItemWarehouseMap.TotalLinItemQuantity,
        //        CreatedByID = salesOrderItemWarehouseMap.CreatedByID,
        //        CreationDate = Common.Helper.GetCurrentDate,
        //        ModifiedByID = salesOrderItemWarehouseMap.ModifiedByID,
        //        UpdateDate = Common.Helper.GetCurrentDate,
        //        WarehouseID = salesOrderItemWarehouseMap.WarehouseID,
        //        BatchID = salesOrderItemWarehouseMap.BatchID,
        //        OrgID = salesOrderItemWarehouseMap.OrgID,
        //    };
        //}

        //private void DeleteWarehouseMapDuringEdit(tblSalesOrderItemWarehouseMap oldLineItem)
        //{

        //    var SOItemWarehouseMapFromDB = Entities.tblSalesOrderItemWarehouseMaps.AsNoTracking()
        //        .Where(e => e.WarehouseID == oldLineItem.WarehouseID
        //       && e.BatchID == oldLineItem.BatchID && e.ItemCode == oldLineItem.ItemCode
        //       && e.ID == oldLineItem.ID).FirstOrDefault();
        //    if (SOItemWarehouseMapFromDB != null)
        //    {
        //        Entities.tblSalesOrderItemWarehouseMaps.Attach(SOItemWarehouseMapFromDB);
        //        Entities.Entry(SOItemWarehouseMapFromDB).State = EntityState.Deleted;
        //    }
        //}
        //private void DeleteWarehouseMapForOldLineItem(tblSalesOrderWithItem oldLineItem)
        //{
        //    foreach (tblSalesOrderItemWarehouseMap w in oldLineItem.tblSalesOrderItemWarehouseMaps)
        //    {
        //        var SOItemWarehouseMapFromDB = Entities.tblSalesOrderItemWarehouseMaps.AsNoTracking()
        //            .Where(e => e.WarehouseID == w.WarehouseID
        //           && e.BatchID == w.BatchID && e.ItemCode == w.ItemCode
        //           && e.ID == w.ID).FirstOrDefault();
        //        if (SOItemWarehouseMapFromDB != null)
        //        {
        //            #region deliveryNoteItem
        //            var deliveryNoteItem = Entities.tblDeliveryNoteItems.AsNoTracking()
        //         .Where(e => e.BatchID == SOItemWarehouseMapFromDB.BatchID && e.ItemCode == SOItemWarehouseMapFromDB.ItemCode
        //         && e.WarehouseID == SOItemWarehouseMapFromDB.WarehouseID
        //         && e.SalesOrderWithItemID == SOItemWarehouseMapFromDB.SalesOrderWithItemID
        //         && e.OrgID == SOItemWarehouseMapFromDB.OrgID).FirstOrDefault();

        //            if (deliveryNoteItem != null)
        //            {
        //                //deliveryNoteItem.IsCorrectionRequired = Convert.ToInt32(CorrectionStatus.CorrectionDone);
        //                //deliveryNoteItem.ItemCode = warehouseMapCreation.ItemCode;
        //                // deliveryNoteItem.UserID = warehouseMapCreation.UserID;
        //                deliveryNoteItem.UpdateDate = Common.Helper.GetCurrentDate;
        //                Entities.tblDeliveryNoteItems.Attach(deliveryNoteItem);
        //                Entities.Entry(deliveryNoteItem).State = EntityState.Modified;
        //            }
        //            #endregion


        //            ////Increment Stock of the Item Which we have changed
        //            var stock = Entities.tblItemWarehouseMaps.AsNoTracking()
        //                       .Where(e => e.WarehouseID == w.WarehouseID
        //                        && e.BatchID == w.BatchID
        //                        && e.ItemCode == w.ItemCode
        //                        && e.OrgID == w.OrgID).FirstOrDefault();

        //            if (stock != null)
        //            {
        //                stock.ModifiedDate = Common.Helper.GetCurrentDate;
        //                stock.CreatedByID = mSalesOrder.CreatedByID;
        //                stock.SaleQuantity = stock.SaleQuantity.Value - w.QuantityOrdered;
        //                Entities.Entry(stock).State = EntityState.Modified;
        //            }
        //            Entities.Entry(SOItemWarehouseMapFromDB).State = EntityState.Deleted;
        //        }
        //    }
        //}

        //private void AdjustStockAndDeliveryNote(DLSalesOrderWithItemCreation updatedLineItem, tblSalesOrderWithItem oldLineItem)
        //{
        //    if (updatedLineItem.SalesOrderItemWarehouseMaps != null && updatedLineItem.SalesOrderItemWarehouseMaps.Count > 0)
        //    {
        //        foreach (DLSalesOrderItemWarehouseMapCreation warehouseMapCreation in updatedLineItem.SalesOrderItemWarehouseMaps)
        //        {
        //            var SOItemWarehouseMapFromDB = Entities.tblSalesOrderItemWarehouseMaps.AsNoTracking()
        //                .Where(e => e.WarehouseID == warehouseMapCreation.WarehouseID
        //               && e.BatchID == warehouseMapCreation.BatchID
        //               && e.ItemCode == warehouseMapCreation.ItemCode
        //               && e.ID == warehouseMapCreation.ID
        //               && e.OrgID == warehouseMapCreation.OrgID).FirstOrDefault();

        //            #region deliveryNoteItem
        //            var deliveryNoteItem = Entities.tblDeliveryNoteItems.AsNoTracking()
        //         .Where(e => e.BatchID == warehouseMapCreation.BatchID && e.ItemCode == warehouseMapCreation.ItemCode
        //         && e.WarehouseID == warehouseMapCreation.WarehouseID
        //         && e.SalesOrderWithItemID == updatedLineItem.SalesOrderWithItemID
        //         && e.OrgID == warehouseMapCreation.OrgID).FirstOrDefault();

        //            if (deliveryNoteItem != null)
        //            {
        //                //deliveryNoteItem.IsCorrectionRequired = Convert.ToInt32(CorrectionStatus.CorrectionDone);
        //                deliveryNoteItem.ItemCode = warehouseMapCreation.ItemCode;
        //                deliveryNoteItem.CreatedByID = warehouseMapCreation.CreatedByID;
        //                deliveryNoteItem.UpdateDate = DateTime.Now;
        //                Entities.tblDeliveryNoteItems.Attach(deliveryNoteItem);
        //                Entities.Entry(deliveryNoteItem).State = EntityState.Modified;
        //            }
        //            #endregion

        //            //If the record already exists in the SalesOrderItemWarehouseMap table
        //            if (SOItemWarehouseMapFromDB != null)
        //            {
        //                #region UpdateStock
        //                //Update Stock if the user has changed the QTY
        //                var stock = Entities.tblItemWarehouseMaps.AsNoTracking()
        //                           .Where(e => e.WarehouseID == warehouseMapCreation.WarehouseID
        //                            && e.BatchID == warehouseMapCreation.BatchID
        //                            && e.ItemCode == warehouseMapCreation.ItemCode
        //                            && e.OrgID == warehouseMapCreation.OrgID).FirstOrDefault();

        //                if (stock != null)
        //                {
        //                    stock.ModifiedDate = DateTime.Now;
        //                    stock.CreatedByID = mSalesOrder.CreatedByID;
        //                    //Reduce SaleQuantity
        //                    if (SOItemWarehouseMapFromDB.QuantityOrdered > warehouseMapCreation.QuantityOrdered)
        //                    {
        //                        stock.SaleQuantity = stock.SaleQuantity.Value - (SOItemWarehouseMapFromDB.QuantityOrdered - warehouseMapCreation.QuantityOrdered);
        //                        stock.ModifiedDate = DateTime.Now;
        //                        stock.CreatedByID = warehouseMapCreation.CreatedByID;
        //                        Entities.tblItemWarehouseMaps.Attach(stock);
        //                        Entities.Entry(stock).State = EntityState.Modified;

        //                        UpdateItemWarehouseMap(warehouseMapCreation, SOItemWarehouseMapFromDB);
        //                    }

        //                    //Increment SaleQuantity
        //                    else if (SOItemWarehouseMapFromDB.QuantityOrdered < warehouseMapCreation.QuantityOrdered)
        //                    {
        //                        stock.SaleQuantity = stock.SaleQuantity.Value + (warehouseMapCreation.QuantityOrdered - SOItemWarehouseMapFromDB.QuantityOrdered);
        //                        stock.ModifiedDate = DateTime.Now;
        //                        stock.CreatedByID = warehouseMapCreation.CreatedByID;
        //                        Entities.tblItemWarehouseMaps.Attach(stock);
        //                        Entities.Entry(stock).State = EntityState.Modified;

        //                        UpdateItemWarehouseMap(warehouseMapCreation, SOItemWarehouseMapFromDB);
        //                    }
        //                }
        //                #endregion

        //            }
        //            //Insert the entries to the Line Item which will be saved to the table 
        //            else
        //            {
        //                tblSalesOrderItemWarehouseMap salesOrderItemWarehouseMap = createLineItemWarehouseMap(warehouseMapCreation);

        //                //Increment SaleQuantity
        //                var stock = Entities.tblItemWarehouseMaps.AsNoTracking()
        //                           .Where(e => e.WarehouseID == salesOrderItemWarehouseMap.WarehouseID
        //                            && e.BatchID == salesOrderItemWarehouseMap.BatchID
        //                            && e.ItemCode == salesOrderItemWarehouseMap.ItemCode
        //                            && e.OrgID == warehouseMapCreation.OrgID).FirstOrDefault();

        //                if (stock != null)
        //                {

        //                    stock.SaleQuantity = stock.SaleQuantity.Value + salesOrderItemWarehouseMap.QuantityOrdered;
        //                    stock.ModifiedDate = DateTime.Now;
        //                    stock.CreatedByID = mSalesOrder.CreatedByID;
        //                    Entities.tblItemWarehouseMaps.Attach(stock);
        //                    Entities.Entry(stock).State = EntityState.Modified;
        //                }
        //                //Save changes to Database
        //                Entities.tblSalesOrderItemWarehouseMaps.Add(salesOrderItemWarehouseMap);
        //            }
        //        }
        //    }
        //}



        //public override object DataActivate(object Context)
        //{
        //    throw new NotImplementedException();
        //}

        private tblCustomerVendorDetail ConstructCustomer(DLCustomerVendorDetailCreation customer)
        {
            return new tblCustomerVendorDetail
            {
                //CustID = "C" + Helper.GetUniqueNumberWithDate,
                FirmName = customer.FirmName,
                ContactpersonName = customer.ContactPersonName,
                MobileNumber = customer.MobileNumber,
                ShippingAddress = customer.ShippingAddress,
                BillingAddress = customer.BillingAddress,
                TINNumber = customer.GSTNumber,
                CreatedByID = customer.CreatedByID.Value,
                CreationDate = Common.Helper.GetCurrentDate,
                ModifiedByID = customer.ModifiedByID,
                UpdatedDate = Common.Helper.GetCurrentDate,
                ApprovalStatus = customer.ApprovalStatus,
                RegistrationType = customer.RegistrationType,
                OrgID = customer.OrgID,
                //BranchID = customer.BranchID,
                //NoofOutstandingBill = customer.NoofOutstandingBill,
                //CrDays = customer.CrDays,
                //CrLimit = customer.CrLament,
                LedgerType = customer.LedgerType,
                IsVendor = false,
                CustomerType = customer.CustomerType,
            };
        }

        //public override object DataActivate(object Context)
        //{
        //    throw new NotImplementedException();
        //}


        private void UpdateLineItem(DLSalesOrderWithItemCreation updatedLineItem, tblSalesOrderWithItem oldLineItem)
        {
            oldLineItem.SalesOrderWithItemID = updatedLineItem.SalesOrderWithItemID;
            oldLineItem.ItemCode = updatedLineItem.ItemCode;
            //oldLineItem.PacketSizeID = updatedLineItem.PacketSizeID;
            //oldLineItem.BagQTY = updatedLineItem.BagQTY;
            oldLineItem.Rate = updatedLineItem.Rate;
            oldLineItem.CreatedByID = updatedLineItem.CreatedByID;
            oldLineItem.ModifiedByID = updatedLineItem.ModifiedByID;
            oldLineItem.UpdateDate = Common.Helper.GetCurrentDate;
            oldLineItem.TotalQTY = updatedLineItem.TotalQTY;
            oldLineItem.Value = updatedLineItem.Value;
            oldLineItem.DiscountPercentage = updatedLineItem.DiscountPercentage;
            oldLineItem.IsDiscountRangeExceeded = updatedLineItem.IsDiscountRangeExceeded;
            oldLineItem.IsRateInQuantls = updatedLineItem.IsRateInQuantls;
            oldLineItem.tblSalesOrderItemWarehouseMaps.Clear();
            Entities.Entry(oldLineItem).State = EntityState.Modified;
        }
    }



    //public class DLVoucherTypes
    //{
    //    public string VoucherID { get; set; }
    //    public string VoucherName { get; set; }
    //    public string OrgID { get; set; }
    //    public string BranchID { get; set; }
    //}

    //public class DLBranchList
    //{
    //    public string BranchID { get; set; }
    //    public string BranchName { get; set; }
    //    public string OrgID { get; set; }
    //}

    //public class DLSalesmanList
    //{
    //    public string BranchID { get; set; }
    //    public string OrgID { get; set; }
    //    public int UserID { get; set; }
    //    public string FName { get; set; }
    //    public string Alias { get; set; }
    //    public int RoleID { get; set; }
    //    public string RoleName { get; set; }
    //    public string Department { get; set; }
    //}

    //public class DLBusinessTypes
    //{
    //    public int BusinessTypeID { get; set; }
    //    public string OrgID { get; set; }
    //    public string BusinessTypeName { get; set; }
    //}

    //public class DLCreditTypes
    //{
    //    public int CreditTypeID { get; set; }
    //    public string CreditTypeName { get; set; }
    //    public string OrgID { get; set; }
    //}

    public class DLGetAllSOBindData
    {
        //public List<DLBranchList> DLBranchList { get; set; } = new List<DLBranchList>();
        //public List<DLBusinessTypes> DLBusinessTypes { get; set; } = new List<DLBusinessTypes>();
        //public List<DLCreditTypes> DLCreditTypes { get; set; } = new List<DLCreditTypes>();
        //public List<DLSalesmanList> DLSalesPersonList { get; set; } = new List<DLSalesmanList>();
        //public List<DLSalesmanList> DLBrokerList { get; set; } = new List<DLSalesmanList>();
        //public List<DLVoucherTypes> DLVoucherTypesList { get; set; } = new List<DLVoucherTypes>();
    }


    //public class DLSalesOrderCreation : DLGetAllSOBindData
    //{
    //    public string Photo1 { get; set; }
    //    public string Photo2 { get; set; }
    //    public string VoucherTypeID { get; set; }
    //    public int UserID { get; set; }
    //    public string SearchText { get; set; }
    //    public string CashRegistrationType { get; set; }
    //    public string OrderNumberCustName { get; set; }
    //    public int ID { get; set; }
    //    public string OrgName { get; set; }
    //    public string SalesOrderNumber { get; set; }
    //    public string PurchaseOrderNumber { get; set; }
    //    public string SalesDatetime { get; set; }
    //    public string CustID { get; set; }
    //    public int? SalesmanID { get; set; }
    //    public string SignatureImage { get; set; }
    //    public bool IsTallyUpdated { get; set; }
    //    public decimal TotalItemCount { get; set; }
    //    public decimal TotalValue { get; set; }
    //    public string TransType { get; set; }
    //    public string Comments { get; set; }
    //    public int CreatedByID { get; set; }
    //    public DateTime CreationDate { get; set; }
    //    public Nullable<int> ModifiedByID { get; set; }
    //    public DateTime ModifiedDate { get; set; }
    //    public DateTime? UpdateDate { get; set; }
    //    public DateTime? RSalesDatetime { get; set; }
    //    public string Location { get; set; }
    //    public DateTime DueDate { get; set; }
    //    public string ReferenceNumber { get; set; }
    //    public string Status { get; set; }
    //    public string ShippingAdddress { get; set; }
    //    public string URDNumber { get; set; }
    //    public string ApprovalStatus { get; set; }
    //    public string RejectionRemark { get; set; }
    //    public Nullable<bool> IsDelivaryNote { get; set; }
    //    public Nullable<bool> IsGatePassEntered { get; set; }
    //    public Nullable<bool> IsActive { get; set; }
    //    public string BranchID { get; set; }
    //    public string RegistrationType { get; set; }
    //    public Nullable<decimal> DiscountPercentage { get; set; }
    //    public Nullable<bool> IsDirectSale { get; set; }
    //    public virtual DLCustomerVendorDetailCreation DLCustomerVendorDetail { get; set; }
    //    public List<DLSalesOrderWithItemCreation> DLSalesOrderWithItemCreations { get; set; }
    //    public List<DLSalesOrderWithItemCreation> CorrectedList { get; set; }
    //    public List<SalesOrderItemWarehouseMapResult> SalesOrderItemWarehouseMapResult { get; set; }
    //    public DateTime SalesDateInDateFormat { get; set; }
    //    public string CustomerName { get; set; }
    //    public string ItemCode { get; set; }
    //    public string ItemName { get; set; }
    //    public decimal TotalQTY { get; set; }
    //    public Nullable<bool> IsCreditLimitExceeded { get; set; }
    //    public Nullable<bool> IsCreditDaysExceeded { get; set; }
    //    public Nullable<bool> IsBillsExceeded { get; set; }
    //    public bool IsSelected { get; set; } // Created for GP screen order selection
    //    public string SourceOfUpdate { get; set; }
    //    public Nullable<bool> IsBulkSale { get; set; }
    //    public string SalesType { get; set; }
    //    public string PANNumber { get; set; }

    //    public string CmpCity { get; set; }
    //    public string OrgID { get; set; }
    //    public Nullable<bool> IsDiscountRangeExceeded { get; set; }
    //    public Nullable<decimal> DiscountAmt { get; set; }
    //    public Nullable<bool> IsDirectSO { get; set; }

    //    public bool SOSelected { get; set; }//Added for Multiso selection  for SO on 12032021
    //    public string SOWarehouseID { get; set; }//Added for Multiso selection  for SO on 12032021
    //    public string SOOrgID { get; set; }//Added for Multiso selection  for SO on 12032021
    //    public string SOBranchID { get; set; }//Added for Multiso selection  for SO on 12032021

    //    #region used for so dashboard 8/1/2020
    //    public int CategoryID { get; set; }
    //    public string CategoryName { get; set; }
    //    public decimal TotalAmount { get; set; }
    //    public decimal AvgBillAmount { get; set; }
    //    public DateTime VisitedDate { get; set; }
    //    public int Quantity { get; set; }
    //    public DateTime FinancialYearStart { get; set; }
    //    public Nullable<System.DateTime> FinancialYearEnd { get; set; }
    //    #endregion

    //    #region DEVIKA
    //    //added on 17 aug
    //    public int? dcid { get; set; }
    //    public string RequisitionNumber { get; set; }
    //    public string ConvertToPO { get; set; }
    //    public string ViewSO { get; set; }
    //    public string BranchName { get; set; }
    //    public string emailID { get; set; }
    //    public string SalesmanName { get; set; }

    //    #endregion

    //    public string BusinessTypeName { get; set; }
    //    public Nullable<int> BusinessTypeId { get; set; }
    //    public Nullable<decimal> BusinessTypeValue { get; set; }
    //    public Nullable<int> CreditTypeId { get; set; }
    //    public Nullable<decimal> CreditTypeValue { get; set; }

    //    //added on 29 AUG Devika
    //    public Nullable<int> DeliverycenterID { get; set; }
    //    public decimal TotalQtyAllocatedItems { get; set; }
    //    //added on 2 NOV for GST of SO number
    //    public string GSTPR { get; set; }
    //    public Nullable<int> BrokerID { get; set; }
    //    //for print needed added by sneha 5thNov2020
    //    public string OrgDetails { get; set; }
    //    //NEEDED FOR PRINT IN 7THDeC2020
    //    public string CmpDeclaration { get; set; }
    //    public string CmpTermsAndConditions { get; set; }
    //    public string CmpPANNumber { get; set; }
    //    public string CmpAccNumber { get; set; }
    //    public string CmpBankName { get; set; }
    //    public string CmpIFSCODE { get; set; }
    //    //public List<ItemNameDetail> itemlist { get; set; }
    //}
}