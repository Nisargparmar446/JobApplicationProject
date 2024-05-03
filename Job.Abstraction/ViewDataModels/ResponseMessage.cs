using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.ViewDataModels
{
    public class ResponseMessage
    {
        public long Id { get; set; }
        public long ErrorCode { get; set; }
        public string? Msg { get; set; }
    }
}
