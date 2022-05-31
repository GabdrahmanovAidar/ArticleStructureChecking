using ArticlesStructureChecking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace ArticlesStructureChecking.Application.Core.Interfaces
{
    public interface IValidateStylisticsDocService
    {
        void ValidateArticleName(ref List<Mistake> mistakes, Word.Paragraph paragraph);
        void ValidateAuthorsName(ref List<Mistake> mistakes, Word.Paragraph paragraph);
        void ValidateAuthorsInformation(ref List<Mistake> mistakes, List<Word.Paragraph> paragraph);
        void ValidateAnnotation(ref List<Mistake> mistakes, Word.Paragraph header, Word.Paragraph text);
        void ValidateKeyWord(ref List<Mistake> mistakes, Word.Paragraph paragraph);
        void ValidateMainPart(ref List<Mistake> mistakes, List<Word.Paragraph> paragraphs);
        void ValidateIntroduction(ref List<Mistake> mistakes, Word.Paragraph header, Word.Paragraph text);
        void ValidateCocnlusion(ref List<Mistake> mistakes, Word.Paragraph header, Word.Paragraph text);
        void ValidateBibliography(ref List<Mistake> mistakes, Word.Paragraph paragraph);
    }
}
