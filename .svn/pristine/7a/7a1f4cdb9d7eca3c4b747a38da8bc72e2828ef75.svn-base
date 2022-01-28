using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;


namespace WBT.DLCustomerCreation
{
    public class Margins
    {
        // public int? ID { get; set; }
        public string OrgID { get; set; }
        //public Nullable<bool> IsEdited { get; set; }
        public int? BusinessTypeID { get; set; }
        public int? CreditTypeID { get; set; }
        public string CreditTypeName { get; set; }
        public decimal? Margin { get; set; }
        public decimal? NextMargin { get; set; }
        public string BranchID { get; set; }
        public string BusinessTypeName { get; set; }
        public int? CityID { get; set; }
        public string CityName { get; set; }
        //public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        // private string mGetDate = "";
        public string FrmEffectiveTime { get; set; }
        //{
        //    return WBT.Common.Helper.GetTimeFormat(Convert.ToDateTime(mGetDate));
        //}
        //{
        //    mGetDate = WBT.Common.Helper.GetTimeFormat(Convert.ToDateTime(value));
        //}
        //private string toGetTime = "";
        public string ToEffectiveTime
        {
            get;
            //{
            //    return WBT.Common.Helper.GetTimeFormat(Convert.ToDateTime(toGetTime));
            //}
            set;
            //{
            //    toGetTime = WBT.Common.Helper.GetTimeFormat(Convert.ToDateTime(value));
            //}
        }
        private string frmGetDate { get; set; }
        public string FrmEffectiveDate
        {
            get;
            //{
            //    return WBT.Common.Helper.GetDateAsStringFormat(Convert.ToDateTime(frmGetDate));
            //}
            set;
            //{
            //    frmGetDate = WBT.Common.Helper.GetDateAsStringFormat(Convert.ToDateTime(value));
            //}
        }
        private string toGetDate { get; set; }
        public string ToEffectiveDate
        {
            get;
            //{
            //    return WBT.Common.Helper.GetDateAsStringFormat(Convert.ToDateTime(toGetDate));
            //}
            set;
            //{
            //    toGetDate = WBT.Common.Helper.GetDateAsStringFormat(Convert.ToDateTime(value));
            //}
        }
        //public string lFrmEffectiveTime { get; set; }
        //public Nullable<DateTime> lFrmEffectiveDate { get; set; }
        public string SetMargin { get; set; }
        public string EndDate { get; set; }

        //public int[] StateList { get; set; }
        //public int[] DistrictList { get; set; }
        //public int[] CityList { get; set; }
        //public string[] BranchList { get; set; }
        public int? stateID { get; set; }

        public int? districtID { get; set; }

        public int? CreditDays { get; set; }
        public string DisplayMessage { get; set; }
    }

    public class MarginType
    {
        public bool IsBusiness { get; set; }
        public bool IsCredit { get; set; }
    }

    public class BusinessTypeProperties
    {
        public string OrgID { get; set; }
        public int? BusinessTypeID { get; set; }
        public int? CreditTypeID { get; set; }
        public string CreditTypeName { get; set; }
        public decimal? Margin { get; set; }
        public decimal? NextMargin { get; set; }
        public string BranchID { get; set; }
        public string BusinessTypeName { get; set; }
        public int? CityID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int? CreatedByID { get; set; }
        public string FrmEffectiveTime { get; set; }
        public string ToEffectiveTime { get; set; }
        public string FrmEffectiveDate { get; set; }
        public string ToEffectiveDate { get; set; }
        public string DisplayMessage { get; set; }
        public string SetMargin { get; set; }

        //public int[] StateList { get; set; }
        //public int[] DistrictList { get; set; }
        //public int[] CityList { get; set; }
        //public string[] BranchList { get; set; }
        public int? stateID { get; set; }
        //public int? cityID { get; set; }
        public int? districtID { get; set; }
        //public int? branchID { get; set; }
    }


    public class DLMargins
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private BusinessType lBusinessType = new BusinessType();
        private CreditType lCreditType = new CreditType();
        private Margins mBusinessTypeCreation = new Margins();
        private Margins mCreditTypeCreation = new Margins();
        private BusinessTypeProperties mBTMP = new BusinessTypeProperties();

        private List<Margins> lstMarginCreation = new List<Margins>();
        private Margins mMarginCreation = new Margins();
        public List<Margins> BusinessTypeCreation
        {
            get { return lstMarginCreation; }
            set { lstMarginCreation = value; }
        }

        public List<Margins> GetBusinessTypeData(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Margins> Businessmargins = new List<Margins>();

                    Businessmargins = (from b in Entities.BusinessTypes
                                       join btc in Entities.BusinessTypeMarginDetails on b.BusinessTypeID
                                                      equals btc.BusinessTypeID
                                       where b.OrgId == OrgID && btc.OrgID == b.OrgId
                                       select new Margins
                                       {
                                           BusinessTypeID = b.BusinessTypeID,
                                           BusinessTypeName = b.BusinessTypeName.Trim(),
                                           Margin = btc.Margin,
                                           BranchID = btc.BranchID,
                                           CityID = btc.CityID,
                                           FrmEffectiveDate = btc.FrmEffectiveDate.ToString().Trim(),
                                           FrmEffectiveTime = btc.FrmEffectiveTime.Trim(),
                                           ToEffectiveDate = btc.ToEffectiveDate.ToString().Trim(),
                                           ToEffectiveTime = btc.ToEffectiveTime.Trim(),
                                           OrgID = b.OrgId
                                       }).OrderByDescending(i => i.BusinessTypeName).ToList();

                    return Businessmargins;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public List<Margins> GetBusinessTypeMarginDetails(string OrgID, int businessTypeID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Margins> Businessmargins = new List<Margins>();

                    Businessmargins = (from b in Entities.BusinessTypes
                                       join btc in Entities.BusinessTypeMarginDetails on b.BusinessTypeID
                                                      equals btc.BusinessTypeID
                                       where b.OrgId == OrgID && btc.OrgID == b.OrgId && b.BusinessTypeID == businessTypeID
                                       select new Margins
                                       {
                                           BusinessTypeID = b.BusinessTypeID,
                                           BusinessTypeName = b.BusinessTypeName.Trim(),
                                           Margin = btc.Margin,
                                           BranchID = btc.BranchID,
                                           CityID = btc.CityID,
                                           FrmEffectiveDate = btc.FrmEffectiveDate.ToString().Trim(),
                                           FrmEffectiveTime = btc.FrmEffectiveTime.Trim(),
                                           ToEffectiveDate = btc.ToEffectiveDate.ToString().Trim(),
                                           ToEffectiveTime = btc.ToEffectiveTime.Trim(),
                                           OrgID = b.OrgId,
                                           CityName = Entities.tblStateWithCities.Where(c=> c.StatewithCityID == btc.CityID).FirstOrDefault().VillageLocalityname,
                                       }).OrderByDescending(i => i.BusinessTypeName).ToList();

                    return Businessmargins;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }


        public List<Margins> GetCreditTypeMarginDetails(string OrgID, int creditTypeID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Margins> Creditmargins = new List<Margins>();

                    Creditmargins = (from b in Entities.CreditTypes
                                     join btc in Entities.CreditTypeMarginDetails on b.CreditTypeID
                                                    equals btc.CreditTypeID
                                     where b.OrgId == OrgID && btc.OrgId == b.OrgId && b.CreditTypeID == creditTypeID
                                     select new Margins
                                     {
                                         CreditTypeID = b.CreditTypeID,
                                         CreditTypeName = b.CreditTypeName.Trim(),
                                         Margin = btc.Margin,
                                         BranchID = btc.BranchID,
                                         CityID = btc.CityID,
                                         CreditDays = btc.CreditDays,
                                         FrmEffectiveDate = btc.FrmEffectiveDate.ToString().Trim(),
                                         FrmEffectiveTime = btc.FrmEffectiveTime.Trim(),
                                         ToEffectiveDate = btc.ToEffectiveDate.ToString().Trim(),
                                         ToEffectiveTime = btc.ToEffectiveTime.Trim(),
                                         OrgID = b.OrgId,
                                         CityName = Entities.tblStateWithCities.Where(c=> c.StatewithCityID == btc.CityID).FirstOrDefault().VillageLocalityname,
                                     }).OrderByDescending(i => i.CreditTypeName).ToList();

                    return Creditmargins;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }


        public List<Margins> GetCreditTypeData(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Margins> Creditmargins = new List<Margins>();

                    Creditmargins = (from b in Entities.CreditTypes
                                     join ctc in Entities.CreditTypeMarginDetails on b.CreditTypeID
                                                      equals ctc.CreditTypeID
                                     where b.OrgId == OrgID && ctc.OrgId == b.OrgId
                                     where b.OrgId == OrgID
                                     select new Margins
                                     {
                                         CreditTypeID = b.CreditTypeID,
                                         CreditTypeName = b.CreditTypeName.Trim(),
                                         Margin = ctc.Margin,
                                         CreditDays = ctc.CreditDays,
                                         BranchID = ctc.BranchID,
                                         CityID = ctc.CityID,
                                         FrmEffectiveDate = ctc.FrmEffectiveDate.ToString().Trim(),
                                         FrmEffectiveTime = ctc.FrmEffectiveTime.Trim(),
                                         ToEffectiveDate = ctc.ToEffectiveDate.ToString().Trim(),
                                         ToEffectiveTime = ctc.ToEffectiveTime.Trim(),
                                         OrgID = b.OrgId
                                     }).OrderByDescending(i => i.CreditTypeName).ToList();

                    return Creditmargins;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public BusinessTypeProperties SaveBusinessMarginData(BusinessTypeProperties margins, string OrgID)
        {
            mBTMP = (BusinessTypeProperties)margins;
            try
            {
                using (Entities = new MWBTCustomerAppEntities())//  new Entity.MWBTechnologyEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var bmlst = Entities.BusinessTypeMarginDetails.ToList();

                        if (bmlst.Count() == 0)
                        {
                            //First time both to be entered in base table
                            FirstTimeDataSave(mBTMP);
                        }
                        else
                        {

                            BusinessTypeMarginDetail dLBusiness = new BusinessTypeMarginDetail();

                            //if entered details are for present date then update the data as follows
                            if (Convert.ToDateTime(mBTMP.FrmEffectiveDate) <= Convert.ToDateTime(WBT.Common.Helper.GetCurrentDate).Date
                                && Convert.ToDateTime(mBTMP.FrmEffectiveTime) <= Convert.ToDateTime(WBT.Common.Helper.GetCurrentDate.ToShortTimeString()))
                            {

                                #region  to check if branch or city already business type exist
                                if (mBTMP.CityID > 0)
                                {
                                    dLBusiness = (from gBT in Entities.BusinessTypeMarginDetails
                                                  where gBT.IsActive == true &&
                                                  gBT.CityID == mBTMP.CityID &&
                                                  gBT.BusinessTypeID == mBTMP.BusinessTypeID
                                                  && gBT.OrgID == mBTMP.OrgID
                                                  select gBT).FirstOrDefault();

                                    PresentDateTimeMarginsSet(dLBusiness);
                                }
                                else if (Convert.ToInt32(mBTMP.BranchID) > 0)
                                {
                                    dLBusiness = (from gBT in Entities.BusinessTypeMarginDetails
                                                  where gBT.IsActive == true &&
                                                  gBT.BranchID == mBTMP.BranchID &&
                                                  gBT.BusinessTypeID == mBTMP.BusinessTypeID
                                                  && gBT.OrgID == mBTMP.OrgID
                                                  select gBT).FirstOrDefault();

                                    PresentDateTimeMarginsSet(dLBusiness);
                                }
                                else
                                {
                                    dLBusiness = (from gBT in Entities.BusinessTypeMarginDetails
                                                  where gBT.IsActive == true &&
                                                  string.IsNullOrEmpty(gBT.BranchID) &&
                                                  (gBT.CityID == 0 || string.IsNullOrEmpty(gBT.CityID.ToString())) &&
                                                  gBT.BusinessTypeID == mBTMP.BusinessTypeID
                                                  && gBT.OrgID == mBTMP.OrgID
                                                  select gBT).FirstOrDefault();

                                    PresentDateTimeMarginsSet(dLBusiness);
                                }
                                #endregion

                                #region if any data exist then make isactive true and insert new margin details in other table
                                //if (dLBusiness != null)
                                //{
                                //    dLBusiness.IsActive = true;
                                //    dLBusiness.Margin = mBusinessTypeCreation.Margin;
                                //    dLBusiness.BusinessTypeID = mBusinessTypeCreation.BusinessTypeID;
                                //    dLBusiness.FrmEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.FrmEffectiveDate);
                                //    dLBusiness.FrmEffectiveTime = mBusinessTypeCreation.FrmEffectiveTime;
                                //    dLBusiness.ToEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.ToEffectiveDate);
                                //    dLBusiness.ToEffectiveTime = mBusinessTypeCreation.ToEffectiveTime;
                                //    dLBusiness.OrgID = mBusinessTypeCreation.OrgID;
                                //    dLBusiness.BranchID = mBusinessTypeCreation.BranchID == "0" ? null : mBusinessTypeCreation.BranchID;
                                //    dLBusiness.CityID = mBusinessTypeCreation.CityID;
                                //    dLBusiness.CreatedDate = Common.Helper.GetCurrentDate;
                                //    dLBusiness.CreatedByID = mBusinessTypeCreation.CreatedByID;
                                //    Entities.BusinessTypeMarginDetails.Add(dLBusiness);
                                //    Entities.Entry(dLBusiness).State = EntityState.Modified;
                                //    Entities.SaveChanges();

                                //}
                                #endregion

                                #region  delete code
                                //dLBusiness = new BusinessTypeMarginDetail();
                                //dLBusiness.Margin = mBusinessTypeCreation.Margin;
                                //dLBusiness.BusinessTypeID = mBusinessTypeCreation.BusinessTypeID;
                                //dLBusiness.FrmEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.FrmEffectiveDate);
                                //dLBusiness.FrmEffectiveTime = mBusinessTypeCreation.FrmEffectiveTime;
                                //dLBusiness.ToEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.ToEffectiveDate);
                                //dLBusiness.ToEffectiveTime = mBusinessTypeCreation.ToEffectiveTime;
                                //dLBusiness.OrgID = mBusinessTypeCreation.OrgID;
                                //dLBusiness.BranchID = mBusinessTypeCreation.BranchID == "0" ? null : mBusinessTypeCreation.BranchID;
                                //dLBusiness.CityID = mBusinessTypeCreation.CityID;
                                //dLBusiness.CreatedDate = Common.Helper.GetCurrentDate;
                                //dLBusiness.CreatedByID = mBusinessTypeCreation.CreatedByID;
                                //dLBusiness.IsActive = true;
                                //Entities.BusinessTypeMarginDetails.Add(dLBusiness);
                                //Entities.SaveChanges();

                                //FuturisticBusinessType futuristicBusinessType = new FuturisticBusinessType();
                                //futuristicBusinessType.Margin = mBusinessTypeCreation.Margin;
                                ////futuristicBusinessType.BTMarginsID = dLBusiness.BTMarginsID;
                                //futuristicBusinessType.NextMargin = mBusinessTypeCreation.NextMargin;
                                //futuristicBusinessType.BusinessTypeID = mBusinessTypeCreation.BusinessTypeID;
                                //futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.FrmEffectiveDate);
                                //futuristicBusinessType.FrmEffectiveTime = mBusinessTypeCreation.FrmEffectiveTime;
                                //futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.ToEffectiveDate);
                                //futuristicBusinessType.ToEffectiveTime = mBusinessTypeCreation.ToEffectiveTime;
                                //futuristicBusinessType.OrgID = mBusinessTypeCreation.OrgID;
                                //futuristicBusinessType.BranchID = mBusinessTypeCreation.BranchID == "0" ? null : mBusinessTypeCreation.BranchID;
                                //futuristicBusinessType.CityID = mBusinessTypeCreation.CityID;
                                //futuristicBusinessType.CreatedDate = Common.Helper.GetCurrentDate;
                                //futuristicBusinessType.CreatedByID = mBusinessTypeCreation.CreatedByID;
                                //Entities.FuturisticBusinessTypes.Add(futuristicBusinessType);
                                //Entities.SaveChanges();
                                #endregion
                            }
                            else
                            {
                                FuturisticDataSave(mBTMP);
                            }
                        }

                        dbcxtransaction.Commit();
                        //this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                        mBTMP.DisplayMessage = "Business Type Margin Set Successfully";
                        return mBTMP;
                    }
                }
            }
            catch (Exception ex)
            {
                mBTMP.DisplayMessage = "Error.. Please Contact Administrator";
                return mBTMP;
            }

        }

        private void FirstTimeDataSave(BusinessTypeProperties mBTMP)
        {
            BusinessTypeMarginDetail dLBusiness = new BusinessTypeMarginDetail();

            if (Convert.ToDateTime(mBTMP.FrmEffectiveDate) <= Convert.ToDateTime(WBT.Common.Helper.GetCurrentDate).Date
                    && Convert.ToDateTime(mBTMP.FrmEffectiveTime) <= Convert.ToDateTime(DateTime.Now.ToShortTimeString()))
            {
                dLBusiness.Margin = mBTMP.Margin;
                dLBusiness.BusinessTypeID = mBTMP.BusinessTypeID;
                dLBusiness.FrmEffectiveDate = Convert.ToDateTime(mBTMP.FrmEffectiveDate);
                dLBusiness.FrmEffectiveTime = mBTMP.FrmEffectiveTime;
                dLBusiness.ToEffectiveDate = Convert.ToDateTime(mBTMP.ToEffectiveDate);
                dLBusiness.ToEffectiveTime = mBTMP.ToEffectiveTime;
                dLBusiness.OrgID = mBTMP.OrgID;
                dLBusiness.BranchID = mBTMP.BranchID == "0" ? null : mBTMP.BranchID;
                dLBusiness.CityID = mBTMP.CityID;
                dLBusiness.CreatedDate = Common.Helper.GetCurrentDate;
                dLBusiness.CreatedByID = mBTMP.CreatedByID;

                dLBusiness.IsActive = true;
                Entities.BusinessTypeMarginDetails.Add(dLBusiness);
                Entities.SaveChanges();
            }

            FuturisticBusinessType futuristicBusinessType = new FuturisticBusinessType();
            futuristicBusinessType.Margin = mBTMP.Margin;
            futuristicBusinessType.BTMarginsID = dLBusiness.BTMarginsID;
            futuristicBusinessType.NextMargin = mBTMP.NextMargin;
            futuristicBusinessType.BusinessTypeID = mBTMP.BusinessTypeID;
            futuristicBusinessType.OrgID = mBTMP.OrgID;
            futuristicBusinessType.BranchID = mBTMP.BranchID == "0" ? null : mBTMP.BranchID;
            futuristicBusinessType.CityID = mBTMP.CityID;
            futuristicBusinessType.CreatedDate = Common.Helper.GetCurrentDate;
            futuristicBusinessType.CreatedByID = mBTMP.CreatedByID;

            futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mBTMP.FrmEffectiveDate);
            futuristicBusinessType.FrmEffectiveTime = mBTMP.FrmEffectiveTime;
            futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mBTMP.ToEffectiveDate);
            futuristicBusinessType.ToEffectiveTime = mBTMP.ToEffectiveTime;

            //26th jan 2021
            //futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.ToEffectiveDate);
            //futuristicBusinessType.FrmEffectiveTime = mBusinessTypeCreation.ToEffectiveTime;
            //futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.ToEffectiveDate).AddDays(30);
            //futuristicBusinessType.ToEffectiveTime = mBusinessTypeCreation.ToEffectiveTime;
            Entities.FuturisticBusinessTypes.Add(futuristicBusinessType);

            Entities.SaveChanges();
        }

        private void PresentDateTimeMarginsSet(BusinessTypeMarginDetail dLBusiness)
        {
            if (dLBusiness != null)
            {
                dLBusiness.IsActive = true;
                dLBusiness.Margin = mBTMP.Margin;
                dLBusiness.BusinessTypeID = mBTMP.BusinessTypeID;
                dLBusiness.FrmEffectiveDate = Convert.ToDateTime(mBTMP.FrmEffectiveDate);
                dLBusiness.FrmEffectiveTime = mBTMP.FrmEffectiveTime;
                dLBusiness.ToEffectiveDate = Convert.ToDateTime(mBTMP.ToEffectiveDate);
                dLBusiness.ToEffectiveTime = mBTMP.ToEffectiveTime;
                dLBusiness.OrgID = mBTMP.OrgID;
                dLBusiness.BranchID = mBTMP.BranchID == "0" ? null : mBTMP.BranchID;
                dLBusiness.CityID = mBTMP.CityID;
                dLBusiness.CreatedDate = Common.Helper.GetCurrentDate;
                dLBusiness.CreatedByID = mBTMP.CreatedByID;
                Entities.BusinessTypeMarginDetails.Add(dLBusiness);
                Entities.Entry(dLBusiness).State = EntityState.Modified;
                //Entities.SaveChanges();
            }
            else
            {
                dLBusiness = new BusinessTypeMarginDetail();
                dLBusiness.Margin = mBTMP.Margin;
                dLBusiness.BusinessTypeID = mBTMP.BusinessTypeID;
                dLBusiness.FrmEffectiveDate = Convert.ToDateTime(mBTMP.FrmEffectiveDate);
                dLBusiness.FrmEffectiveTime = mBTMP.FrmEffectiveTime;
                dLBusiness.ToEffectiveDate = Convert.ToDateTime(mBTMP.ToEffectiveDate);
                dLBusiness.ToEffectiveTime = mBTMP.ToEffectiveTime;
                dLBusiness.OrgID = mBTMP.OrgID;
                dLBusiness.BranchID = mBTMP.BranchID == "0" ? null : mBTMP.BranchID;
                dLBusiness.CityID = mBTMP.CityID;
                dLBusiness.CreatedDate = Common.Helper.GetCurrentDate;
                dLBusiness.CreatedByID = mBTMP.CreatedByID;
                dLBusiness.IsActive = true;
                Entities.BusinessTypeMarginDetails.Add(dLBusiness);
                Entities.SaveChanges();
            }

            FuturisticBusinessType futuristicBusinessType = new FuturisticBusinessType();
            futuristicBusinessType.Margin = mBTMP.Margin;
            futuristicBusinessType.NextMargin = mBTMP.NextMargin;
            futuristicBusinessType.BusinessTypeID = mBTMP.BusinessTypeID;
            futuristicBusinessType.OrgID = mBTMP.OrgID;
            futuristicBusinessType.BranchID = mBTMP.BranchID == "0" ? null : mBTMP.BranchID;
            futuristicBusinessType.CityID = mBTMP.CityID;
            futuristicBusinessType.CreatedDate = Common.Helper.GetCurrentDate;
            futuristicBusinessType.CreatedByID = mBTMP.CreatedByID;
            futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mBTMP.FrmEffectiveDate);
            futuristicBusinessType.FrmEffectiveTime = mBTMP.FrmEffectiveTime;
            futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mBTMP.ToEffectiveDate);
            futuristicBusinessType.ToEffectiveTime = mBTMP.ToEffectiveTime;
            //26th Jan
            futuristicBusinessType.BTMarginsID = dLBusiness.BTMarginsID;
            //futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.ToEffectiveDate);
            //futuristicBusinessType.FrmEffectiveTime = mBusinessTypeCreation.ToEffectiveTime;
            //futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mBusinessTypeCreation.ToEffectiveDate).AddDays(30);
            //futuristicBusinessType.ToEffectiveTime = mBusinessTypeCreation.ToEffectiveTime;
            Entities.FuturisticBusinessTypes.Add(futuristicBusinessType);

            Entities.SaveChanges();
        }

        private void FuturisticDataSave(BusinessTypeProperties mBTMP)
        {
            int BTMarginid = Entities.BusinessTypeMarginDetails.Where(i => i.OrgID == mBTMP.OrgID && i.BranchID == mBTMP.BranchID && i.CityID == mBTMP.CityID && i.IsActive == true
            && i.BusinessTypeID == mBTMP.BusinessTypeID).FirstOrDefault().BTMarginsID;

            FuturisticBusinessType futuristicBusinessType = new FuturisticBusinessType();
            futuristicBusinessType.Margin = mBTMP.Margin;
            futuristicBusinessType.NextMargin = mBTMP.NextMargin;
            futuristicBusinessType.BusinessTypeID = mBTMP.BusinessTypeID;
            futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mBTMP.FrmEffectiveDate);
            futuristicBusinessType.FrmEffectiveTime = mBTMP.FrmEffectiveTime;
            futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mBTMP.ToEffectiveDate);
            futuristicBusinessType.ToEffectiveTime = mBTMP.ToEffectiveTime;
            futuristicBusinessType.OrgID = mBTMP.OrgID;
            futuristicBusinessType.BranchID = mBTMP.BranchID == "0" ? null : mBTMP.BranchID;
            futuristicBusinessType.CityID = mBTMP.CityID;
            futuristicBusinessType.CreatedDate = Common.Helper.GetCurrentDate;
            futuristicBusinessType.CreatedByID = mBTMP.CreatedByID;

            //26th jan
            futuristicBusinessType.BTMarginsID = BTMarginid;
            Entities.FuturisticBusinessTypes.Add(futuristicBusinessType);
            Entities.SaveChanges();
        }


        public Margins SaveCreditDetails(Margins margindetails, string OrgID)
        {
            //lstCreaditTypeMarginsCreation = (List<DLCreaditTypeMarginsCreation>)Context;
            mCreditTypeCreation = (Margins)margindetails;
            try
            {
                using (Entities = new MWBTCustomerAppEntities())//  new Entity.MWBTechnologyEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var bmlst = Entities.CreditTypeMarginDetails.ToList();

                        if (bmlst.Count() == 0)
                        {
                            //First time both to be entered in base table
                            CreditFirstTimeDataSave(mCreditTypeCreation);
                        }
                        else
                        {

                            CreditTypeMarginDetail dLBusiness = new CreditTypeMarginDetail();

                            //if entered details are for present date then update the data as follows
                            if (Convert.ToDateTime(mCreditTypeCreation.FrmEffectiveDate) <= Convert.ToDateTime(WBT.Common.Helper.GetCurrentDate).Date
                                && Convert.ToDateTime(mCreditTypeCreation.FrmEffectiveTime) <= Convert.ToDateTime(Helper.GetCurrentDate.ToShortTimeString()))
                            {

                                #region  to check if branch or city already business type exist
                                if (mCreditTypeCreation.CityID > 0)
                                {
                                    dLBusiness = (from gBT in Entities.CreditTypeMarginDetails
                                                  where gBT.IsActive == true &&
                                                  gBT.CityID == mCreditTypeCreation.CityID &&
                                                  gBT.CreditTypeID == mCreditTypeCreation.CreditTypeID
                                                  && gBT.OrgId == mCreditTypeCreation.OrgID
                                                  select gBT).FirstOrDefault();

                                    CreditPresentDateTimeMarginsSet(dLBusiness);
                                }
                                else if (Convert.ToInt32(mCreditTypeCreation.BranchID) > 0)
                                {
                                    dLBusiness = (from gBT in Entities.CreditTypeMarginDetails
                                                  where gBT.IsActive == true &&
                                                  gBT.BranchID == mCreditTypeCreation.BranchID &&
                                                  gBT.CreditTypeID == mCreditTypeCreation.CreditTypeID
                                                  && gBT.OrgId == mCreditTypeCreation.OrgID
                                                  select gBT).FirstOrDefault();

                                    CreditPresentDateTimeMarginsSet(dLBusiness);
                                }
                                else
                                {
                                    dLBusiness = (from gBT in Entities.CreditTypeMarginDetails
                                                  where gBT.IsActive == true &&
                                               string.IsNullOrEmpty(gBT.BranchID) &&
                                                  (gBT.CityID == 0 || string.IsNullOrEmpty(gBT.CityID.ToString())) &&
                                                  gBT.CreditTypeID == mCreditTypeCreation.CreditTypeID
                                                  && gBT.OrgId == mCreditTypeCreation.OrgID
                                                  select gBT).FirstOrDefault();

                                    CreditPresentDateTimeMarginsSet(dLBusiness);
                                }
                                #endregion

                            }
                            else
                            {
                                CreditFuturisticDataSave(mCreditTypeCreation);
                            }
                        }

                        dbcxtransaction.Commit();
                        //this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                        mCreditTypeCreation.DisplayMessage = "Credit Type Inserted Successfull";
                        return mCreditTypeCreation;
                        //dbcxtransaction.Commit();
                        //this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                //throw;
                mCreditTypeCreation.DisplayMessage = "Credit Type Failed to Insert";
                return mCreditTypeCreation;
            }
            //return this.GetApplicationActivate;
        }


        private void CreditFuturisticDataSave(Margins mCreaditTypeMarginsCreation)
        {
            FuturisticCreditType futuristicBusinessType = new FuturisticCreditType();
            futuristicBusinessType.Margin = mCreaditTypeMarginsCreation.Margin;
            futuristicBusinessType.CreditDays = mCreaditTypeMarginsCreation.CreditDays;
            futuristicBusinessType.NextMargin = mCreaditTypeMarginsCreation.NextMargin;
            futuristicBusinessType.CreditTypeID = mCreaditTypeMarginsCreation.CreditTypeID;
            futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mCreaditTypeMarginsCreation.FrmEffectiveDate);
            futuristicBusinessType.FrmEffectiveTime = mCreaditTypeMarginsCreation.FrmEffectiveTime;
            futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mCreaditTypeMarginsCreation.ToEffectiveDate);
            futuristicBusinessType.ToEffectiveTime = mCreaditTypeMarginsCreation.ToEffectiveTime;
            futuristicBusinessType.OrgID = mCreaditTypeMarginsCreation.OrgID;
            futuristicBusinessType.BranchID = mCreaditTypeMarginsCreation.BranchID == "0" ? null : mCreaditTypeMarginsCreation.BranchID;
            futuristicBusinessType.CityID = mCreaditTypeMarginsCreation.CityID;
            futuristicBusinessType.CreatedDate = Common.Helper.GetCurrentDate;
            futuristicBusinessType.CreatedByID = mCreaditTypeMarginsCreation.CreatedByID;
            Entities.FuturisticCreditTypes.Add(futuristicBusinessType);
            Entities.SaveChanges();
        }

        private void CreditFirstTimeDataSave(Margins mCreaditTypeMarginsCreation)
        {
            if (Convert.ToDateTime(mCreaditTypeMarginsCreation.FrmEffectiveDate) <= Convert.ToDateTime(WBT.Common.Helper.GetCurrentDate).Date
                    && Convert.ToDateTime(mCreaditTypeMarginsCreation.FrmEffectiveTime) <= Convert.ToDateTime(DateTime.Now.ToShortTimeString()))
            {
                CreditTypeMarginDetail dLCredits = new CreditTypeMarginDetail();
                dLCredits.Margin = mCreaditTypeMarginsCreation.Margin;
                dLCredits.CreditDays = mCreaditTypeMarginsCreation.CreditDays;
                dLCredits.CreditTypeID = mCreaditTypeMarginsCreation.CreditTypeID;
                dLCredits.FrmEffectiveDate = Convert.ToDateTime(mCreaditTypeMarginsCreation.FrmEffectiveDate);
                dLCredits.FrmEffectiveTime = mCreaditTypeMarginsCreation.FrmEffectiveTime;
                dLCredits.ToEffectiveDate = Convert.ToDateTime(mCreaditTypeMarginsCreation.ToEffectiveDate);
                dLCredits.ToEffectiveTime = mCreaditTypeMarginsCreation.ToEffectiveTime;
                dLCredits.OrgId = mCreaditTypeMarginsCreation.OrgID;
                dLCredits.BranchID = mCreaditTypeMarginsCreation.BranchID == "0" ? null : mCreaditTypeMarginsCreation.BranchID;
                dLCredits.CityID = mCreaditTypeMarginsCreation.CityID;
                dLCredits.CreatedDate = Common.Helper.GetCurrentDate;
                dLCredits.CreditTypeID = mCreaditTypeMarginsCreation.CreatedByID;
                dLCredits.IsActive = true;

                Entities.CreditTypeMarginDetails.Add(dLCredits);
                Entities.SaveChanges();
            }

            FuturisticCreditType futuristicBusinessType = new FuturisticCreditType();
            futuristicBusinessType.Margin = mCreaditTypeMarginsCreation.Margin;
            futuristicBusinessType.CreditDays = mCreaditTypeMarginsCreation.CreditDays;
            futuristicBusinessType.NextMargin = mCreaditTypeMarginsCreation.NextMargin;
            futuristicBusinessType.CreditTypeID = mCreaditTypeMarginsCreation.CreditTypeID;
            futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mCreaditTypeMarginsCreation.FrmEffectiveDate);
            futuristicBusinessType.FrmEffectiveTime = mCreaditTypeMarginsCreation.FrmEffectiveTime;
            futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mCreaditTypeMarginsCreation.ToEffectiveDate);
            futuristicBusinessType.ToEffectiveTime = mCreaditTypeMarginsCreation.ToEffectiveTime;
            futuristicBusinessType.OrgID = mCreaditTypeMarginsCreation.OrgID;
            futuristicBusinessType.BranchID = mCreaditTypeMarginsCreation.BranchID == "0" ? null : mCreaditTypeMarginsCreation.BranchID;
            futuristicBusinessType.CityID = mCreaditTypeMarginsCreation.CityID;
            futuristicBusinessType.CreatedDate = Common.Helper.GetCurrentDate;
            futuristicBusinessType.CreatedByID = mCreaditTypeMarginsCreation.CreatedByID;
            Entities.FuturisticCreditTypes.Add(futuristicBusinessType);
            Entities.SaveChanges();

        }

        private void CreditPresentDateTimeMarginsSet(CreditTypeMarginDetail dLBusiness)
        {
            if (dLBusiness != null)
            {
                dLBusiness.IsActive = true;
                dLBusiness.Margin = mCreditTypeCreation.Margin;
                dLBusiness.CreditDays = mCreditTypeCreation.CreditDays;
                dLBusiness.CreditTypeID = mCreditTypeCreation.CreditTypeID;
                dLBusiness.FrmEffectiveDate = Convert.ToDateTime(mCreditTypeCreation.FrmEffectiveDate);
                dLBusiness.FrmEffectiveTime = mCreditTypeCreation.FrmEffectiveTime;
                dLBusiness.ToEffectiveDate = Convert.ToDateTime(mCreditTypeCreation.ToEffectiveDate);
                dLBusiness.ToEffectiveTime = mCreditTypeCreation.ToEffectiveTime;
                dLBusiness.OrgId = mCreditTypeCreation.OrgID;
                dLBusiness.BranchID = mCreditTypeCreation.BranchID == "0" ? null : mCreditTypeCreation.BranchID;
                dLBusiness.CityID = mCreditTypeCreation.CityID;
                dLBusiness.CreatedDate = Common.Helper.GetCurrentDate;
                dLBusiness.CreatedById = mCreditTypeCreation.CreatedByID;
                Entities.CreditTypeMarginDetails.Add(dLBusiness);
                Entities.Entry(dLBusiness).State = EntityState.Modified;
                Entities.SaveChanges();
            }
            else
            {
                dLBusiness = new CreditTypeMarginDetail();
                dLBusiness.CreditDays = mCreditTypeCreation.CreditDays;
                dLBusiness.Margin = mCreditTypeCreation.Margin;
                dLBusiness.CreditTypeID = mCreditTypeCreation.CreditTypeID;
                dLBusiness.FrmEffectiveDate = Convert.ToDateTime(mCreditTypeCreation.FrmEffectiveDate);
                dLBusiness.FrmEffectiveTime = mCreditTypeCreation.FrmEffectiveTime;
                dLBusiness.ToEffectiveDate = Convert.ToDateTime(mCreditTypeCreation.ToEffectiveDate);
                dLBusiness.ToEffectiveTime = mCreditTypeCreation.ToEffectiveTime;
                dLBusiness.OrgId = mCreditTypeCreation.OrgID;
                dLBusiness.BranchID = mCreditTypeCreation.BranchID == "0" ? null : mCreditTypeCreation.BranchID;
                dLBusiness.CityID = mCreditTypeCreation.CityID;
                dLBusiness.CreatedDate = Common.Helper.GetCurrentDate;
                dLBusiness.CreatedById = mCreditTypeCreation.CreatedByID;
                dLBusiness.IsActive = true;
                Entities.CreditTypeMarginDetails.Add(dLBusiness);
                Entities.SaveChanges();
            }

            FuturisticCreditType futuristicBusinessType = new FuturisticCreditType();
            futuristicBusinessType.Margin = mCreditTypeCreation.Margin;
            futuristicBusinessType.NextMargin = mCreditTypeCreation.NextMargin;
            futuristicBusinessType.CreditDays = mCreditTypeCreation.CreditDays;
            futuristicBusinessType.CreditTypeID = mCreditTypeCreation.CreditTypeID;
            futuristicBusinessType.FrmEffectiveDate = Convert.ToDateTime(mCreditTypeCreation.FrmEffectiveDate);
            futuristicBusinessType.FrmEffectiveTime = mCreditTypeCreation.FrmEffectiveTime;
            futuristicBusinessType.ToEffectiveDate = Convert.ToDateTime(mCreditTypeCreation.ToEffectiveDate);
            futuristicBusinessType.ToEffectiveTime = mCreditTypeCreation.ToEffectiveTime;
            futuristicBusinessType.OrgID = mCreditTypeCreation.OrgID;
            futuristicBusinessType.BranchID = mCreditTypeCreation.BranchID == "0" ? null : mCreditTypeCreation.BranchID;
            futuristicBusinessType.CityID = mCreditTypeCreation.CityID;
            futuristicBusinessType.CreatedDate = Common.Helper.GetCurrentDate;
            futuristicBusinessType.CreatedByID = mCreditTypeCreation.CreatedByID;
            Entities.FuturisticCreditTypes.Add(futuristicBusinessType);
            Entities.SaveChanges();
        }
    }

}