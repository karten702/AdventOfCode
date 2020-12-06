using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day06
{

    class Solution
    {

        public static List<string> Input =>
              InputHelper.GetInput(2020, 06);

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
            List<Group> groups = new List<Group>();
            Group currentGroup = new Group();
            foreach (string answers in Input)
            {
                if (!string.IsNullOrEmpty(answers))
                {
                    foreach (char answer in answers)
                    {
                        if (currentGroup.answers.ContainsKey(answer))                        
                            currentGroup.answers[answer] += 1;                        
                        else
                            currentGroup.answers.Add(answer, 1);
                    }
                }
                else
                {
                    groups.Add(currentGroup);
                    currentGroup = new Group();
                }
            }
            groups.Add(currentGroup);

            return groups.Sum(g => g.answers.Count);
        }

        public static int Part2()
        {
            List<Group> groups = new List<Group>();
            Group currentGroup = new Group();
            foreach (string answers in Input)
            {
                if (!string.IsNullOrEmpty(answers))
                {
                    currentGroup.groupSize++;
                    foreach (char answer in answers)
                    {
                        if (currentGroup.answers.ContainsKey(answer))
                            currentGroup.answers[answer] += 1;
                        else
                            currentGroup.answers.Add(answer, 1);
                    }
                }
                else
                {
                    groups.Add(currentGroup);
                    currentGroup = new Group();
                }
            }
            groups.Add(currentGroup);
            return groups.Sum(g => g.answers.Where(a => a.Value == g.groupSize).Count());
        }
    }

    class Group
    {
        public Dictionary<char, int> answers;
        public int groupSize;

        public Group()
        {
            answers = new Dictionary<char, int>();
            groupSize = 0;
        }
    }
}