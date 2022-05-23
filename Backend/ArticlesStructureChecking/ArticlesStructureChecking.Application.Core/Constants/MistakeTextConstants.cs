using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Core.Constants
{
    public static class MistakeTextConstants
    {
        public const string YDKNotExist = "Отсутствует УДК.";
        public const string NameNotExist = "Отсутствует название статьи.";
        public const string AuthorsNotExist = "Отсутствуют авторы.";
        public const string AuthorsInformationNotExist = "Отсутствует информация об авторах.";
        public const string AnnotationNotExist = "Отсутствует аннотация.";
        public const string KeyWordNotExist = "Отсутствуют ключевые слова.";
        public const string IntroductionNotExist = "Отсутствует введение.";
        public const string ConclusionNotExist = "Отсутствует заключение.";
        public const string BibliographyNotExist = "Отсутствует список литературы.";

        public const string NameFontErr = "Неверный шрифт названия статьи. Требуется: Calibri.";
        public const string NameBoldErr = "Неверный шрифт названия статьи. Требуется: Bold";
        public const string NameTextSizeErr = "Неверный размер шрифта названия статьи. Требуется: 16pt";

        public const string AuthorsFontErr = "Неверный шрифт авторов. Требуется: Calibri.";
        public const string AuthorsBoldErr = "Неверный шрифт авторов. Требуется: Bold";
        public const string AuthorsTextSizeErr = "Неверный размер шрифта авторов. Требуется: 14pt";

        public const string AuthorsInformationFontErr = "Неверный шрифт информации об авторах. Требуется: Calibri.";
        public const string AuthorsInformationBoldErr = "Неверный шрифт информации об авторах. Требуется: Bold";
        public const string AuthorsInformationTextSizeErr = "Неверный размер шрифта информации об авторах. Требуется: 14pt";

        public const string AnnotationFontErr = "Неверный шрифт аннотации. Требуется: Calibri.";
        public const string AnnotationBoldErr = "Неверный шрифт аннотации. Требуется: Bold";
        public const string AnnotationItalicErr = "Неверный шрифт аннотации. Требуется: Italic";
        public const string AnnotationTextSizeErr = "Неверный размер шрифта аннотации. Требуется: 14pt";
        public const string TextAnnotationMaxLength = "Превышено кол-во максимум знаков текста аннотации. Требуется: не более 2000 знаков.";

        public const string KeyWordsNameBoldErr = "Неверный шрифт названия раздела Ключевые слова. Требуется: Bold";
        public const string KeyWordsFontErr = "Неверный шрифт ключевых слов. Требуется: Calibri.";
        public const string KeyWordsItalicErr = "Неверный шрифт ключевых слов. Требуется: italic";
        public const string KeyWordsTextSizeErr = "Неверный размер шрифта ключевых слов. Требуется: 14pt";
        public const string KeyWordsCountWarn = "Рекомендуемое кол-во ключевых слов: 10-15.";

        public const string IntroductionFontErr = "Неверный шрифт введении. Требуется: Calibri.";
        public const string IntroductionBoldErr = "Неверный шрифт названия раздела Введение. Требуется: Bold";
        public const string IntroductionTextSizeErr = "Неверный размер шрифта введения. Требуется: 14pt";

        public const string MainPartFontErr = "Неверный шрифт разделов. Требуется: Calibri.";
        public const string MainPartBoldErr = "Неверный шрифт названия разделов. Требуется: Bold";
        public const string MainPartTextSizeErr = "Неверный размер шрифта разделов. Требуется: 14pt";

        public const string ConclusionFontErr = "Неверный шрифт заключения. Требуется: Calibri.";
        public const string ConclusionBoldErr = "Неверный шрифт названия раздела Заключение. Требуется: Bold";
        public const string ConclusionTextSizeErr = "Неверный размер шрифта заключения. Требуется: 14pt";

        public const string BibliographyBoldErr = "Неверный шрифт списка литературы. Требуется: Bold";
        public const string BibliographyFontErr = "Неверный шрифт списка литературы. Требуется: Calibri.";
        public const string BibliographyItalicErr = "Неверный шрифт списка литературы. Требуется: italic";
        public const string BibliographyTextSizeErr = "Неверный размер шрифта списка литературы. Требуется: 14pt";
    }
}
