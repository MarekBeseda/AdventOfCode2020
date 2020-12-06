using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Problem5 : ProblemBase
    {
        public Problem5(string inputDirectoryPath) : base(inputDirectoryPath)
        {
        }

        protected override int ProblemNumber => 5;

        public int Transform(String str)
        {
            var (minInterval, maxInterval) = (0, 127);
            var (left, right) = (0, 7);
            foreach (var c in str.ToCharArray())
            {
                if (c == 'F')
                {
                    maxInterval = maxInterval - (maxInterval - minInterval) / 2 - 1;
                }
                else if(c == 'B')
                {
                    minInterval = minInterval + (maxInterval - minInterval) / 2 + 1;
                }
                else if (c == 'L')
                {
                    right = right - (right - left) / 2 - 1;
                }
                else
                {
                    left = left + (right - left) / 2 + 1;
                }
            }
            return minInterval * 8 + left;
        }

        public override string Answer()
        {
            var max = input.Select(Transform).Max();
            return max.ToString();
        }

        public override string Answer2()
        {
            var orderedIDs = input.Select(Transform).ToArray();
            int theoreticalSum = (orderedIDs.Max() - orderedIDs.Min() + 1) / 2 * (orderedIDs.Min() + orderedIDs.Max());
            
            return (theoreticalSum - orderedIDs.Sum()).ToString();
        }
    }
}