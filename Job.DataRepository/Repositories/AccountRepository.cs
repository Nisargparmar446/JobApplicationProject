using Dapper;
using Job.Abstraction;
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
    public class AccountRepository: BaseRepository<BaseDataTableEntity>, IAccountRepository
    {
        public IConfiguration appConfig;
        public AccountRepository(IConfiguration config) : base(config)
        {
            appConfig = config ?? throw new ArgumentNullException(nameof(config));
        }
        public async Task<LoginDetails> AuthenticateUser(LoginDetails loginDetails)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@Username", loginDetails.EmailId);
                    queryParameters.Add("@Password", loginDetails.Password);
                    var result = await conn.QueryFirstOrDefaultAsync<LoginDetails>("AuthenticateUser", queryParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
