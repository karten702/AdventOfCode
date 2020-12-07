using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day07
{

    class Solution
    {

        public static string[] Input =>
              InputHelper.GetInput(2020, 07).ToArray();

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
            List<Bag> bags = Input.Select(s => new Bag(s)).ToList();
            return FindContents(bags, new HashSet<string>(), "shiny gold");
        }

        public static int Part2()
        {
            List<Bag> bags = Input.Select(s => new Bag(s)).ToList();
            return CountContents(bags, "shiny gold") - 1;
        }

        public static int CountContents(List<Bag> bags, string colorToFind)
        {
            Bag gold = bags.Where(b => b.Color == colorToFind).FirstOrDefault();
            int total = 1;
            foreach (var item in gold.specification)
            {
                total += item.Value * CountContents(bags, item.Key);
            }
            return total;
        }

        public static int FindContents(List<Bag> bags, HashSet<string> foundBags, string colorToFind)
        {
            List<Bag> containsColor = bags.Where(b => b.specification.ContainsKey(colorToFind) && !foundBags.Contains(b.Color)).ToList();
            foundBags.Add(colorToFind);
            foreach (var item in containsColor)
            {
                foundBags.Add(item.Color);
            }

            int counter = containsColor.Count;
            foreach (Bag bag in containsColor)
            {
                counter += FindContents(bags, foundBags, bag.Color);
            }
            return counter;
        }
    }

    class Bag
    {
        public string Color = string.Empty;
        public Dictionary<string, int> specification = new Dictionary<string, int>();

        public Bag(string input)
        {
            var split = input.Split(' ');
            Color = split[0] + " " + split[1];
            SetSpecs(input);
        }

        private void SetSpecs(string input)
        {
            var matches = Regex.Matches(input, @"\d\s\w+\s\w+");
            foreach (Match match in matches)
            {
                var split = match.Value.Split(' ');
                specification.Add(string.Join(' ', split[1], split[2]), Convert.ToInt32(split[0]));
            }
        }
    }
}