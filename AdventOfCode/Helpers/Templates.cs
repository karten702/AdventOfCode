using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers
{
    public class Templates
    {
        public string GenerateSolution(int year, string day)
        {
            return $@"using System;
                 |using System.Collections.Generic;
                 |using System.Collections.Immutable;
                 |using System.Linq;
                 |using System.Text.RegularExpressions;
                 |using System.Text;
                 |
                 |namespace AdventOfCode.Y{year}.Day{day} {{
                 |     
                 |    class Solution{{
                 |
                 |        public static List<string> Input =>
                 |              InputHelper.GetInput({year}, {day});
                 |
                 |        public static void Run(){{
                 |            Console.WriteLine(""Part 1:"");
                 |            Console.WriteLine(Part1());
                 |            Console.WriteLine();
                 |            Console.WriteLine(""Part 2:"");
                 |            Console.WriteLine(Part2());
                 |        }}
                 |        public static bool Part1()
                 |        {{
                 |            return true;
                 |        }}
                 |
                 |        public static bool Part2()
                 |        {{
                 |            return true;
                 |        }}
                 |    }}
                 |}}".StripMargin();
        }

        public string GenerateYearSolutionSelector(int year)
        {
            return $@"using System;
                    |using System.Collections.Generic;
                    |using System.Text;
                    |
                    |namespace AdventOfCode.Y{year}
                    |{{
                    |    public class Year{year}
                    |    {{
                    |        public Year{year}(int day)
                    |        {{
                    |            switch (day)
                    |            {{
                    |                //case 1:
                    |                //    Day01.Solution.Run();
                    |                //    break;
                    |                //case 2:
                    |                //    Day02.Solution.Run();
                    |                //    break;
                    |                //case 3:
                    |                //    Day03.Solution.Run();
                    |                //    break;
                    |                //case 4:
                    |                //    Day04.Solution.Run();
                    |                //    break;
                    |                //case 5:
                    |                //    Day05.Solution.Run();
                    |                //    break;
                    |                //case 6:
                    |                //    Day06.Solution.Run();
                    |                //    break;
                    |                //case 7:
                    |                //    Day07.Solution.Run();
                    |                //    break;
                    |                //case 8:
                    |                //    Day08.Solution.Run();
                    |                //    break;
                    |                //case 9:
                    |                //    Day09.Solution.Run();
                    |                //    break;
                    |                //case 10:
                    |                //    Day10.Solution.Run();
                    |                //    break;
                    |                //case 11:
                    |                //    Day11.Solution.Run();
                    |                //    break;
                    |                //case 12:
                    |                //    Day12.Solution.Run();
                    |                //    break;
                    |                //case 13:
                    |                //    Day13.Solution.Run();
                    |                //    break;
                    |                //case 14:
                    |                //    Day14.Solution.Run();
                    |                //    break;
                    |                //case 15:
                    |                //    Day15.Solution.Run();
                    |                //    break;
                    |                //case 16:
                    |                //    Day16.Solution.Run();
                    |                //    break;
                    |                //case 17:
                    |                //    Day17.Solution.Run();
                    |                //    break;
                    |                //case 18:
                    |                //    Day18.Solution.Run();
                    |                //    break;
                    |                //case 19:
                    |                //    Day19.Solution.Run();
                    |                //    break;
                    |                //case 20:
                    |                //    Day20.Solution.Run();
                    |                //    break;
                    |                //case 21:
                    |                //    Day21.Solution.Run();
                    |                //    break;
                    |                //case 22:
                    |                //    Day22.Solution.Run();
                    |                //    break;
                    |                //case 23:
                    |                //    Day23.Solution.Run();
                    |                //    break;
                    |                //case 24:
                    |                //    Day24.Solution.Run();
                    |                //    break;
                    |                //case 25:
                    |                //    Day25.Solution.Run();
                    |                //    break;
                    |                default:
                    |                    Console.WriteLine(""This solution doesnt exist yet"");
                    |                    break;
                    |            }}
                    |        }}
                    |    }}
                    |}}".StripMargin();
        }
    }
}
