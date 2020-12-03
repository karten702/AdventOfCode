using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2019.Day03
{

    class Solution
    {

        public static List<string> Input =>
              InputHelper.GetInput(2019, 03);

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
            var line1 = DeterminePoints(Input[0]);
            var line2 = DeterminePoints(Input[1]);
            var intersects = line1.Intersect(line2);
            List<int> distancesToCentre = new List<int>();
            foreach (var intersect in intersects)
            {
                distancesToCentre.Add(ManhattanDistance(intersect, (0, 0)));
            }
            return distancesToCentre.Min();
        }

        static int ManhattanDistance((int x, int y) point1, (int x, int y) point2)
            => Math.Abs(point1.x - point2.x) + Math.Abs(point1.y - point2.y);

        public static int Part2()
        {
            var line1 = DeterminePoints(Input[0]);
            var line2 = DeterminePoints(Input[1]);
            var intersects = line1.Intersect(line2);
            List<int> distancesTaken = new List<int>();
            foreach (var intersect in intersects)
            {
                distancesTaken.Add(line1.IndexOf(intersect) + 1 + line2.IndexOf(intersect) + 1);
            }


            return distancesTaken.Min();
        }

        static List<(int x, int y)> DeterminePoints(string input)
        {
            var points = new List<(int x, int y)>();
            var path = input.Split(',');

            var stats = (x:0, y:0);
            foreach (var instruction in path)
            {
                var Move = (x:0, y:0);
                switch (instruction[0])
                {
                    case 'U':
                        Move = (0, 1);
                        break;
                    case 'D':
                        Move = (0, -1);
                        break;
                    case 'R':
                        Move = (1, 0);
                        break;
                    case 'L':
                        Move = (-1, 0);
                        break;
                    default:
                        break;
                };

                int amount = int.Parse(instruction.Substring(1));
                for (int i = 0; i < amount; i++)
                {
                    stats = (stats.x + Move.x, stats.y + Move.y);
                    points.Add(stats);
                }
            }
            return points;
        }
    }
}