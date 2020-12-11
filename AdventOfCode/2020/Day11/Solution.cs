using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day11
{

    class Solution
    {

        public static List<string> Input =>
              InputHelper.GetInput(2020, 11);

        public static List<string> Test = new List<string>()
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };

        public static void Run()
        {
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static int Part1()
        {
            var grid = BuildArr(Input);
            int maxX = grid.GetLength(1);
            int maxY = grid.GetLength(0);

            var resulting = grid.Clone() as char[,];
            var lastGrid = grid.Clone() as char[,];
            int numberOfIterations = 0;

            while (true)
            {
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        resulting[i, j] = SetThing(lastGrid, i, j, 4, GetAdjacent(lastGrid, i, j, maxY, maxX));
                    }
                }
                if (resulting.Cast<char>().SequenceEqual(lastGrid.Cast<char>()))
                {
                    Console.WriteLine($"Iterations: {numberOfIterations}");
                    Console.Write("Number of seats taken: ");
                    return resulting.Cast<char>().Count(x => x == '#');
                }
                else
                {
                    numberOfIterations++;
                    lastGrid = resulting.Clone() as char[,];
                }
            }
        }

        public static int Part2()
        {
            var grid = BuildArr(Input);
            int maxX = grid.GetLength(1);
            int maxY = grid.GetLength(0);

            var resulting = grid.Clone() as char[,];
            var lastGrid = grid.Clone() as char[,];
            int numberOfIterations = 0;

            while (true)
            {
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        resulting[i, j] = SetThing(lastGrid, i, j, 5, GetAdjacentPart2(lastGrid, i, j, maxY, maxX));
                    }
                }
                if (resulting.Cast<char>().SequenceEqual(lastGrid.Cast<char>()))
                {
                    Console.WriteLine($"Iterations: {numberOfIterations}");
                    Console.Write("Number of seats taken: ");
                    return resulting.Cast<char>().Count(x => x == '#');
                }
                else
                {
                    numberOfIterations++;
                    lastGrid = resulting.Clone() as char[,];
                }
            }
        }

        private static char SetThing(char[,] grid, int y, int x, int tolerancy, List<char> results)
        {
            return (grid[y, x]) switch
            {
                'L' => results.Any(x => x == '#') ? grid[y, x] : '#',
                '#' => results.Count(x => x == '#') >= tolerancy ? grid[y, x] : 'L',
                _ => grid[y,x]
            };
        }

        private static char[,] BuildArr(List<string> input)
        {
            char[,] grid = new char[input.Count, input[0].Length];

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    grid[i, j] = input[i][j];
                }
            }

            return grid;
        }

        static List<(int y, int x)> directions = new List<(int y, int x)>() { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (-1, 1), (1, -1), (-1, -1) };

        private static List<char> GetAdjacentPart2(char[,] grid, int y, int x, int maxY, int maxX)
        {
            List<char> result = new List<char>(8);
            foreach (var direction in directions)
            {
                int dirY = y;
                int dirX = x;
                while (true)
                {
                    dirX += direction.x;
                    dirY += direction.y;

                    if (dirX >= 0 && dirY >= 0 && dirX < maxX && dirY < maxY)
                    {
                        if (grid[dirY, dirX] != '.')
                        {
                            result.Add(grid[dirY, dirX]);
                            break;
                        }
                    }
                    else
                        break;
                }
            }
            return result;
        }

        private static List<char> GetAdjacent(char[,] grid, int y, int x, int maxY, int maxX)
        {
            List<char> result = new List<char>(8);
            foreach (var direction in directions)
            {
                int dirY = y + direction.y;
                int dirX = x + direction.x;
                if (dirX >= 0 && dirY >= 0 && dirX < maxX && dirY < maxY)
                {
                    result.Add(grid[dirY, dirX]);
                }
            }
            return result;
        }
    }
}