using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdvancedCalculator
{
    internal class NewCalc
    {
        string calculation;
        double result;

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
            List<string> list = new List<string>();
            // Regex matches letters and numbers and the rest and splits it into an array of strings? then removes white spaces
            Regex regex = new Regex(@"[a-zA-Z]+|[\d.]+|[\W](?<!\s)");
            MatchCollection ms = regex.Matches(calculation);
            foreach (Match m in ms)
            {
                list.Add(m.Value);
                //Console.WriteLine($"<{m.Value}>");
            }
            result = Compute(list);
            Console.WriteLine("# of units: " + ms.Count);
            Console.ReadLine();
        }

        private double Compute(List<string> list)
        {
            int i = 0;
            double r = 0;
            char lastOp = ' ';

            do
            {
                string s = list[i];
                if (Regex.IsMatch(list[i], @"^[\d\.]+$"))
                {
                    double n;
                    if (Double.TryParse(s, out n))
                    {

                        switch (lastOp)
                        {
                            case '+':
                                break;
                            case '-':
                                break;
                            case '*':
                                break;
                            case '/':
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine($"{list[i]} is Numerical");
                    }
                }
                else if (Regex.IsMatch(list[i], @"^\w+$"))
                {
                    Console.WriteLine($"{list[i]} is letters");
                }
                else if (Regex.IsMatch(list[i], @"^[\+\-\*\/]+$"))
                {
                    Console.WriteLine($"{list[i]} is operator");

                }
                else
                {
                    Console.WriteLine($"{list[i]} is invalid!");
                }
                i++;
            } while (i < list.Count);

            return r;
        }
    }
}