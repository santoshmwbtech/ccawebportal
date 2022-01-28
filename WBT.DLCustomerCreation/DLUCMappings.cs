using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLUCMappings
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<Users> GetUserList(int? UserType, int? ID, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<Users> users = new List<Users>();
                        if (UserType != null)
                        {
                            if (UserType == 1)
                            {
                                if (ID != null && ID != 0)
                                {
                                    users = (from u in Entities.tblSysUsers
                                             join r in Entities.tblSysRoles on u.RoleID equals r.RoleID
                                             where u.OrgID == OrgID && u.Department.ToLower() == "sales"
                                             && r.RoleName.ToLower() != "sales man"
                                             && u.UserID != ID
                                             select new Users
                                             {
                                                 value = u.UserID.ToString(),
                                                 text = u.FName + " (" + r.RoleName + ")"
                                             }).ToList();
                                }
                                else
                                {
                                    users = (from u in Entities.tblSysUsers
                                             join r in Entities.tblSysRoles on u.RoleID equals r.RoleID
                                             where u.OrgID == OrgID && u.Department.ToLower() == "sales"
                                             && r.RoleName.ToLower() != "sales man"
                                             select new Users
                                             {
                                                 value = u.UserID.ToString(),
                                                 text = u.FName + " (" + r.RoleName + ")"
                                             }).ToList();
                                }
                            }
                            else if (UserType == 2)
                            {
                                if (ID != null && ID != 0)
                                {
                                    int ChannelTypeID = Entities.tblSysChannelPartners.Where(c => c.ChannelPartnerID == ID.ToString()).FirstOrDefault().ChannelTypeID.Value;
                                    users = (from u in Entities.tblSysChannelPartners
                                             join c in Entities.tblSalesChannelTypes on u.ChannelTypeID equals c.ID
                                             where u.OrgID == OrgID && u.ChannelPartnerID != ID.ToString() && u.ChannelTypeID == ChannelTypeID
                                             select new Users
                                             {
                                                 value = u.ChannelPartnerID,
                                                 text = u.ChannelPartnerName + " (" + c.ChannelType + ")"
                                             }).ToList();
                                }
                                else
                                {
                                    users = (from u in Entities.tblSysChannelPartners
                                             join c in Entities.tblSalesChannelTypes on u.ChannelTypeID equals c.ID
                                             where u.OrgID == OrgID
                                             select new Users
                                             {
                                                 value = u.ChannelPartnerID,
                                                 text = u.ChannelPartnerName + " (" + c.ChannelType + ")"
                                             }).ToList();
                                }
                            }
                        }
                        return users;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public List<UserDetails> GetUsers(int? UserType, int? ID, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<UserDetails> users = new List<UserDetails>();
                        if (ID != null)
                        {
                            if (UserType != null)
                            {
                                if (UserType == 1)
                                {
                                    int RoleID = Entities.tblSysUsers.Where(s => s.UserID == ID).FirstOrDefault().RoleID;

                                    users = (from u in Entities.tblSysUsers
                                             join r in Entities.tblSysRoles on u.RoleID equals r.RoleID
                                             join m in Entities.tblUserMappings on u.UserID equals m.UserId
                                             where u.OrgID == OrgID && r.ParentRoleID == RoleID && m.ParentUserId == ID.Value
                                             select new UserDetails
                                             {
                                                 ID = u.UserID,
                                                 ChannelPartnerID = "0",
                                                 Name = u.FName,
                                                 UCType = r.RoleName,
                                                 IsChecked = Entities.tblUserMappings.Where(uc => uc.UserId == u.UserID && uc.ParentUserId == ID).FirstOrDefault() == null ? false : true
                                             }).OrderByDescending(s => s.IsChecked).ToList();
                                }
                                else if (UserType == 2)
                                {
                                    int ChannelTypeID = Entities.tblSysChannelPartners.Where(br => br.ChannelPartnerID == ID.ToString()).FirstOrDefault().ChannelTypeID.Value;

                                    users = (from b in Entities.tblSysChannelPartners
                                             join c in Entities.tblSalesChannelTypes on b.ChannelTypeID equals c.ID
                                             join m in Entities.tblChannelPartnerMappings on b.ChannelPartnerID equals m.ChannelPartnerId
                                             where b.OrgID == OrgID && c.ParentChannelType == ChannelTypeID && m.ParentChannelPartnerId == ID.ToString()
                                             select new UserDetails
                                             {
                                                 ID = 0,
                                                 ChannelPartnerID = b.ChannelPartnerID,
                                                 Name = b.ChannelPartnerName,
                                                 UCType = c.ChannelType,
                                                 IsChecked = Entities.tblChannelPartnerMappings.Where(ch => ch.ChannelPartnerId == b.ChannelPartnerID && ch.ParentChannelPartnerId == ID.ToString()).FirstOrDefault() == null ? false : true,
                                             }).OrderByDescending(s => s.IsChecked).ToList();
                                }
                            }
                        }
                        return users;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public UCMappings Save(UCMappings uCMappings, int UserID)
        {
            UCMappings Result = new UCMappings();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                        if (uCMappings != null)
                        {
                            if (uCMappings.UserType == 1)
                            {
                                if (uCMappings.Users.Count() > 0 && uCMappings.Users != null)
                                {
                                    if (uCMappings.IsSwapping)
                                    {
                                        int[] Users = null;

                                        if (uCMappings.Users != null && uCMappings.Users.Count() > 0)
                                        {
                                            Users = uCMappings.Users.Where(um => um.IsChecked == true).Select(x => x.ID).ToArray();
                                        }

                                        var Mappings = Entities.tblUserMappings.Where(u => u.ParentUserId == uCMappings.ID && Users.Contains(u.UserId)).ToList();
                                        Entities.tblUserMappings.RemoveRange(Mappings);
                                        Entities.SaveChanges();

                                        uCMappings.Users = uCMappings.Users.Where(x => x.IsChecked == true).ToList();

                                        //Get is already swapped
                                        var PreviousMappings = (from m in Entities.tblUserMappings
                                                                where m.ParentUserId == uCMappings.SwapID
                                                                select new UserDetails
                                                                {
                                                                    ID = m.UserId,
                                                                }).ToList();

                                        if (PreviousMappings != null && PreviousMappings.Count() > 0)
                                        {
                                            int[] PrevUsers = PreviousMappings.Select(x => x.ID).ToArray();
                                            uCMappings.Users = uCMappings.Users.Where(m => !PrevUsers.Contains(m.ID)).ToList();
                                        }                                            

                                        if(uCMappings.Users != null && uCMappings.Users.Count() > 0)
                                        {
                                            foreach (var item in uCMappings.Users)
                                            {
                                                tblUserMapping tblUserMapping = new tblUserMapping();
                                                tblUserMapping.UserId = item.ID;
                                                tblUserMapping.ParentUserId = uCMappings.SwapID.Value;
                                                tblUserMapping.CreatedDate = DateTimeNow;
                                                tblUserMapping.CreateddBy = UserID;
                                                Entities.tblUserMappings.Add(tblUserMapping);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var Mappings = Entities.tblUserMappings.Where(u => u.ParentUserId == uCMappings.ID).ToList();
                                        Entities.tblUserMappings.RemoveRange(Mappings);
                                        Entities.SaveChanges();

                                        uCMappings.Users = uCMappings.Users.Where(x => x.IsChecked == true).ToList();
                                        foreach (var item in uCMappings.Users)
                                        {
                                            tblUserMapping tblUserMapping = new tblUserMapping();
                                            tblUserMapping.UserId = item.ID;
                                            tblUserMapping.ParentUserId = uCMappings.ID;
                                            tblUserMapping.CreatedDate = DateTimeNow;
                                            tblUserMapping.CreateddBy = UserID;
                                            Entities.tblUserMappings.Add(tblUserMapping);
                                        }
                                    }
                                }
                            }
                            else if (uCMappings.UserType == 2)
                            {
                                if (uCMappings.Users.Count() > 0 && uCMappings.Users != null)
                                {
                                    if (uCMappings.IsSwapping)
                                    {
                                        string[] Users = null;

                                        if (uCMappings.Users != null && uCMappings.Users.Count() > 0)
                                        {
                                            Users = uCMappings.Users.Where(um => um.IsChecked == true).Select(x => x.ChannelPartnerID).ToArray();
                                        }

                                        var Mappings = Entities.tblChannelPartnerMappings.Where(u => u.ParentChannelPartnerId == uCMappings.ID.ToString() && Users.Contains(u.ChannelPartnerId)).ToList();
                                        Entities.tblChannelPartnerMappings.RemoveRange(Mappings);
                                        Entities.SaveChanges();

                                        //Get is already swapped
                                        var PreviousMappings = (from m in Entities.tblChannelPartnerMappings
                                                                where m.ParentChannelPartnerId == uCMappings.SwapID.ToString()
                                                                select new UserDetails
                                                                {
                                                                    ChannelPartnerID = m.ChannelPartnerId,
                                                                }).ToList();

                                        if (PreviousMappings != null && PreviousMappings.Count() > 0)
                                        {
                                            string[] PrevUsers = PreviousMappings.Select(x => x.ChannelPartnerID).ToArray();
                                            uCMappings.Users = uCMappings.Users.Where(m => !PrevUsers.Contains(m.ChannelPartnerID)).ToList();
                                        }

                                        uCMappings.Users = uCMappings.Users.Where(x => x.IsChecked == true).ToList();
                                        if(uCMappings.Users != null && uCMappings.Users.Count() > 0)
                                        {
                                            foreach (var item in uCMappings.Users)
                                            {
                                                tblChannelPartnerMapping tblChannelPartner = new tblChannelPartnerMapping();
                                                tblChannelPartner.ChannelPartnerId = item.ChannelPartnerID;
                                                tblChannelPartner.ParentChannelPartnerId = uCMappings.SwapID.Value.ToString();
                                                tblChannelPartner.CreatedDate = DateTimeNow;
                                                tblChannelPartner.CreateddBy = UserID;
                                                Entities.tblChannelPartnerMappings.Add(tblChannelPartner);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var Mappings = Entities.tblChannelPartnerMappings.Where(u => u.ParentChannelPartnerId == uCMappings.ID.ToString()).ToList();
                                        Entities.tblChannelPartnerMappings.RemoveRange(Mappings);
                                        Entities.SaveChanges();

                                        uCMappings.Users = uCMappings.Users.Where(x => x.IsChecked == true).ToList();
                                        foreach (var item in uCMappings.Users)
                                        {
                                            tblChannelPartnerMapping tblChannelPartner = new tblChannelPartnerMapping();
                                            tblChannelPartner.ChannelPartnerId = item.ChannelPartnerID;
                                            tblChannelPartner.ParentChannelPartnerId = uCMappings.ID.ToString();
                                            tblChannelPartner.CreatedDate = DateTimeNow;
                                            tblChannelPartner.CreateddBy = UserID;
                                            Entities.tblChannelPartnerMappings.Add(tblChannelPartner);
                                        }
                                    }
                                }
                            }
                        }
                        Entities.SaveChanges();
                        dbcxtransaction.Commit();
                        Result.DisplayMessage = "success";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? ex.InnerException : null, ex.StackTrace);
                Result.DisplayMessage = "error";
                return Result;
            }
        }
        public static int ParseInt32(string str, int defaultValue = 0)
        {
            int result;
            return Int32.TryParse(str, out result) ? result : defaultValue;
        }
    }
    public class UCMappings
    {
        [Required(ErrorMessage = "Please select Marketing/Channel Partner Type")]
        public int UserType { get; set; }
        [Required(ErrorMessage = "Please select Marketing / Channel Partner")]
        public int ID { get; set; }
        public bool IsSwapping { get; set; }
        public int? SwapID { get; set; }
        public List<UserDetails> Users { get; set; }
        public string DisplayMessage { get; set; }
    }
    public class UserDetails
    {
        public int ID { get; set; }
        public string UCType { get; set; }
        public string ChannelPartnerID { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class ChannelPartners
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
