using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using WBT.DLCustomerCreation;
using WBT.Entity;
using System.Net;
using System.IO;

namespace CCAPortal.Controllers
{
    public class BranchCreationController : Controller
    {
        DLBranchCreation dLBranchCreation = new DLBranchCreation();
        CustomerCreations customerCreations = new CustomerCreations();
        DLSalesChannelType dLSalesChannelType = new DLSalesChannelType();
        public ActionResult Index()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult BranchCreate()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
            ViewBag.CompanyList = new SelectList(customerCreations.GetOrgList(), "OrgID", "Name");

            BranchDetails branchDetails = new BranchDetails();
            List<QRDocs> qrDocs = new List<QRDocs> { new QRDocs { DocumentType = "", DocFile = null } };
            branchDetails.qrDocs = qrDocs;

            return PartialView(branchDetails);
        }
        public ActionResult BranchDisplayList()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            return PartialView(dLBranchCreation.GetBranchDetailsList(Session["OrgID"].ToString()).ToList());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBranchDetails(BranchDetails branchDetails)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                //List<string> OtherDocs = new List<string>();

                //foreach (HttpPostedFileBase postedFile in branchDetails.DocumentFiles)
                //{
                //    if (postedFile != null)
                //    {
                //        byte[] thePictureAsBytes = new byte[postedFile.ContentLength];
                //        using (BinaryReader theReader = new BinaryReader(postedFile.InputStream))
                //        {
                //            thePictureAsBytes = theReader.ReadBytes(postedFile.ContentLength);
                //        }
                //        string Base64ImageString = Convert.ToBase64String(thePictureAsBytes);
                //        OtherDocs.Add(Base64ImageString);
                //    }
                //}
                //branchDetails.Documents = OtherDocs;

                if (branchDetails.qrDocs != null && branchDetails.qrDocs.Count() > 0)
                {
                    foreach (var item in branchDetails.qrDocs)
                    {
                        byte[] thePictureAsBytes = new byte[item.DocFile.ContentLength];
                        using (BinaryReader theReader = new BinaryReader(item.DocFile.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(item.DocFile.ContentLength);
                        }
                        item.DocBase64 = Convert.ToBase64String(thePictureAsBytes);
                    }
                }

                if (dLBranchCreation.SaveBranch(branchDetails, Session["UserID"].ToString(), Session["OrgID"].ToString()))
                {
                    ModelState.Clear();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {

                    }
                }
            }
            return PartialView("BranchDisplayList", dLBranchCreation.GetBranchDetailsList(Session["OrgID"].ToString()).ToList());
        }

        public ActionResult EditBranchDetails(string BranchID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (BranchID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchDetails obj = dLBranchCreation.GetBranchDetail(BranchID);
            int StateID = obj.BranchState.Value;
            ViewBag.CityList = new SelectList(customerCreations.GetCities(StateID), "StateWithCityID", "VillageLocalityName");
            ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
            ViewBag.CompanyList = new SelectList(customerCreations.GetOrgList(), "OrgID", "Name");

            if (obj == null)
            {
                return HttpNotFound();
            }

            if (obj.qrDocs == null || obj.qrDocs.Count() <= 0)
            {
                List<QRDocs> qrDocs = new List<QRDocs> { new QRDocs { DocumentType = "", DocFile = null } };
                obj.qrDocs = qrDocs;
            }

            return PartialView("EditBranchDetails", obj);
        }
        public ActionResult Delete(string BranchID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            
            string Result = dLBranchCreation.DeleteBranch(BranchID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBranchDetails(BranchDetails branchDetails)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                //List<string> OtherDocs = new List<string>();
                //foreach (HttpPostedFileBase postedFile in branchDetails.DocumentFiles)
                //{
                //    if (postedFile != null)
                //    {
                //        byte[] thePictureAsBytes = new byte[postedFile.ContentLength];
                //        using (BinaryReader theReader = new BinaryReader(postedFile.InputStream))
                //        {
                //            thePictureAsBytes = theReader.ReadBytes(postedFile.ContentLength);
                //        }
                //        string Base64ImageString = Convert.ToBase64String(thePictureAsBytes);
                //        OtherDocs.Add(Base64ImageString);
                //    }
                //}
                //branchDetails.Documents = OtherDocs;

                if (branchDetails.qrDocs != null && branchDetails.qrDocs.Count() > 0)
                {
                    foreach (var item in branchDetails.qrDocs)
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
                    }
                }

                if (dLBranchCreation.SaveBranch(branchDetails, Session["UserID"].ToString(), Session["OrgID"].ToString()))
                {
                    ModelState.Clear();
                    return PartialView("BranchDisplayList", dLBranchCreation.GetBranchDetailsList(Session["OrgID"].ToString()).ToList());
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        //  DoSomethingWith(error);
                    }
                }

            }

            return PartialView("BranchDisplayList", dLBranchCreation.GetBranchDetailsList(Session["OrgID"].ToString()).ToList());
        }
        [HttpPost]
        public JsonResult AssigningCities(int StateID)
        {
            var jsonResult = Json(customerCreations.GetCities(StateID), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        [HttpPost]
        public JsonResult ChannelTypeChanged(int? ChannelTypeID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return Json(dLBranchCreation.GetAssociates(ChannelTypeID), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult AssociateChanged(int? AssociateID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return Json(dLBranchCreation.GetChannelPartners(AssociateID), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult SearchByName(string searchTerm)
        {
            var jsonResult = Json(dLBranchCreation.GetCities(0, searchTerm), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}