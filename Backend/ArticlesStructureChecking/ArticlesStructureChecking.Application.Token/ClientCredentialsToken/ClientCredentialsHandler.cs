using ArticlesStructureChecking.Application.Token.AcessToken;
using OneOf;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Token.ClientCredentialsToken
{
    public class ClientCredentialsHandler : ITokenHandler
    {
        private readonly IOpenIddictScopeManager _scopeManager;

        public ClientCredentialsHandler(IOpenIddictScopeManager scopeManager)
        {
            _scopeManager = scopeManager;
        }

        public async Task<OneOf<OpenIddictError, ClaimsPrincipal, bool>> Handle(OpenIddictRequest request)
        {
            if (!request.IsClientCredentialsGrantType())
                return false;

            var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            identity.AddClaim(OpenIddictConstants.Claims.Subject,
                request.ClientId ?? throw new InvalidOperationException());

            var allScopes = new List<string>();

            await foreach (var scope in _scopeManager.ListResourcesAsync(request.GetScopes()))
            {
                allScopes.Add(scope);
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);

            claimsPrincipal.SetScopes(request.GetScopes());
            claimsPrincipal.SetResources(allScopes);

            return claimsPrincipal;
        }
    }
}
