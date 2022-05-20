using ArticlesStructureChecking.Application.Core.Interfaces;
using ArticlesStructureChecking.Domain.Entities.Article;
using ArticlesStructureChecking.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace ArticlesStructureChecking.Application.Article.CheckArticleReview
{
    public class CheckArticleReviewCommandHandler : IRequestHandler<CheckArticleReviewCommand, CheckArticleReviewResponse>
    {
        private readonly DbContext _db;
        private readonly IReadDocTextService _readDocTextService;

        public CheckArticleReviewCommandHandler(DbContext db, IReadDocTextService readDocTextService)
        {
            _db = db;
            _readDocTextService = readDocTextService;
        }

        public async Task<CheckArticleReviewResponse> Handle(CheckArticleReviewCommand request, CancellationToken cancellationToken)
        {
            var articleReview = await _db.Set<ArticleReviewEntity>().FirstOrDefaultAsync(x => x.Id == request.ArticleReviewId);
            if (articleReview == null)
                throw new NotFoundException(@"Article review with id {} not found");

            object filePath = articleReview.FilePath;
            object rOnly = true;
            object SaveChanges = false;
            object MissingObj = System.Reflection.Missing.Value;

            Word.Application app = new Word.Application();
            Word.Document doc = null;

            try
            {
                doc = app.Documents.Open(ref filePath, ref MissingObj, ref rOnly, ref MissingObj,
                                         ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj,
                                         ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj,
                                         ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj);

                var mainText = _readDocTextService.GetMainText(doc);
            }
            catch
            {

            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(ref SaveChanges);
                }
                if (app != null)
                {
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                    app = null;
                }
            }
            return new CheckArticleReviewResponse();
        }
    }
}
