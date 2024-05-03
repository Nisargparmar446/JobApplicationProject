using Job.Abstraction;
using Job.Abstraction.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DataRepository.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T : BaseDataTableEntity
    {
        IConfiguration appConfig;

        public BaseRepository(IConfiguration config)
        {
            appConfig = config;
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(appConfig.GetConnectionString("JobAppConnection"));
        }
    }
}
