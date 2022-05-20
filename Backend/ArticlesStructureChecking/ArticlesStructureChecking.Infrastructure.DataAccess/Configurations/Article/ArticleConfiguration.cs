using ArticlesStructureChecking.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Infrastructure.DataAccess.Configurations.Article
{
    public class ArticleConfiguration : IEntityTypeConfiguration<ArticleEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleEntity> builder)
        {
            builder.ToTable("Articles");
        }
    }
}
