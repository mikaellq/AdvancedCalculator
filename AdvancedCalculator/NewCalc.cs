using System;
using System.Text.RegularExpressions;

namespace AdvancedCalculator
{
    internal class NewCalc
    {
        string calculation;

        public NewCalc()
        {
            calculation = "";
        }

        internal string Calculation
        {
            get
            {
                return calculation;
            }
            set
            {
                calculation = value;
                TestCalculation(calculation);
            }
        }

        private void TestCalculation(string calculation)
        {
//            char[] delimiterChars = { ' ', '+', '-', '*', '/' };
            Regex regex = new Regex(@"[\w]+|[\W]");
            MatchCollection ms = regex.Matches(calculation);
            foreach (Match m in ms)
            {
                Console.WriteLine(m.Value);
            }
            Console.ReadLine();
            //foreach (var word in words)
            //{
            //    System.Console.WriteLine($"<{word}>");
            //}
        }
    }
}