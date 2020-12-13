using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day13 {
     
    class Solution{

        public static List<string> Input =>
              InputHelper.GetInput(2020, 13);

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2Cheat());
        }
        public static int Part1()
        {
            int startTime = int.Parse(Input[0]);
            List<int> busIds = GetBusIds(Input[1]);
            int time = startTime;
            int myBus = 0;
            while (true)
            {
                foreach (int bus in busIds)
                {
                    if (time % bus == 0)
                    {
                        myBus = bus;
                        break;
                    }
                }
                if (myBus != 0)
                    break;
                time++;
            }

            return (time-startTime) * myBus;
        }

        public static long Part2()
        {
            //int startTime = int.Parse(Input[0]);
            string Test = "17,x,13,19";
            string Test2 = "67,7,59,61";
            string Test3 = "1789,37,47,1889";
            List<string> schedule= Input[1].Split(',').ToList();
            long interval = long.Parse(schedule[0]);

            long time = GetStartTime(1100000000000000, interval);
            while (true)
            {
                long relativeTime = time+1;
                bool completed = false;
                for (int i = 1; i < schedule.Count; i++)
                {
                    if (schedule[i] == "x")
                        relativeTime++;
                    else
                    {
                        int busID = int.Parse(schedule[i]);
                        if (relativeTime % busID == 0)
                        {
                            completed = true;
                            relativeTime++;
                        }
                        else
                        {
                            completed = false;
                            break;
                        }
                    }
                }
                if (completed)
                    return time;

                time+=interval;
            }
        }

        public static long Part2Cheat()
        {
            string[] bus = Input[1].Split(",");
            var time = 0L;
            var inc = long.Parse(bus[0]);
            for (var i = 1; i < bus.Length; i++)
            {
                if (!bus[i].Equals("x"))
                {
                    var newTime = int.Parse(bus[i]);
                    while (true)
                    {
                        time += inc;
                        if ((time + i) % newTime == 0)
                        {
                            inc *= newTime;
                            break;
                        }
                    }
                }
            }
            return time;
        }

        public static List<int> GetBusIds(string input)
        {
            List<int> ids = new List<int>();

            foreach (var id in Input[1].Split(','))
            {
                if (int.TryParse(id, out int validID))
                    ids.Add(validID);
            }

            return ids;
        }

        public static long GetStartTime(long start, long busID)
        {
            while (true)
            {
                if (start % busID != 0)
                    start++;
                else
                    return start;
            }
        }
    }
}