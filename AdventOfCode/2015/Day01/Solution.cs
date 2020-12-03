using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2015.Day01 {
     
    class Solution{

        public static List<string> Input =>
              InputHelper.GetInput(2015, 01);

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static int Part1()
        {
            string thisInput = Input[0];
            int counter = 0;
            for (int i = 0; i < thisInput.Length; i++)
            {
                if (thisInput[i].Equals('('))
                    counter++;
                else
                    counter--;
            }

            return counter;
        }

        public static int Part2()
        {
            int counter = 0;
            string thisInput = Input[0];
            for (int i = 0; i < thisInput.Length; i++)
            {
                if (thisInput[i].Equals('('))
                    counter++;
                else
                    counter--;
                if (counter == -1)
                    return i+1;
            }
            return counter;
        }
    }
}