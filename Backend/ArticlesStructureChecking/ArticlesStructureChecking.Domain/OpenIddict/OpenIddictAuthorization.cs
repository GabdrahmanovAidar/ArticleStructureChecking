using OpenIddict.EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Domain.OpenIddict
{
    public class OpenIddictAuthorization : OpenIddictEntityFrameworkCoreAuthorization<string, OpenIddictApplication, OpenIddictToken>
    {
        public OpenIddictAuthorization()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string ApplicationId { get; protected set; }

        [ForeignKey(nameof(ApplicationId))]
        public override OpenIddictApplication Application
        {
            get => base.Application;
            set => base.Application = value;
        }
    }
}
