using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Job.Abstraction.ViewDataModels;
using Job.Abstraction.Services;
using Job.Common;
using Job.Abstraction;
using Microsoft.AspNetCore.Mvc.Rendering;
using Job.Services;
using Job.Common;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Reflection;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Job.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IAccountServices _iAccountService;
        private readonly IJobApplicationServices _iJobApplicationService;
        private readonly ClaimsPrincipal _claimPincipal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IdropdownMasterService _dropdownMasterService;
        public JobApplicationController(IConfiguration config, IAccountServices iAccountService, IJobApplicationServices iJobApplicationService, IdropdownMasterService idropdownMasterService, IHttpContextAccessor httpContextAccessor)
        {

            _config = config;
            _iAccountService = iAccountService;
            _iJobApplicationService = iJobApplicationService;
            _dropdownMasterService = idropdownMasterService;
            _httpContextAccessor = httpContextAccessor;
            _claimPincipal = _httpContextAccessor.HttpContext.User ;
        }
        public IActionResult JobApplication()
        {
            BindDropDown(1);
            return View("GetJobApplication");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetJobApplicationList(DashBoard dashBoard)
        {
            int jobApplicationId = 0;
            long userId = Convert.ToInt64(_claimPincipal.FindFirstValue(ClaimTypes.NameIdentifier));
            try
            {
                dashBoard.UserId = userId;
                var modelList = await _iJobApplicationService.GetJobApplicationList(dashBoard);
                return View("JobApplicationDashboard",modelList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> AddUpdateJobApplicationDetails(JobApplicationDetails jobApplicationDetails)
        {
            try
            {
                ResponseMessage regResponse = new ResponseMessage();
                var ObjEducationDetailsList = new List<EducationDetails>();
                var ObjWorkExpDetailsList = new List<WorkExpDetails>();
                var jobAppId = jobApplicationDetails.JobApplicationId;
                if (ModelState.IsValid)
                {
                    jobApplicationDetails.IPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    jobApplicationDetails.UserId = Convert.ToInt32(_claimPincipal.FindFirstValue(ClaimTypes.NameIdentifier));

                    foreach (var item in jobApplicationDetails.objEducationDetails)
                    {
                        var ObjEducation = new EducationDetails();
                        if (item.IsDeleted == false)
                        {
                            ObjEducation.EducationId = item.EducationId;
                            ObjEducation.University = item.University;
                            ObjEducation.PassoutYear = item.PassoutYear;
                            ObjEducation.Percentage = item.Percentage;
                            ObjEducationDetailsList.Add(ObjEducation);
                        }
                    }
                    var dtData = ToDataTable(ObjEducationDetailsList);
                    jobApplicationDetails.dtEducationDetails = dtData;
                    foreach (var item in jobApplicationDetails.objWorkExpDetails)
                    {
                        var ObjWorkExp = new WorkExpDetails();
                        if (item.IsDeleted == false)
                        {
                            ObjWorkExp.Company = item.Company;
                            ObjWorkExp.Designation = item.Designation;
                            ObjWorkExp.ExpFromDate = item.ExpFromDate;
                            ObjWorkExp.ExpToDate = item.ExpToDate;
                            ObjWorkExpDetailsList.Add(ObjWorkExp);
                        }
                    }
                    var dtWork = ToDataTable(ObjWorkExpDetailsList);
                    jobApplicationDetails.dtWorkExpDetails = dtWork;
                    regResponse = await _iJobApplicationService.AddUpdateJobApplicationDetails(jobApplicationDetails);
                    if (regResponse != null)
                    {
                        string errorMsg = regResponse.Msg == null ? "Somthing went wrong please try again." : regResponse.Msg;

                        if (jobAppId == regResponse.Id)
                        {
                            ModelState.Clear();
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.success), "||");
                            return RedirectToAction("GetJobApplicationList", "JobApplication");
                        }
                        else if (regResponse != null && regResponse.ErrorCode == 0)
                        {
                            ModelState.Clear();
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.success), "||");
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.warning), "||");
                            ModelState.Clear();
                            return RedirectToAction("AddUpdateJobApplicationDetails", "JobApplication");
                        }
                    }
                    else
                    {
                        TempData["Message"] = CommonUtils.ConcatString("Somthing went wrong please try after sometime.", Convert.ToString((int)EnumLookup.ResponseMsgType.error), "||");
                        return RedirectToAction("AddUpdateJobApplicationDetails", "JobApplication");
                    }
                }
                else
                {
                    TempData["Message"] = CommonUtils.ConcatString("Somthing went wrong please try after sometime.", Convert.ToString((int)EnumLookup.ResponseMsgType.error), "||");
                    return RedirectToAction("AddUpdateJobApplicationDetails", "JobApplication");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ViewJobApplication(string strJobApplicationId = "")
        {
            int JobApplicationId = 0;
            try
            {
                if (!string.IsNullOrEmpty(strJobApplicationId))
                {
                    JobApplicationId = Convert.ToInt32(strJobApplicationId);
                }

                JobApplicationDetails jobApplicationDetails = await _iJobApplicationService.GetJobApplicationById(JobApplicationId);
                
                return View(jobApplicationDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetJobApplication(string strJobApplicationId = "")
        {
            int JobApplicationId = 0;
            try
            {
                if (!string.IsNullOrEmpty(strJobApplicationId))
                {
                    JobApplicationId = Convert.ToInt32(strJobApplicationId);
                }

                JobApplicationDetails jobApplicationDetails = await _iJobApplicationService.GetJobApplicationById(JobApplicationId);
                
                BindDropDown(1);
                return View(jobApplicationDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteJobApplication(string strjobApplicationId="")
        {
            try
            {
                JobApplicationDetails jobApplicationDetails = new JobApplicationDetails();
                if (!string.IsNullOrEmpty(strjobApplicationId))
                {
                    jobApplicationDetails.JobApplicationId = Convert.ToInt32(strjobApplicationId);
                }
                ResponseMessage regResponse = new ResponseMessage();
                var jobAppId = jobApplicationDetails.JobApplicationId;
                jobApplicationDetails.IPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    jobApplicationDetails.UserId = Convert.ToInt32(_claimPincipal.FindFirstValue(ClaimTypes.NameIdentifier));

                    regResponse = await _iJobApplicationService.DeleteJobApplication(jobApplicationDetails);
                    if (regResponse != null)
                    {
                        string errorMsg = regResponse.Msg == null ? "Somthing went wrong please try again." : regResponse.Msg;

                        if (jobAppId == regResponse.Id)
                        {
                            ModelState.Clear();
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.success), "||");
                            return RedirectToAction("GetJobApplicationList", "JobApplication");
                        }
                        else if (regResponse != null && regResponse.ErrorCode == 0)
                        {
                            ModelState.Clear();
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.success), "||");
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["Message"] = CommonUtils.ConcatString(errorMsg, Convert.ToString((int)EnumLookup.ResponseMsgType.warning), "||");
                            ModelState.Clear();
                            return RedirectToAction("AddUpdateJobApplicationDetails", "JobApplication");
                        }
                    }
                    else
                    {
                        TempData["Message"] = CommonUtils.ConcatString("Somthing went wrong please try after sometime.", Convert.ToString((int)EnumLookup.ResponseMsgType.error), "||");
                        return RedirectToAction("AddUpdateJobApplicationDetails", "JobApplication");
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void BindDropDown(int Type = 0)
        {
            ViewBag.EducationType = _dropdownMasterService.GetDropDownMaster(Convert.ToInt32(CommonEnums.DropdownMasterType.EducationType), 0)
                    .Select(c => new SelectListItem() { Text = c.Text, Value = c.Value }).ToList();
                    
            //ViewBag.EducationType = new List<SelectListItem>
            //    {
            //        new SelectListItem { Text = "SSC", Value = "1" },
            //        new SelectListItem { Text = "HSC", Value = "2" }
            //    };

            //ViewBag.LanguageType = _dropdownMasterService.GetDropDownMaster(Convert.ToInt32(CommonEnums.DropdownMasterType.LanguageType), 0)
            //        //.Select(c => new SelectListItem() { Text = c.Text, Value = c.Value }).ToList();
            //        .Select(c => new SelectListItem() { Text = "Hindi", Value = "1" }).ToList();

            
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
