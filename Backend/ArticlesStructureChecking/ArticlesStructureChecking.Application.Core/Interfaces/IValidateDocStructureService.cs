using ArticlesStructureChecking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace ArticlesStructureChecking.Application.Core.Interfaces
{
    public interface IValidateDocStructureService
    {
        List<Mistake> Validate(Word.Document document, string articleName);
    }
}
