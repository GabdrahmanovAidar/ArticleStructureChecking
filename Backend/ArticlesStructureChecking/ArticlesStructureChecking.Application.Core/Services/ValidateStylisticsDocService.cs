using ArticlesStructureChecking.Application.Core.Constants;
using ArticlesStructureChecking.Application.Core.Interfaces;
using ArticlesStructureChecking.Domain.Enums;
using ArticlesStructureChecking.Domain.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Core.Services
{
    public class ValidateStylisticsDocService : IValidateStylisticsDocService
    {
        public void ValidateAnnotation(ref List<Mistake> mistakes, Paragraph header, Paragraph text)
        {
            if (header.Range.Font.Name != "Calibri" || text.Range.Font.Name != "Calibri")
                mistakes.Add(new Mistake(MistakeTextConstants.AnnotationFontErr));
            if (header.Range.Font.Bold == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.AnnotationBoldErr));
            if (header.Range.Font.Italic == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.AnnotationItalicErr));
            if (header.Range.Font.Size != 14 || text.Range.Font.Size != 14)
                mistakes.Add(new Mistake(MistakeTextConstants.AnnotationTextSizeErr));
            if (text.Range.Text.Length > 2000)
                mistakes.Add(new Mistake(MistakeTextConstants.TextAnnotationMaxLength));
        }

        public void ValidateArticleName(ref List<Mistake> mistakes, Paragraph paragraph)
        {
            if (paragraph.Range.Font.Name != "Calibri")
                mistakes.Add(new Mistake(MistakeTextConstants.NameFontErr));
            if (paragraph.Range.Font.Bold == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.NameBoldErr));
            if (paragraph.Range.Font.Size != 16)
                mistakes.Add(new Mistake(MistakeTextConstants.NameTextSizeErr));
        }

        public void ValidateAuthorsInformation(ref List<Mistake> mistakes, List<Paragraph> paragraphs)
        {
            return;
        }

        public void ValidateAuthorsName(ref List<Mistake> mistakes, Paragraph paragraph)
        {
            return;
        }

        public void ValidateBibliography(ref List<Mistake> mistakes, Paragraph paragraph)
        {
            if (paragraph.Range.Font.Name != "Calibri")
                mistakes.Add(new Mistake(MistakeTextConstants.BibliographyFontErr));
            if (paragraph.Range.Font.Italic != 0)
                mistakes.Add(new Mistake(MistakeTextConstants.BibliographyItalicErr));
            if (paragraph.Range.Font.Size != 14)
                mistakes.Add(new Mistake(MistakeTextConstants.BibliographyTextSizeErr));
            if (paragraph.Range.Font.Bold == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.BibliographyBoldErr));
        }

        public void ValidateCocnlusion(ref List<Mistake> mistakes, Paragraph header, Paragraph text)
        {
            if (header.Range.Font.Name != "Calibri" || text.Range.Font.Name != "Calibri")
                mistakes.Add(new Mistake(MistakeTextConstants.ConclusionFontErr));
            if (header.Range.Font.Size != 14 || text.Range.Font.Size != 14)
                mistakes.Add(new Mistake(MistakeTextConstants.ConclusionTextSizeErr));
            if (header.Range.Font.Bold == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.ConclusionBoldErr));
        }

        public void ValidateIntroduction(ref List<Mistake> mistakes, Paragraph header, Paragraph text)
        {
            if (header.Range.Font.Name != "Calibri" || text.Range.Font.Name != "Calibri")
                mistakes.Add(new Mistake(MistakeTextConstants.IntroductionFontErr));
            if (header.Range.Font.Size != 14 || text.Range.Font.Size != 14)
                mistakes.Add(new Mistake(MistakeTextConstants.IntroductionTextSizeErr));
            if (header.Range.Font.Bold == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.IntroductionBoldErr));
        }

        public void ValidateKeyWord(ref List<Mistake> mistakes, Paragraph paragraph)
        {
            if (paragraph.Range.Font.Name != "Calibri")
                mistakes.Add(new Mistake(MistakeTextConstants.KeyWordsFontErr));
            if (paragraph.Range.Font.Italic == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.KeyWordsItalicErr));
            if (paragraph.Range.Font.Size != 14)
                mistakes.Add(new Mistake(MistakeTextConstants.KeyWordsTextSizeErr));
            var keywordsString = paragraph.Range.Text.Split(":")[1];
            var keywords = keywordsString.Split(",");
            if (keywords.Length < 10 || keywords.Length > 15)
                mistakes.Add(new Mistake(MistakeTextConstants.KeyWordsCountWarn, EMistakeType.Warn));
            paragraph.Range.MoveEndUntil(":");
            if (paragraph.Range.Font.Bold == 0)
                mistakes.Add(new Mistake(MistakeTextConstants.KeyWordsNameBoldErr));
        }

        public void ValidateMainPart(ref List<Mistake> mistakes, List<Paragraph> paragraphs)
        {
            return;
        }
    }
}
