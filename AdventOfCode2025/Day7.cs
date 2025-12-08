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
    public static class Day7
    {
        public static int Puzzle1()
        {
            int count = 0;
            string filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "puzzles", "Day7Puzzle1.txt");

            char[][] gameboard = File.ReadAllLines(filename).Select(x => x.ToCharArray()).ToArray();
            Tuple<int, int> startingPosition = Tuple.Create(0, gameboard[0].ToList().FindIndex(x => x == 'S'));
            return March(gameboard, startingPosition);
        }

        private static int March(char[][] gameboard, Tuple<int, int> startingPosition)
        {
            int split = 0;
            // cannot move down any further
            if (startingPosition.Item1 >= gameboard.Length - 1)
                return split;

            Tuple<int, int> moveDown = new Tuple<int, int>(startingPosition.Item1 + 1, startingPosition.Item2);

            // already trodden path
            char moveDownPosition = gameboard[moveDown.Item1][moveDown.Item2];
            if (moveDownPosition == '|')
                return split;
            else if (moveDownPosition == '^')
            {
                split++;
                Tuple<int, int> moveLeft = new Tuple<int, int>(startingPosition.Item1, startingPosition.Item2 - 1);
                split += March(gameboard, moveLeft);
                Tuple<int, int> moveRight = new Tuple<int, int>(startingPosition.Item1, startingPosition.Item2 + 1);
                split += March(gameboard, moveRight);

                return split;
            }
            else
            {
                gameboard[moveDown.Item1][moveDown.Item2] = '|';
                return split += March(gameboard, moveDown);
            }
        }

        public static long Puzzle2()
        {
            long count = 0;
            string filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "puzzles", "Day7Puzzle1.txt");
            //string filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "puzzles", "test.txt");

            string[][] gameboard = File.ReadAllLines(filename).Select(x => x.ToCharArray().Select(y => y.ToString()).ToArray()).ToArray();
            Tuple<int, int> startingPosition = Tuple.Create(0, gameboard[0].ToList().FindIndex(x => x == "S"));
            count = MarchDuplicatePath(gameboard, startingPosition);
            //Print(gameboard);
            return count;
        }

        private static long MarchDuplicatePath(string[][] gameboard, Tuple<int, int> startingPosition)
        {
            long worlds = 0;
            // cannot move down any further
            if (startingPosition.Item1 >= gameboard.Length - 1)
                return 1;

            Tuple<int, int> currentPosition = new Tuple<int, int>(startingPosition.Item1 + 1, startingPosition.Item2);
            string currentPositionValue = gameboard[currentPosition.Item1][currentPosition.Item2];
            string startingPositionValue = gameboard[startingPosition.Item1][startingPosition.Item2];

            if (currentPositionValue == "^")
            {
                Tuple<int, int> moveLeft = new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1);
                long worldsLeft = MarchDuplicatePath(gameboard, moveLeft);
                gameboard[moveLeft.Item1][moveLeft.Item2] = worldsLeft.ToString();

                Tuple<int, int> moveRight = new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1);
                long worldsRight = MarchDuplicatePath(gameboard, moveRight);
                gameboard[moveRight.Item1][moveRight.Item2] = worldsRight.ToString();

                return worlds + worldsRight + worldsLeft;
            }
            else if (long.TryParse(startingPositionValue, out worlds))
            {
                return worlds;
            }
            else
            {
                gameboard[currentPosition.Item1][currentPosition.Item2] = "|";
                return worlds += MarchDuplicatePath(gameboard, currentPosition);
            }
        }

        public static void Print(string[][] gameboard)
        {
            string s = "";
            foreach (string[] board in gameboard)
            {
                foreach (string c in board)
                    s += c;
                s += "\n";
            }
            Console.Clear();
            Console.WriteLine(s);
        }
    }
}