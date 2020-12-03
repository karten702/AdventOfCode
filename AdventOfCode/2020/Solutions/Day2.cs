using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020.Solutions
{
    public static class Day2
    {
        public static string[] Input =>
            InputHelper.GetInput(2020, 2).ToArray();

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
            List<string> validPasswords = new List<string>();

            foreach (string line in Input)
            {
                string[] Splitvalues = line.Split(':');
                string[] splitRequirements = Splitvalues[0].Split(' ');
                string[] splitrequirementCounts = splitRequirements[0].Split('-');

                string password = Splitvalues[1].Trim();
                char required = Convert.ToChar(splitRequirements[1]);
                int min = Convert.ToInt32(splitrequirementCounts[0]);
                int max = Convert.ToInt32(splitrequirementCounts[1]);

                int count = password.Count(x => x == required);
                if (count >= min && count <= max)
                    validPasswords.Add(line);
            }
            Console.WriteLine($"Found {validPasswords.Count} passwords");

            return validPasswords.Count;
        }

        public static int Part2()
        {
            List<string> validPasswords = new List<string>();
            foreach (string line in Input)
            {
                string[] Splitvalues = line.Split(':');
                string[] splitRequirements = Splitvalues[0].Split(' ');
                string[] splitrequirementCounts = splitRequirements[0].Split('-');

                string password = Splitvalues[1].Trim();
                char required = Convert.ToChar(splitRequirements[1]);
                int min = Convert.ToInt32(splitrequirementCounts[0]);
                int max = Convert.ToInt32(splitrequirementCounts[1]);

                bool valid = false;

                if (password[min - 1] == required)
                    valid = true;

                if (!valid && password[max - 1] == required)
                    valid = true;
                else if (valid && password[max - 1] == required)
                    valid = false;

                int count = password.Count(x => x == required);
                if (valid)
                    validPasswords.Add(line);
            }
            Console.WriteLine($"Found {validPasswords.Count} passwords");

            return validPasswords.Count;
        }

    }
}
