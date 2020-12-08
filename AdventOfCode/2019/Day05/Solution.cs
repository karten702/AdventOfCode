using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using AdventOfCode._2019;

namespace AdventOfCode.Y2019.Day05
{

    class Solution
    {

        public static List<int> Input =>
              InputHelper.GetInput(2019, 05)[0].Split(',').Select(int.Parse).ToList();

        public static void Run()
        {
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static string Part1()
        {
            //var x = new List<int>() { 1002, 4, 3, 4, 33 };
            var program = new IntcodeProgram(Input);
            var computer = new IntCodeMachine(program, 1);
            computer.Run();

            var formattedOutputs = string.Join(",", computer.Outputs.ToArray());
            return $"All outputs: [{formattedOutputs}]";
            //return Input[0];
        }

        private static string Part2()
        {
            //var x = new List<int>() { 3,9,8,9,10,9,4,9,99,-1,8 };
            //var x = new List<int>() { 3,9,7,9,10,9,4,9,99,-1,8 };
            //var x = new List<int>() { 3,3,1108,-1,8,3,4,3,99 };
            //var x = new List<int>() { 3,3,1107,-1,8,3,4,3,99 };
            //var x = new List<int>() { 3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9 };
            //var x = new List<int>() { 3,3,1105,-1,9,1101,0,0,12,4,12,99,1 };
            //var x = new List<int>() { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 };
            //var program = new IntcodeProgram(x);
            //var computer = new IntCodeMachine(program, 13);
            //computer.Run();

            var program = new IntcodeProgram(Input);
            var computer = new IntCodeMachine(program, 5);
            computer.Run();

            var formattedOutputs = string.Join(",", computer.Outputs.ToArray());
            return $"All outputs: [{formattedOutputs}]";
        }
    }
}