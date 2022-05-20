using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace ArticlesStructureChecking.Application.Core.Interfaces
{
    public interface IReadDocTextService
    {
        string GetMainText(Word.Document document);
    }
}
