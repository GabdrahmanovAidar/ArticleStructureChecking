using ArticlesStructureChecking.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Infrastructure.DataAccess.Configurations.ArticleReview
{
    internal class ArticleReviewConfiguration : IEntityTypeConfiguration<ArticleReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleReviewEntity> builder)
        {
            builder.ToTable("ArticleReviews");
        }
    }
}
