using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020.Solutions
{
    public static class Day1
    {
        public static List<int> Input =>
            InputHelper.GetInput(2020, 1).Select(int.Parse).ToList();

        public static void Run()
        {
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Part2();
            //Console.WriteLine(Part2());
        }

        public static int Part1()
        {
            int number1 = -1;
            int number2 = -1;

            foreach (int number in Input)
            {
                var numberToFind = 2020 - number;

                if (Input.Find(i => i == numberToFind) is int found && found != 0)
                {
                    number1 = number;
                    number2 = found;
                    break;
                }
            }

            return number1 * number2;
        }

        public static void Part2()
        {
            for (int i = 0; i < Input.Count - 2; i++)
            {
                for (int j = i + 1; j < Input.Count - 1; j++)
                {
                    for (int l = i + 2; l < Input.Count; l++)
                    {
                        if (Input[i] + Input[j] + Input[l] > 2020)
                            break;
                        if (Input[i] + Input[j] + Input[l] == 2020)
                        {
                            Console.WriteLine($"Found numbers: {Input[i]}, {Input[j]} and {Input[l]}");
                            Console.WriteLine($"Multiply: {Input[i] * Input[j] * Input[l]}");
                            break;
                        }
                    }
                }
            }
        }
    }
}
