﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPrinter
{
    public interface IPaper
    {
        void Print(string text);
        void Show();
    }
}
