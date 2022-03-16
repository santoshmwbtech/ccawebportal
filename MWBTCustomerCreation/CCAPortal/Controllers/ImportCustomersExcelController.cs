using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class ImportCustomersExcelController : Controller
    {
        // GET: ImportCustomersExcelController
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                CustomerCreations customerCreations = new CustomerCreations();
                ViewBag.OrgList = new SelectList(customerCreations.GetBranchList(Session["OrgID"].ToString()), "BranchID", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadExcel(CustomerCreation customer, HttpPostedFileBase postedExcelFile)
        {
            List<string> data = new List<string>();
            if (postedExcelFile != null)
            {
                CustomerCreations DL = new CustomerCreations();
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");  
                if (postedExcelFile.ContentType == "application/vnd.ms-excel" || postedExcelFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = postedExcelFile.FileName;
                    string targetpath = Server.MapPath("~/Uploads/");
                    postedExcelFile.SaveAs(targetpath + filename);
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
                    var customerExcels = from customers in excelFile.Worksheet<CustomerCreation>(sheetName) select customers;
                    List<CustomerCreation> customerExcelFiles = customerExcels.Where(d => !string.IsNullOrEmpty(d.FirmName)).ToList();

                    string UserID = Session["UserID"].ToString();
                    List<CustomerCreation> Result = DL.ImportExcel(customerExcelFiles, UserID, customer.BranchID, Session["OrgID"].ToString());

                    if (Result != null && Result.Count() > 0)
                    {
                        data.Add("<ul>");
                        foreach (var item in Result)
                        {
                            data.Add("<li>" + item.FirmName + " -- " + item.DisplayMessage + "</li>");
                        }
                        data.Add("</ul>");
                        data.ToArray();
                        var jsonResult = new
                        {
                            success = false,
                            data = data,
                        };
                        return Json(jsonResult, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var jsonResult = new
                        {
                            success = true,
                            data = data,
                        };
                        return Json(jsonResult, JsonRequestBehavior.AllowGet);
                    }
                        
                }
                else
                {
                    //alert message for invalid file format  
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    var jsonResult = new
                    {
                        success = false,
                        data = data
                    };
                    return Json(jsonResult, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (postedExcelFile == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                var jsonResult = new
                {
                    success = false,
                    data = data
                };
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
        }
    }
}