using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.ViewDataModels
{
    public class LoginDetails
    {
        public long? UserId { get; set; }
        public long? UserTypeId { get; set; }
        public string? DisplayName { get; set; }

        [Required(ErrorMessage = "Please Enter EmailId.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Pease Enter Password.")]
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
