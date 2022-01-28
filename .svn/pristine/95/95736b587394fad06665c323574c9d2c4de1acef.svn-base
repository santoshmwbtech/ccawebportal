using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.DLCustomerCreation.Reports;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLCustomerCitySwap
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        public List<CustomerCitySwap> GetCustomerList(CustomerCreation search)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<CustomerCitySwap> customerCitySwaps = (from c in Entities.tblCustomerVendorDetails
                                                                where c.OrgID == search.OrgID
                                                                select new CustomerCitySwap
                                                                {
                                                                    CustID = c.CustID,
                                                                    OrgID = c.OrgID,
                                                                    BranchID = c.BranchID,
                                                                    FirmName = c.FirmName,
                                                                    BillingState = c.BillingState,
                                                                    BillingCity = c.BillingCity == null ? "" : c.BillingCity,
                                                                    StateID = c.StateID == null ? 0 : c.StateID.Value,
                                                                    CityID = c.CityID == null ? 0 : c.CityID,
                                                                    CreationDate = c.CreationDate,
                                                                }).ToList();

                    if (!string.IsNullOrEmpty(search.BillingCity))
                    {
                        customerCitySwaps = customerCitySwaps.Where(m => m.BillingCity.ToLower().Contains(search.BillingCity.ToLower())).ToList();
                    }

                    if (!string.IsNullOrEmpty(search.FromDate) && !string.IsNullOrEmpty(search.ToDate))
                    {
                        DateTime FromDateTime = DateTime.ParseExact(Convert.ToDateTime(search.FromDate).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        DateTime ToDateTime = DateTime.ParseExact(Convert.ToDateTime(search.ToDate).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        //created list
                        var customerCreationListCreated = customerCitySwaps.Where(c => Convert.ToDateTime(c.CreationDate.Value.ToString("yyyy-MM-dd")) >= FromDateTime && Convert.ToDateTime(c.CreationDate.Value.ToString("yyyy-MM-dd")) <= ToDateTime).ToList();

                        customerCitySwaps = new List<CustomerCitySwap>();
                        customerCitySwaps = customerCreationListCreated.ToList();
                        customerCitySwaps = customerCitySwaps.Distinct().ToList();
                    }
                    return customerCitySwaps;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public string CustomerCitySwap(SwapCity swap)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        swap.customerCitySwaps = swap.customerCitySwaps.Where(c => c.IsChecked == true).ToList();
                        string Result = string.Empty;
                        if (swap.customerCitySwaps.Count() > 0)
                        {
                            string cityName = Entities.tblStateWithCities.Where(c => c.StatewithCityID == swap.CityID).FirstOrDefault().VillageLocalityname;
                            foreach (var item in swap.customerCitySwaps)
                            {
                                tblCustomerVendorDetail tblCustomerVendorDetail = new tblCustomerVendorDetail();
                                tblCustomerVendorDetail.CustID = item.CustID.ToString();
                                tblCustomerVendorDetail.CityID = swap.CityID;
                                tblCustomerVendorDetail.BillingCity = cityName;
                                tblCustomerVendorDetail.ShippingCity = cityName;
                                Entities.tblCustomerVendorDetails.Attach(tblCustomerVendorDetail);
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.CityID).IsModified = true;
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.BillingCity).IsModified = true;
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.ShippingCity).IsModified = true;
                                Entities.SaveChanges();
                            }
                            dbcxtransaction.Commit();
                            Result = "Swapping of City done!!";
                        }
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return "Error!! Please contact administrator";
            }
        }

        //GetCities Of a Branch
        public ACLists GetCitiesOfBranch(string BranchID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<State> stateList = new List<State>();
                        List<AreaList> areaList = new List<AreaList>();
                        List<District> districtList = new List<District>();

                        ACLists aCLists = new ACLists();

                        stateList = (from c in Entities.tblCustomerVendorDetails
                                     join s in Entities.tblStates on c.StateID equals s.StateID
                                     where c.BranchID == BranchID && c.StateID != null
                                     select new State
                                     {
                                         BranchID = c.BranchID,
                                         StateID = s.StateID,
                                         StateName = s.StateName
                                     }).Distinct().ToList();

                        cityList = (from c in Entities.tblCustomerVendorDetails
                                    join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                    where c.BranchID == BranchID && c.CityID != null && c.StateID != null
                                    select new City
                                    {
                                        DistrictID = ct.DistrictID.Value,
                                        BranchID = c.BranchID,
                                        CityID = ct.StatewithCityID,
                                        CityName = ct.VillageLocalityname
                                    }).Distinct().ToList();

                        districtList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        join d in Entities.tblDistricts on ct.DistrictID equals d.DistrictID
                                        where c.BranchID == BranchID && c.CityID != null && c.StateID != null
                                        select new District
                                        {
                                            BranchID = c.BranchID,
                                            DistrictID = d.DistrictID,
                                            DistrictName = d.DistrictName
                                        }).Distinct().ToList();

                        var dList = districtList.GroupBy(dls => dls.DistrictID).Select(i => i.FirstOrDefault()).ToList();

                        dList = (from d in dList
                                 join c in cityList on d.DistrictID equals c.DistrictID
                                 select new District
                                 {
                                     BranchID = c.BranchID,
                                     DistrictID = d.DistrictID,
                                     DistrictName = d.DistrictName
                                 }).Distinct().ToList();

                        areaList = (from c in Entities.tblCustomerVendorDetails
                                    where c.BranchID == BranchID && c.BillingCity != null
                                    select new AreaList
                                    {
                                        BranchID = c.BranchID,
                                        BillingArea = c.BillingCity,
                                        ShippingArea = c.BillingArea
                                    }).Distinct().ToList();

                        aCLists.cities = cityList;
                        aCLists.states = stateList;
                        aCLists.areaLists = areaList;
                        aCLists.districts = dList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, districts and areas Of a state
        public ACLists GetCitiesOfState(string OrgID, string BranchID, string StateID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<State> stateList = new List<State>();
                        List<AreaList> areaList = new List<AreaList>();
                        List<District> districts = new List<District>();
                        ACLists aCLists = new ACLists();

                        if (!string.IsNullOrEmpty(StateID))
                        {
                            cityList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.OrgID == OrgID && c.BranchID == BranchID && c.StateID.ToString() == StateID && ct.StateID.ToString() == StateID && c.BillingCity != null && c.BillingState != null
                                        select new City
                                        {
                                            BranchID = c.BranchID,
                                            StateID = s.StateID,
                                            CityID = ct.StatewithCityID,
                                            CityName = ct.VillageLocalityname,
                                            DistrictID = ct.DistrictID.Value
                                        }).Distinct().ToList();

                            var dList = cityList.GroupBy(dls => dls.DistrictID).Select(i => i.FirstOrDefault()).ToList();

                            var DistrictList = (from dst in Entities.tblDistricts.ToList()
                                                join c in dList on dst.DistrictID equals c.DistrictID
                                                select new District
                                                {
                                                    DistrictID = dst.DistrictID,
                                                    DistrictName = dst.DistrictName
                                                }).Distinct().ToList();
                            districts = DistrictList.GroupBy(d => d.DistrictID).Select(i => i.FirstOrDefault()).ToList();

                            areaList = (from c in Entities.tblCustomerVendorDetails
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.OrgID == OrgID && c.BranchID == BranchID && c.StateID.ToString() == StateID && c.BillingArea != null && c.StateID != null
                                        select new AreaList
                                        {
                                            BranchID = c.BranchID,
                                            StateID = s.StateID,
                                            BillingArea = c.BillingCity,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();
                        }

                        aCLists.cities = cityList;
                        aCLists.districts = districts;
                        aCLists.areaLists = areaList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, areas Of a state
        public ACLists GetCitiesOfDistrict(string OrgID, string BranchID, string StateID, string DistrictID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<AreaList> areaList = new List<AreaList>();
                        ACLists aCLists = new ACLists();

                        if (!string.IsNullOrEmpty(DistrictID))
                        {
                            cityList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.OrgID == OrgID && c.BranchID == BranchID && c.StateID.ToString() == StateID
                                        && ct.DistrictID.ToString() == DistrictID && c.BillingCity != null && c.BillingState != null
                                        select new City
                                        {
                                            BranchID = c.BranchID,
                                            StateID = s.StateID,
                                            CityID = ct.StatewithCityID,
                                            CityName = ct.VillageLocalityname,
                                            DistrictID = ct.DistrictID.Value
                                        }).Distinct().ToList();

                            cityList = cityList.GroupBy(d => d.CityID).Select(i => i.FirstOrDefault()).ToList();

                            areaList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.OrgID == OrgID && c.BranchID == BranchID && c.StateID.ToString() == StateID && ct.DistrictID.ToString() == DistrictID && c.BillingArea != null && c.StateID != null && c.CityID != null
                                        select new AreaList
                                        {
                                            BranchID = c.BranchID,
                                            StateID = s.StateID,
                                            CityID = c.CityID.Value,
                                            BillingArea = c.BillingCity,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();

                            areaList = areaList.GroupBy(d => d.BillingArea).Select(i => i.FirstOrDefault()).ToList();
                        }

                        aCLists.cities = cityList;
                        aCLists.areaLists = areaList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
    }
    public class CustomerCitySwap
    {
        public string CustID { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        public string FirmName { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public bool IsChecked { get; set; }

        //for search
        public int[] StateList { get; set; }
        public int[] DistrictList { get; set; }
        public int[] CityList { get; set; }
        public int[] BranchList { get; set; }
    }

    public class SwapCity
    {
        public int CityID { get; set; }
        public int BranchID { get; set; }
        public string OrgID { get; set; }
        public int StateID { get; set; }
        public List<CustomerCitySwap> customerCitySwaps { get; set; }
    }
}
