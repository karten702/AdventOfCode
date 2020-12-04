using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day04
{

    class Solution
    {

        public static List<string> Input =>
              InputHelper.GetInput(2020, 04);

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
            List<Passport> validPassports = new List<Passport>();
            int passwordcounter = 1;
            Passport currentPassport = new Passport(passwordcounter++);
            foreach (string inputPassport in Input)
            {
                if (string.IsNullOrEmpty(inputPassport))
                {
                    if (currentPassport.isValid())
                        validPassports.Add(currentPassport);

                    currentPassport = new Passport(passwordcounter++);
                }
                foreach (Match test in Regex.Matches(inputPassport, @"(?<hgt>hgt:)|(?<ecl>ecl:)|(?<iyr>iyr:)|(?<eyr>eyr:)|(?<byr>byr:)|(?<hcl>hcl:)|(?<pid>pid:)|(?<cid>cid:)"))
                {
                    if (test.Success)
                    {
                        if (test.Groups["byr"].Success)
                            currentPassport.byr = test.Groups["byr"].Value;
                        if (test.Groups["hgt"].Success)
                            currentPassport.hgt = test.Groups["hgt"].Value;
                        if (test.Groups["iyr"].Success)
                            currentPassport.iyr = test.Groups["iyr"].Value;
                        if (test.Groups["ecl"].Success)
                            currentPassport.ecl = test.Groups["ecl"].Value;
                        if (test.Groups["eyr"].Success)
                            currentPassport.eyr = test.Groups["eyr"].Value;
                        if (test.Groups["pid"].Success)
                            currentPassport.pid = test.Groups["pid"].Value;
                        if (test.Groups["hcl"].Success)
                            currentPassport.hcl = test.Groups["hcl"].Value;
                        if (test.Groups["cid"].Success)
                            currentPassport.cid = test.Groups["cid"].Value;
                    }
                }
            }
            if (currentPassport.isValid())
                validPassports.Add(currentPassport);
            Console.WriteLine("Checked " + passwordcounter + " passwords");
            return validPassports.Count;
        }

        public static int Part2()
        {
            List<Passport> validPassports = new List<Passport>();
            int passwordcounter = 1;
            Passport currentPassport = new Passport(passwordcounter++);
            foreach (string inputPassport in Input)
            {
                if (string.IsNullOrEmpty(inputPassport))
                {
                    if (currentPassport.isValid())
                        validPassports.Add(currentPassport);

                    currentPassport = new Passport(passwordcounter++);
                }
                foreach (Match test in Regex.Matches(inputPassport, @"(?<hgt>hgt:)|(?<ecl>ecl:)|(?<iyr>iyr:)|(?<eyr>eyr:)|(?<byr>byr:)|(?<hcl>hcl:)|(?<pid>pid:)|(?<cid>cid:)"))
                {
                    if (test.Success)
                    {
                        if (test.Groups["byr"].Success)
                        {
                            Match group = Regex.Match(inputPassport, @"(?<byr>(byr:)(?<year>\d{4}))");
                            if (group.Success)
                            {
                                int yr = int.Parse(group.Groups["year"].Value);
                                if (yr >= 1920 && yr <= 2002)
                                    currentPassport.byr = yr.ToString();
                            }
                        }
                        else if (test.Groups["hgt"].Success)
                        {
                            Match group = Regex.Match(inputPassport, @"(?<hgt>((hgt:)(?<number>\d{2,3})(?<measure>\w{2})))");
                            if (group.Success)
                            {
                                switch (group.Groups["measure"].Value)
                                {
                                    case "cm":
                                        int cm = int.Parse(group.Groups["number"].Value);
                                        if (cm >= 150 && cm <= 193)
                                            currentPassport.hgt = cm.ToString()+group.Groups["measure"].Value;
                                        break;
                                    case "in":
                                        int number = int.Parse(group.Groups["number"].Value);
                                        if (number >= 59 && number <= 76)
                                            currentPassport.hgt = number.ToString() + group.Groups["measure"].Value;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else if (test.Groups["iyr"].Success)
                        {
                            Match group = Regex.Match(inputPassport, @"(?<iyr>(iyr:)(?<year>\d{4}))");
                            if (group.Success)
                            {
                                int yr = int.Parse(group.Groups["year"].Value);
                                if (yr >= 2010 && yr <= 2020)
                                    currentPassport.iyr = group.Groups["year"].Value;
                            }
                        }

                        else if (test.Groups["ecl"].Success)
                        {
                            Match group = Regex.Match(inputPassport, @"(?<ecl>(ecl:)(?<color>\w{3})(\s|$))");
                            if (group.Success)
                            {
                                currentPassport.ecl = group.Groups["color"].Value switch
                                {
                                    "amb" => group.Groups["color"].Value,
                                    "blu" => group.Groups["color"].Value,
                                    "brn" => group.Groups["color"].Value,
                                    "gry" => group.Groups["color"].Value,
                                    "grn" => group.Groups["color"].Value,
                                    "hzl" => group.Groups["color"].Value,
                                    "oth" => group.Groups["color"].Value,
                                    _ => string.Empty
                                };
                            }
                        }

                        else if(test.Groups["eyr"].Success)
                        {
                            Match group = Regex.Match(inputPassport, @"(?<eyr>(eyr:)(?<year>\d{4}))");
                            if (group.Success)
                            {
                                int yr = int.Parse(group.Groups["year"].Value);
                                if (yr >= 2020 && yr <= 2030)
                                    currentPassport.eyr = group.Groups["year"].Value;
                            }
                        }

                        else if (test.Groups["pid"].Success)
                        {
                            Match group = Regex.Match(inputPassport, @"(?<pid>(pid:)(?<number>\d{9})(\s|$))");
                            if (group.Success)                            
                                    currentPassport.pid = group.Groups["number"].Value.Trim();
                            
                        }

                        else if (test.Groups["hcl"].Success)
                        {
                            Match group = Regex.Match(inputPassport, @"(?<hcl>(hcl:#)([0-9a-f]{6})(\s|$))");
                            if (group.Success)
                                currentPassport.hcl = group.Value.Trim();
                        }

                        else if (test.Groups["cid"].Success)
                        {
                            currentPassport.cid = test.Groups["cid"].Value;
                        }
                    }
                }
            }


            if (currentPassport.isValid())
                validPassports.Add(currentPassport);
            Console.WriteLine("Checked " + passwordcounter + " passwords");
            return validPassports.Count;
        }
    }

    class Passport
    {
        public int id { get; set; }
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public Passport(int id) { this.id = id; }

        public bool isValid()
        {
            if (!string.IsNullOrEmpty(byr) &&
               !string.IsNullOrEmpty(iyr) &&
               !string.IsNullOrEmpty(eyr) &&
               !string.IsNullOrEmpty(hgt) &&
               !string.IsNullOrEmpty(hcl) &&
               !string.IsNullOrEmpty(ecl) &&
               !string.IsNullOrEmpty(pid))
                return true;
            else
                return false;

        }
        /*
         byr (Birth Year)
    iyr (Issue Year)
    eyr (Expiration Year)
    hgt (Height)
    hcl (Hair Color)
    ecl (Eye Color)
    pid (Passport ID)
    cid (Country ID)*/
    }
}