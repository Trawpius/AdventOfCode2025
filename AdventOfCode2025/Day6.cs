using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public static class Day6
    {
        public static long Puzzle1()
        {
            long sum = 0;
            string filename = Path.Combine( Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "puzzles", "Day6Puzzle1.txt");
            string[] content = File.ReadAllLines(filename);
            string[] operandsStr = content.Take(content.Length - 1).ToArray();
            long[][] operands = operandsStr.Select(x => x.Split(' ', options: StringSplitOptions.RemoveEmptyEntries).Select(y => long.Parse(y)).ToArray()).ToArray();
            string[] operators = content.Last().Split(' ', options: StringSplitOptions.RemoveEmptyEntries).ToArray();

            for(int i = 0; i < operators.Length; i++)
            {
                long innerSum = 0;
                long innerProduct = 1;
                switch (operators[i])
                {
                    case "*":
                        {
                            for (int j = 0; j < operands.Length; j++)
                            {
                                Console.Write($"{operands[j][i]} * ");
                                innerProduct *= operands[j][i];
                            }
                            sum += innerProduct;
                        }
                        break;
                    case "+":
                        {
                            for(int j = 0; j < operands.Length; j++ )
                            {
                                Console.Write($"{operands[j][i]} + ");
                                innerSum += operands[j][i];
                            }
                            sum += innerSum;
                        }
                        break;
                    default:
                        throw new NotSupportedException("Heeeelp!");
                        
                }
                Console.WriteLine();
            }

            return sum;
        }


        public static long Puzzle2()
        {
            long sum = 0;
            string filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "puzzles", "Day6Puzzle1.txt");

            char[][] content = File.ReadAllLines(filename).Select(X => X.Reverse().ToArray()).ToArray() ;

            List<long> operands = new List<long>();

            for (int i = 0; i < content[0].Length; i++)
            {
                string columnString = ColumnString(content, i);
                char toOperate = columnString[columnString.Length - 1];
                string toParse = columnString.Remove(columnString.Length - 1, 1).Trim();
                
                if (toParse.Length==0)
                {
                    operands.Clear();
                }
                else
                {
                    long parsedString = long.Parse(toParse);
                    operands.Add(parsedString);
                   
                    if (toOperate == '*')
                    {
                        long mult = operands.Multiply();
                        Console.WriteLine($"{string.Join("*", operands)} = {mult}");
                        sum += mult;
                    }    
                    else if(toOperate == '+')
                    {
                        long add = operands.Addition();
                        Console.WriteLine($"{string.Join("+", operands)} = {add}");
                        sum += add;
                    }
                        
                }
            }
            return sum;
        }

        private static string ColumnString(char[][] content, int i)
        {
            string s = "";
            foreach (char[] row in content)
            {
                s += row[i];
            }
            return s;
        }

        private static long Multiply(this List<long> longs)
        {
            long product = 1;
            foreach (long l in longs) 
            {
               // Console.WriteLine($"{l} * ");
                product *= l; 
            }
            return product;
        }

        private static long Addition(this List<long> longs)
        {
            long sum = 0;
            foreach (long l in longs)
            {
               // Console.WriteLine($"{l} + ");
                sum += l;
            }
            return sum;
        }
    }
}
