using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day08 {
     
    class Solution{

        public static string[] Input =>
              InputHelper.GetInput(2020, 08).ToArray();

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static int Part1()
        {
            int acc = 0;
            HashSet<int> codes = new HashSet<int>();

            for (int i = 0; i < Input.Length; i++)
            {
                if (!codes.Contains(i))
                {
                    codes.Add(i);
                    var instruction = Input[i].Split(' ');
                    switch (instruction[0])
                    {
                        case "acc":
                            acc = instruction[1][0] switch
                            {
                                '+' => acc + Convert.ToInt32(instruction[1].Substring(1)),
                                '-' => acc - Convert.ToInt32(instruction[1].Substring(1))
                            };
                            break;
                        case "jmp":
                            i = instruction[1][0] switch
                            {
                                '+' => i + Convert.ToInt32(instruction[1].Substring(1)) - 1,
                                '-' => i - Convert.ToInt32(instruction[1].Substring(1)) - 1
                            };
                            break;
                    }
                }
                else
                    break;
            }
            return acc;
        }

        public static bool Part2()
        {
            return true;
        }
    }
}