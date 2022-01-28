using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class CreditSetMarginController : Controller
    {
        // GET: CreditSetMargin
        public CustomerCreations customerCreations = new CustomerCreations();
        public Margins pmargin = new Margins();
        
        public DLMargins dlMargins = new DLMargins();
        public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public int credittypeiddetail = 0;
        public string creditTypeName = "";
        public ActionResult Index(string route, string routeName)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                //credittypeid = Convert.ToInt32(route);
                creditTypeName = WBT.Common.Helper.Decrypt(routeName, "sblw-3hn8-sqoy19");

                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["UserID"].ToString()), "BranchID", "Name");

                credittypeiddetail = Convert.ToInt32(route);
                creditTypeName = WBT.Common.Helper.Decrypt(routeName, "sblw-3hn8-sqoy19");
                pmargin.CreditTypeName = creditTypeName;
                pmargin.CreditTypeID = credittypeiddetail;
                return View(pmargin);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult PreviousCreditTypeList(string route, string routeName)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            List<Margins> result = new List<Margins>();
            try
            {
                credittypeiddetail = Convert.ToInt32(route);
                result = dlMargins.GetCreditTypeMarginDetails(Session["OrgID"].ToString(), credittypeiddetail);
            }
            catch (Exception ex)
            {
            }
            return PartialView(result);
        }

        [HttpPost]
        public JsonResult InsertData(Margins marginsvalue, string route, string routeName)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            else
            {
               // credittypeid = Convert.ToInt32(route);
                // businessTypeName = Helper.Decrypt(routeName, "sblw-3hn8-sqoy19");
                // btmargin.BusinessTypeName = businessTypeName;

               // marginsvalue.CreditTypeID = credittypeid;
                marginsvalue.OrgID = Session["OrgID"].ToString();
                marginsvalue.CreatedByID = Convert.ToInt32(Session["UserID"].ToString());
                marginsvalue.CreatedByID = Convert.ToInt32(Session["UserID"].ToString());
                Margins Result = dlMargins.SaveCreditDetails(marginsvalue, marginsvalue.OrgID);
                return Json(Result);
            }
        }
    }
}