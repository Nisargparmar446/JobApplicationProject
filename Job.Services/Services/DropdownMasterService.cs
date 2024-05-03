using Job.Abstraction.Repositories;
using Job.Abstraction.Services;
using Job.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services
{
    public class DropdownMasterService : IdropdownMasterService
    {
        private readonly IDropdownMasterRepository _dropdownMasterRepository;
        public DropdownMasterService(IDropdownMasterRepository dropdownMasterRepository)
        {
            _dropdownMasterRepository = dropdownMasterRepository;
        }

        public IEnumerable<DropDownMasterViewModel> GetDropDownMaster(int DropdownType, int ParentId)
        {
            return _dropdownMasterRepository.GetDropDownMaster(DropdownType, ParentId);
        }
    }
}
