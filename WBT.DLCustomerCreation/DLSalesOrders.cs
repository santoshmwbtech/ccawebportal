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
using System.Net;
using System.Configuration;
using WBT.Common.Constants;

namespace WBT.DLCustomerCreation
{
    public class SalesOrders
    {
        public int ID { get; set; }
        public string SalesOrderNumber { get; set; }
        public string SalesDateTime { get; set; }
        public string OrgID { get; set; }
        public string CustID { get; set; }
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
        public string UserID { get; set; }
        public int createdByID { get; set; }
        public string BranchName { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string VoucherTypeID { get; set; }
        public string SearchText { get; set; }
        public string CashRegistrationType { get; set; }
        public string OrderNumberCustName { get; set; }
        public string OrgName { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int? SalesmanID { get; set; }
        public string SignatureImage { get; set; }
        public bool TallySync { get; set; }
        public bool IsTallyUpdated { get; set; }
        public decimal TotalItemCount { get; set; }
        public decimal TotalValue { get; set; }
        public string TransType { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? RSalesDatetime { get; set; }
        public string Location { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string ShippingAdddress { get; set; }
        public string URDNumber { get; set; }
        public string ApprovalStatus { get; set; }
        public string RejectionRemark { get; set; }
        public Nullable<bool> IsDelivaryNote { get; set; }
        public Nullable<bool> IsGatePassEntered { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string RegistrationType { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public Nullable<bool> IsDirectSale { get; set; }
        public string TallyStatus { get; set; }
        public virtual DLCustomerVendorDetailCreation DLCustomerVendorDetail { get; set; }
        public Nullable<DateTime> SalesDateInDateFormat { get; set; }
        public decimal TotalQTY { get; set; }
        public Nullable<bool> IsCreditLimitExceeded { get; set; }
        public Nullable<bool> IsCreditDaysExceeded { get; set; }
        public Nullable<bool> IsBillsExceeded { get; set; }
        public bool IsSelected { get; set; }
        public string SourceOfUpdate { get; set; }
        public Nullable<bool> IsBulkSale { get; set; }
        public string PANNumber { get; set; }
        public string CmpCity { get; set; }
        public Nullable<bool> IsDiscountRangeExceeded { get; set; }
        public Nullable<decimal> DiscountAmt { get; set; }
        public Nullable<bool> IsDirectSO { get; set; }
        public bool SOSelected { get; set; }
        public string SOWarehouseID { get; set; }
        public string SOOrgID { get; set; }
        public string SOBranchID { get; set; }

        #region used for so dashboard 8/1/2020
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AvgBillAmount { get; set; }
        public DateTime VisitedDate { get; set; }
        public int Quantity { get; set; }
        public DateTime FinancialYearStart { get; set; }
        public DateTime? FinancialYearEnd { get; set; }
        #endregion

        #region DEVIKA
        public int? dcid { get; set; }
        public string RequisitionNumber { get; set; }
        public string ConvertToPO { get; set; }
        public string ViewSO { get; set; }
        public string emailID { get; set; }
        public string SalesmanName { get; set; }
        #endregion
        public string BusinessTypeName { get; set; }
        public Nullable<int> BusinessTypeId { get; set; }
        public Nullable<decimal> BusinessTypeValue { get; set; }
        public Nullable<int> CreditTypeId { get; set; }
        public Nullable<decimal> CreditTypeValue { get; set; }

        public Nullable<int> DeliverycenterID { get; set; }
        public decimal TotalQtyAllocatedItems { get; set; }
        public string GSTPR { get; set; }
        public decimal? GSTPer { get; set; }
        public Nullable<int> BrokerID { get; set; }
        public string OrgDetails { get; set; }
        public string CmpDeclaration { get; set; }
        public string CmpTermsAndConditions { get; set; }
        public string CmpPANNumber { get; set; }
        public string CmpAccNumber { get; set; }
        public string CmpBankName { get; set; }
        public string CmpIFSCODE { get; set; }
        public string BillingAddress { get; set; }
        public string VoucherTypeNo { get; set; }
        public string DisplayMessage { get; set; }
        public bool IsChecked { get; set; }
        public string UserName { get; set; }

        public List<DLSalesOrderWithItemCreation> DLSalesOrderWithItemCreations { get; set; }
        public List<DLSalesOrderWithItemCreation> CorrectedList { get; set; }
        public List<SalesOrderItemWarehouseMapResult> SalesOrderItemWarehouseMapResult { get; set; }
        public CustomerCreation customerInfo { get; set; }

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
        public bool IsEdited { get; set; }
        public string CustomerState { get; set; }
        public string CompanyState { get; set; }
        public string CompanyCity { get; set; }
        public string PaymentInfo { get; set; }
        public BranchDetails BranchDetails { get; set; }
        public string cpincode { get; set; }
        public bool PriceSyncType { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class DLSalesOrders
    {
        private MWBTCustomerAppEntities Entities;
        private List<SalesOrders> salesOrders;
        public DLSalesOrders()
        {
            Entities = new MWBTCustomerAppEntities();
            salesOrders = new List<SalesOrders>();
        }

        
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
        public List<SalesOrders> GetData(string OrgID, string Name = "")
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();


                    return GetSalesOrders(OrgID, Entities, Name);

                }
            }
            catch (Exception ex)
            {

            }
            return salesOrders;
        }

        private List<SalesOrders> GetSalesOrders(string OrgID, MWBTCustomerAppEntities Entities, string name)
        {
            string query = $"{OrgID}";
            if (!string.IsNullOrEmpty(name))
            {
                query = $"{OrgID} && so.BranchID.ToLower().Contains({name})";
            }

            salesOrders = (from so in Entities.tblSalesOrders
                      join cust in Entities.tblCustomerVendorDetails on so.CustID equals cust.CustID
                      where so.OrgID == query
                      select new SalesOrders
                      {
                          ID = so.ID,
                          SalesOrderNumber = so.SalesOrderNumber,
                          FirmName = cust.FirmName,
                          OrderNumber = so.SalesOrderNumber,
                          BranchName = Entities.tblSysBranches.Where(r => r.BranchID == so.BranchID).FirstOrDefault().Name,
                          OrderDate = so.SalesDatetime,
                          IsTallyUpdated = so.IsTallyUpdated,
                          TallySync = so.TallySync.HasValue ? so.TallySync.Value : false,
                          TallyStatus = so.IsTallyUpdated ? "Synced" : "Pending",
                          TotalAmount = so.tblSalesOrderWithItems.Select(c => c.Value).Sum() - (so.tblSalesOrderWithItems.Select(d => d.DiscountAmt).Sum().HasValue ? so.tblSalesOrderWithItems.Select(d => d.DiscountAmt).Sum().Value : 0),
                          IsEdited = so.IsEdited,
                      }).OrderByDescending(i => i.ID).ToList();
           
            return salesOrders;
        }

        public List<SalesOrders> GetSOList(SalesOrders search)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    var customers = Entities.tblCustomerVendorDetails.AsNoTracking();

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
                                                     SalesmanID = so.CreatedByID,
                                                     SalesOrderNumber = so.SalesOrderNumber,
                                                     FirmName = cust.FirmName,
                                                     OrderNumber = so.SalesOrderNumber,
                                                     BranchName = Entities.tblSysBranches.Where(r => r.BranchID == so.BranchID).FirstOrDefault().Name,
                                                     OrderDate = so.SalesDatetime,
                                                     createdByID = so.CreatedByID,
                                                     SalesDateTime = so.SalesDatetime,
                                                     CustomerName = customers.Where(r => r.CustID == so.CustID).FirstOrDefault().FirmName,
                                                     stateID = customers.Where(r => r.CustID == so.CustID).FirstOrDefault().StateID,
                                                     cityID = customers.Where(r => r.CustID == so.CustID).FirstOrDefault().CityID,
                                                     districtID = customers.Where(r => r.CustID == so.CustID).FirstOrDefault().DistrictID,
                                                     CreationDate = so.CreationDate,
                                                     companyTypeID = cust.CompanyTypeID,
                                                     customerType = cust.CustomerTypeID,
                                                     area = cust.BillingArea,
                                                     IsTallyUpdated = so.IsTallyUpdated,
                                                     TallyStatus = so.IsTallyUpdated == true ? "Yes" : "No",
                                                     TallySync = so.TallySync == null ? false : so.TallySync.Value,
                                                     TotalAmount = so.tblSalesOrderWithItems.Select(c => c.Value).Sum(),
                                                     IsEdited = so.IsEdited,
                                                 }).ToList();

                    if (!string.IsNullOrEmpty(search.SalesOrderNumber) && !string.IsNullOrEmpty(search.SalesOrderNumber))
                    {
                        soLists = soLists.Where(m => m.SalesOrderNumber.ToString().ToLower() == search.SalesOrderNumber.ToLower()).ToList();
                    }

                    if (!string.IsNullOrEmpty(search.CustomerName) && !string.IsNullOrEmpty(search.CustomerName))
                    {
                        soLists = soLists.Where(m => m.CustomerName.ToLower().Contains(search.CustomerName.ToLower())).ToList();
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

                    var taxLedgers = Entities.tblTaxLedgers.Where(d => d.OrgID == OrgID).ToList();

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
                                                     CustomerState = so.tblCustomerVendorDetail.BillingState,
                                                     CompanyState = so.tblCustomerVendorDetail.tblSysOrganization.State,
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
                                                     IsEdited = so.IsEdited,
                                                     //      DLSalesOrderWithItemCreations = so.tblSalesOrderWithItems
                                                     //.Select(i => new DLSalesOrderWithItemCreation()
                                                     //{
                                                     //    SalesOrderNumber = i.SalesOrderNumber,
                                                     //    BagQTY = i.BagQTY,
                                                     //    TotalQTY = i.TotalQTY,
                                                     //    Rate = i.Rate,
                                                     //    Value = i.Value,
                                                     //    DiscountPercentage = i.DiscountPercentage,
                                                     //    ItemName = i.tblItem.ItemName,
                                                     //    ItemCode = i.ItemCode,
                                                     //    GSTPer = Entities.tblItems.Where(d => d.ItemCode == i.ItemCode).FirstOrDefault().GST,
                                                     //}).ToList(),
                                                     DLSalesOrderWithItemCreations = (from i in so.tblSalesOrderWithItems
                                                                                      join item in Entities.tblItems on i.ItemCode equals item.ItemCode
                                                                                      select new DLSalesOrderWithItemCreation()
                                                                                      {
                                                                                          SalesOrderNumber = i.SalesOrderNumber,
                                                                                          BagQTY = i.BagQTY,
                                                                                          TotalQTY = i.TotalQTY,
                                                                                          Rate = i.Rate,
                                                                                          Value = i.Value,
                                                                                          DiscountPercentage = i.DiscountPercentage,
                                                                                          DiscountAmt = i.DiscountAmt,
                                                                                          ItemName = i.tblItem.ItemName,
                                                                                          ItemCode = i.ItemCode,
                                                                                          GSTPer = item.GST,
                                                                                          CGSTLedger = taxLedgers.Where(t => t.TaxPercentage == item.GST / 2 && t.TaxType == "CGST").FirstOrDefault().Name,
                                                                                          SGSTLedger = taxLedgers.Where(t => t.TaxPercentage == item.GST / 2 && t.TaxType == "SGST").FirstOrDefault().Name,
                                                                                          IGSTLedger = taxLedgers.Where(t => t.TaxPercentage == item.GST && t.TaxType == "IGST").FirstOrDefault().Name,
                                                                                          RatePerUnit = i.tblItem.tblItemRate.tblUOM.Unit
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
        public SalesOrders GetSalesOrderDetails(string SalesOrderNumber, bool requestPrint = false, bool requestPrintPage = false)
        {
            SalesOrders salesOrder = new SalesOrders();
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    if (requestPrintPage)
                    {
                        SalesOrderNumber = Entities.tblPrintItems.Where(d => d.Id.ToString() == SalesOrderNumber).FirstOrDefault().OrderNo;
                    }

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        salesOrder = (from tblsalesorders in Entities.tblSalesOrders
                                      join c in Entities.tblCustomerVendorDetails on tblsalesorders.CustID equals c.CustID
                                      where tblsalesorders.SalesOrderNumber == SalesOrderNumber
                                      select new SalesOrders
                                      {
                                          CustID = tblsalesorders.CustID,
                                          OrderNumber = tblsalesorders.SalesOrderNumber,
                                          SalesOrderNumber = tblsalesorders.SalesOrderNumber,
                                          OrgID = tblsalesorders.OrgID,
                                          BranchID = tblsalesorders.BranchID,
                                          SalesmanID = tblsalesorders.SalesmanID,
                                          createdByID = tblsalesorders.CreatedByID,
                                          IsDirectSO = tblsalesorders.IsDirectSO,
                                          IsDirectSale = tblsalesorders.IsDirectSale,
                                          Photo1 = tblsalesorders.Photo1,
                                          Photo2 = tblsalesorders.Photo2,
                                          BrokerID = tblsalesorders.BrokerID,
                                          VoucherTypeNo = tblsalesorders.VoucherTypeNo,
                                          SignatureImage = tblsalesorders.SignatureImage,
                                          IsBulkSale = tblsalesorders.IsBulkSale,
                                          SalesType = tblsalesorders.SalesType,
                                          IsTallyUpdated = tblsalesorders.IsTallyUpdated,
                                          Status = tblsalesorders.Status,
                                          DiscountPercentage = tblsalesorders.DiscountPercentage,
                                          DiscountAmt = tblsalesorders.DiscountAmt,
                                          ApprovalStatus = tblsalesorders.ApprovalStatus,
                                          RegistrationType = tblsalesorders.RegistrationType,
                                          TransType = tblsalesorders.TransType,
                                          Comments = tblsalesorders.Comments,
                                          Location = tblsalesorders.Location,
                                          PANNumber = tblsalesorders.PANNumber,
                                          IsActive = tblsalesorders.IsActive,
                                          IsDelivaryNote = tblsalesorders.IsDelivaryNote,
                                          URDNumber = tblsalesorders.URDNumber,
                                          IsGatePassEntered = tblsalesorders.IsGatePassEntered,
                                          CreditTypeId = tblsalesorders.CreditTypeId,
                                          BillingAddress = tblsalesorders.BillingAddress,
                                          IsEdited = tblsalesorders.IsEdited,
                                          BranchName = tblsalesorders.tblSysBranch.Name,
                                          CustomerName = tblsalesorders.tblCustomerVendorDetail.FirmName,
                                          MobileNumber = tblsalesorders.tblCustomerVendorDetail.MobileNumber,
                                          caddress = !string.IsNullOrEmpty(tblsalesorders.tblCustomerVendorDetail.ShippingAddress) ? tblsalesorders.tblCustomerVendorDetail.ShippingAddress : "NA",
                                          cstate = !string.IsNullOrEmpty(tblsalesorders.tblCustomerVendorDetail.ShippingState) ? tblsalesorders.tblCustomerVendorDetail.ShippingState : "NA",
                                          ccity = !string.IsNullOrEmpty(tblsalesorders.tblCustomerVendorDetail.ShippingCity) ? tblsalesorders.tblCustomerVendorDetail.ShippingCity : "NA",
                                          cpincode = !string.IsNullOrEmpty(tblsalesorders.tblCustomerVendorDetail.BillingPincode) ? tblsalesorders.tblCustomerVendorDetail.BillingPincode : string.Empty,
                                          SalesDateTime = tblsalesorders.SalesDatetime,
                                          area = c.BillingArea,
                                          CustomerState = tblsalesorders.tblCustomerVendorDetail.BillingState,
                                          CompanyState = tblsalesorders.tblCustomerVendorDetail.tblSysOrganization.State,
                                          CompanyCity = tblsalesorders.tblCustomerVendorDetail.tblSysOrganization.City,

                                          SalesmanName = tblsalesorders.tblSysUser3.FName,
                                          PriceSyncType = Entities.tblAdminSettings.Where(d => d.OrgID == tblsalesorders.OrgID).FirstOrDefault().PriceSyncType,
                                          customerInfo = new CustomerCreation
                                          {
                                              FirmName = tblsalesorders.tblCustomerVendorDetail.FirmName,
                                              BillingAddress = tblsalesorders.tblCustomerVendorDetail.BillingAddress,
                                              BillingPincode = tblsalesorders.tblCustomerVendorDetail.BillingPincode,
                                              BillingCity = tblsalesorders.tblCustomerVendorDetail.BillingCity,
                                              BillingState = tblsalesorders.tblCustomerVendorDetail.BillingState,
                                              ShippingAddress = tblsalesorders.tblCustomerVendorDetail.ShippingAddress,
                                              ShippingPincode = tblsalesorders.tblCustomerVendorDetail.ShippingPincode,
                                              ShippingCity = tblsalesorders.tblCustomerVendorDetail.ShippingCity,
                                              ShippingState = tblsalesorders.tblCustomerVendorDetail.ShippingState,
                                          },

                                      }).FirstOrDefault();

                        var branchDetails = (from b in Entities.tblSysBranches
                                             join s in Entities.tblStates on b.State equals s.StateID.ToString()
                                             where b.BranchID == salesOrder.BranchID
                                             select new BranchDetails
                                             {
                                                 Name = b.Name,
                                                 Address = b.BillingAddress,
                                                 GST = b.GST,
                                                 Mobile = b.Mobile,
                                                 City = b.City,
                                                 State = s.StateName,
                                                 PinCode = b.PinCode,
                                                 PANNumber = b.PANNumber,
                                             }).FirstOrDefault();
                        salesOrder.BranchDetails = branchDetails;

                        var itemsList = (from a in Entities.tblSalesOrderWithItems
                                         join b in Entities.tblSalesOrders on a.SalesOrderNumber.ToLower().Trim() equals b.SalesOrderNumber.ToLower().Trim()
                                         join c in Entities.tblItems on a.ItemCode.ToLower().Trim() equals c.ItemCode.ToLower().Trim()
                                         where a.SalesOrderNumber == SalesOrderNumber && a.Rate > 0
                                         select new DLSalesOrderWithItemCreation
                                         {
                                             ItemName = c.ItemName,
                                             HSNCode = c.HSNCode.ToString(),
                                             BagQTY = a.BagQTY,
                                             Value = a.Value,
                                             ItemCode = a.ItemCode,
                                             Rate = a.Rate,
                                             TotalQTY = a.TotalQTY,
                                             SalesOrderWithItemID = a.SalesOrderWithItemID,
                                             IsRateInQuantls = a.IsRateInQuantls,
                                             DiscountPercentage = a.DiscountPercentage.HasValue ? a.DiscountPercentage.Value : 0,
                                             LoadingUnloadingCharge = a.LoadingUnloadingCharge,
                                             ItemRowNumber = a.ItemRowNumber,
                                             FrieghtCharge = a.FrieghtCharge,
                                             OtherExpense = a.OtherExpense,
                                             GSTPer = c.GST,
                                             CGSTLedger = Entities.tblTaxLedgers.Where(t => t.TaxPercentage == c.GST).FirstOrDefault().Name,
                                             SGSTLedger = Entities.tblTaxLedgers.Where(t => t.TaxPercentage == c.GST).FirstOrDefault().Name,
                                             IGSTLedger = Entities.tblTaxLedgers.Where(t => t.TaxPercentage == c.GST).FirstOrDefault().Name,
                                             DiscountAmt = a.DiscountAmt == null ? 0 : a.DiscountAmt.Value,
                                             RatePerUnit = a.tblItem.tblItemRate.tblUOM.Unit,
                                         }).Distinct().OrderBy(d => d.ItemName).ToList();
                        var adminSettings = Entities.tblAdminSettings.Where(d => d.OrgID == salesOrder.OrgID).FirstOrDefault();
                        if (requestPrint)
                        {
                            if (salesOrder.PriceSyncType)
                            {
                                foreach (var item in itemsList)
                                {
                                    if (item.Rate > 0)
                                    {
                                        item.Rate = Math.Round(item.Rate * 100 / (100 + item.GSTPer.Value), 2);
                                        var totalValue = Math.Round(item.Rate * item.TotalQTY, 2);
                                        var discountAmt = Math.Round((totalValue * item.DiscountPercentage.Value) / 100, 2);
                                        item.DiscountAmt = discountAmt;
                                        item.Value = Math.Round(totalValue - discountAmt, 2);
                                        item.GSTValue = Math.Round(((totalValue - item.DiscountAmt.Value) * item.GSTPer.Value) / 100, 2);
                                        item.CGSTValue = Math.Round(item.GSTValue.Value / 2, 2);
                                        item.SGSTValue = Math.Round(item.GSTValue.Value / 2, 2);
                                        item.IGSTValue = Math.Round(item.GSTValue.Value, 2);
                                    }
                                }
                            }
                            else
                            {
                                itemsList.ForEach(d => d.GSTPer = 0);
                            }
                        }
                        salesOrder.PaymentInfo = adminSettings.PaymentInfo;
                        salesOrder.SalesType = salesOrder.CustomerState.ToLower() == salesOrder.CompanyState.ToLower() ? "Local State" : "Inter State";
                        salesOrder.DLSalesOrderWithItemCreations = itemsList.ToList();
                        return salesOrder;
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
        public bool UpdateTallyStatusFromService(SalesOrders sOrders, bool Error = false)
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
                            if (Error)
                            {
                                tblSalesOrder tblSalesOrders = new tblSalesOrder();
                                tblSalesOrders.SalesOrderNumber = sOrders.SalesOrderNumber;
                                tblSalesOrders.UpdateDate = DateTime.Now;
                                tblSalesOrders.IsTallyUpdated = false;
                                tblSalesOrders.TallySync = false;
                                tblSalesOrders.TransType = sOrders.TransType;
                                tblSalesOrders.SalesDatetime = sOrders.SalesDateTime;
                                Entities.tblSalesOrders.Attach(tblSalesOrders);
                                Entities.Entry(tblSalesOrders).Property(c => c.UpdateDate).IsModified = true;
                                Entities.Entry(tblSalesOrders).Property(c => c.IsTallyUpdated).IsModified = true;
                                Entities.Entry(tblSalesOrders).Property(c => c.TallySync).IsModified = true;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                return true;
                            }
                            else
                            {
                                tblSalesOrder tblSalesOrders = new tblSalesOrder();
                                tblSalesOrders.SalesOrderNumber = sOrders.SalesOrderNumber;
                                tblSalesOrders.UpdateDate = sOrders.ModifiedDate;
                                tblSalesOrders.IsTallyUpdated = true;
                                tblSalesOrders.TallySync = false;
                                tblSalesOrders.TransType = sOrders.TransType;
                                tblSalesOrders.SalesDatetime = sOrders.SalesDateTime;
                                tblSalesOrders.IsEdited = true;
                                Entities.tblSalesOrders.Attach(tblSalesOrders);
                                Entities.Entry(tblSalesOrders).Property(c => c.UpdateDate).IsModified = true;
                                Entities.Entry(tblSalesOrders).Property(c => c.IsTallyUpdated).IsModified = true;
                                Entities.Entry(tblSalesOrders).Property(c => c.TallySync).IsModified = true;
                                Entities.Entry(tblSalesOrders).Property(c => c.IsEdited).IsModified = true;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                return true;
                            }
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
        private SalesOrders mSalesOrder = new SalesOrders();
        private tblSalesOrder lSalesOrder = new tblSalesOrder();
        public SalesOrders updateSalesOrder(SalesOrders mSalesOrder)
        {
            var result = new SalesOrders();
            try
            {

                lSalesOrder = (from so in Entities.tblSalesOrders.AsNoTracking()
                               where so.SalesOrderNumber.ToLower().Trim() == mSalesOrder.SalesOrderNumber.ToLower().Trim()
                               select so).FirstOrDefault();

                if (lSalesOrder != null)
                {
                    using (Entities = new MWBTCustomerAppEntities())
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
                                lSalesOrder.SalesType = mSalesOrder.SalesType.ToLower() == "local state" ? "LS" : "IS";
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
                                lSalesOrder.IsEdited = mSalesOrder.IsTallyUpdated == true ? true : false;


                                #endregion
                                var customer = Entities.tblCustomerVendorDetails.Where(i => i.CustID == mSalesOrder.CustID).FirstOrDefault();
                                #region Edit Credit/cash Customer Shipping Address 12/12/2019
                                if (mSalesOrder.DLCustomerVendorDetail != null)
                                {
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
                                string baseURL = ConfigurationManager.AppSettings["BaseURL"].ToString();
                                string apiKEY = ConfigurationManager.AppSettings["SMSAPIKey"].ToString();
                                string senderID = ConfigurationManager.AppSettings["SenderID"].ToString();
                                string portalUrl = ConfigurationManager.AppSettings["PortalURL"].ToString();
                                string bitlyToken = ConfigurationManager.AppSettings["bitlyToken"].ToString();
                                string bitlyUserName = ConfigurationManager.AppSettings["bitlyUserName"].ToString();

                                string bitlyUrl = ConfigurationManager.AppSettings["bitlyUrl"].ToString();
                                string urlParameter = saveUrl(mSalesOrder.SalesOrderNumber, Entities);

                                portalUrl = portalUrl + "p/pi?N=" + urlParameter;
                                var shortUrl = Helper.ShortenUrl(bitlyUrl, portalUrl, bitlyToken).Result;
                                var otpMsg = messageTemplates.SALES_ORDER_APPROVED;
                                otpMsg = otpMsg.Replace("{0}", customer.FirmName);
                                otpMsg = otpMsg.Replace("{1}", mSalesOrder.SalesOrderNumber);
                                otpMsg = otpMsg.Replace("{2}", shortUrl);
                                Helper.SendMessage(baseURL, apiKEY, customer.MobileNumber, otpMsg, senderID);

                                result.statusCode = HttpStatusCode.OK;
                            }
                            catch (Exception ex)
                            {
                                result.statusCode = HttpStatusCode.InternalServerError;
                                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.statusCode = HttpStatusCode.InternalServerError;
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
            }
            return result;
        }
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
        public string GetCustomerState(string CustID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var customerState = string.Empty;
                        var customer = Entities.tblCustomerVendorDetails.Where(d => d.CustID == CustID).FirstOrDefault();
                        if (customer != null)
                            customerState = customer.BillingState;
                        return customerState;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public string GetCompanyState(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var companyState = string.Empty;
                        var company = Entities.tblSysOrganizations.Where(d => d.OrgID == OrgID).FirstOrDefault();
                        if (company != null)
                            companyState = company.State;
                        return companyState;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
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
            oldLineItem.DiscountAmt = updatedLineItem.DiscountAmt;
            oldLineItem.DiscountPercentage = updatedLineItem.DiscountPercentage;
            oldLineItem.IsDiscountRangeExceeded = updatedLineItem.IsDiscountRangeExceeded;
            oldLineItem.IsRateInQuantls = updatedLineItem.IsRateInQuantls;
            oldLineItem.tblSalesOrderItemWarehouseMaps.Clear();
            Entities.Entry(oldLineItem).State = EntityState.Modified;
        }
        public string DeleteItem(string Id)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var soItem = Entities.tblSalesOrderWithItems.Where(d => d.SalesOrderWithItemID.ToString() == Id).FirstOrDefault();
                    if (soItem != null)
                    {
                        Entities.tblSalesOrderWithItems.Remove(soItem);
                        Entities.SaveChanges();
                        return "success";
                    }
                    else
                        return "error";
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return "error";
            }
        }
        private string saveUrl(string salesOrderNo, MWBTCustomerAppEntities dbContext)
        {
            try
            {
                var tblPrintItems = new tblPrintItem
                {
                    OrderNo = salesOrderNo,
                };
                dbContext.tblPrintItems.Add(tblPrintItems);
                dbContext.SaveChanges();
                return tblPrintItems.Id.ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
    //public static class MessageTemplate
    //{
    //    public static string SALES_ORDER_ACCEPTED = "Dear {0} , I place order Number {1} i have sent confirmation. Thanks {2}";
    //}
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