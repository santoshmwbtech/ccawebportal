using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;
using WBT.DLCustomerCreation.Reports;

namespace CCAPortal.Controllers
{

    public class UserCreationController : Controller
    {
        // GET: UserCreation
        DLGetUserCreation getUser = new DLGetUserCreation();
        DLGetUserCreation dLGetUserCreation = new DLGetUserCreation();
        CustomerCreations customerCreations = new CustomerCreations();
        DLBranchCreation DLBranch = new DLBranchCreation();
        DLRouteMapping dLRouteMappingData = new DLRouteMapping();
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {

                return View(getUser.GetData(Session["OrgID"].ToString()).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Create(DLUserCreation dLUserCreation)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.StateList = new SelectList(customerCreations.GetRegisteredStates(Session["OrgID"].ToString()), "StateID", "StateName");
                ViewBag.RolesList = new SelectList(getUser.GetRolesData(), "RoleID", "RoleName");
                ViewBag.BranchList = new SelectList(getUser.GetBranchData(Session["OrgID"].ToString()), "BranchID", "BranchName");
                ViewBag.WareHouseList = new SelectList(getUser.GetWarehouseData(Session["OrgID"].ToString()), "WarehouseID", "WarehouseName");
                ViewBag.CountryList = new SelectList(customerCreations.GetCountryList(), "CountryID", "CountryName");
                ViewBag.ParentUsers = new SelectList(dLGetUserCreation.GetParentUsersOfaRole(0, Session["OrgID"].ToString()), "UserID", "Fname");
                ViewBag.DeptList = new SelectList(dLGetUserCreation.GetDepartments(), "DeptID", "DepartmentName");
                DLUserCreation dLUser = new DLUserCreation();
                dLUser.CountryID = 79;
                dLUser.IsActive = true;

                ViewBag.DocTypes = new SelectList(
                                    new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Aadhaar Card", Value = "Aadhaar Card" },
                                        new SelectListItem { Text = "PAN Card", Value = "PAN Card"},
                                        new SelectListItem { Text = "Driving License", Value = "Driving License"},
                                        new SelectListItem { Text = "RC Book", Value = "RC Book"},
                                        new SelectListItem { Text = "Other", Value = "Other"},
                                    }, "Value", "Text");

                List<UserDocs> userDocs = new List<UserDocs> { new UserDocs { DocumentType = "", DocumentNumber = "", DocFile = null } };
                dLUser.userDocs = userDocs;
                return PartialView(dLUser);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Search()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.RolesList = new SelectList(getUser.GetRolesData(), "RoleID", "RoleName");
                ViewBag.SalesmanList = new SelectList(getUser.GetData(Session["OrgID"].ToString()), "UserID", "Username");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DLUserCreation dLUserCreation)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                string OrgID = Session["OrgID"].ToString();
                int LoginUserID = Convert.ToInt32(Session["UserID"]);

                if(dLUserCreation.userDocs != null && dLUserCreation.userDocs.Count() > 0)
                {
                    foreach (var item in dLUserCreation.userDocs)
                    {
                        byte[] thePictureAsBytes = new byte[item.DocFile.ContentLength];
                        using (BinaryReader theReader = new BinaryReader(item.DocFile.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(item.DocFile.ContentLength);
                        }
                        item.DocBase64 = Convert.ToBase64String(thePictureAsBytes);
                    }
                }
                //dLUserCreation.customers = dLUserCreation.CustomerDetails.customers;

                if (Convert.ToBoolean(getUser.SaveData(dLUserCreation, LoginUserID, OrgID)))
                {
                    ModelState.Clear();
                }
                else
                {
                    ModelState.Clear();
                    return HttpNotFound();
                }
            }
            return PartialView("UserList", getUser.GetData(Session["OrgID"].ToString()).ToList());
        }
        public ActionResult UserList()
        {
            List<DLUserCreation> result = new List<DLUserCreation>();
            try
            {
                result = getUser.GetData(Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {

            }
            return PartialView(result);
        }
        public ActionResult Edit(int UserID)
        {
            SelectList MySelectList = new SelectList(new List<string>());

            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (UserID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.StateList = new SelectList(customerCreations.GetRegisteredStates(Session["OrgID"].ToString()), "StateID", "StateName");
            ViewBag.RolesList = new SelectList(getUser.GetRolesData(), "RoleID", "RoleName");
            ViewBag.BranchList = new SelectList(getUser.GetBranchData(Session["OrgID"].ToString()), "BranchID", "BranchName");
            ViewBag.WareHouseList = new SelectList(getUser.GetWarehouseData(Session["OrgID"].ToString()), "WarehouseID", "WarehouseName");
            ViewBag.CountryList = new SelectList(customerCreations.GetCountryList(), "CountryID", "CountryName");
            ViewBag.DeptList = new SelectList(dLGetUserCreation.GetDepartments(), "DeptID", "DepartmentName");

            DLUserCreation user = getUser.GetUserDeatils(UserID);
            //int StateID = obj.State == null ? 0 : obj.State.Value;

            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentUsers = new SelectList(dLGetUserCreation.GetParentUsersOfaRole(user.RoleID, Session["OrgID"].ToString()), "UserID", "Fname");
            ViewBag.CityList = new SelectList(dLGetUserCreation.SearchByCityName(user.State, user.CityName), "CityID", "CityName");

            string States = string.Join(",", user.StateList);
            string Districts = string.Join(",", user.DistrictList);
            string Cities = string.Join(",", user.CityList);
            ViewBag.States = ViewBag.StateList;
            ViewBag.Districts = new SelectList(dLGetUserCreation.GetDistrictsOfState(States, Session["OrgID"].ToString()).districts, "DistrictID", "DistrictName");
            ViewBag.Cities = new SelectList(dLGetUserCreation.GetCitiesOfDistrict(Districts, Session["OrgID"].ToString()).cities, "CityID", "CityName");
            ViewBag.Areas = new SelectList(dLGetUserCreation.GetAreasofCity(Cities, Session["OrgID"].ToString()).areaLists, "BillingArea", "BillingArea");

            //List<DLUserCreation> AssignableUsers = dLGetUserCreation.GetUserDetailsByRoleIdWise(obj.RoleID);
            //List<DLUserCreation> Assignedusers = getUser.GetAssignedUsersByUserID(UserID);
            //ViewBag.DopdownList = obj.UnderSysRolelist;
            ViewBag.DocTypes = new SelectList(
                                    new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Aadhaar Card", Value = "Aadhaar Card" },
                                        new SelectListItem { Text = "PAN Card", Value = "PAN Card"},
                                        new SelectListItem { Text = "Driving License", Value = "Driving License"},
                                        new SelectListItem { Text = "RC Book", Value = "RC Book"},
                                        new SelectListItem { Text = "Other", Value = "Other"},
                                    }, "Value", "Text");

            if(user.userDocs == null || user.userDocs.Count() <= 0)
            {
                List<UserDocs> userDocs = new List<UserDocs> { new UserDocs { DocumentType = "", DocumentNumber = "", DocFile = null } };
                user.userDocs = userDocs;
            }

            return PartialView("Edit", user);
        }
        public ActionResult Delete(int UserID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (UserID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string Result = dLGetUserCreation.DeleteUser(UserID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(DLUserCreation dluser)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                string OrgID = Session["OrgID"].ToString();
                int LoginUserID = Convert.ToInt32(Session["UserID"]);

                if (dluser.userDocs != null && dluser.userDocs.Count() > 0)
                {
                    foreach (var item in dluser.userDocs)
                    {
                        if(item.DocFile != null)
                        {
                            byte[] thePictureAsBytes = new byte[item.DocFile.ContentLength];
                            using (BinaryReader theReader = new BinaryReader(item.DocFile.InputStream))
                            {
                                thePictureAsBytes = theReader.ReadBytes(item.DocFile.ContentLength);
                            }
                            item.DocBase64 = Convert.ToBase64String(thePictureAsBytes);
                        }
                        else
                        {
                            item.DocBase64 = item.Base64Str;
                        }
                    }
                }

                if (Convert.ToBoolean(getUser.EditData(dluser, LoginUserID, OrgID)))
                {
                    ModelState.Clear();
                    return PartialView("UserList", getUser.GetData(Session["OrgID"].ToString()).ToList());
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public JsonResult SearchUserName(string username)
        {

            bool uname = getUser.SearchUserName(username);
            if (uname == true)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        [HttpPost]
        public JsonResult AssignedUnderUsers(int Userid)
        {

            return Json(dLGetUserCreation.GetAssignableUsersByUserID(Userid));

        }
        [HttpPost]
        public JsonResult AssigningUnderUsers(int underroleid)
        {

            return Json(dLGetUserCreation.GetUserDetailsByRoleIdWise(underroleid));

        }
        [HttpPost]
        public JsonResult AssignedUsersByUserID(int UserID)
        {

            return Json(getUser.GetAssignedUsersByUserID(UserID));

        }
        [HttpPost]
        public JsonResult AssigningCities(int? StateID)
        {
            if (StateID == null)
                StateID = 0;
            var jsonResult = Json(customerCreations.GetCities(StateID.Value), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public JsonResult SearchByName(string searchTerm)
        {
            var jsonResult = Json(dLGetUserCreation.GetCities(0, searchTerm), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public JsonResult GetParentUsers(int? RoleID)
        {
            var jsonResult = Json(dLGetUserCreation.GetParentUsersOfaRole(RoleID, Session["OrgID"].ToString()), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public JsonResult StateChanged(string StateList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ACLists aCLists = new ACLists();
                aCLists = dLGetUserCreation.GetDistrictsOfState(StateList, Session["OrgID"].ToString());

                var list = (from c in aCLists.districts
                            select new
                            {
                                label = c.DistrictName,
                                value = c.DistrictID
                            }).ToList();

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult DistrictChanged(string DistrictList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ACLists aCLists = new ACLists();
                aCLists = dLGetUserCreation.GetCitiesOfDistrict(DistrictList, Session["OrgID"].ToString());
                return Json(aCLists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult CityChanged(string CityList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return Json(dLGetUserCreation.GetAreasofCity(CityList, Session["OrgID"].ToString()), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public ActionResult AreaChanged(string StateList, string DistrictList, string CityList, string AreaList)
        {
            List<CustomerVendorDetails> CustomerList = new List<CustomerVendorDetails>();
            CustomerList = dLGetUserCreation.GetCustomersofArea(StateList, DistrictList, CityList, AreaList, Session["OrgID"].ToString());
            DLUserCreation dLUser = new DLUserCreation();
            dLUser.customers = CustomerList;
            return PartialView("CVList", dLUser);
        }

        [HttpPost]
        public JsonResult DocTypeLoad()
        {
            SelectList DocTypes = new SelectList(
                                    new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Aadhaar Card", Value = "Aadhaar Card" },
                                        new SelectListItem { Text = "PAN Card", Value = "PAN Card"},
                                        new SelectListItem { Text = "Driving License", Value = "Driving License"},
                                        new SelectListItem { Text = "RC Book", Value = "RC Book"},
                                        new SelectListItem { Text = "Other", Value = "Other"},
                                    }, "Value", "Text");

            return Json(DocTypes, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CheckDuplicateNumber(string MobileNumber)
        {
            return Json(dLGetUserCreation.CheckDuplicateNumber(MobileNumber), JsonRequestBehavior.AllowGet);
        }
    }
}