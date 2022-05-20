﻿namespace ZamZamSSO.Oidc
{
    public partial class ZamZamOidcConfiguration
    {
        public class Client
        {
            public string ClientId { get; set; }

            public string DisplayName { get; set; }

            public string ClientSecret { get; set; }

            public IReadOnlyCollection<string> Permissions { get; set; }
        }
    }
}
