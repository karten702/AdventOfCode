using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day10
{

    class Solution
    {

        public static List<int> Input =>
              InputHelper.GetInput(2020, 10).Select(int.Parse).ToList();
        public static List<int> Test => new List<int>() { 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3 };

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
            List<int> dev = Input;
            dev.Add(0);
            dev.Add(dev.Max() + 3);
            dev = dev.OrderBy(x => x).ToList();
            int diff1 = 0;
            int diff3 = 0;

            for (int i = 0; i < dev.Count; i++)
            {
                if (i + 1 == dev.Count)
                    break;
                if (dev[i + 1] - dev[i] < 3)
                    diff1++;
                else
                    diff3++;                    
            }
            return diff1 * diff3;
        }

        public static long Part2()
        {
            List<int> dev = Input;
            dev.Add(0);
            dev.Add(Input.Max() + 3);
            dev = dev.OrderBy(x => x).ToList();
            long[] ways= new long[dev.Count];
            ways[0] = 1;

            for (int i = 0; i < dev.Count; i++)
            {
                for (int j = i + 1; j < dev.Count; j++)
                {
                    if (dev[j] - dev[i] > 3)
                        break;
                    ways[j] = ways[j] += ways[i];
                }
            }

            return ways.Last();
        }
    }
}