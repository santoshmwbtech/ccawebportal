using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class AccessControlController : Controller
    {
        // GET: AccessControl
        DLAccessControl DAL = new DLAccessControl();
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.Roles = new SelectList(DAL.GetSysRoles(), "RoleID", "RoleName");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AccessControlItemList()
        {
            if (Session["UserID"] != null)
            {
                List<AccessControlItem> itemList = new List<AccessControlItem>();
                itemList = DAL.GetItems();
                return PartialView(itemList.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult LoadAccessControlItems(int? RoleID)
        {
            if (Session["UserID"] != null)
            {
                ViewBag.Roles = new SelectList(DAL.GetSysRoles(), "RoleID", "RoleName");
                List<AccessControlItem> itemList = new List<AccessControlItem>();
                itemList = DAL.LoadAccessControlItems(RoleID);
                return PartialView("AccessControlItemList", itemList.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Save(AccessControl accessControl, List<AccessControlItem> ItemList)
        {
            if (Session["UserID"] != null)
            {
                if (ModelState.IsValid)
                {
                    accessControl.Items = ItemList;
                    AccessControl Result = DAL.SaveAccessControl(accessControl, Convert.ToInt32(Session["UserID"].ToString()));
                    ModelState.Clear();
                    ViewBag.Roles = new SelectList(DAL.GetSysRoles(), "RoleID", "RoleName");
                    List<AccessControlItem> itemList = new List<AccessControlItem>();
                    itemList = DAL.GetItems();
                    return PartialView("AccessControlItemList", itemList.ToList());
                }
                else
                {
                    List<string> Errors = new List<string>();
                    foreach (ModelState modelState in ViewData.ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            Errors.Add(error.ErrorMessage);
                        }
                    }
                    ModelState.AddModelError("", Errors.ToString());
                    return HttpNotFound("Your request did not find.");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}