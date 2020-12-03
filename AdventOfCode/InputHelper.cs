using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class InputHelper
    {
        public static List<string> GetInput(int year, int day)
        {
            string daystring = day.ToString();
            if (day < 10)
                daystring = daystring.Insert(0, "0");
            return File.ReadAllLines($"..//..//..//{year}//Day{daystring}//Day{daystring}.txt").ToList();
        }
    }
}
