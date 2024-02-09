using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPrinter
{
    public class Sunrise : IPaper
    {
        private StringBuilder _content = new ();
        public void Print(string text)
        {
            _content.Append (text);
        }

        public void Show()
        {
            Console.WriteLine(_content.ToString());
        }
    }
}
