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
            calculation = calculation.Replace(".", ",");
            // Regex matches letters and numbers and the rest and splits it into an array of strings? then removes white spaces
            Regex regex = new Regex(@"[a-zA-Z]+|[\d\,]+|[\W](?<!\s)");
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
            char lastOp = '+';

            do
            {
                string s = list[i];
                if (Regex.IsMatch(s, @"^[\d]+|[,]$"))
                {
                    double n;
                    if (Double.TryParse(s, out n))
                    {
                        switch (lastOp)
                        {
                            case '+':
                                result += n;
                                break;
                            case '-':
                                result -= n;
                                break;
                            case '*':
                                result *= n;
                                break;
                            case '/':
                                result /= n;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        Console.WriteLine($"{s} couldn't become a double!");
                    Console.WriteLine($"{s} is Numerical, result = {result}");
                }
                else if (Regex.IsMatch(s, @"^\w+$"))
                {
                    Console.WriteLine($"{s} is letters");
                }
                else if (Regex.IsMatch(s, @"^[\+\-\*\/]+$"))
                {
                    lastOp = s[0];
                    Console.WriteLine($"{lastOp} is operator");
                }
                else
                {
                    Console.WriteLine($"Invalid input: {s}");
                }
                i++;
            } while (i < list.Count);

            return r;
        }
    }
}