using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day12
{

    class Solution
    {

        public static List<string> Input =>
              InputHelper.GetInput(2020, 12);

        public static List<string> Test = new List<string>() { "F10", "N3", "F7", "R90", "F11" };

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
            int x = 0;
            int y = 0;
            int heading = 90;
            foreach (var instruction in Input)
            {
                int distance = int.Parse(instruction.Substring(1));
                switch (instruction[0])
                {
                    case 'N':
                        y += distance;
                        break;
                    case 'S':
                        y -= distance;
                        break;
                    case 'E':
                        x += distance;
                        break;
                    case 'W':
                        x -= distance;
                        break;
                    case 'R':
                        heading = (heading + distance) % 360;
                        break;
                    case 'L':
                        heading = (heading - distance + 360) % 360;
                        break;
                    case 'F':
                        switch (heading)
                        {
                            case 0:
                                y += distance;
                                break;
                            case 90:
                                x += distance;
                                break;
                            case 180:
                                y -= distance;
                                break;
                            case 270:
                                x -= distance;
                                break;
                        }
                        break;
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }

        public static int Part2()
        {
            int x = 0;
            int y = 0;
            int waypointX = 10;
            int waypointY = 1;
            foreach (var instruction in Input)
            {
                int distance = int.Parse(instruction.Substring(1));
                switch (instruction[0])
                {
                    case 'N':
                        waypointY += distance;
                        break;
                    case 'S':
                        waypointY -= distance;
                        break;
                    case 'E':
                        waypointX += distance;
                        break;
                    case 'W':
                        waypointX -= distance;
                        break;
                    case 'R':
                        for (int i = 0; i < distance; i += 90)
                        {
                            int tempY = waypointY;
                            waypointY = waypointX * -1;
                            waypointX = tempY;
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < distance; i += 90)
                        {
                            int tempX = waypointX;
                            waypointX = waypointY * -1;
                            waypointY = tempX;
                        }
                        break;
                    case 'F':
                        y += distance * waypointY;
                        x += distance * waypointX;
                        break;
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }
    }
}