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
                distancesToCentre.Add(ManhattanDistance(intersect));
            }
            return distancesToCentre.Min();
        }

        static int ManhattanDistance(Point point1)
            => Math.Abs(point1.X) + Math.Abs(point1.Y);

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

        static List<Point> DeterminePoints(string input)
        {
            var points = new List<Point>();
            var path = input.Split(',');

            var stats = new Point(x:0, y:0);
            foreach (var instruction in path)
            {
                var Move = new Point(x:0, y:0);
                switch (instruction[0])
                {
                    case 'U':
                        Move = new Point(0, 1);
                        break;
                    case 'D':
                        Move = new Point(0, -1);
                        break;
                    case 'R':
                        Move = new Point(1, 0);
                        break;
                    case 'L':
                        Move = new Point(-1, 0);
                        break;
                    default:
                        break;
                };

                int amount = int.Parse(instruction.Substring(1));
                for (int i = 0; i < amount; i++)
                {
                    stats = new Point(stats.X + Move.X, stats.Y + Move.Y);
                    points.Add(stats);
                }
            }
            return points;
        }
    }

    class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            if (other is null)
                return false;

            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) => Equals(obj as Point);
        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}