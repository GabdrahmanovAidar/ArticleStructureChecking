using ArticlesStructureChecking.Application.Token.Oidc;
using ArticlesStructureChecking.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using OneOf;
using OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Token.AcessToken
{
    public class ArticleStructureCheckingAccessTokenHandler : AccessTokenHandler
    {
        public ArticleStructureCheckingAccessTokenHandler(UserManager<User> userManager,
        OidcClaimsPrincipalProvider claimsPrincipalProvider) : base(userManager, claimsPrincipalProvider)
        {
        }

        protected override bool IsNeedToHandle(ImmutableArray<string> scopes)
        {
            return true;
        }

        protected override async Task<User?> GetCurrentUser(string userName)
        {
            return await UserManager.FindByNameAsync(userName);
        }

        protected override async Task<OneOf<UserNotConfirmed, bool>> CheckIfUserNotConfirmed(User user)
        {
            var isConfirmed = await UserManager.IsPhoneNumberConfirmedAsync(user);

            return isConfirmed switch
            {
                true => true,
                false => new UserNotConfirmed(OpenIddictConstants.Errors.InvalidGrant,
                    "The user phone number is not confirmed.")
            };
        }
    }
}
