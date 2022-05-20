using ArticlesStructureChecking.Application.Token.Oidc;
using Extensions.Hosting.AsyncInitialization;
using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;

namespace ArticlesStructureChecking.Initializers
{
    public class OidcInitializer : IAsyncInitializer
    {
        private readonly OidcConfiguration _configuration;
        private readonly IOpenIddictScopeManager _scopeManager;
        private readonly IOpenIddictApplicationManager _clientManager;

        public OidcInitializer(IOptions<OidcConfiguration> configuration,
            IOpenIddictScopeManager scopeManager,
            IOpenIddictApplicationManager clientManager)
        {
            _configuration = configuration.Value;
            _scopeManager = scopeManager;
            _clientManager = clientManager;
        }

        public async Task InitializeAsync()
        {
            await CreateClientsAsync();

            async Task CreateClientsAsync()
            {
                foreach (var client in _configuration.Clients)
                {
                    var clientDescriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = client.ClientId,
                        ClientSecret = client.ClientSecret,
                        Type = OpenIddictConstants.ClientTypes.Confidential,
                        DisplayName = client.DisplayName
                    };
                    clientDescriptor.Permissions.UnionWith(client.Permissions);

                    var stored = await _clientManager.FindByClientIdAsync(client.ClientId);

                    if (stored == null)
                    {
                        await _clientManager.CreateAsync(clientDescriptor);
                    }
                    else
                    {
                        await _clientManager.UpdateAsync(stored, clientDescriptor);
                    }
                }
            }
        }
    }
}
