using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day05 {
     
    class Solution{

        public static List<string> Input =>
              InputHelper.GetInput(2020, 05);

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static int Part1()
        {
            return Input.Select(b => CalculateSeat(b, 128, 8)).Max();
        }

        public static int Part2()
        {
            List<int> seatIds = Input.Select(b => CalculateSeat(b, 128, 8)).ToList();
            return Enumerable.Range(0, seatIds.Max()).Except(seatIds).Max();
        }

        public static int CalculateSeat(string input, int rows, int columns)
        {
            int minRow = 0;
            int maxRow = rows - 1;

            for (int i = 0; i < 7; i++)
            {
                switch (input[i])
                {
                    case 'F':
                        maxRow = (minRow + maxRow) / 2;
                        break;
                    case 'B':
                        minRow = ((minRow + maxRow) / 2) + 1;
                        break;
                }
            }

            int minCol = 0;
            int maxCol = columns - 1;
            for (int i = 7; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'R':
                        minCol = ((minCol + maxCol) / 2) + 1;
                        break;
                    case 'L':
                        maxCol = (minCol + maxCol) / 2;
                        break;
                }
            }

            return (minRow * columns) + minCol;
        }
    }
}