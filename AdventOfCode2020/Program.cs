using System;
using System.Runtime.CompilerServices;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemBase.EnableTest = false;
            var t = Type.GetType("AdventOfCode2020.Problem6");
            var problem =
                (ProblemBase) Activator.CreateInstance(t, @"C:\Users\clara\AdventOfCode2020\Inputs");
            Console.WriteLine(problem.Answer());
            Console.WriteLine(problem.Answer2());
        }
    }
}