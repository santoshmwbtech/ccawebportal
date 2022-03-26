using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using WBT.Common;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(Login login)
        {
            string ResultMsg = string.Empty;
            try
            {
                login.Password = Helper.Encrypt(login.Password);
                CustomerCreations customerCreation = new CustomerCreations();
                UserLogin user = customerCreation.Login(login);
                if (user != null)
                {
                    Session["UserID"] = user.UserId;
                    Session["OrgID"] = user.OrgID;
                    Session["UserName"] = user.FName;
                    Session["IsTallyUsing"] = user.IsTallyUsing;
                    Session["FirmName"] = user.OrgName;

                    DLGetRoleCreation dlRole = new DLGetRoleCreation();
                    var role = dlRole.GetDeatil(user.RoleID);

                    Session["RoleName"] = role.RoleName;
                    FormsAuthentication.SetAuthCookie(user.UserId.ToString(), login.RememberMe);

                    DLAccessControl dL = new DLAccessControl();
                    List<AccessControlItem> MenuList = dL.LoadAccessControlItems(user.RoleID);
                    Session["MenuMaster"] = MenuList;

                    if(user.IsTallyUsing == true && user.IsServiceInstalled == false)
                    {
                        ResultMsg = "Login Success!! Please install the tally service and configure to continue..";
                        var Result = new
                        {
                            resultmsg = ResultMsg,
                            success = true,
                            IsTallyUsing = user.IsTallyUsing,
                            IsServiceInstalled = user.IsServiceInstalled
                        };
                        return Json(Result);
                    }
                    else
                    {
                        ResultMsg = "Login Success!! Please wait..";
                        var Result = new
                        {
                            resultmsg = ResultMsg,
                            success = true,
                            IsTallyUsing = user.IsTallyUsing,
                            IsServiceInstalled = user.IsServiceInstalled
                        };
                        return Json(Result);
                    }
                }
                else
                {
                    ResultMsg = "Invalid Credentials";
                    var Result = new
                    {
                        resultmsg = ResultMsg,
                        success = false,
                        IsTallyUsing = false
                    };
                    return Json(Result);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ResultMsg = "Error!! Please try again later";
                var Result = new
                {
                    resultmsg = ResultMsg,
                    success = false,
                    IsTallyUsing = false
                };
                return Json(Result);
            }
        }
        public FileResult DownloadFile()
        {
            string FilePath = Server.MapPath(ConfigurationManager.AppSettings["ExeFileName"].ToString());
            System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
            byte[] bytes = System.IO.File.ReadAllBytes(FilePath);
            return File(bytes, "application/octet-stream", file.Name);
        }
    }
}