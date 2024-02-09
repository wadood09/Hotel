using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPrinter
{
    internal class DoublePrint : IPaper
    {
        private StringBuilder _content = new();
        public void Print(string text)
        {
            _content.Append(text);
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(_content.ToString());
            Console.ResetColor();
        }
    }
}
