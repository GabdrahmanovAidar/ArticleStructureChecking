namespace ZamZamSSO.Oidc
{
    public partial class ZamZamOidcConfiguration
    {
        public class Scope
        {
            public string Name { get; set; }

            public IReadOnlyCollection<string> Resources { get; set; }
        }
    }
}
