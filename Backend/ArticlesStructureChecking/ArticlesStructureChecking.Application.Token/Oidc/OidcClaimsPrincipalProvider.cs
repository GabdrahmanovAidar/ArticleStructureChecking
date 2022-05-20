using ArticlesStructureChecking.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Abstractions;
using System.Collections.Immutable;
using System.Security.Claims;

namespace ArticlesStructureChecking.Application.Token.Oidc
{
    public class OidcClaimsPrincipalProvider
    {
        private readonly IOpenIddictScopeManager _scopeManager;
        private readonly SignInManager<User> _signInManager;

        public OidcClaimsPrincipalProvider(IOpenIddictScopeManager scopeManager,
            SignInManager<User> signInManager)
        {
            _scopeManager = scopeManager;
            _signInManager = signInManager;
        }

        public async Task<ClaimsPrincipal> GetUserClaimsPrincipalAsync(User user, ImmutableArray<string> scopes)
        {
            var userClaims = await _signInManager.CreateUserPrincipalAsync(user);

            userClaims.SetClaim(ClaimTypes.NameIdentifier, user.Id.ToString());
            userClaims.SetClaim(OpenIddictConstants.Claims.Subject, user.Id.ToString());
            var principal = new ClaimsPrincipal(userClaims);

            principal.SetScopes(scopes);

            var allScopes = new List<string>();

            await foreach (var scope in _scopeManager.ListResourcesAsync(principal.GetScopes()))
            {
                allScopes.Add(scope);
            }

            principal.SetResources(allScopes);

            foreach (var claim in principal.Claims)
            {
                claim.SetDestinations(GetDestinations(claim, principal));
            }

            return principal;
        }

        private static IEnumerable<string> GetDestinations(Claim claim, ClaimsPrincipal principal)
        {
            switch (claim.Type)
            {
                case OpenIddictConstants.Claims.Name:
                    yield return OpenIddictConstants.Destinations.AccessToken;

                    if (principal.HasScope(OpenIddictConstants.Permissions.Scopes.Profile))
                        yield return OpenIddictConstants.Destinations.IdentityToken;

                    yield break;

                case OpenIddictConstants.Claims.Email:
                    yield return OpenIddictConstants.Destinations.AccessToken;

                    if (principal.HasScope(OpenIddictConstants.Permissions.Scopes.Email))
                        yield return OpenIddictConstants.Destinations.IdentityToken;

                    yield break;

                case OpenIddictConstants.Claims.Role:
                    yield return OpenIddictConstants.Destinations.AccessToken;

                    if (principal.HasScope(OpenIddictConstants.Permissions.Scopes.Roles))
                        yield return OpenIddictConstants.Destinations.IdentityToken;

                    yield break;

                case "AspNet.Identity.SecurityStamp": yield break;

                default:
                    yield return OpenIddictConstants.Destinations.AccessToken;
                    yield break;
            }
        }
    }
}
