using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Domain.Entities.User
{
    public class Role : IdentityRole<Guid>
    {
        public Role(string roleName) : base(roleName)
        {
        }

        protected Role()
        {
        }
    }
}
