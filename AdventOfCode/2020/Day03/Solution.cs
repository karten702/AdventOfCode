using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day03 {
     
    class Solution{

        public static string[] Input =>
              InputHelper.GetInput(2020, 03).ToArray();

        public static void Run()
        {
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }

        public static string Part1()
        {
            int treeCounter = TreesForSlope(3, 1);

            return $"Bomen: {treeCounter}";
        }

        public static string Part2()
        {
            long Slope1 = TreesForSlope(1, 1);
            long Slope2 = TreesForSlope(3, 1);
            long Slope3 = TreesForSlope(5, 1);
            long Slope4 = TreesForSlope(7, 1);
            long Slope5 = TreesForSlope(1, 2);

            Console.WriteLine(Slope1);
            Console.WriteLine(Slope2);
            Console.WriteLine(Slope3);
            Console.WriteLine(Slope4);
            Console.WriteLine(Slope5);

            long TotalTrees = Slope1 * Slope2 * Slope3 * Slope4 * Slope5;
            return $"Totaal aantal bomen: {TotalTrees}";
        }

        private static int TreesForSlope(int right, int down)
        {
            int positionX = 0;
            int treeCounter = 0;
            for (int i = down; i < Input.Length; i += down)
            {
                positionX += right;
                positionX %= Input[i].Length;
                if (Input[i][positionX].Equals('#'))
                    treeCounter++;
            }
            return treeCounter;
        }
    }
}