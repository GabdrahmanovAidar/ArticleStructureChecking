using ArticlesStructureChecking.Application.Token.AcessToken;
using OneOf;
using OpenIddict.Abstractions;
using System.Security.Claims;

namespace ArticlesStructureChecking.Application.Token
{
    public interface ITokenHandler
    {
        Task<OneOf<OpenIddictError, ClaimsPrincipal, bool>> Handle(OpenIddictRequest request);
    }
}
