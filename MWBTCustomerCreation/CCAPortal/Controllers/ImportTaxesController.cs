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
    public class ImportTaxesController : Controller
    {
        // GET: ImportTaxes
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
        public JsonResult UploadExcel(CustomerCreation customer, HttpPostedFileBase ExcelFile)
        {
            List<string> data = new List<string>();
            try
            {
                if (ExcelFile != null)
                {
                    DLTaxLedgers dlTaxLedgers = new DLTaxLedgers();
                    if (ExcelFile.ContentType == "application/vnd.ms-excel" || ExcelFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        string filename = ExcelFile.FileName;
                        string targetpath = Server.MapPath("~/Uploads/");
                        ExcelFile.SaveAs(targetpath + filename);
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
                        var taxLedgerExcels = from debtors in excelFile.Worksheet<TaxLedgersDTO>(sheetName) select debtors;
                        List<TaxLedgersDTO> taxLedgersExcelFiles = taxLedgerExcels.ToList();
                        taxLedgersExcelFiles = taxLedgersExcelFiles.Where(d => !string.IsNullOrEmpty(d.Name)).ToList();
                        string UserID = Session["UserID"].ToString();
                        List<TaxLedgersDTO> Result = dlTaxLedgers.ImportExcel(taxLedgersExcelFiles, UserID, Session["OrgID"].ToString());

                        if (Result != null && Result.Count() > 0)
                        {
                            data.Add("<ul>");
                            foreach (var item in Result)
                            {
                                data.Add("<li><b>" + item.Name + " </b>-- " + item.DisplayMsg + "</li>");
                            }
                            data.Add("</ul>");
                            data.ToArray();
                            var jsonResult = new
                            {
                                success = false,
                                data = data
                            };
                            return Json(jsonResult, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            data.Add("<ul>");
                            data.Add("<li><b>Success</li>");
                            data.Add("</ul>");
                            data.ToArray();
                            var jsonResult = new
                            {
                                success = true,
                                data = data
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
                    if (ExcelFile == null) data.Add("<li>Please choose Excel file</li>");
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
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                data.Add("<ul>");
                data.Add("<li>" + ex.Message + "</li>");
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