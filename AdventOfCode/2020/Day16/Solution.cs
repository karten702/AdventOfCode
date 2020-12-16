using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics;

namespace AdventOfCode.Y2020.Day16
{

    class Solution
    {

        public static List<string> Input =>
              InputHelper.GetInput(2020, 16);

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
            InputCollections x = new InputCollections(Input);
            return x.GetInValidTicketValuesP1().Sum();
        }

        public static long Part2()
        {
            InputCollections x = new InputCollections(Input);
            var validTickets = x.GetValidTickets();
            validTickets.Add(x.myTicket);

            Dictionary<string, int> fieldMap = new Dictionary<string, int>();

            for (int fieldIndex = 0; fieldIndex < x.fields.Count; fieldIndex++)
            {
                foreach (Field field in x.fields)
                {
                    if (validTickets.All(t => field.IsValidForRange(t.FieldValues[fieldIndex])))
                        field.probablePositions.Add(fieldIndex);
                }
            }

            while (fieldMap.Count != x.fields.Count)
            {
                Field positionField = x.fields.Where(f => f.probablePositions.Count == 1 && !fieldMap.ContainsKey(f.name)).First();
                fieldMap.Add(positionField.name, positionField.probablePositions[0]);
                foreach (Field field in x.fields)
                {
                    if (field.probablePositions.Count == 1)
                        continue;
                    else
                        field.probablePositions.Remove(positionField.probablePositions[0]);
                }
            }

            return x.GetMyTicketValue(fieldMap);
        }


    }

    class InputCollections
    {
        public Ticket myTicket;
        public List<Ticket> nearbyTickets = new List<Ticket>();
        public List<Field> fields = new List<Field>();

        bool doneFields = false;
        bool doneMyTicket = false;

        public InputCollections(List<string> input)
        {
            foreach (string item in input)
            {
                if (item.Length == 0)
                {
                    doneFields = true;
                    if (myTicket != null)
                        doneMyTicket = true;
                    continue;
                }
                if (item.Contains("ticket"))
                    continue;

                if (!doneFields)
                {
                    fields.Add(new Field(item));
                }
                else if (!doneMyTicket)
                {
                    myTicket = new Ticket(item);
                }
                else
                {
                    nearbyTickets.Add(new Ticket(item));
                }
            }
        }

        public List<Ticket> GetValidTickets()
        {
            List<Ticket> invalidValues = new List<Ticket>();

            foreach (Ticket ticket in nearbyTickets)
            {
                foreach (int fieldValue in ticket.FieldValues)
                {
                    if (!fields.Any(f => f.IsValidForRange(fieldValue)))
                    {
                        invalidValues.Add(ticket);
                        break;
                    }
                }
            }
            return nearbyTickets.Where(t => !invalidValues.Contains(t)).ToList();
        }

        public List<int> GetInValidTicketValuesP1()
        {
            List<int> invalidValues = new List<int>();

            foreach (Ticket ticket in nearbyTickets)
            {
                foreach (int fieldValue in ticket.FieldValues)
                {
                    if (!fields.Any(f => f.IsValidForRange(fieldValue)))
                        invalidValues.Add(fieldValue);
                }
            }

            return invalidValues;
        }

        public long GetMyTicketValue(Dictionary<string, int> map)
        {
            long total = 1;
            foreach (var item in map.Keys)
            {
                if (item.StartsWith("departure"))
                    total *= myTicket.FieldValues[map[item]];
            }
            return total;
        }
    }

    class Field
    {
        public string name;

        public int minRange1;
        public int maxRange1;

        public int minRange2;
        public int maxRange2;

        public List<int> probablePositions = new List<int>();

        public Field(string input)
        {
            name = input.Split(':').First();
            List<string> value = input.Split(':')
                                      .Last()
                                      .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                      .Where(s => s.Contains("-"))
                                      .ToList();
            minRange1 = int.Parse(value[0].Split('-').First());
            maxRange1 = int.Parse(value[0].Split('-').Last());
            minRange2 = int.Parse(value[1].Split('-').First());
            maxRange2 = int.Parse(value[1].Split('-').Last());
        }

        public bool IsValidForRange(int value) =>
            (minRange1 <= value && value <= maxRange1) ||
            (minRange2 <= value && value <= maxRange2);
    }

    class Ticket
    {
        public List<int> FieldValues = new List<int>();

        public Ticket(string fieldValues)
        {
            FieldValues = fieldValues.Split(',').Select(int.Parse).ToList();
        }
    }
}