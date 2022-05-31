using ArticlesStructureChecking.Application.Core.Constants;
using ArticlesStructureChecking.Application.Core.Interfaces;
using ArticlesStructureChecking.Domain.Models;
using ArticlesStructureChecking.Exceptions;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var isAthorsExist = false;
            var isAuthorsInformationExist = false;
            var isAuthorsFioExist = false;
            var isAuthorsMailExist = false;
            var fioRegex = new Regex(@"[А-Я]\.+");
            var mailRegex = new Regex(@"^((\w[^\W]+)[\.\-]?){1,}\@(([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3})|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");
            var authorsInformationParagraphs = new List<Paragraph>();
            Paragraph authorsParagraph = null;
            foreach (Word.Paragraph paragraph in paragraphs)
            {
                string text = (paragraph.Range == null || paragraph.Range.Text == null) ? null : paragraph.Range.Text;
                if (text != null && fioRegex.IsMatch(text))
                {
                    isAthorsExist = true;
                    authorsParagraph = paragraph;
                    _validateService.ValidateAuthorsName(ref mistakes, paragraph);
                }
                if (text != null && mailRegex.IsMatch(text))
                {
                    isAuthorsMailExist = true;
                }
            }
            if (!isAthorsExist || !isAuthorsMailExist)
            {
                if(!isAthorsExist)
                    mistakes.Add(new Mistake(MistakeTextConstants.AuthorsNotExist));
                if(!isAuthorsInformationExist)
                    mistakes.Add(new Mistake(MistakeTextConstants.AuthorsInformationNotExist));
            }
            else
            {
                authorsInformationParagraphs.Add(authorsParagraph.Next());
                do
                {
                    authorsInformationParagraphs.Add(authorsInformationParagraphs.Last().Next());
                } while (!mailRegex.IsMatch(authorsInformationParagraphs.Last().Range.Text) || authorsInformationParagraphs.Count > 3);
                if (mailRegex.IsMatch(authorsInformationParagraphs.Last().Range.Text))
                    _validateService.ValidateAuthorsInformation(ref mistakes, authorsInformationParagraphs);
                else
                    mistakes.Add(new Mistake(MistakeTextConstants.AuthorsInformationNotExist));
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
                while (!mainParagraphs.Last().Next().Range.Text.Contains("ЗАКЛЮЧЕНИЕ"))
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
                if (text != null && text.Contains("СПИСОК ЛИТЕРАТУРЫ"))
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
