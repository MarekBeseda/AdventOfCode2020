using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Problem2 : ProblemBase

    {
        protected override int ProblemNumber => 2;
        
        public Problem2(string inputDirectoryPath) : base(inputDirectoryPath)
        {
        }

        public override string Answer()
        {
            return input.Select(l => Regex.Match(l, @"(?<lower>\d+)-(?<upper>\d+) (?<char>.): (?<pass>.+)"))
                .Count(m =>
                {
                    var lower = int.Parse(m.Groups["lower"].Value);
                    var upper = int.Parse(m.Groups["upper"].Value);
                    var letter = m.Groups["char"].Value[0];
                    var pass = m.Groups["pass"].Value;
                    var occurences = pass.Count(c => c == letter);
                    return occurences >= lower && occurences <= upper;
                }).ToString();
        }

        public override string Answer2()
        {
            return input.Select(l => Regex.Match(l, @"(?<lower>\d+)-(?<upper>\d+) (?<char>.): (?<pass>.+)"))
                .Count(m =>
                {
                    var lower = int.Parse(m.Groups["lower"].Value);
                    var upper = int.Parse(m.Groups["upper"].Value);
                    var letter = m.Groups["char"].Value[0];
                    var pass = m.Groups["pass"].Value;
                    return (pass[lower - 1] == letter) ^ (pass[upper - 1] == letter);
                }).ToString();
        }
    }
}