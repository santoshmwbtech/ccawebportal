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
    public class DLBrands
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public Brands SaveData(Brands brands, string OrgID, string UserID)
        {
            Brands Result = new Brands();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    var isValueExists = Entities.tblBrands.AsNoTracking().Where(i => i.BrandID == brands.BrandID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        var IsNameExists = Entities.tblBrands.AsNoTracking().Where(i => i.BrandName.ToLower().Trim() == brands.BrandName.ToLower().Trim()).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblBrand tblbrand = new tblBrand();
                            tblbrand.BrandName = brands.BrandName;
                            tblbrand.ItemCompanyID = brands.ItemCompanyID;
                            tblbrand.IsTrademarkRegistered = brands.IsTrademarkRegistered;
                            tblbrand.OrgID = OrgID;
                            tblbrand.CreatedByID = Convert.ToInt32(UserID);
                            tblbrand.CreatedDate = DateTimeNow;
                            tblbrand.IsActive = brands.IsActive;
                            Entities.tblBrands.Add(tblbrand);
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Brand Saved Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Brand Name already exists";
                            return Result;
                        }
                    }
                    else
                    {
                        var IsNameExists = Entities.tblBrands.AsNoTracking().Where(i => i.BrandName.ToLower().Trim() == brands.BrandName.ToLower().Trim() && i.BrandID != brands.BrandID).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblBrand tblbrand = new tblBrand();
                            tblbrand.BrandID = brands.BrandID;
                            tblbrand.BrandName = brands.BrandName;
                            tblbrand.ItemCompanyID = brands.ItemCompanyID;
                            tblbrand.IsTrademarkRegistered = brands.IsTrademarkRegistered;
                            tblbrand.OrgID = OrgID;
                            tblbrand.CreatedByID = isValueExists.CreatedByID;
                            tblbrand.CreatedDate = isValueExists.CreatedDate;
                            tblbrand.ModifiedDate = DateTimeNow;
                            tblbrand.ModifiedByID = Convert.ToInt32(UserID);
                            tblbrand.IsActive = brands.IsActive;
                            Entities.tblBrands.Add(tblbrand);
                            Entities.Entry(tblbrand).State = EntityState.Modified;
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Brand Updated Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Brand Name already exists";
                            return Result;
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Error.. Please contact administrator";
                return Result;
            }
        }
        public List<Brands> GetData(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Brands> brands = new List<Brands>();

                    brands = (from b in Entities.tblBrands
                              where b.OrgID == OrgID
                              select new Brands
                              {
                                  BrandID = b.BrandID,
                                  BrandName = b.BrandName,
                                  CreatedByID = b.CreatedByID,
                                  CreatedDate = b.CreatedDate.Value,
                                  IsActive = b.IsActive == null ? false : b.IsActive.Value,
                                  IsTrademarkRegistered = b.IsTrademarkRegistered == null ? false : b.IsTrademarkRegistered.Value,
                                  ItemCompanyID = b.ItemCompanyID,
                                  ItemCompanyName = b.tblItemCompany == null ? "" : b.tblItemCompany.CompanyName,
                                  ModifiedDate = b.ModifiedDate != null ? b.ModifiedDate.Value : b.ModifiedDate,
                                  OrgID = b.OrgID,
                                  sIsTrademarkRegistered = b.IsTrademarkRegistered == true ? "Yes" : "No",
                                  Status = b.IsActive == true ? "Active" : "Inactive",
                              }).OrderByDescending(i => i.ItemCompanyID).ToList();

                    return brands;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Brands GetIBrandDetail(int BrandID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    Brands brands = new Brands();
                    brands = (from b in Entities.tblBrands
                              where b.BrandID == BrandID
                              select new Brands
                              {
                                  BrandID = b.BrandID,
                                  BrandName = b.BrandName,
                                  CreatedByID = b.CreatedByID,
                                  CreatedDate = b.CreatedDate.Value,
                                  IsActive = b.IsActive == null ? false : b.IsActive.Value,
                                  IsTrademarkRegistered = b.IsTrademarkRegistered == null ? false : b.IsTrademarkRegistered.Value,
                                  ItemCompanyID = b.ItemCompanyID,
                                  ItemCompanyName = b.tblItemCompany == null ? "" : b.tblItemCompany.CompanyName,
                                  ModifiedDate = b.ModifiedDate.Value,
                                  OrgID = b.OrgID,
                                  sIsTrademarkRegistered = b.IsTrademarkRegistered == true ? "Yes" : "No",
                              }).FirstOrDefault();
                    return brands;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Brands DeleteBrand(int BrandID, string OrgID, string UserID)
        {
            Brands Result = new Brands();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblBrands.AsNoTracking().Where(u => u.BrandID == BrandID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblBrands.Remove(Entities.tblBrands.Where(r => r.BrandID == BrandID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Brand Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Can not delete Brand as it is being used by other departments";
                return Result;
            }
        }
        public List<ItemCompany> GetItemCompanies(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<ItemCompany> itemCompanies = new List<ItemCompany>();

                    itemCompanies = (from i in Entities.tblItemCompanies
                                     where i.OrgID == OrgID && i.IsActive == true
                                     select new ItemCompany
                                     {
                                         ItemCompanyID = i.ItemCompanyID,
                                         CompanyName = i.CompanyName,
                                     }).OrderByDescending(i => i.ItemCompanyID).ToList();

                    return itemCompanies;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
    }
    public class Brands
    {
        /// <summary>
        /// Get or Set the Brand ID in int
        /// </summary>
        public int BrandID { get; set; }
        /// <summary>
        /// Get or Set the Brand name in string 
        /// </summary>   
        public string BrandName { get; set; }
        /// <summary>
        /// Get or Set User ID in int
        /// </summary>        
        public int CreatedByID { get; set; }
        /// <summary>
        /// Get or Set Created Date in DateTime
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Get or Set Modified Date in DateTime
        /// </summary>
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> ItemCompanyID { get; set; }
        public string ItemCompanyName { get; set; }
        public bool IsTrademarkRegistered { get; set; }
        public string sIsTrademarkRegistered { get; set; }
        public string OrgID { get; set; }
        public string SerachText { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public string DisplayMessage { get; set; }
    }
}
