using ArticlesStructureChecking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Domain.Models
{
    public class Mistake
    {
        public Mistake(string text, string? position = null)
        {
            Text = text;
            Type = EMistakeType.Error;
            Position = position;
        }

        public Mistake(string text, EMistakeType type, string? position = null)
        {
            Text = text;
            Type = type;
            Position = position;
        }

        public string Text { get; set; }
        public string Position { get; set; }
        public EMistakeType Type { get; set; }
    }
}
