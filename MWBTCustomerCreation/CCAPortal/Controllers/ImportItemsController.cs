using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.Common;
using WBT.DLCustomerCreation;
using WBT.DLCustomerCreation.DTOs;

namespace CCAPortal.Controllers
{
    public class ImportItemsController : Controller
    {
        // GET: ImportItems
        private readonly DLItem _itemRepository = new DLItem();
        //public ImportItemsController(DLItem itemRepository)
        //{
        //    _itemRepository = itemRepository;
        //}
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadExcel(HttpPostedFileBase readExcelFile)
        {
            List<string> result = new List<string>();
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {   
                try
                {
                    if (readExcelFile != null)
                    {
                        if (readExcelFile.ContentType == "application/vnd.ms-excel" || readExcelFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            string filename = readExcelFile.FileName;
                            string targetpath = Server.MapPath("~/Uploads/");
                            readExcelFile.SaveAs(targetpath + filename);
                            string pathToExcelFile = targetpath + filename;
                            var connectionString = "";
                            if (filename.EndsWith(".xls"))
                            {
                                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                            }
                            else if (filename.EndsWith(".xlsx"))
                            {
                                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                            }

                            var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                            var ds = new DataSet();

                            adapter.Fill(ds, "ExcelTable");
                            DataTable dtable = ds.Tables["ExcelTable"];
                            string sheetName = "Sheet1";

                            var excelFile = new ExcelQueryFactory(pathToExcelFile);
                            var itemExcel = from debtors in excelFile.Worksheet<ItemDTO>(sheetName) select debtors;
                            List<ItemDTO> items = itemExcel.ToList();
                            items = items.Where(d => !string.IsNullOrEmpty(d.ItemName)).ToList();
                            string userID = Session["UserID"].ToString();
                            List<ItemDTO> Result = _itemRepository.ImportExcel(items, userID, Session["OrgID"].ToString());

                            if (Result != null && Result.Count() > 0)
                            {
                                result.Add("<ul>");
                                foreach (var item in Result)
                                {
                                    result.Add("<li><b>" + item.ItemName + " </b>-- " + item.Status + "</li>");
                                }
                                result.Add("</ul>");
                                result.ToArray();
                                var jsonResult = new
                                {
                                    success = false,
                                    data = result
                                };
                                return Json(jsonResult, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                result.Add("<ul>");
                                result.Add("<li><b>Success</li>");
                                result.Add("</ul>");
                                result.ToArray();
                                var jsonResult = new
                                {
                                    success = true,
                                    data = result
                                };
                                return Json(result, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            //alert message for invalid file format  
                            result.Add("<ul>");
                            result.Add("<li>Only Excel file format is allowed</li>");
                            result.Add("</ul>");
                            result.ToArray();
                            var jsonResult = new
                            {
                                success = false,
                                data = result
                            };
                            return Json(jsonResult, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        result.Add("<ul>");
                        if (readExcelFile == null) result.Add("<li>Please choose Excel file</li>");
                        result.Add("</ul>");
                        result.ToArray();
                        var jsonResult = new
                        {
                            success = false,
                            data = result
                        };
                        return Json(jsonResult, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                    result.Add("<ul>");
                    result.Add("<li>" + ex.Message + "</li>");
                    result.Add("</ul>");
                    result.ToArray();
                    var jsonResult = new
                    {
                        success = false,
                        data = result
                    };
                    return Json(jsonResult, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("sessionexpired");
            }
        }
    }
}