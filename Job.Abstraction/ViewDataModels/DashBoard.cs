using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.ViewDataModels
{
    public class DashBoard
    {
        public List<DashBoard> DashboardDeatilsList { get; set; }
        public DashBoard()
        {
            DashboardDeatilsList = new List<DashBoard>();
        }
        public Int64 JobApplicationId { get; set; }
        public Int64 UserId { get; set; }
        public string? ApplicationNo { get; set; }
        public string? ApplicantName { get; set; }
        public string? ApplicationType { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
