using Job.Abstraction.Repositories;
using Job.Abstraction.Services;
using Job.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Services.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _accountRepository;
        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<LoginDetails> AuthenticateUser(LoginDetails loginDetails)
        {
            var res = await _accountRepository.AuthenticateUser(loginDetails);
            return res;
        }
    }
}
