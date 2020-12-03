using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2019.Day02
{

    class Solution
    {

        public static List<int> Input =>
              InputHelper.GetInput(2019, 02)[0].Split(',').Select(int.Parse).ToList();

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
            Input[1] = 12;
            Input[2] = 2;

            for (int i = 0; i < Input.Count; i+=4)
            {
                if (Input[i] == 99)
                    break;
                else if (Input[i] == 1)
                    Input[Input[i + 3]] = Input[Input[i + 1]] + Input[Input[i + 2]];
                else if (Input[i] == 2)
                    Input[Input[i + 3]] = Input[Input[i + 1]] * Input[Input[i + 2]];
            }

            return Input[0];
        }

        private static int Part2()
        {
            int count = Input.Count;
            int target = 19690720;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    List<int> data = Input;
                    data[1] = i;
                    data[2] = j;
                    for (int y = 0; y < Input.Count; y+=4)
                    {
                        if (data[y] == 99)
                            break;
                        else if (data[y] == 1)                        
                            data[data[y + 3]] = data[data[y + 1]] + data[data[y + 2]];                        
                        else if (data[y] == 2)                        
                            data[data[y + 3]] = data[data[y + 1]] * data[data[y + 2]];                        
                    }

                    if (data[0] == target)
                        return 100 * i + j;
                }
            }
            return 0;
        }
    }
}