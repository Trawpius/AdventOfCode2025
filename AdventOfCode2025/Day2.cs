using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public static class Day2
    {
        public static double Puzzle1()
        {
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day2Puzzle1.txt");
            string[] allIdRanges = string.Join("",File.ReadAllLines(puzzlePath)).Split(new char[] { ';', ',' }).ToArray();
            double sum = 0;
            foreach(string idRange in allIdRanges)
            {
                string[] idRangeSplit = idRange.Split('-');
                double start = double.Parse(idRangeSplit[0]);
                double stop = double.Parse(idRangeSplit[1]);

                for(double i = start; i <= stop; i++)
                {
                    string id = i.ToString();
                    if (id.Length % 2 == 0)
                    {
                        string firstHalf = new string(id.Take(id.Length / 2).ToArray());
                        string secondHalf = new string(id.Skip(id.Length / 2).ToArray());

                        if (firstHalf.Equals(secondHalf, StringComparison.OrdinalIgnoreCase))
                        {
                            double converted = double.Parse(id);
                            sum += converted;
                        }
                    }
                }
            }
            return sum;
        }

        public static double Puzzle2()
        {
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day2Puzzle1.txt");
            string[] allIdRanges = string.Join("", File.ReadAllLines(puzzlePath)).Split(new char[] { ';', ',' }).ToArray();
            double sum = 0;
            foreach (string idRange in allIdRanges)
            {
                string[] idRangeSplit = idRange.Split('-');
                double start = double.Parse(idRangeSplit[0]);
                double stop = double.Parse(idRangeSplit[1]);

                for (double i = start; i <= stop; i++)
                {
                    string id = i.ToString();
                    if (!IsValid(id))
                    {
                        double converted = double.Parse(id);
                        sum += converted;
                    }
                }
            }
            return sum;
        }

        private static bool IsValid(string id)
        {
            int middle = id.Length / 2;
            for (int i = 1; i <= middle; i++)
            {
                string tempID = id.Clone().ToString();
                string firstString = null;
                bool breakMatch = false;

                while(tempID.Count() > 0 && !breakMatch)
                {
                    string substring = String.Concat(tempID.Take(i));
                    if(firstString==null)
                        firstString = substring;
                    else
                    {
                        if (!firstString.Equals(substring))
                            breakMatch = true;
                    }
                    tempID = String.Concat((tempID.Skip(i)));
                }
                if (!breakMatch)
                    return false;
            }
            return true;
        }
    }
}
