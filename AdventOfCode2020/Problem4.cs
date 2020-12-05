using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Problem4 : ProblemBase
    {
        public Problem4(string inputDirectoryPath) : base(inputDirectoryPath)
        {
        }

        protected override int ProblemNumber => 4;

        public override string Answer()
        {
            var required = new[]
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
            };

            return input.Aggregate(new List<Dictionary<string, string>> {new Dictionary<string, string>()}, (list, l) =>
            {
                if (string.IsNullOrWhiteSpace(l))
                {
                    list.Add(new Dictionary<string, string>());
                }
                else
                {
                    foreach (var group in l.Split(" ").Select(g => g.Split(":")))
                    {
                        list[^1].Add(group[0], group[1]);
                    }
                }
                return list;
            }).Count(p => required.All(p.ContainsKey)).ToString();
        }

        public bool ValidatePassword(string field, string value)
        {
            switch (field)
            {
                case "byr":
                    return Regex.IsMatch(value, @"^\d\d\d\d$") && int.TryParse(value, out var byr) &&
                           byr >= 1920 && byr <= 2002;
                case "iyr":
                    return Regex.IsMatch(value, @"^\d\d\d\d$") && int.TryParse(value, out var iyr) &&
                           iyr >= 2010 && iyr <= 2020;
                case "eyr":
                    return Regex.IsMatch(value, @"^\d\d\d\d$") && int.TryParse(value, out var eyr) &&
                           eyr >= 2020 && eyr <= 2030;
                case "hgt":
                    var match = Regex.Match(value, @"^(?<height>\d+)(?<unit>(cm)|(in))$");
                    return match.Success && int.TryParse(match.Groups["height"].Value, out var height) &&
                           ((match.Groups["unit"].Value == "cm" && height >= 150 && height <= 193) ||
                            (match.Groups["unit"].Value == "in" && height >= 59 && height <= 76));
                case "hcl":
                    return Regex.IsMatch(value, @"^#[0-9a-f]{6}$");
                case "ecl":
                    return Regex.IsMatch(value, @"^(amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)$");
                case "pid": return Regex.IsMatch(value, @"^\d{9}$");
                case "cid":
                    return true;
                default:
                    return false;
            }
        }

        public override string Answer2()
        {
            var required = new[]
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
            };

            var passports = new List<Dictionary<string, string>>();


            var current = new Dictionary<string, string>();
            passports.Add(current);
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    current = new Dictionary<string, string>();
                    passports.Add(current);
                }
                else
                {
                    foreach (var group in line.Split(" ").Select(g => g.Split(":")))
                    {
                        current.Add(group[0], group[1]);
                    }
                }
            }
            var count = 0;

            foreach (var passport in passports)
            {
                if (passport.All(g => ValidatePassword(g.Key, g.Value)) && required.All(passport.ContainsKey))
                {
                    Console.WriteLine(string.Join(',', passport.OrderBy(g=>g.Key).Select(g => $"{g.Key}:{g.Value}")));
                    count++;
                }
            }
            return count.ToString();
        }
    }
}