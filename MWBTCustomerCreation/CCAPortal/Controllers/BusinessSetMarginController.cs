using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.Common;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class BusinessSetMarginController : Controller
    {
        public CustomerCreations customerCreations = new CustomerCreations();
        public Margins pmargin = new Margins();
        public BusinessTypeProperties btmargin = new BusinessTypeProperties();
        public DLMargins dlMargins = new DLMargins();
        public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public int businesstypeid = 0;
        public string businessTypeName = "";
        // GET: BusinessSetMargin
        public ActionResult Index(string route, string routeName)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                businesstypeid = Convert.ToInt32(route);
                businessTypeName = Helper.Decrypt(routeName, "sblw-3hn8-sqoy19");

                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["UserID"].ToString()), "BranchID", "Name");

                businesstypeid = Convert.ToInt32(route);
                businessTypeName = Helper.Decrypt(routeName, "sblw-3hn8-sqoy19");
                btmargin.BusinessTypeName = businessTypeName;
                btmargin.BusinessTypeID = businesstypeid;
                return View(btmargin);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LoadDetails(string route, string routeName)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {


                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["UserID"].ToString()), "BranchID", "Name");

                businesstypeid = Convert.ToInt32(route);
                businessTypeName = Helper.Decrypt(routeName, "sblw-3hn8-sqoy19");
                pmargin.BusinessTypeName = businessTypeName;

                return PartialView(pmargin);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

       [HttpPost]
        public JsonResult InsertData(BusinessTypeProperties marginsvalue)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            else
            {
                //businesstypeid = Convert.ToInt32(route);
                //businessTypeName = Helper.Decrypt(routeName, "sblw-3hn8-sqoy19");
                //btmargin.BusinessTypeName = businessTypeName;

                //marginsvalue.BusinessTypeID = businesstypeid;
                marginsvalue.OrgID = Session["OrgID"].ToString();
                marginsvalue.CreatedByID = Convert.ToInt32(Session["UserID"].ToString());
                BusinessTypeProperties Result = dlMargins.SaveBusinessMarginData(marginsvalue, marginsvalue.OrgID);
                return Json(Result); 
            }
        }

        
        public ActionResult PreviousBusinessTypeList(string route, string routeName)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            List<Margins> result = new List<Margins>();
            try
            {
                businesstypeid = Convert.ToInt32(route);
                result = dlMargins.GetBusinessTypeMarginDetails(Session["OrgID"].ToString(),businesstypeid);
            }
            catch (Exception ex)
            {
            }
            return PartialView(result);
        }

        //[HttpPost]
        //public ActionResult valu(Margins marginsvalues)
        //{
        //    if (Session["UserID"] == null || Session["OrgID"] == null)
        //    {
        //        return Json("error", JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        marginsvalues.OrgID = Session["OrgID"].ToString();
        //        marginsvalues.CreatedByID = Convert.ToInt32(Session["UserID"].ToString());
        //        Margins Result = dlMargins.SaveBusinessMarginData(marginsvalues, marginsvalues.OrgID);
        //        return Json(Result.DisplayMessage);
        //    }
        //}

    }
}