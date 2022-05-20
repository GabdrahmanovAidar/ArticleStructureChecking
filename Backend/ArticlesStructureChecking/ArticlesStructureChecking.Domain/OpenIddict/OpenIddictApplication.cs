using OpenIddict.EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Domain.OpenIddict
{
    public class OpenIddictApplication : OpenIddictEntityFrameworkCoreApplication<string, OpenIddictAuthorization,
       OpenIddictToken>
    {
        public OpenIddictApplication()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
