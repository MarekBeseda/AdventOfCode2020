using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Problem7 : ProblemBase
    {
        HashSet<string> uniqueColors = new HashSet<string>();
        public Problem7(string inputDirectoryPath) : base(inputDirectoryPath)
        {
        }

        protected override int ProblemNumber => 7;

        int Lookup(string key, Dictionary<string, List<string>> pairs, string initialKey)
        {
            if (key == "shiny gold")
            {
                uniqueColors.Add(initialKey);
                return 1;
            }

            if (key == "" || key == "no other" || !pairs.ContainsKey(key))
            {
                return 0;
            }

            foreach (var value in pairs[key])
            {
                if (value == "shiny gold")
                {
                    uniqueColors.Add(initialKey);
                }
                return Lookup(value, pairs, initialKey);
            }

            return 0;
        }

        public override string Answer()
        {
            var pairs = new Dictionary<string, List<string>>();

            foreach (var line in input)
            {
                string[] words = line.Split(" bag");
                var key = words[0];
                for (int i = 1; i < words.Length - 1; i++)
                {
                    string[] w = words[i].Split(' ');
                    var entry = w[^2] + " " + w[^1];
                    if(!pairs.ContainsKey(key)) {
                        pairs.Add(key, new List<string>());
                    }
                    pairs[key].Add(entry);
                }
            }

            string colour = "shiny gold";
            int number = 0;
            
            foreach (var key in pairs.Keys)
            {
                if (key == colour)
                {
                    continue;
                }
                
                number += Lookup(key, pairs, key);
            }
            Console.WriteLine(number);
            return uniqueColors.Count.ToString();
        }
        

        public override string Answer2()
        {
            throw new System.NotImplementedException();
        }
    }
}