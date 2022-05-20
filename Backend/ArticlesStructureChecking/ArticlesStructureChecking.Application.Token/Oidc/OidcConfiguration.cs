namespace ArticlesStructureChecking.Application.Token.Oidc
{
    public partial class OidcConfiguration
    {
        public const string OidcConfigurationName = "Oidc";

        public int AccessTokenLifeTimeMinutes { get; set; }

        public IReadOnlyCollection<Client> Clients { get; set; }

        public IReadOnlyCollection<Scope> Scopes { get; set; }
    }
}
