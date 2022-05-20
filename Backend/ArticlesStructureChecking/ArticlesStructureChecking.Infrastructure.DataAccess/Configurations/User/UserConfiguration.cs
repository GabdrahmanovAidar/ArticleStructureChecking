using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Infrastructure.DataAccess.Configurations.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.User.User> builder)
        {
            builder.ToTable("Users");
        }
    }
}
