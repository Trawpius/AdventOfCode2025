using System.Reflection;
using System.Runtime;

namespace AdventOfCode2025
{
    public static class Day4
    {
        static Tuple<int, int> up = Tuple.Create(-1, 0);
        static Tuple<int, int> upleft = Tuple.Create(-1, -1);
        static Tuple<int, int> upright = Tuple.Create(-1, 1);
        static Tuple<int, int> left = Tuple.Create(0, -1);
        static Tuple<int, int> right = Tuple.Create(0, 1);
        static Tuple<int, int> down = Tuple.Create(1, 0);
        static Tuple<int, int> downleft = Tuple.Create(1, -1);
        static Tuple<int, int> downright = Tuple.Create(1, 1);

        static char paperRoll = '@';
        static char empty = '.';
        public static double Puzzle1()
        {
            int sum = 0;
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day4Puzzle1.txt");
            char[][] gameboard = File.ReadAllLines(puzzlePath).Select(x => x.ToCharArray()).ToArray();
            int maxY = gameboard.Length-1;
            int maxX = gameboard[0].Length-1;

            for (int y = 0; y < gameboard.Length; y++)
            {
                for (int x = 0; x < gameboard[0].Length; x++)
                {
                    if (gameboard[y][x] == paperRoll)
                    {
                        int countAdj = 0;
                        if (y > 0 && gameboard[y + up.Item1][x + up.Item2] == paperRoll) countAdj++;
                        if (y > 0 && x > 0 && gameboard[y + upleft.Item1][x + upleft.Item2] == paperRoll) countAdj++;
                        if (y > 0 && x < maxX && gameboard[y + upright.Item1][x + upright.Item2] == paperRoll) countAdj++;
                        if (x > 0 && gameboard[y + left.Item1][x + left.Item2] == paperRoll) countAdj++;
                        if (x < maxX && gameboard[y + right.Item1][x + right.Item2] == paperRoll) countAdj++;
                        if (y < maxY && gameboard[y + down.Item1][x + down.Item2] == paperRoll) countAdj++;
                        if (y < maxY && x > 0 && gameboard[y + downleft.Item1][x + downleft.Item2] == paperRoll) countAdj++;
                        if (y < maxY && x < maxX && gameboard[y + downright.Item1][x + downright.Item2] == paperRoll) countAdj++;

                        if (countAdj < 4)
                            sum++;
                    }
                }
            }

            return sum;
        }

        public static double Puzzle2()
        {
            int sum = 0;
            string puzzlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Puzzles", "Day4Puzzle1.txt");
            char[][] gameboard = File.ReadAllLines(puzzlePath).Select(x => x.ToCharArray()).ToArray();
            int maxY = gameboard.Length - 1;
            int maxX = gameboard[0].Length - 1;

            int initialSum = sum;
            int delta = -1;
            while (delta != 0)
            {
                for (int y = 0; y < gameboard.Length; y++)
                {
                    for (int x = 0; x < gameboard[0].Length; x++)
                    {
                        if (gameboard[y][x] == paperRoll)
                        {
                            int countAdj = 0;
                            if (y > 0 && gameboard[y + up.Item1][x + up.Item2] == paperRoll) countAdj++;
                            if (y > 0 && x > 0 && gameboard[y + upleft.Item1][x + upleft.Item2] == paperRoll) countAdj++;
                            if (y > 0 && x < maxX && gameboard[y + upright.Item1][x + upright.Item2] == paperRoll) countAdj++;
                            if (x > 0 && gameboard[y + left.Item1][x + left.Item2] == paperRoll) countAdj++;
                            if (x < maxX && gameboard[y + right.Item1][x + right.Item2] == paperRoll) countAdj++;
                            if (y < maxY && gameboard[y + down.Item1][x + down.Item2] == paperRoll) countAdj++;
                            if (y < maxY && x > 0 && gameboard[y + downleft.Item1][x + downleft.Item2] == paperRoll) countAdj++;
                            if (y < maxY && x < maxX && gameboard[y + downright.Item1][x + downright.Item2] == paperRoll) countAdj++;

                            if (countAdj < 4)
                            {
                                gameboard[y][x] = empty;
                                sum++;
                            }
                        }
                    }
                }
                delta = initialSum - sum;
                initialSum = sum;
            }

            return sum;
        }
    }
}
