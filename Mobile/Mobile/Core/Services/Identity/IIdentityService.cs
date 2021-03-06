﻿using Mobile.Core.Models.Token;
using System.Threading.Tasks;

namespace Mobile.Core.Services.Identity
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();

        string CreateLogoutRequest(string token);

        Task<UserToken> GetTokenAsync(string code);

    }
}
