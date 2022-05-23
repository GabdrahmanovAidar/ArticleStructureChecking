using ArticlesStructureChecking.Application.Core.Constants;
using ArticlesStructureChecking.Application.Core.Interfaces;
using ArticlesStructureChecking.Domain.Models;
using ArticlesStructureChecking.Exceptions;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace ArticlesStructureChecking.Application.Core.Services
{
    public class ValidateDocStructureService : IValidateDocStructureService
    {
        private readonly IValidateStylisticsDocService _validateService;
        public List<Mistake> mistakes = new List<Mistake>();

        public ValidateDocStructureService(IValidateStylisticsDocService validateService)
        {
            _validateService = validateService;
        }

        public List<Mistake> Validate(Document doc, string articleName)
        {
            var paragraphs = doc.Paragraphs;
            YDKCheck(paragraphs);
            NameCheck(paragraphs, articleName);
            AuthorsCheck(paragraphs);
            AnnotationCheck(paragraphs);
            KeyWordsCheck(paragraphs);
            MainPartCheck(paragraphs);
            BibliographyCheck(paragraphs);
            return mistakes;
        }

        private void YDKCheck(Paragraphs paragraphs)
        {
            var isYDKExist = false;
            var YDKString = "УДК";
            foreach (Word.Paragraph paragraph in paragraphs)
            {
                string text = (paragraph.Range == null || paragraph.Range.Text == null) ? null : paragraph.Range.Text;
                if (text != null && text.Contains(YDKString))
                    isYDKExist = true;
            }
            if (!isYDKExist)
                mistakes.Add(new Mistake(MistakeTextConstants.YDKNotExist));
        }

        private void NameCheck(Paragraphs paragraphs, string articleName)
        {
            var isNameExist = false;
            foreach (Word.Paragraph paragraph in paragraphs)
            {
                string text = (paragraph.Range == null || paragraph.Range.Text == null) ? null : paragraph.Range.Text;
                if (text != null && text.Contains(articleName))
                {
                    isNameExist = true;
                    _validateService.ValidateArticleName(ref mistakes, paragraph);
                }
            }
            if (!isNameExist)
                mistakes.Add(new Mistake(MistakeTextConstants.YDKNotExist));
                
        }
        private void AuthorsCheck(Paragraphs paragraphs)
        {
            foreach (Word.Paragraph paragraph in paragraphs)
            {

            }
        }
        private void AnnotationCheck(Paragraphs paragraphs)
        {
            var isAnnotationExist = false;
            foreach (Word.Paragraph paragraph in paragraphs)
            {
                string text = (paragraph.Range == null || paragraph.Range.Text == null) ? null : paragraph.Range.Text;
                if (text != null && text.Contains("Аннотация"))
                {
                    isAnnotationExist = true;
                    _validateService.ValidateAnnotation(ref mistakes, paragraph, paragraph.Next());
                }
            }
            if (!isAnnotationExist)
                mistakes.Add(new Mistake(MistakeTextConstants.AnnotationNotExist));
        }
        private void KeyWordsCheck(Paragraphs paragraphs)
        {
            var isKeyWordsExist = false;
            foreach (Word.Paragraph paragraph in paragraphs)
            {
                string text = (paragraph.Range == null || paragraph.Range.Text == null) ? null : paragraph.Range.Text;
                if (text != null && text.Contains("Ключевые слова"))
                {
                    isKeyWordsExist = true;
                    _validateService.ValidateKeyWord(ref mistakes, paragraph);
                }
            }
            if (!isKeyWordsExist)
                mistakes.Add(new Mistake(MistakeTextConstants.KeyWordNotExist));
        }
        private void MainPartCheck(Paragraphs paragraphs)
        {
            var isIntroductionExist = false;
            var isConclusionExist = false;
            var mainParagraphs = new List<Paragraph>();
            Paragraph introductionParagraph = null;
            foreach (Word.Paragraph paragraph in paragraphs)
            {
                string text = (paragraph.Range == null || paragraph.Range.Text == null) ? null : paragraph.Range.Text;
                if (text != null && text.Contains("ВВЕДЕНИЕ"))
                {
                    introductionParagraph = paragraph;
                    isIntroductionExist = true;
                    _validateService.ValidateIntroduction(ref mistakes, paragraph, paragraph.Next());
                }
                if (text != null && text.Contains("ЗАКЛЮЧЕНИЕ"))
                {
                    isConclusionExist = true;
                    _validateService.ValidateCocnlusion(ref mistakes, paragraph, paragraph.Next());
                }
            }
            if (!isIntroductionExist)
                mistakes.Add(new Mistake(MistakeTextConstants.IntroductionNotExist));
            if (!isConclusionExist)
                mistakes.Add(new Mistake(MistakeTextConstants.ConclusionNotExist));
            if (isConclusionExist && isIntroductionExist && introductionParagraph != null)
            {
                mainParagraphs.Add(introductionParagraph.Next());
                while (mainParagraphs.Last().Next().Range.Text.Contains("ЗАКЛЮЧЕНИЕ"))
                    mainParagraphs.Add(mainParagraphs.Last().Next());
                _validateService.ValidateMainPart(ref mistakes, mainParagraphs);
            }
        }
        private void BibliographyCheck(Paragraphs paragraphs)
        {
            var isBibliographyExist = false;
            foreach (Word.Paragraph paragraph in paragraphs)
            {
                string text = (paragraph.Range == null || paragraph.Range.Text == null) ? null : paragraph.Range.Text;
                if (text != null && text.Contains("Ключевые слова"))
                {
                    isBibliographyExist = true;
                    _validateService.ValidateBibliography(ref mistakes, paragraph);
                }
            }
            if (!isBibliographyExist)
                mistakes.Add(new Mistake(MistakeTextConstants.BibliographyNotExist));
        }
    }
}
