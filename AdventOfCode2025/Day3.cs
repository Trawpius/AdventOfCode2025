using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public static class Day3
    {
        public static double Puzzle1()
        {
            int sum = 0;
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day3Puzzle1.txt");
            var lines = File.ReadAllLines(puzzlePath).Select(x => x.Select(y => int.Parse(y.ToString())).ToArray());
            foreach (var line in lines) 
            {
                (int max, int index) = MaxAndIndex(line);
                var subLine = line.Skip(index + 1).ToArray();
                (int nextMax, int nextIndex) = MaxAndIndex(subLine);

                sum += (max * 10 + nextMax);
            }
            return sum;
        }

        private static (int max, int index) MaxAndIndex(int[] line)
        {
            int max = -1;
            int maxIndex = -1;
            for (int i = 0; i < line.Count(); i++)
            {
                if (line[i] > max)
                {
                    max = line[i];
                    maxIndex = i;
                }
            }
            return (max, maxIndex);
        }

        public static double Puzzle2()
        {
            double sum = 0;
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day3Puzzle1.txt");
            var lines = File.ReadAllLines(puzzlePath).Select(x => x.Select(y => int.Parse(y.ToString())).ToArray());
            foreach (var line in lines)
            {
                int[] subLine = line;
                for (int i = 11; i >= 0; i--)
                {
                    (int max, int index) = MaxAndIndexInRange(subLine,i);
                    subLine = subLine.Skip(index + 1).ToArray();

                    sum += max * Math.Pow(10, i);
                }
            }
            return sum;
        }

        private static (int max, int index) MaxAndIndexInRange(int[] line, int remaining)
        {
            int length = line.Length;
            int indexStop = length - remaining;
            
            int max = -1;
            int maxIndex = -1;

            for (int i = 0; i < indexStop; i++)
            {
                if (line[i] > max)
                {
                    max = line[i];
                    maxIndex = i;
                }
            }
            return (max, maxIndex);
        }
    }
}
