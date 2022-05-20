﻿using ArticlesStructureChecking.Domain.Entities.Article;
using ArticlesStructureChecking.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Article.CreateArticleReview
{
    public class CreateArticleReviewCommandHandler : IRequestHandler<CreateArticleReviewCommand, Unit>
    {
        private readonly DbContext _db;
        private IHostEnvironment _hostingEnvironment;
        public CreateArticleReviewCommandHandler(DbContext db, IHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Unit> Handle(CreateArticleReviewCommand command, CancellationToken cancellationToken)
        {
            if (command.File.Length == 0)
                throw new BadRequestException("Empty file");

            var filesPath = Path.Combine(_hostingEnvironment.ContentRootPath, "files");

            string filePath = Path.Combine(filesPath, DateTime.Now.ToString());
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await command.File.CopyToAsync(fileStream);
            }

            var articleReview = new ArticleReviewEntity(command.ArticleId, filePath);
            await _db.Set<ArticleReviewEntity>().AddAsync(articleReview);
            return Unit.Value;
        }
    }
}
