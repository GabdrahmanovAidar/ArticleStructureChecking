using OpenIddict.EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Domain.OpenIddict
{
    public class OpenIddictToken : OpenIddictEntityFrameworkCoreToken<string, OpenIddictApplication, OpenIddictAuthorization>
    {
        public OpenIddictToken()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Column("Application_Id")]
        public string? ApplicationId { get; protected set; }

        [ForeignKey(nameof(ApplicationId))]
        public override OpenIddictApplication Application
        {
            get => base.Application;
            set => base.Application = value;
        }

        [Column("Authorization_Id")]
        public string? Authorization_Id { get; protected set; }

        [ForeignKey(nameof(Authorization_Id))]
        public override OpenIddictAuthorization Authorization
        {
            get => base.Authorization;
            set => base.Authorization = value;
        }
    }
}
