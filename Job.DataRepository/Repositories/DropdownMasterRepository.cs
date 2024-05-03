using Dapper;
using Job.Abstraction.Repositories;
using Job.Abstraction.ViewDataModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DataRepository.Repositories
{
    public class DropdownMasterRepository : BaseRepository<DropDownMasterViewModel>, IDropdownMasterRepository
    {
        public IConfiguration _configuration;
        public DropdownMasterRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<DropDownMasterViewModel> GetDropDownMaster(int DropdownType, int ParentId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@Type", DropdownType);
                    queryParameters.Add("@ParentId", ParentId);
                    return conn.Query<DropDownMasterViewModel>("GetDropDownData", queryParameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
