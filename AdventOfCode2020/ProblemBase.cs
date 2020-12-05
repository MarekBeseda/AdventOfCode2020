using System.IO;

namespace AdventOfCode2020
{
    public abstract class ProblemBase
    {
        public static bool EnableTest = false;
        private readonly string inputDirectoryPath;
        protected abstract int ProblemNumber { get; }
        private string[] _input;
        protected string[] input {
            get
            {
                if (_input == null)
                {
                    _input = ReadFile($"problem{ProblemNumber}{(EnableTest ? "_test" : "")}.txt");
                }
                return _input;
            }
        }

        public ProblemBase(string inputDirectoryPath)
        {
            this.inputDirectoryPath = inputDirectoryPath;
        }

        public string[] ReadFile(string fileName)
        {
            return File.ReadAllLines(Path.Join(inputDirectoryPath, fileName));
        }

        public abstract string Answer();
        public abstract string Answer2();
    }
}