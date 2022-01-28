using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;
using WBT.DLCustomerCreation.Reports;

namespace CCAPortal.Controllers
{
    public class promotionController : Controller
    {
        DLTemplates dLTemplates = new DLTemplates();
        DLPromotion dLPromotion = new DLPromotion();
        DLGetCustomerCreationReport dLCustomerCreationReport = new DLGetCustomerCreationReport();
        // GET: promotion
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                CustomerPromotion customerPromotion = new CustomerPromotion();
                customerPromotion.TotalCustomers = dLCustomerCreationReport.GetAllCustomerList(Session["OrgID"].ToString());
                ViewBag.SMSTemplates = new SelectList(dLTemplates.GetSMSTemplates(Session["OrgID"].ToString()), "ID", "TemplateName");
                ViewBag.EmailTemplates = new SelectList(dLTemplates.GetEmailTemplates(Session["OrgID"].ToString()), "ID", "TemplateName");
                ViewBag.WhatsappTemplates = new SelectList(dLTemplates.GetWhatsappTemplates(Session["OrgID"].ToString()), "ID", "TemplateName");
                return View(customerPromotion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public JsonResult GetSMSTemplate(int? TemplateID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                var SMSTemplate = dLTemplates.GetSMSTemplateDetails(TemplateID.Value);
                return Json(SMSTemplate, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult GetEmailTemplate(int? TemplateID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                var EmailTemplate = dLTemplates.GetEmailTemplateDetails(TemplateID.Value);
                return Json(EmailTemplate, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
    }
}