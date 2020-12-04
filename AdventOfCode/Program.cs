using AdventOfCode.Helpers;
using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateFolders();
            
            Console.WriteLine("Hello Welcome to the Advent of Code Program!");
            int year = ReadYear("Choose which year you want and we will check if we have solutions for this year (Press enter for current year)");
            int day = ReadDay("Now please choose a day (1-25) to pick a solution for this year");

            switch (year)
            {
                case 2015:
                    new Y2015.Year2015(day);
                    break;
                //case 2016:
                //    new Y2016.Year2016(day);
                //    break;
                //case 2017:
                //    new Y2017.Year2017(day);
                //    break;
                //case 2018:
                //    new Y2018.Year2018(day);
                //    break;
                case 2019:
                    new Y2019.Year2019(day);
                    break;
                case 2020:
                    new Y2020.Year2020(day);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("DONE!");
            Console.ReadLine();
        }

        private static void GenerateFolders()
        {
            foreach (int year in Constants.AvailableYears)
            {
                if (!Directory.Exists($"..//..//..//{year}"))                
                    Directory.CreateDirectory($"..//..//..//{year}");
                WriteYearFile(year);
                
                for (int i = 1; i < 26; i++)
                {
                    string day;
                    if (i < 10)
                        day = "0" + i;
                    else
                        day = i.ToString();
                    if (!Directory.Exists($"..//..//..//{year}//Day{day}"))                    
                        Directory.CreateDirectory($"..//..//..//{year}//Day{day}");                    
                    WriteSolutionFile(year, day);
                    WriteInputFile(year, day);
                }
            }
        }

        static void WriteYearFile(int year)
        {
            var file = Path.Combine($"..//..//..//{year}", $"Year{year}.cs");
            if (!File.Exists(file))
                WriteFile(file, new Templates().GenerateYearSolutionSelector(year));
        }

        static void WriteSolutionFile(int year, string day)
        {
            var file = Path.Combine($"..//..//..//{year}//Day{day}", "Solution.cs");
            if (!File.Exists(file))            
                WriteFile(file, new Templates().GenerateSolution(year, day));            
        }
        static void WriteInputFile(int year, string day)
        {
            var file = Path.Combine($"..//..//..//{year}//Day{day}", $"Day{day}.txt");
            if (!File.Exists(file))
                WriteFile(file,"");
        }

        static void WriteFile(string file, string content)
        {
            Console.WriteLine($"Writing {file}");
            File.WriteAllText(file, content);
        }

        private static int ReadYear(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);

                string input = Console.ReadLine();

                if (int.TryParse(input, out int year) && Array.IndexOf(Constants.AvailableYears, year) >= 0)
                {
                    return year;
                }
                else if (string.IsNullOrEmpty(input))
                {
                    return DateTime.Now.Year;
                }
                else
                {
                    Console.WriteLine("We have no solution for this year or you didnt enter a number");
                }
            }
        }

        private static int ReadDay(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);

                if (int.TryParse(Console.ReadLine(), out int day) && day > 0 && day <= 25)
                {
                    return day;
                }
                else
                {
                    Console.WriteLine("We have no solution for this day or you didnt enter a correct number");
                }
            }
        }

        //Console.WriteLine("Hello World!");

        //_2020.Solutions.Day4.Run();

        //Console.WriteLine("Done!");
        //Console.ReadLine();
    }
}
