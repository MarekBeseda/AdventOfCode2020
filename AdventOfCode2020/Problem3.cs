using System;
using System.Linq;

namespace AdventOfCode2020
{
    class Problem3 : ProblemBase
    {
        protected override int ProblemNumber => 3;

        public Problem3(string inputDirectoryPath) : base(inputDirectoryPath)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = string.Concat(Enumerable.Repeat(input[i], 100));
            }
        }

        public bool IsTree(int x, int y)
        {
            return input[y][x] == '#';
        }

        private int Solve(int slopeX, int slopeY)
        {
            
            var x = 0;
            var y = 0;
            var treeCount = 0;
            while (y + slopeY < input.Length)
            {
                x += slopeX;
                y += slopeY;
                if (IsTree(x, y))
                {
                    treeCount++;
                }
            }
            return treeCount;
        }
        
        public override string Answer()
        {
            return Solve(3, 1).ToString();
        }

        public override string Answer2()
        {
            Int64 product = 1;
            foreach (var (slopeX, slopeY) in new []{(1,1),(3,1),(5,1),(7,1),(1,2)})
            {
                product *= Solve(slopeX, slopeY);
            }
            return product.ToString();
        }
    }
}