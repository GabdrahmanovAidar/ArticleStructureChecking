using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using ArticlesStructureChecking.Application.Token;
using OpenIddict.Server.AspNetCore;
using Microsoft.AspNetCore.Authentication;

namespace ArticlesStructureChecking.Controllers
{
    [ApiController]
    [Route("identity/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IEnumerable<ITokenHandler> _tokenHandlers;

        public TokenController(IEnumerable<ITokenHandler> tokenHandlers)
        {
            _tokenHandlers = tokenHandlers;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var request = HttpContext.GetOpenIddictServerRequest() ??
                          throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            foreach (var tokenHandler in _tokenHandlers)
            {
                var handleResult = await tokenHandler.Handle(request);

                if (handleResult.IsT2)
                {
                    continue;
                }

                if (handleResult.IsT0)
                {
                    var errorResponse = handleResult.AsT0;

                    return Forbid(
                        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                        properties: new AuthenticationProperties(new Dictionary<string, string>
                        {
                            [OpenIddictServerAspNetCoreConstants.Properties.Error] = errorResponse.Error,
                            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                                errorResponse.ErrorDescription
                        }!));
                }

                if (handleResult.IsT1)
                {
                    return SignIn(handleResult.AsT1, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                }
            }

            throw new InvalidOperationException("The specified grant type is not supported.");
        }
    }
}
