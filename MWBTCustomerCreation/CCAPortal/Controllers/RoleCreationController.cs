using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class RoleCreationController : Controller
    {
        DLGetUserCreation dLGetUserCreation = new DLGetUserCreation();
        DLGetRoleCreation getRoleCreation = new DLGetRoleCreation();
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                
                return View(getRoleCreation.GetData().ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Create(DLRoleCreation dLRoleCreation)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {

                ViewBag.RolesList = new SelectList(dLGetUserCreation.GetRolesData(), "RoleID", "RoleName");
                ViewBag.DeptList = new SelectList(dLGetUserCreation.GetDepartments(), "DeptID", "DepartmentName");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DLRoleCreation dLRoleCreation)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                DLRoleCreation Result = getRoleCreation.SaveData(dLRoleCreation);
                //if (getRoleCreation.SaveData(dLRoleCreation))
                //{
                //    ModelState.Clear();
                //}
                //else
                //{
                //    ModelState.Clear();
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
            }
            return PartialView("RoleList", getRoleCreation.GetData().ToList());
        }
        public ActionResult RoleList()
        {
            List<DLRoleCreation> result = new List<DLRoleCreation>();
            try
            {
                result = getRoleCreation.GetData();
            }
            catch(Exception ex)
            {

            }
            return PartialView(result);
        }

        public ActionResult Edit(int RoleID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (RoleID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            DLRoleCreation obj = getRoleCreation.GetDeatil(RoleID);

            if (obj == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolesList = new SelectList(dLGetUserCreation.GetRolesData(), "RoleID", "RoleName");
            ViewBag.DeptList = new SelectList(dLGetUserCreation.GetDepartments(), "DeptID", "DepartmentName");
            return PartialView("Edit", obj);
        }
        public ActionResult Delete(int RoleID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (RoleID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLRoleCreation Result = getRoleCreation.DeleteRole(RoleID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(DLRoleCreation dLRole)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ModelState.IsValid)
            {
                DLRoleCreation Result = getRoleCreation.SaveData(dLRole);
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("RoleList", getRoleCreation.GetData().ToList()).RenderToString()
                });
            }
            else
            {
                return Json(new
                {
                    Message = "Error!!",
                    AjaxReturn = PartialView("RoleList", getRoleCreation.GetData().ToList()).RenderToString()
                });
            }
        }
        public JsonResult SearchName(string rolename)
        {
          
            bool rname = getRoleCreation.SearchRoleName(rolename);
            if (rname == true)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        [HttpPost]
        public ActionResult SearchByName(string Name)
        {
            List<DLRoleCreation> result = new List<DLRoleCreation>();
            try
            {
                result = getRoleCreation.GetData(Name);
            }
            catch (Exception ex)
            {

            }
            return PartialView("RoleList", result);
        }
        [HttpPost]
        public JsonResult LoadDeptRoles(int? DeptID)
        {
            return Json(getRoleCreation.LoadDeptRoles(DeptID), JsonRequestBehavior.AllowGet);
        }
    }
}