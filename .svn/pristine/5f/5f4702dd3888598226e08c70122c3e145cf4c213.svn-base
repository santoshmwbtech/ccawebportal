using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;
using WBT.Entity;

namespace CCAPortal.Content
{
    public class TemplatesController : Controller
    {
        // GET: Templates
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public JsonResult Save(string data, string Title)
        {
            if(Session["UserID"] != null)
            {
                try
                {
                    data = data.Substring(data.IndexOf(",") + 1);
                    string DirectoryPath = "~/UserTemplates/";
                    var ImagePath = Path.Combine(Server.MapPath(DirectoryPath), Title);
                    bool exists = System.IO.Directory.Exists(Server.MapPath(DirectoryPath));
                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                    }
                    byte[] bytes = Convert.FromBase64String(data);
                    var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".jpeg";
                    var fullPath = Path.Combine(Server.MapPath("~/UserTemplates/"), randomFileName);

                    MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
                    ms.Write(bytes, 0, bytes.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    image.Save(fullPath);
                    tblUserTemplate tblUserTemplate = new tblUserTemplate();
                    tblUserTemplate.TemplateName = Title;
                    tblUserTemplate.TemplateURL = fullPath;
                    tblUserTemplate.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    tblUserTemplate.TemplateName = Title;
                    DLTemplates DAL = new DLTemplates();
                    string ResultMsg = DAL.SaveUserTemplate(tblUserTemplate).DisplayMessage;
                    var Result = new
                    {
                        success = true,
                        redirect = "Templates",
                        message = ResultMsg,
                        imageurl = fullPath
                    };
                    return Json(Result);
                }
                catch (Exception ex)
                {
                    var Result = new
                    {
                        success = false,
                        redirect = "Templates",
                        message = "Error!! Please contact administrator",
                        imageurl = ""
                    };
                    return Json(Result);
                }
            }
            else
            {
                var Result = new
                {
                    success = false,
                    redirect = "Login",
                    message = "Session Expired",
                    imageurl = ""
                };
                return Json(Result);
            }
        }
        public ActionResult DownloadFile(string FilePath)
        {
            string filename = Path.GetFileName(FilePath);
            return File(FilePath, "application/octet-stream", filename);
        }
    }
}