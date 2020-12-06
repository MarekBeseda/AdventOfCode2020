using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Problem6 : ProblemBase
    {
        public Problem6(string inputDirectoryPath) : base(inputDirectoryPath)
        {
        }

        protected override int ProblemNumber => 6;

        public override string Answer()
        {
            HashSet<char> seenLetters = new HashSet<char>();
            int totalScore = 0;
            foreach (var entry in input)
            {
                if (entry == "")
                {
                    totalScore += seenLetters.Count;
                    seenLetters.Clear();
                    continue;
                }

                foreach (var c in entry)
                {
                    seenLetters.Add(c);
                }
            }
            totalScore += seenLetters.Count;

            return totalScore.ToString();
        }

        public override string Answer2()
        {
            HashSet<char> seenLetters = new HashSet<char>();
            int totalScore = 0;
            bool startNewGroup = true;
            foreach (var entry in input)
            {
                if (entry == "")
                {
                    totalScore += seenLetters.Count;
                    seenLetters.Clear();
                    startNewGroup = true;
                    continue;
                }

                if (startNewGroup)
                {
                    foreach (var c in entry)
                    {
                        seenLetters.Add(c);
                        startNewGroup = false;
                    }
                }

                seenLetters.RemoveWhere(x => !entry.Contains(x));
            }
            totalScore += seenLetters.Count;
            return totalScore.ToString();
        }
    }
}