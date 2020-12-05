using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Problem1 : ProblemBase
    {
        protected override int ProblemNumber => 1;

        public override string Answer()
        {
            var numbers = input.Select(int.Parse).ToHashSet();
            foreach (var n in numbers)
            {
                if (numbers.Contains(2020 - n))
                {
                    return (n * (2020 - n)).ToString();
                }
            }
            throw new Exception();
        }

        public override string Answer2()
        {
            var numbers = input.Select(int.Parse).ToHashSet();
            var combinations = new Dictionary<int, HashSet<int>>();
            foreach (var x in numbers)
            {
                foreach (var y in numbers)
                {
                    if (x != y && x + y < 2020)
                    {
                        combinations.TryAdd(x + y, new HashSet<int> {x, y});
                    }
                }
            }
            foreach (var n in numbers)
            {
                if (combinations.TryGetValue(2020 - n, out var comb) && !comb.Contains(n))
                {
                    return (n * comb.Aggregate((x, y) => x * y)).ToString();
                }
            }
            throw new Exception();
        }

        public Problem1(string inputDirectoryPath) : base(inputDirectoryPath)
        {
        }
    }
}