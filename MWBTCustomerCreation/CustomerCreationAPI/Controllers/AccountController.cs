using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WBT.Common;
using WBT.DLCustomerCreation;
using WBT.Entity;

namespace CustomerCreationAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        WBT.BL.CustomerCreation BLCustomerCreation = new WBT.BL.CustomerCreation();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        [HttpPost]
        [Route("Login")]
        [ResponseType(typeof(tblSysUser))]
        public IHttpActionResult LoginUser([FromBody] UserLogin userLoginDetails)
        {
            try
            {
                string json1 = Newtonsoft.Json.JsonConvert.SerializeObject(userLoginDetails);
                Helper.LogError(json1, null, null, null, false);

                CustomerCreations customerCreations = new CustomerCreations();
                UserLogin Result = customerCreations.LoginAppUser(userLoginDetails);

                if(Result != null)
                {
                    if(Result.Message == "success")
                    {
                        return Ok(Result);
                    }
                    else
                    {
                        return ResponseMessage(Request.CreateResponse(HttpStatusCode.Unauthorized, Result));
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                //logger.LogWriter.Write(ex.Message);
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost]
        [ResponseType(typeof(CustomerID))]
        [Route("RegisterCustomer")]
        public IHttpActionResult RegisterUser([FromBody]CustomerCreation customerCreation)
        {
            try
            {
                /*old code with image upload commented on 27th May 2020*/
                #region
                //byte[] imageBytes1 = null;
                //byte[] imageBytes2 = null;
                //byte[] imageBytes3 = null;
                //byte[] imageBytes4 = null;
                //var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                //var json = await filesReadToProvider.Contents[0].ReadAsStringAsync();
                //Helper.LogError(json, null, null, null, false);
                //Helper.LogError(filesReadToProvider.Contents.Count.ToString(), null, null, null, false);

                //CustomerCreation customerCreation = JsonConvert.DeserializeObject<CustomerCreation>(json);

                //if (filesReadToProvider.Contents.Count > 1)
                //{
                //    if(filesReadToProvider.Contents.Count > 1)
                //    {
                //        for(int i=0; i < filesReadToProvider.Contents.Count; i++)
                //        {
                //            string keys = filesReadToProvider.Contents[i].Headers.ContentDisposition.Name;
                //            imageBytes1 = await filesReadToProvider.Contents[i].ReadAsByteArrayAsync();
                //            if (imageBytes1 != null && imageBytes1.Length > 0)
                //            {
                //                if (keys.Contains(@"\"))
                //                    keys.Replace(@"\", "");
                //                if(keys.ToLower().Contains("gstphoto"))
                //                {
                //                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_gst_{0}.jpg", customerCreation.PANNumber));
                //                    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto);
                //                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                //                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                //                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //                    image.Save(filePath);
                //                    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_gst_{0}.jpg", customerCreation.PANNumber);
                //                    customerCreation.GSTPhoto = serverPath;
                //                }
                //                else if(keys.ToLower().Contains("panphoto"))
                //                {
                //                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_pan_{0}.jpg", customerCreation.PANNumber));
                //                    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto);
                //                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                //                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                //                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //                    image.Save(filePath);
                //                    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_pan_{0}.jpg", customerCreation.PANNumber);
                //                    customerCreation.PANPhoto = serverPath;
                //                }
                //                else if(keys.ToLower().Contains("shopimage"))
                //                {
                //                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_si_{0}.jpg", customerCreation.PANNumber));
                //                    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto);
                //                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                //                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                //                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //                    image.Save(filePath);
                //                    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_si_{0}.jpg", customerCreation.PANNumber);
                //                    customerCreation.ShopImage = serverPath;
                //                }
                //                else if(keys.ToLower().Contains("ownerphoto"))
                //                {
                //                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_op_{0}.jpg", customerCreation.PANNumber));
                //                    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto);
                //                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                //                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                //                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //                    image.Save(filePath);
                //                    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_op_{0}.jpg", customerCreation.PANNumber);
                //                    customerCreation.OwnerPhoto = serverPath;
                //                }
                //            }
                //        }
                //    }
                //if (filesReadToProvider.Contents.Count == 5)
                //{
                //    string keys = filesReadToProvider.Contents[1].Headers.ContentDisposition.Name;
                //    imageBytes1 = await filesReadToProvider.Contents[1].ReadAsByteArrayAsync();
                //    imageBytes2 = await filesReadToProvider.Contents[2].ReadAsByteArrayAsync();
                //    imageBytes3 = await filesReadToProvider.Contents[3].ReadAsByteArrayAsync();
                //    imageBytes4 = await filesReadToProvider.Contents[4].ReadAsByteArrayAsync();
                //}
                //else if(filesReadToProvider.Contents.Count == 4)
                //{
                //    imageBytes1 = await filesReadToProvider.Contents[1].ReadAsByteArrayAsync();
                //    imageBytes2 = await filesReadToProvider.Contents[2].ReadAsByteArrayAsync();
                //    imageBytes3 = await filesReadToProvider.Contents[3].ReadAsByteArrayAsync();
                //}
                //else if (filesReadToProvider.Contents.Count == 3)
                //{
                //    imageBytes1 = await filesReadToProvider.Contents[1].ReadAsByteArrayAsync();
                //    imageBytes2 = await filesReadToProvider.Contents[2].ReadAsByteArrayAsync();
                //}
                //else if (filesReadToProvider.Contents.Count == 2)
                //{
                //    imageBytes1 = await filesReadToProvider.Contents[1].ReadAsByteArrayAsync();
                //}
                //}

                //if (imageBytes1 != null && imageBytes1.Length > 0)
                //{
                //    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_gst_{0}.jpg", customerCreation.PANNumber));
                //    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto);
                //    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                //    ms.Write(imageBytes1, 0, imageBytes1.Length);
                //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //    image.Save(filePath);
                //    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_gst_{0}.jpg", customerCreation.PANNumber);
                //    customerCreation.GSTPhoto = serverPath;
                //}

                //if (imageBytes2 != null && imageBytes2.Length > 0)
                //{
                //    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_pan_{0}.jpg", customerCreation.PANNumber));
                //    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto2);
                //    MemoryStream ms = new MemoryStream(imageBytes2, 0, imageBytes2.Length);
                //    ms.Write(imageBytes2, 0, imageBytes2.Length);
                //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //    image.Save(filePath);
                //    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_pan_{0}.jpg", customerCreation.PANNumber);
                //    customerCreation.PANPhoto = serverPath;
                //}
                //if (imageBytes3 != null && imageBytes3.Length > 0)
                //{
                //    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_si_{0}.jpg", customerCreation.PANNumber));
                //    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto);
                //    MemoryStream ms = new MemoryStream(imageBytes3, 0, imageBytes3.Length);
                //    ms.Write(imageBytes3, 0, imageBytes3.Length);
                //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //    image.Save(filePath);
                //    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_si_{0}.jpg", customerCreation.PANNumber);
                //    customerCreation.ShopImage = serverPath;
                //}

                //if (imageBytes4 != null && imageBytes4.Length > 0)
                //{
                //    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_op_{0}.jpg", customerCreation.PANNumber));
                //    //byte[] imageBytes = Convert.FromBase64String(submitQuery.ProductPhoto2);
                //    MemoryStream ms = new MemoryStream(imageBytes4, 0, imageBytes4.Length);
                //    ms.Write(imageBytes4, 0, imageBytes4.Length);
                //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //    image.Save(filePath);
                //    string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_op_{0}.jpg", customerCreation.PANNumber);
                //    customerCreation.OwnerPhoto = serverPath;
                //}
                #endregion 
                /*old code with image upload commented on 27th May 2020*/

                string json1 = Newtonsoft.Json.JsonConvert.SerializeObject(customerCreation);
                Helper.LogError(json1, null, null, null, false);

                CustomerCreations customerCreations = new CustomerCreations();
                CustomerID Result = customerCreations.SaveData(customerCreation);

                if(Result.StatusCode == 409)
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, Result.UpdateStatus));
                if (Result.StatusCode == 500)
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, Result.UpdateStatus));

                return Ok(Result);
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, false);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        //[HttpPost]
        //[ResponseType(typeof(CustomerID))]
        //[Route("RegisterCustomer")]
        //public IHttpActionResult UpdateUser([FromBody]CustomerCreation customerCreation)
        //{
        //    try
        //    {
        //        string json1 = Newtonsoft.Json.JsonConvert.SerializeObject(customerCreation);
        //        Helper.LogError(json1, null, null, null, false);

        //        CustomerCreations customerCreations = new CustomerCreations();
        //        CustomerID Result = customerCreations.UpdateData(customerCreation);

        //        return Ok(Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, false);
        //        return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
        //    }
        //}

        [ResponseType(typeof(CustomerCreations))]
        [Route("GetCustomerList/{OrgID}")]
        public IHttpActionResult GetCustomerList(string OrgID)
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<CustomerListForApp> customerCreations = new List<CustomerListForApp>();
                customerCreations = Context.GetCustomerListForApp(OrgID);

                if (customerCreations == null)
                {
                    return NotFound();
                }

                //return Ok(tblCustomerDetails);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, customerCreations));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, false);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [ResponseType(typeof(CustomerCreations))]
        [Route("GetCustomerDetails/{CustID}")]
        public IHttpActionResult GetCustomerDetails(string CustID)
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                CustomerCreation customerCreations = new CustomerCreation();
                customerCreations = Context.GetCustomerDetails(CustID);

                if (customerCreations == null)
                {
                    return NotFound();
                }

                //return Ok(tblCustomerDetails);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, customerCreations));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, false);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost]
        [ResponseType(typeof(CustomerID))]
        [Route("UploadImages/")]
        public async Task<IHttpActionResult> UploadImages()
        {
            try
            {
                DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                byte[] imageBytes1 = null;
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                var json = await filesReadToProvider.Contents[0].ReadAsStringAsync();
                Helper.LogError(json, null, null, null, false);


                CustomerID customerID = JsonConvert.DeserializeObject<CustomerID>(json);
                tblCustomerVendorDetail customerCreation = new tblCustomerVendorDetail();
                customerCreation.CustID = customerID.CustID.ToString();
                customerCreation.OrgID = customerID.OrgID.ToString();
                customerCreation.ModifiedByID = customerID.ModifiedByID;
                customerCreation.UpdatedDate = DateTimeNow;
                string ServerPath = string.Empty;

                if (filesReadToProvider.Contents.Count > 1)
                {
                    if (filesReadToProvider.Contents.Count > 1)
                    {
                        string keys = filesReadToProvider.Contents[1].Headers.ContentDisposition.Name;
                        imageBytes1 = await filesReadToProvider.Contents[1].ReadAsByteArrayAsync();
                        Helper.LogError("Key - " + keys + "", null, null, null, false);
                        Helper.LogError("File Name - " + filesReadToProvider.Contents[1].Headers.ContentDisposition.FileName + "", null, null, null, false);
                        using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                        {
                            if (keys.Contains(@"\"))
                                keys.Replace(@"\", "");

                            if (imageBytes1 != null && imageBytes1.Length > 0)
                            {
                                if (keys.ToLower().Contains("gstphoto"))
                                {
                                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_gst_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID));
                                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                                    image.Save(filePath);
                                    ServerPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_gst_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID);
                                    customerCreation.GSTPhoto = ServerPath;
                                    dbContext.tblCustomerVendorDetails.Attach(customerCreation);
                                    dbContext.Entry(customerCreation).Property(x => x.GSTPhoto).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.ModifiedByID).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.UpdatedDate).IsModified = true;
                                    dbContext.SaveChanges();
                                }
                                else if (keys.ToLower().Contains("panphoto"))
                                {
                                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_pan_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID));
                                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                                    image.Save(filePath);
                                    ServerPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_pan_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID);
                                    customerCreation.PANPhoto = ServerPath;
                                    dbContext.tblCustomerVendorDetails.Attach(customerCreation);
                                    dbContext.Entry(customerCreation).Property(x => x.PANPhoto).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.ModifiedByID).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.UpdatedDate).IsModified = true;
                                    dbContext.SaveChanges();
                                }
                                else if (keys.ToLower().Contains("shopimage"))
                                {
                                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_si_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID));
                                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                                    image.Save(filePath);
                                    ServerPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_si_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID);
                                    customerCreation.ShopImage = ServerPath;
                                    dbContext.tblCustomerVendorDetails.Attach(customerCreation);
                                    dbContext.Entry(customerCreation).Property(x => x.ShopImage).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.ModifiedByID).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.UpdatedDate).IsModified = true;
                                    dbContext.SaveChanges();
                                }
                                else if (keys.ToLower().Contains("ownerphoto"))
                                {
                                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_op_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID));
                                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                                    image.Save(filePath);
                                    ServerPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_op_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID);
                                    customerCreation.OwnerPhoto = ServerPath;
                                    dbContext.tblCustomerVendorDetails.Attach(customerCreation);
                                    dbContext.Entry(customerCreation).Property(x => x.OwnerPhoto).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.ModifiedByID).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.UpdatedDate).IsModified = true;
                                    dbContext.SaveChanges();
                                }
                                else if (keys.ToLower().Contains("aadhaarphoto"))
                                {
                                    string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_aadhaar_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID));
                                    MemoryStream ms = new MemoryStream(imageBytes1, 0, imageBytes1.Length);
                                    ms.Write(imageBytes1, 0, imageBytes1.Length);
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                                    image.Save(filePath);
                                    ServerPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_aadhaar_{0}_{1}.jpg", customerCreation.CustID, customerCreation.OrgID);
                                    customerCreation.AadhaarPhoto = ServerPath;
                                    dbContext.tblCustomerVendorDetails.Attach(customerCreation);
                                    dbContext.Entry(customerCreation).Property(x => x.AadhaarPhoto).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.ModifiedByID).IsModified = true;
                                    dbContext.Entry(customerCreation).Property(x => x.UpdatedDate).IsModified = true;
                                    dbContext.SaveChanges();
                                }
                                else
                                {
                                    Helper.LogError(keys, null, null, null);
                                    ServerPath = "Invalid Key Name";
                                }
                            }
                        }
                    }
                }
                //return Ok(tblCustomerDetails);
                ImgPath ImagePath = new ImgPath();
                ImagePath.ImagePath = ServerPath;
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, ImagePath));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, false);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        //public string SaveImage(tblCustomerVendorDetail customerCreation, string keys, byte[] ImageArray)
        //{
        //    try
        //    {
        //        using(MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
        //        {
        //            string filePath = HttpContext.Current.Server.MapPath("~/Images/" + string.Format("img_si_{0}.jpg", CustID.Trim()));
        //            MemoryStream ms = new MemoryStream(ImageArray, 0, ImageArray.Length);
        //            ms.Write(ImageArray, 0, ImageArray.Length);
        //            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
        //            image.Save(filePath);
        //            string serverPath = "http://" + Request.RequestUri.Authority + ConfigurationManager.AppSettings["ImagePath"] + string.Format("img_si_{0}.jpg", CustID.Trim());
        //            customerCreation.ShopImage = serverPath;
        //            dbContext.tblCustomerVendorDetails.Attach(customerCreation);
        //            dbContext.Entry(customerCreation).Property(x => x.ShopImage).IsModified = true;
        //            dbContext.SaveChanges();
        //            return serverPath;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, false);
        //        return ex.Message;
        //    }
        //}

        [ResponseType(typeof(tblState))]
        [Route("GetStateList")]
        public IHttpActionResult GetStateList()
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<tblState> StateList = new List<tblState>();
                StateList = Context.GetStateList();

                if (StateList == null)
                {
                    return NotFound();
                }

                //return Ok(tblCustomerDetails);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, StateList));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, false);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
        
        [HttpGet]
        [ResponseType(typeof(tblStateWithCity))]
        [Route("CityList/{StateId}")]
        public IHttpActionResult CityList(int StateId)
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<tblStateWithCity> tblStateWithCitiesList = new List<tblStateWithCity>();
                tblStateWithCitiesList = Context.GetCities(StateId);
                if (tblStateWithCitiesList == null)
                {
                    return NotFound();
                }
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, tblStateWithCitiesList));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, true);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [ResponseType(typeof(tblLedgerType))]
        [Route("GetLedgerTypes")]
        public IHttpActionResult GetLedgerTypes()
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<tblLedgerType> ledgerTypes = new List<tblLedgerType>();
                ledgerTypes = Context.GetLedgerTypes();
                if (ledgerTypes == null)
                {
                    return NotFound();
                }
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, ledgerTypes));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, true);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [ResponseType(typeof(tblCustomerType))]
        [Route("GetCustomerTypes")]
        public IHttpActionResult GetCustomerTypes()
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<tblCustomerType> customerTypes = new List<tblCustomerType>();
                customerTypes = Context.GetCustomerTypes();
                if (customerTypes == null)
                {
                    return NotFound();
                }
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, customerTypes));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, true);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [ResponseType(typeof(tblCompanyType))]
        [Route("GetCompanyTypes")]
        public IHttpActionResult GetCompanyTypes()
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<tblCompanyType> companyTypes = new List<tblCompanyType>();
                companyTypes = Context.GetCompanyTypes();
                if (companyTypes == null)
                {
                    return NotFound();
                }
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, companyTypes));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, true);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [ResponseType(typeof(tblCategoryType))]
        [Route("GetCategoryTypes")]
        public IHttpActionResult GetCategoryTypes()
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<tblCategoryType> categoryTypes = new List<tblCategoryType>();
                categoryTypes = Context.GetCategoryTypes();
                if (categoryTypes == null)
                {
                    return NotFound();
                }
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, categoryTypes));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, true);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [ResponseType(typeof(tblTaxationType))]
        [Route("GetTaxationTypes")]
        public IHttpActionResult GetTaxationTypes()
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations Context = new WBT.DLCustomerCreation.CustomerCreations();
                List<tblTaxationType> taxationTypes = new List<tblTaxationType>();
                taxationTypes = Context.GetTaxationTypes();
                if (taxationTypes == null)
                {
                    return NotFound();
                }
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, taxationTypes));
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace, true);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
