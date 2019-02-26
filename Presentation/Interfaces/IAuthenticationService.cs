using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IIdentity> GetUser();
        void SignOut();
    }
}
