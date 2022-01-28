using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLTemplates
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public Templates SaveSMSTemplate(Templates templates, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    string RoleName = (from u in Entities.tblSysUsers
                                       join role in Entities.tblSysRoles on u.RoleID equals role.RoleID
                                       where u.UserID.ToString() == UserID
                                       select role.RoleName).FirstOrDefault();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    var isValueExists = Entities.tblSMSTemplates.AsNoTracking().Where(i => i.ID == templates.ID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        var IsNameExists = Entities.tblSMSTemplates.AsNoTracking().Where(i => i.TemplateName.ToLower().Trim() == templates.TemplateName.ToLower().Trim()).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblSMSTemplate tblSMSTemplate = new tblSMSTemplate();
                            tblSMSTemplate.TemplateName = templates.TemplateName;
                            tblSMSTemplate.TemplateBody = templates.TemplateBody;
                            tblSMSTemplate.OrgID = OrgID;
                            tblSMSTemplate.CreatedBy = Convert.ToInt32(UserID);
                            tblSMSTemplate.CreatedDate = DateTimeNow;
                            if (RoleName.ToLower() == "admin")
                                tblSMSTemplate.IsActive = 1;
                            else
                                tblSMSTemplate.IsActive = 0;
                            tblSMSTemplate.Deleted = 0;
                            Entities.tblSMSTemplates.Add(tblSMSTemplate);
                            Entities.SaveChanges();
                            Result.DisplayMessage = "SMS Template Saved Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "SMS Template Name already exists";
                            return Result;
                        }
                    }
                    else
                    {
                        var IsNameExists = Entities.tblSMSTemplates.AsNoTracking().Where(i => i.TemplateName.ToLower().Trim() == templates.TemplateName.ToLower().Trim() && i.ID != templates.ID).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblSMSTemplate tblSMSTemplate = new tblSMSTemplate();
                            tblSMSTemplate.ID = templates.ID;
                            tblSMSTemplate.TemplateName = templates.TemplateName;
                            tblSMSTemplate.TemplateBody = templates.TemplateBody;
                            tblSMSTemplate.OrgID = OrgID;
                            tblSMSTemplate.CreatedBy = Convert.ToInt32(UserID);
                            tblSMSTemplate.CreatedDate = DateTimeNow;
                            if (RoleName.ToLower() == "admin")
                                tblSMSTemplate.IsActive = 1;
                            else
                                tblSMSTemplate.IsActive = 0;
                            tblSMSTemplate.Deleted = isValueExists.Deleted;
                            Entities.tblSMSTemplates.Add(tblSMSTemplate);
                            Entities.Entry(tblSMSTemplate).State = EntityState.Modified;
                            Entities.SaveChanges();
                            Result.DisplayMessage = "SMS Template Updated Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "SMS Template Name already exists";
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
        public Templates SaveEmailTemplate(Templates templates, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    string RoleName = (from u in Entities.tblSysUsers
                                       join role in Entities.tblSysRoles on u.RoleID equals role.RoleID
                                       where u.UserID.ToString() == UserID
                                       select role.RoleName).FirstOrDefault();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    var isValueExists = Entities.tblEmailTemplates.AsNoTracking().Where(i => i.ID == templates.ID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        var IsNameExists = Entities.tblEmailTemplates.AsNoTracking().Where(i => i.TemplateName.ToLower().Trim() == templates.TemplateName.ToLower().Trim()).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblEmailTemplate tblEmailTemplate = new tblEmailTemplate();
                            tblEmailTemplate.TemplateName = templates.TemplateName;
                            tblEmailTemplate.TemplateBody = templates.TemplateBody;
                            tblEmailTemplate.OrgID = OrgID;
                            tblEmailTemplate.CreatedBy = Convert.ToInt32(UserID);
                            tblEmailTemplate.CreatedDate = DateTimeNow;
                            tblEmailTemplate.TemplateSubject = templates.TemplateSubject;
                            if (RoleName.ToLower() == "admin")
                                tblEmailTemplate.IsActive = 1;
                            else
                                tblEmailTemplate.IsActive = 0;
                            tblEmailTemplate.Deleted = 0;
                            Entities.tblEmailTemplates.Add(tblEmailTemplate);
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Email Template Saved Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Email Template Name already exists";
                            return Result;
                        }
                    }
                    else
                    {
                        var IsNameExists = Entities.tblEmailTemplates.AsNoTracking().Where(i => i.TemplateName.ToLower().Trim() == templates.TemplateName.ToLower().Trim() && i.ID != templates.ID).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblEmailTemplate tblEmailTemplate = new tblEmailTemplate();
                            tblEmailTemplate.ID = templates.ID;
                            tblEmailTemplate.TemplateName = templates.TemplateName;
                            tblEmailTemplate.TemplateBody = templates.TemplateBody;
                            tblEmailTemplate.OrgID = OrgID;
                            tblEmailTemplate.CreatedBy = Convert.ToInt32(UserID);
                            tblEmailTemplate.CreatedDate = DateTimeNow;
                            tblEmailTemplate.TemplateSubject = templates.TemplateSubject;
                            if (RoleName.ToLower() == "admin")
                                tblEmailTemplate.IsActive = 1;
                            else
                                tblEmailTemplate.IsActive = 0;
                            tblEmailTemplate.Deleted = isValueExists.Deleted;
                            Entities.tblEmailTemplates.Add(tblEmailTemplate);
                            Entities.Entry(tblEmailTemplate).State = EntityState.Modified;
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Email Template Updated Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Email Template Name already exists";
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
        public Templates SaveWhatsappTemplate(Templates templates, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    string RoleName = (from u in Entities.tblSysUsers
                                       join role in Entities.tblSysRoles on u.RoleID equals role.RoleID
                                       where u.UserID.ToString() == UserID
                                       select role.RoleName).FirstOrDefault();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    var isValueExists = Entities.tblWhatsappTemplates.AsNoTracking().Where(i => i.ID == templates.ID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        var IsNameExists = Entities.tblWhatsappTemplates.AsNoTracking().Where(i => i.TemplateName.ToLower().Trim() == templates.TemplateName.ToLower().Trim()).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblWhatsappTemplate tblWhatsappTemplate = new tblWhatsappTemplate();
                            tblWhatsappTemplate.TemplateName = templates.TemplateName;
                            tblWhatsappTemplate.TemplateBody = templates.TemplateBody;
                            tblWhatsappTemplate.OrgID = OrgID;
                            tblWhatsappTemplate.CreatedBy = Convert.ToInt32(UserID);
                            tblWhatsappTemplate.CreatedDate = DateTimeNow;
                            tblWhatsappTemplate.TemplateSubject = templates.TemplateSubject;
                            if (RoleName.ToLower() == "admin")
                                tblWhatsappTemplate.IsActive = 1;
                            else
                                tblWhatsappTemplate.IsActive = 0;
                            tblWhatsappTemplate.Deleted = 0;
                            Entities.tblWhatsappTemplates.Add(tblWhatsappTemplate);
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Whatsapp Template Saved Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Whatsapp Template Name already exists";
                            return Result;
                        }
                    }
                    else
                    {
                        var IsNameExists = Entities.tblWhatsappTemplates.AsNoTracking().Where(i => i.TemplateName.ToLower().Trim() == templates.TemplateName.ToLower().Trim() && i.ID != templates.ID).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblWhatsappTemplate tblWhatsappTemplate = new tblWhatsappTemplate();
                            tblWhatsappTemplate.ID = templates.ID;
                            tblWhatsappTemplate.TemplateName = templates.TemplateName;
                            tblWhatsappTemplate.TemplateBody = templates.TemplateBody;
                            tblWhatsappTemplate.OrgID = OrgID;
                            tblWhatsappTemplate.CreatedBy = Convert.ToInt32(UserID);
                            tblWhatsappTemplate.CreatedDate = DateTimeNow;
                            tblWhatsappTemplate.TemplateSubject = templates.TemplateSubject;
                            if (RoleName.ToLower() == "admin")
                                tblWhatsappTemplate.IsActive = 1;
                            else
                                tblWhatsappTemplate.IsActive = 0;
                            tblWhatsappTemplate.Deleted = isValueExists.Deleted;
                            Entities.tblWhatsappTemplates.Add(tblWhatsappTemplate);
                            Entities.Entry(tblWhatsappTemplate).State = EntityState.Modified;
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Whatsapp Template Updated Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Whatsapp Template Name already exists";
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
        public List<Templates> GetSMSTemplates(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Templates> smsTemplates = new List<Templates>();

                    smsTemplates = (from b in Entities.tblSMSTemplates
                                    where b.OrgID == OrgID && b.Deleted != 1
                                    select new Templates
                                    {
                                        ID = b.ID,
                                        TemplateName = b.TemplateName,
                                        CreatedBy = b.CreatedBy,
                                        CreatedDate = b.CreatedDate,
                                        Deleted = b.Deleted,
                                        IsActive = b.IsActive,
                                        Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                        OrgID = b.OrgID,
                                        TemplateBody = b.TemplateBody,
                                    }).OrderByDescending(i => i.TemplateName).ToList();

                    return smsTemplates;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<Templates> GetEmailTemplates(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Templates> emailTemplates = new List<Templates>();

                    emailTemplates = (from b in Entities.tblEmailTemplates
                                      where b.OrgID == OrgID && b.Deleted != 1
                                      select new Templates
                                      {
                                          ID = b.ID,
                                          TemplateName = b.TemplateName,
                                          CreatedBy = b.CreatedBy,
                                          CreatedDate = b.CreatedDate,
                                          Deleted = b.Deleted,
                                          IsActive = b.IsActive,
                                          Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                          OrgID = b.OrgID,
                                          TemplateBody = b.TemplateBody,
                                      }).OrderByDescending(i => i.TemplateName).ToList();

                    return emailTemplates;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<Templates> GetWhatsappTemplates(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Templates> whatsappTemplates = new List<Templates>();

                    whatsappTemplates = (from b in Entities.tblWhatsappTemplates
                                         where b.OrgID == OrgID && b.Deleted != 1
                                         select new Templates
                                         {
                                             ID = b.ID,
                                             TemplateName = b.TemplateName,
                                             CreatedBy = b.CreatedBy,
                                             CreatedDate = b.CreatedDate,
                                             Deleted = b.Deleted,
                                             IsActive = b.IsActive,
                                             Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                             OrgID = b.OrgID,
                                             TemplateBody = b.TemplateBody,
                                         }).OrderByDescending(i => i.TemplateName).ToList();

                    return whatsappTemplates;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Templates GetSMSTemplateDetails(int ID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    Templates templates = new Templates();
                    templates = (from b in Entities.tblSMSTemplates
                                 where b.ID == ID && b.Deleted != 1
                                 select new Templates
                                 {
                                     ID = b.ID,
                                     TemplateName = b.TemplateName,
                                     CreatedBy = b.CreatedBy,
                                     CreatedDate = b.CreatedDate,
                                     Deleted = b.Deleted,
                                     IsActive = b.IsActive,
                                     Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                     OrgID = b.OrgID,
                                     TemplateBody = b.TemplateBody,
                                     templateType = TemplateType.SMS,
                                 }).FirstOrDefault();
                    return templates;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Templates GetEmailTemplateDetails(int ID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    Templates templates = new Templates();
                    templates = (from b in Entities.tblEmailTemplates
                                 where b.ID == ID && b.Deleted != 1
                                 select new Templates
                                 {
                                     ID = b.ID,
                                     TemplateName = b.TemplateName,
                                     CreatedBy = b.CreatedBy,
                                     CreatedDate = b.CreatedDate,
                                     Deleted = b.Deleted,
                                     IsActive = b.IsActive,
                                     Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                     OrgID = b.OrgID,
                                     TemplateBody = b.TemplateBody,
                                     TemplateSubject = b.TemplateSubject,
                                     templateType = TemplateType.Email,
                                 }).FirstOrDefault();
                    return templates;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Templates GetWhatsappTemplateDetails(int ID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    Templates templates = new Templates();
                    templates = (from b in Entities.tblWhatsappTemplates
                                 where b.ID == ID && b.Deleted != 1
                                 select new Templates
                                 {
                                     ID = b.ID,
                                     TemplateName = b.TemplateName,
                                     CreatedBy = b.CreatedBy,
                                     CreatedDate = b.CreatedDate,
                                     Deleted = b.Deleted,
                                     IsActive = b.IsActive,
                                     Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                     OrgID = b.OrgID,
                                     TemplateBody = b.TemplateBody,
                                     TemplateSubject = b.TemplateSubject,
                                     templateType = TemplateType.Whatsapp,
                                 }).FirstOrDefault();
                    return templates;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Templates DeleteSMSTemplate(int ID, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblSMSTemplates.AsNoTracking().Where(u => u.ID == ID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        //Entities.tblSMSTemplates.Remove(Entities.tblSMSTemplates.Where(r => r.ID == ID).FirstOrDefault());
                        tblSMSTemplate tblSMSTemplate = new tblSMSTemplate();
                        tblSMSTemplate.ID = ID;
                        tblSMSTemplate.Deleted = 1;
                        Entities.tblSMSTemplates.Attach(tblSMSTemplate);
                        Entities.Entry(tblSMSTemplate).Property(s => s.Deleted).IsModified = true;
                        Entities.SaveChanges();
                        Result.DisplayMessage = "SMS Template Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Something went wrong. Please contact administrator";
                return Result;
            }
        }
        public Templates DeleteEmailTemplate(int ID, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblEmailTemplates.AsNoTracking().Where(u => u.ID == ID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        tblEmailTemplate tblEmailTemplate = new tblEmailTemplate();
                        tblEmailTemplate.ID = ID;
                        tblEmailTemplate.Deleted = 1;
                        Entities.tblEmailTemplates.Attach(tblEmailTemplate);
                        Entities.Entry(tblEmailTemplate).Property(s => s.Deleted).IsModified = true;
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Email Template Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Something went wrong. Please contact administrator";
                return Result;
            }
        }
        public Templates DeleteWhatsappTemplate(int ID, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblWhatsappTemplates.AsNoTracking().Where(u => u.ID == ID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        tblWhatsappTemplate tblWhatsappTemplate = new tblWhatsappTemplate();
                        tblWhatsappTemplate.ID = ID;
                        tblWhatsappTemplate.Deleted = 1;
                        Entities.tblWhatsappTemplates.Attach(tblWhatsappTemplate);
                        Entities.Entry(tblWhatsappTemplate).Property(s => s.Deleted).IsModified = true;
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Whatsapp Template Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Something went wrong. Please contact administrator";
                return Result;
            }
        }
        public List<Templates> GetAllTemplates(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Templates> allTemplates = new List<Templates>();

                    List<Templates> whatsappTemplates = (from b in Entities.tblWhatsappTemplates
                                                         where b.OrgID == OrgID && b.Deleted != 1 && b.IsActive != 1
                                                         select new Templates
                                                         {
                                                             ID = b.ID,
                                                             TemplateName = b.TemplateName,
                                                             CreatedBy = b.CreatedBy,
                                                             CreatedDate = b.CreatedDate,
                                                             Deleted = b.Deleted,
                                                             IsActive = b.IsActive,
                                                             Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                                             OrgID = b.OrgID,
                                                             TemplateBody = b.TemplateBody,
                                                             templateType = TemplateType.Whatsapp,
                                                             CreatedByUser = Entities.tblSysUsers.Where(u => u.UserID == b.CreatedBy).FirstOrDefault().FName,
                                                         }).OrderByDescending(i => i.TemplateName).ToList();

                    List<Templates> emailTemplates = (from b in Entities.tblEmailTemplates
                                                      where b.OrgID == OrgID && b.Deleted != 1 && b.IsActive != 1
                                                      select new Templates
                                                      {
                                                          ID = b.ID,
                                                          TemplateName = b.TemplateName,
                                                          CreatedBy = b.CreatedBy,
                                                          CreatedDate = b.CreatedDate,
                                                          Deleted = b.Deleted,
                                                          IsActive = b.IsActive,
                                                          Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                                          OrgID = b.OrgID,
                                                          TemplateBody = b.TemplateBody,
                                                          templateType = TemplateType.Email,
                                                          CreatedByUser = Entities.tblSysUsers.Where(u => u.UserID == b.CreatedBy).FirstOrDefault().FName,
                                                      }).OrderByDescending(i => i.TemplateName).ToList();

                    List<Templates> smsTemplates = (from b in Entities.tblSMSTemplates
                                                    where b.OrgID == OrgID && b.Deleted != 1 && b.IsActive != 1
                                                    select new Templates
                                                    {
                                                        ID = b.ID,
                                                        TemplateName = b.TemplateName,
                                                        CreatedBy = b.CreatedBy,
                                                        CreatedDate = b.CreatedDate,
                                                        Deleted = b.Deleted,
                                                        IsActive = b.IsActive,
                                                        Status = b.IsActive == 0 ? "Not Approved" : "Approved",
                                                        OrgID = b.OrgID,
                                                        TemplateBody = b.TemplateBody,
                                                        templateType = TemplateType.SMS,
                                                        CreatedByUser = Entities.tblSysUsers.Where(u => u.UserID == b.CreatedBy).FirstOrDefault().FName,
                                                    }).OrderByDescending(i => i.TemplateName).ToList();
                    allTemplates = allTemplates.Union(whatsappTemplates).Union(emailTemplates).Union(smsTemplates).ToList();
                    return allTemplates;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public Templates ApproveTemplate(Templates templates, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                if (templates.templateType == TemplateType.SMS)
                    Result = SaveSMSTemplate(templates, OrgID, UserID);
                else if (templates.templateType == TemplateType.Email)
                    Result = SaveEmailTemplate(templates, OrgID, UserID);
                else if (templates.templateType == TemplateType.Whatsapp)
                    Result = SaveWhatsappTemplate(templates, OrgID, UserID);
                return Result;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Error.. Please contact administrator";
                return Result;
            }
        }
        public Templates DeleteTemplate(int ID, TemplateType templateType, string OrgID, string UserID)
        {
            Templates Result = new Templates();
            try
            {
                if (templateType == TemplateType.SMS)
                    Result = DeleteSMSTemplate(ID, OrgID, UserID);
                else if (templateType == TemplateType.Email)
                    Result = DeleteEmailTemplate(ID, OrgID, UserID);
                else if (templateType == TemplateType.Whatsapp)
                    Result = DeleteWhatsappTemplate(ID, OrgID, UserID);
                return Result;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Something went wrong. Please contact administrator";
                return Result;
            }
        }
        public Templates SaveUserTemplate(tblUserTemplate tblUserTemplate)
        {
            Templates Result = new Templates();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    if (tblUserTemplate != null)
                    {
                        tblUserTemplate.CreatedDate = DateTimeNow;
                        Entities.tblUserTemplates.Add(tblUserTemplate);
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Template saved successfully";
                        return Result;
                    }
                    else
                    {
                        Result.DisplayMessage = "Invalid Template";
                        return Result;
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
    }
    public class Templates
    {
        public int ID { get; set; }
        public string OrgID { get; set; }
        [Required(ErrorMessage = "Please enter template name")]
        public string TemplateName { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Please enter message")]
        public string TemplateBody { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> Deleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public TemplateType templateType { get; set; }
        public string DisplayMessage { get; set; }
        public string Status { get; set; }
        public string TemplateSubject { get; set; }
        public string CreatedByUser { get; set; }
    }
    public enum TemplateType
    {
        Email,
        SMS,
        Whatsapp
    }
}
