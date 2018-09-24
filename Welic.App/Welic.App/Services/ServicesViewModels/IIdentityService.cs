using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Token;

namespace Welic.App.Services.ServicesViewModels
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);
    }
}
