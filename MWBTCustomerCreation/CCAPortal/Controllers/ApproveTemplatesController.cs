using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.Common;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class ApproveTemplatesController : Controller
    {
        DLTemplates dLTemplates = new DLTemplates();
        // GET: ApproveTemplates
        public ActionResult Index(string route, string type)
        {
            if (Session["UserID"] != null && !string.IsNullOrEmpty(route) && !string.IsNullOrEmpty(type) && Session["OrgID"] != null)
            {
                Templates templates = new Templates();
                string templateType = Helper.Decrypt(type, "sblw-3hn8-sqoy19");
                int ID = Convert.ToInt32(Helper.Decrypt(route, "sblw-3hn8-sqoy19"));
                TemplateType enumTemplateType = (TemplateType) Enum.Parse(typeof(TemplateType), templateType);
                if (enumTemplateType == TemplateType.Email)
                    templates = dLTemplates.GetEmailTemplateDetails(ID);
                else if(enumTemplateType == TemplateType.SMS)
                    templates = dLTemplates.GetSMSTemplateDetails(ID);
                else
                    templates = dLTemplates.GetWhatsappTemplateDetails(ID);
                return View(templates);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Templates templates)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                Templates Result = dLTemplates.ApproveTemplate(templates, Session["OrgID"].ToString(), Session["UserID"].ToString());
                return Json(Result.DisplayMessage);
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new { allErrors });
            }
        }
        [HttpPost]
        public JsonResult DeleteTemplate(int? ID, TemplateType templateType)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json("sessionexpired");
            }
            Templates Result = dLTemplates.DeleteTemplate(ID.Value, templateType, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result.DisplayMessage);
        }
    }
}