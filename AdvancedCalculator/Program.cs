﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            NewCalc newcalc = new NewCalc();
            newcalc.Calculation = Console.ReadLine();
        }
    }
}
