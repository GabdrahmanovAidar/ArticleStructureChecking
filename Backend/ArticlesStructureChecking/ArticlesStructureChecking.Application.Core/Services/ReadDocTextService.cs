using ArticlesStructureChecking.Application.Core.Interfaces;
using ArticlesStructureChecking.Exceptions;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Application.Core.Services
{
    public class ReadDocTextService : IReadDocTextService
    {
        public string GetMainText(Document doc)
        {
            object StartPosition = 0;
            object EndPositiojn = doc.Characters.Count;
            var range = doc.Range(ref StartPosition, ref EndPositiojn);

            // Получение основного текста со страниц (без учёта сносок и колонтитулов)
            string mainText = (range == null || range.Text == null) ? null : range.Text;
            if (mainText == null)
                throw new BadRequestException("Empty document");

            return mainText;
        }
    }
}
