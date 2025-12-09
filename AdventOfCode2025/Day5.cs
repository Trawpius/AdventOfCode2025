using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime;
using System.Security;

namespace AdventOfCode2025
{
    public static class Day5
    {
        
        public static int Puzzle1()
        {
            int count = 0;
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day5Puzzle1.txt");
           
            List<Tuple<double,double>> ranges = new List<Tuple<double,double>>();
            List<double> ids = new List<double>();

            foreach (string line in File.ReadLines(puzzlePath))
            {
                string[] parts = line.Split('-');
                if (parts.Length == 2)
                    ranges.Add(new Tuple<double, double>(double.Parse(parts[0]), double.Parse(parts[1])));
                else
                    ids.Add(double.Parse(parts[0]));

            }

            foreach(double id in ids)
            {
                bool found = false;
                foreach(Tuple<double, double> range in ranges)
                {
                    if(id >= range.Item1 && id <= range.Item2)
                    {
                        found = true; break;
                    }
                }
                if (found)
                    count++;
            }

            return count;
        }

        public static double Puzzle2()
        {
            double count = 0;
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day5Puzzle1.txt");

            List<Tuple<double, double>> ranges = new List<Tuple<double, double>>();
            //List<Tuple<double, double>> truncatedRanges = new List<Tuple<double, double>>();

            foreach (string line in File.ReadLines(puzzlePath))
            {
                string[] parts = line.Split('-');
                if (parts.Length == 2)
                    ranges.Add(new Tuple<double, double>(double.Parse(parts[0]), double.Parse(parts[1])));
            }
            ranges = ranges.OrderBy(x => x.Item1).ToList();

            Tuple<double, double> prevRange = null;
            foreach (var range in ranges)
            {
                if (prevRange == null)
                {
                    count += (range.Item2 - range.Item1 + 1);
                    prevRange = range;
                }
                else
                {
                    if (ContainedInRange(prevRange, range.Item1) && ContainedInRange(prevRange, range.Item2))
                    {
                        // skip
                    }
                    else if(ContainedInRange(prevRange, range.Item1) && !ContainedInRange(prevRange, range.Item2))
                    {
                        Tuple<double, double> newRange = new Tuple<double, double>(prevRange.Item2 + 1, range.Item2);
                        prevRange = range;
                        count += (newRange.Item2 - newRange.Item1 + 1);
                        //truncatedRanges.Add(newRange);
                    }
                    else if (!ContainedInRange(prevRange, range.Item1) && !ContainedInRange(prevRange, range.Item2))
                    {
                        prevRange = range;
                        count += (range.Item2 - range.Item1 + 1);
                        //truncatedRanges.Add(range);
                    }
                    else
                    {
                        throw new NotSupportedException("Help!");
                    }
                }
            }
            return count;
        }

        public static bool ContainedInRange(Tuple<double,double> range, double value)
        {
            if (value >= range.Item1 && value <= range.Item2)
                return true;
            return false;
        }
    }
}
