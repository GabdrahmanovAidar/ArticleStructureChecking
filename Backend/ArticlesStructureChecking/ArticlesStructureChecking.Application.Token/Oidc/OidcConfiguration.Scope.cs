namespace ArticlesStructureChecking.Application.Token.Oidc
{
    public partial class OidcConfiguration
    {
        public class Scope
        {
            public string Name { get; set; }

            public IReadOnlyCollection<string> Resources { get; set; }
        }
    }
}
