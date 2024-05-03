using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.ViewDataModels
{
    public class JobApplicationDetails : BaseDataTableEntity
    {
        public JobApplicationDetails() {

        }
        public JobApplicationDetails? objJobApplicationDetails {get;set;}
        public List<EducationDetails>? objEducationDetails { get; set; }
        public List<WorkExpDetails>? objWorkExpDetails { get; set; }
        public List<LanguageDetails>? objLanguageDetails { get; set; }
        public List<TechSkillDetails>? objTechSkillDetails { get; set; }
        public long UserId { get; set; }
        public long JobApplicationId { get; set; }
        [Required(ErrorMessage = "Please Enter Name.")]
        public string ApplicantName { get; set; }
        [Required(ErrorMessage = "Please Enter EmailId.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Please Select Gender.")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Please Enter MobileNo.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Mobile number should be valid.")]
        public string? Contact { get; set; }
        [Required(ErrorMessage = "Please Select Location")]
        public string? PreferredLocation { get; set; }
        [Required(ErrorMessage = "Please Enter Expected CTC")]
        public decimal? ExpectedCTC { get; set; }
        [Required(ErrorMessage = "Please Enter Current CTC.")]
        public decimal? CurrentCTC { get; set; }
        [Required(ErrorMessage = "Please Enter Notice Period.")]
        public int? NoticePeriod { get; set; }
        public string? AppFromDate { get; set; }
        public string? AppToDate { get; set; }
        public DataTable? dtEducationDetails { get; set; }
        public DataTable? dtWorkExpDetails { get; set; }
        public DataTable? dtLanguageDetails { get; set; }
        public DataTable? dtTechSkillDetails { get; set; }
        public string? IPAddress { get; set; }
        public string? HostName { get; set; }
    }
    public class EducationDetails
    {
        public long? EducationDetailId { get; set; }
        public long? JobApplicationId { get; set; }
        public long? EducationId { get; set; }
        public string? Education { get; set; }
        public string? University { get; set; }
        public string? PassoutYear { get; set; }
        public decimal? Percentage { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class WorkExpDetails
    {
        public long? WorkExpDetailId { get; set; }
        public long? JobApplicationId { get; set; }
        public string? Company { get; set; }
        public string? Designation { get; set; }
        public string? ExpFromDate { get; set; }
        public string? ExpToDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class LanguageDetails
    {
        public long? LanguageDetailId { get; set; }
        public long? JobApplicationId { get; set; }
        public long? LanguageId { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsWrite { get; set; }
        public bool? IsSpeak { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class TechSkillDetails
    {
        public long? TechSkillDetailId { get; set; }
        public long? JobApplicationId { get; set; }
        public long? TechSkillId { get; set; }
        public bool? IsBeginner { get; set; }
        public bool? IsMediator { get; set; }
        public bool? IsExpert { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
