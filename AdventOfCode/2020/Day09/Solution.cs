using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day09
{

    class Solution
    {

        public static List<long> Input =>
              InputHelper.GetInput(2020, 09).Select(long.Parse).ToList();

        public static void Run()
        {
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static long Part1()
        {
            //List<int> testList = new List<int>() { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 };
            //for (int i = 5; i < testList.Count; i++)
            //{
            //    if (!FindCombination(testList.GetRange(i - 5, 5), testList[i]))
            //        return testList[i];
            //}
            for (int i = 25; i < Input.Count; i++)
            {
                if (!FindCombination(Input.GetRange(i - 25, 25), Input[i]))
                    return Input[i];
            }

            return 0;
        }

        public static string Part2()
        {
            //List<long> testList = new List<long>() { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 };
            long invalidNumber = 0;
            //for (int i = 5; i < testList.Count; i++)
            //{
            //    if (!FindCombination(testList.GetRange(i - 5, 5), testList[i]))
            //        invalidNumber = testList[i];
            //}

            //int startIndex = 0;
            //int endIndex = 1;
            //while (true)
            //{
            //    var x = testList.GetRange(startIndex, endIndex).Sum();
            //    if (x == invalidNumber)
            //    {
            //        long highest = testList.GetRange(startIndex, endIndex).Max();
            //        long lowest = testList.GetRange(startIndex, endIndex).Min();
            //        Console.WriteLine($"Indexes: {startIndex} - {startIndex+endIndex-1}");
            //        Console.WriteLine($"High: {highest} - Low: {lowest}");
            //        Console.WriteLine($"Sum: {highest + lowest}");
            //        return $"High: {highest} - Low: {lowest}";
            //        //return $"Start: {testList[startIndex]} - End: {testList[startIndex+endIndex-1]}";
            //    }
            //    else if (x < invalidNumber)
            //        endIndex++;
            //    else if (x > invalidNumber)
            //    {
            //        startIndex++;
            //        endIndex = 1;
            //    }

            //    if (endIndex == testList.Count/2)
            //    {
            //        startIndex++;
            //        endIndex = 1;
            //    }
            //    if (startIndex == testList.Count)
            //        return "IDIOT!";
            //}

            for (int i = 25; i < Input.Count; i++)
            {
                if (!FindCombination(Input.GetRange(i - 25, 25), Input[i]))
                    invalidNumber = Input[i];
            }

            int startIndex = 0;
            int endIndex = 1;
            while (true)
            {
                var x = Input.GetRange(startIndex, endIndex).Sum();
                if (x == invalidNumber)
                {
                    long highest = Input.GetRange(startIndex, endIndex).Max();
                    long lowest = Input.GetRange(startIndex, endIndex).Min();
                    Console.WriteLine($"Sum: {highest + lowest}");
                    return $"high: {highest} - low: {lowest}";
                }
                else if (x < invalidNumber)
                    endIndex++;
                else if (x > invalidNumber)
                {
                    startIndex++;
                    endIndex = 1;
                }

                if (endIndex > Input.Count / 2)
                {
                    endIndex = (startIndex + 1) % (Input.Count / 2);
                }
                if (startIndex == Input.Count)
                    return "IDIOT!";
            }
        }

        private static bool FindCombination(List<long> options, long numberToFind)
        {
            HashSet<long> s = new HashSet<long>();
            for (int i = 0; i < options.Count; ++i)
            {
                long temp = numberToFind - options[i];

                if (s.Contains(temp))
                {
                    return true;
                }
                s.Add(options[i]);
            }
            Console.WriteLine("No pair for number: " + numberToFind);
            return false;
        }
    }
}