using OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Token.RefreshToken
{
    public static class Extensions
    {
        public static T GetAuthenticatedUserId<T>(this ClaimsPrincipal principal) where T : IConvertible
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.FindFirstValue(OpenIddictConstants.Claims.Subject);

            return (T)Convert.ChangeType(loggedInUserId, typeof(T));
        }

        public static IEnumerable<string> GetDestinations(Claim claim, ClaimsPrincipal principal)
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

                // Never include the security stamp in the access and identity tokens, as it's a secret value.
                case "AspNetCore.Identity.SecurityStamp": yield break;

                default:
                    yield return OpenIddictConstants.Destinations.AccessToken;
                    yield break;
            }
        }
    }
}
