using System.Reflection;

namespace AdventOfCode2025
{
    public static class Day1
    {
        public static int Puzzle1()
        {
            int position = 50;
            int zeroCount = 0;

            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day1Puzzle1.txt");
            foreach (string s in File.ReadLines(puzzlePath))
            {
                char direction = s[0];
                int rotation = int.Parse(new string(s.Skip(1).ToArray()));

                if (direction == 'L') 
                    position -= rotation;
                else if (direction == 'R')
                    position += rotation;
                else
                    throw new NotImplementedException();

                position = position % 100;
                if (position < 0) position = 100 + position;
                if (position == 0)
                    zeroCount++;
            }

            return zeroCount;
        }

        public static int Puzzle2()
        {
            int position = 50;
            int zeroCrossing = 0;

            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day1Puzzle1.txt");
            foreach (string s in File.ReadLines(puzzlePath))
            {
                char direction = s[0];
                int rotation = int.Parse(new string(s.Skip(1).ToArray()));

                int fullRotations = rotation / 100;
                int remainder = rotation % 100;

                int oldPosition = position;
                if (direction == 'L')
                    position -= remainder;
                else if (direction == 'R')
                    position += remainder;
                else
                    throw new NotImplementedException();

                zeroCrossing += fullRotations;

                // passes positive to negative
                if(position <= 0 && oldPosition > 0)
                    zeroCrossing++;
                // passes negative to positive
                if (position >= 100 && oldPosition < 100)
                    zeroCrossing++;

                position = position % 100;
                if (position < 0) position = 100 + position;
            }
            return zeroCrossing;
        }
    }
}
