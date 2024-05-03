using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.ViewDataModels
{
    public class DropDownMasterViewModel : BaseDataTableEntity
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
    }
}
