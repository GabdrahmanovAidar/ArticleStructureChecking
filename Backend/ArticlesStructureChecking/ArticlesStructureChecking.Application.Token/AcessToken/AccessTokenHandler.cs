using ArticlesStructureChecking.Application.Token.Oidc;
using ArticlesStructureChecking.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using OneOf;
using OpenIddict.Abstractions;
using System.Collections.Immutable;
using System.Security.Claims;

namespace ArticlesStructureChecking.Application.Token.AcessToken
{
    public abstract class AccessTokenHandler : ITokenHandler
    {
        protected readonly UserManager<User> UserManager;
        private readonly OidcClaimsPrincipalProvider _claimsPrincipalProvider;

        protected AccessTokenHandler(UserManager<User> userManager,
            OidcClaimsPrincipalProvider claimsPrincipalProvider)
        {
            UserManager = userManager;
            _claimsPrincipalProvider = claimsPrincipalProvider;
        }

        public virtual async Task<OneOf<OpenIddictError, ClaimsPrincipal, bool>> Handle(OpenIddictRequest request)
        {
            if (!request.IsPasswordGrantType() || !IsNeedToHandle(request.GetScopes()))
            {
                return false;
            }

            var user = await GetCurrentUser(request.Username!);

            if (user is null)
            {
                return new UserNotFound(OpenIddictConstants.Errors.InvalidGrant,
                    "User not found.");
            }

            var isCorrectPassword = await UserManager.CheckPasswordAsync(user, request.Password);

            if (!isCorrectPassword)
            {
                return new IncorrectPassword(OpenIddictConstants.Errors.InvalidGrant,
                    "The username/password couple is invalid.");
            }

            var isUserNotConfirmed = await CheckIfUserNotConfirmed(user);

            if (isUserNotConfirmed.IsT0)
            {
                return isUserNotConfirmed.AsT0;
            }

            return await _claimsPrincipalProvider.GetUserClaimsPrincipalAsync(user, request.GetScopes());
        }

        protected abstract bool IsNeedToHandle(ImmutableArray<string> scopes);

        protected abstract Task<User?> GetCurrentUser(string userName);

        protected abstract Task<OneOf<UserNotConfirmed, bool>> CheckIfUserNotConfirmed(User user);
    }

    public class UserNotFound : OpenIddictError
    {
        public UserNotFound(string error, string errorDescription) : base(error, errorDescription)
        {
        }
    }

    public class IncorrectPassword : OpenIddictError
    {
        public IncorrectPassword(string error, string errorDescription) : base(error, errorDescription)
        {
        }
    }

    public class UserNotConfirmed : OpenIddictError
    {
        public UserNotConfirmed(string error, string errorDescription) : base(error, errorDescription)
        {
        }
    }

    public abstract class OpenIddictError
    {
        protected OpenIddictError(string error, string errorDescription)
        {
            Error = error;
            ErrorDescription = errorDescription;
        }

        public string Error { get; }

        public string ErrorDescription { get; }
    }
}
