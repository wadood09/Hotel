using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPrinter
{
    public class GenericLaserPrinter<T> where T : IPaper
    {
        private readonly T _paper;
        public GenericLaserPrinter(T paper)
        {
            _paper = paper;
        }
        public void Print(string text)
        {
            _paper.Print(text);
        }

        public void Display()
        {
            _paper.Show();
        }
    }
}
