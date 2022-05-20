using ArticlesStructureChecking.Application.Token.AcessToken;
using ArticlesStructureChecking.Domain.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OneOf;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Token.RefreshToken
{
    public class RefreshTokenHandler : ITokenHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public RefreshTokenHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<OneOf<OpenIddictError, ClaimsPrincipal, bool>> Handle(OpenIddictRequest request)
        {
            if (!request.IsRefreshTokenGrantType()) return false;

            var principal =
                (await _httpContextAccessor.HttpContext!.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults
                    .AuthenticationScheme))
                .Principal!;

            var userId = principal.GetAuthenticatedUserId<string>();
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return new UserNotFound(OpenIddictConstants.Errors.InvalidGrant,
                    "The token is no longer valid.");
            }

            foreach (var claim in principal.Claims)
            {
                claim.SetDestinations(Extensions.GetDestinations(claim, principal));
            }

            return principal;
        }
    }
}
