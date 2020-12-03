using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2019.Day01 {
     
    class Solution{

        public static List<decimal> Input =>
              InputHelper.GetInput(2019, 01).Select(decimal.Parse).ToList();

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static decimal Part1()
        {
            decimal total = 0;
            foreach (decimal module in Input)
            {
                total += Math.Floor(module / 3) - 2;
            }
            return total;
        }

        public static decimal Part2()
        {
            decimal total = 0;
            foreach (decimal module in Input)
            {
                decimal ModuleTotal = 0;
                decimal required = module;
                while(required > 0)
                {
                    required = Math.Floor(required / 3) - 2;
                    if(required > 0)
                        ModuleTotal += required;
                }
                total += ModuleTotal;
            }
            return total;
        }
    }
}