using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day01 {
     
    class Solution{

        public static List<int> Input =>
            InputHelper.GetInput(2020, 1).Select(int.Parse).ToList();

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
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

        public static int Part2()
        {
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;

            List<int> values = new List<int>();
            int count = Input.Count;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    int numberToFind = 2020 - Input[i] - Input[j];

                    if (Input.Find(i => i == numberToFind) is int found && found != 0)
                    {
                        number1 = Input[i];
                        number2 = Input[j];
                        number3 = found;
                        break;
                    }
                }
                if (number3 != 0)
                    break;
            }

            return number1 * number2 * number3;
        }
    }
}