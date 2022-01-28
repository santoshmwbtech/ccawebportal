using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class ChannelPartnersController : Controller
    {
        DLChannelPartners DAL = new DLChannelPartners();
        CustomerCreations DLcustomerCreations = new CustomerCreations();
        DLSalesChannelType dLSalesChannelType = new DLSalesChannelType();
        DLBranchCreation DLBranch = new DLBranchCreation();
        // GET: ChannelPartners
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
        public ActionResult Create()
        {
            if (Session["UserID"] == null && Session["OrgID"] != null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            
            ViewBag.StateList = new SelectList(DLcustomerCreations.GetStateList(), "StateID", "StateName");

            //ViewBag.CityList = new SelectList(DLcustomerCreations.getc(), "ID", "CityName");

            ViewBag.CompanyList = new SelectList(DLcustomerCreations.GetOrgList(), "OrgID", "Name");
            ViewBag.ChannelTypes = new SelectList(DAL.GetChannelTypeList(Session["OrgID"].ToString()), "ID", "ChannelType");
            ViewBag.SalesChannel = new SelectList(DAL.GetChannelPartnerList(Session["OrgID"].ToString()), "ChannelPartnerID", "ChannelPartnerName");
            ViewBag.Assiciates = new SelectList(DAL.GetChannelTypeList(Session["OrgID"].ToString()), "ID", "ChannelType");
            ViewBag.BranchList = new SelectList(DLBranch.GetBranchDetailsList(Session["OrgID"].ToString()), "BranchID", "Name");

            ViewBag.DocTypes = new SelectList(
                                    new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Aadhaar Card", Value = "Aadhaar Card" },
                                        new SelectListItem { Text = "PAN Card", Value = "PAN Card"},
                                        new SelectListItem { Text = "GST Certificate", Value = "GST Certificate"},
                                        new SelectListItem { Text = "Other", Value = "Other"},
                                    }, "Value", "Text");

            ChannelPartner channelPartner = new ChannelPartner();
            List<UserDocs> userDocs = new List<UserDocs> { new UserDocs { DocumentType = "", DocumentNumber = "", DocFile = null } };
            channelPartner.userDocs = userDocs;
            return PartialView(channelPartner);
        }
        public ActionResult CPList()
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            return PartialView(DAL.GetChannelPartnerList(Session["OrgID"].ToString()).ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ChannelPartner channelPartner)
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                if (channelPartner.userDocs != null && channelPartner.userDocs.Count() > 0)
                {
                    foreach (var item in channelPartner.userDocs)
                    {
                        byte[] thePictureAsBytes = new byte[item.DocFile.ContentLength];
                        using (BinaryReader theReader = new BinaryReader(item.DocFile.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(item.DocFile.ContentLength);
                        }
                        item.DocBase64 = Convert.ToBase64String(thePictureAsBytes);
                    }
                }
                if (DAL.Save(channelPartner, Session["UserID"].ToString(), Session["OrgID"].ToString()))
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
            return PartialView("CPList", DAL.GetChannelPartnerList(Session["OrgID"].ToString()).ToList());
        }

        public ActionResult Edit(string ChannelPartnerID)
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ChannelPartnerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelPartner channelPartner = DAL.GetChannelPartnerDetails(ChannelPartnerID);
            int StateID = channelPartner.BranchState.Value;
            ViewBag.CityList = new SelectList(DLcustomerCreations.GetCities(StateID), "StatewithCityID", "VillageLocalityName");
            ViewBag.StateList = new SelectList(DLcustomerCreations.GetStateList(), "StateID", "StateName");
            ViewBag.ChannelTypes = new SelectList(DAL.GetChannelTypeList(Session["OrgID"].ToString()), "ID", "ChannelType");
            ViewBag.SalesChannel = new SelectList(DAL.GetChannelPartners(channelPartner.AssociatedTo.Value), "ChannelPartnerID", "ChannelPartnerName");
            ViewBag.Associates = new SelectList(DAL.GetChannelTypeList(Session["OrgID"].ToString()), "ID", "ChannelType");
            ViewBag.CompanyList = new SelectList(DLcustomerCreations.GetOrgList(), "OrgID", "Name");
            ViewBag.BranchList = new SelectList(DLBranch.GetBranchDetailsList(Session["OrgID"].ToString()), "BranchID", "Name");

            ViewBag.DocTypes = new SelectList(
                                    new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Aadhaar Card", Value = "Aadhaar Card" },
                                        new SelectListItem { Text = "PAN Card", Value = "PAN Card"},
                                        new SelectListItem { Text = "GST Certificate", Value = "GST Certificate"},
                                        new SelectListItem { Text = "Other", Value = "Other"},
                                    }, "Value", "Text");

            if (channelPartner.userDocs == null)
            {
                List<UserDocs> userDocs = new List<UserDocs> { new UserDocs { DocumentType = "", DocumentNumber = "", DocFile = null } };
                channelPartner.userDocs = userDocs;
            }

            if (channelPartner == null)
            {
                return HttpNotFound();
            }

            return PartialView("Edit", channelPartner);
        }
        public ActionResult Delete(string ChannelPartnerID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            string Result = DAL.DeleteChannelPartner(ChannelPartnerID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ChannelPartner channelPartner)
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                if (channelPartner.userDocs != null && channelPartner.userDocs.Count() > 0)
                {
                    foreach (var item in channelPartner.userDocs)
                    {
                        if (item.DocFile != null)
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
                if (DAL.Save(channelPartner, Session["UserID"].ToString(), Session["OrgID"].ToString()))
                {
                    ModelState.Clear();
                    return PartialView("BranchDisplayList", DAL.GetChannelPartnerList(Session["OrgID"].ToString()).ToList());
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

            return PartialView("BranchDisplayList", DAL.GetChannelPartnerList(Session["OrgID"].ToString()).ToList());
        }
        [HttpPost]
        public JsonResult AssigningCities(int StateID)
        {
            var jsonResult = Json(DLcustomerCreations.GetCities(StateID), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult ChannelTypeChanged(int? ChannelTypeID)
        {
            if (Session["UserID"] != null)
            {
                var Result = DAL.GetAssociates(ChannelTypeID);
                if (Result == null)
                    Result = "Error";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult AssociateChanged(int? AssociateID)
        {
            if (Session["UserID"] != null)
            {
                return Json(DAL.GetChannelPartners(AssociateID), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult SearchByName(string searchTerm)
        {
            var jsonResult = Json(DAL.GetCities(0, searchTerm), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}