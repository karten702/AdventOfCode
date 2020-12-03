using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class InputHelper
    {   
        public static List<string> GetInput(int year, int day) =>
            File.ReadAllLines($"..//..//..//{year}//Input//Day{day}.txt").ToList();
    }
}
