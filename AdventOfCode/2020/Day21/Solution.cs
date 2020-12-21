using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day21 {
     
    class Solution{

        public static List<string> Input =>
              InputHelper.GetInput(2020, 21);

        public static List<string> Test = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
                                            trh fvjkl sbzzf mxmxvkd (contains dairy)
                                            sqjhc fvjkl (contains soy)
                                            sqjhc mxmxvkd sbzzf (contains fish)".Split(Environment.NewLine).ToList();

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static int Part1()
        {
            Recipes recipes = new Recipes(Input);
            HashSet<string> allergies = recipes.PotentialAllergies.Values.SelectMany(a => a).ToHashSet();

            return recipes.IngredientCounts.Where(k => !allergies.Contains(k.Key)).Sum(k => k.Value);
        }

        public static string Part2()
        {
            Recipes recipes = new Recipes(Input);
            var allergiesDict = recipes.MappedAllergens();
            return string.Join(',', allergiesDict.OrderBy(k => k.Key).Select(a => a.Value));
        }
    }

    class Recipes
    {
        public Dictionary<string, int> IngredientCounts = new Dictionary<string, int>();
        public Dictionary<string, HashSet<string>> PotentialAllergies = new Dictionary<string, HashSet<string>>();

        public Recipes(List<string> input)
        {
            foreach (string row in input)
            {
                string[] split = row.Split(" (contains ");
                string[] ingredients = split[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] allergies = split[1].Replace(")", "").Split(", ");

                foreach (string ingredient in ingredients)
                {
                    if (IngredientCounts.ContainsKey(ingredient))
                        IngredientCounts[ingredient] += 1;
                    else
                        IngredientCounts[ingredient] = 1;
                }

                foreach (string allergen in allergies)
                {
                    if (PotentialAllergies.ContainsKey(allergen))
                        PotentialAllergies[allergen].IntersectWith(ingredients);
                    else
                        PotentialAllergies[allergen] = new HashSet<string>(ingredients);
                }
            }
        }

        public Dictionary<string, string> MappedAllergens()
        {
            var allergiesDict = PotentialAllergies;

            while (allergiesDict.Values.Any(x => x.Count != 1))
            {
                foreach (string allergen in allergiesDict.Keys)
                {
                    HashSet<string> allergenIngredients = allergiesDict[allergen];
                    if (allergenIngredients.Count != 1)
                        continue;

                    foreach (string key in allergiesDict.Keys)
                    {
                        if (key == allergen)
                            continue;

                        allergiesDict[key].ExceptWith(allergenIngredients);
                    }
                }
            }
            return allergiesDict.ToDictionary(d => d.Key, d => d.Value.First());
        }
    }
}