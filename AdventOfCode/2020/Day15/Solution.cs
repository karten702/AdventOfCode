using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day15 {
     
    class Solution{

        public static List<int> Input =>
              InputHelper.GetInput(2020, 15)[0].Split(',').Select(int.Parse).ToList();
        public static List<int> Test = new List<int>() { 3,1,2 };

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static int Part1()
        {  
            return GetLastNumber(Input, 2020);
        }

        public static int Part2()
        {
            return GetLastNumber(Input, 30000000);
        }

        public static int GetLastNumber(List<int> game, int turncount)
        {
            Dictionary<int, int> gamemap = new Dictionary<int, int>();
            for (int i = 0; i < game.Count - 1; i++)
            {
                gamemap.Add(game[i], i + 1);
            }

            int last = game[game.Count - 1];

            for (int turn = game.Count + 1; turn <= turncount; turn++)
            {
                int next;
                if (gamemap.ContainsKey(last))
                    next = turn - 1 - gamemap[last];
                else
                    next = 0;
                gamemap[last] = turn - 1;
                last = next;
            }
            return last;
        }
    }
}