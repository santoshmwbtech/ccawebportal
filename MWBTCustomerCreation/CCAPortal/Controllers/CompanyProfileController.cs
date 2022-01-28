using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CustomerCreationAdminPortal.Controllers
{
    public class CompanyProfileController : Controller
    {
        CustomerCreations customerCreations = new CustomerCreations();
        DLCompanyProfile DAL = new DLCompanyProfile();
        DLGetUserCreation dLGetUserCreation = new DLGetUserCreation();
        // GET: CompanyProfile
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");                
                ViewBag.CountryList = new SelectList(customerCreations.GetCountryList(), "CountryID", "CountryName");
                SysOrganization sysOrganization = DAL.GetOrganizationDetails(Session["UserID"].ToString());
                sysOrganization.Country = "79";
                return View(sysOrganization);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult UpdateProfile(SysOrganization organization)
        {
            SysOrganization Result = new SysOrganization();
            Result = DAL.UpdateOrganizationDetails(organization);
            return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        }
    }
}