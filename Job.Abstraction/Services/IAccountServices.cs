using Job.Abstraction.ViewDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.Services
{
    public interface IAccountServices
    {
        Task<LoginDetails> AuthenticateUser(LoginDetails loginDetails);
    }
}
