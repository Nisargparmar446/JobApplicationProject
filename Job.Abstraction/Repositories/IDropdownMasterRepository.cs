using Job.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.Repositories
{
    public interface IDropdownMasterRepository
    {
        IEnumerable<DropDownMasterViewModel> GetDropDownMaster(int DropdownType, int ParentId);
    }
}
