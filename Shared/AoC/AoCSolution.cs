using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AoC
{
    public abstract class AoCSolution
    {
        private string _mainInputFile = "";
        private List<(string InputFilePath, string ExpectedOutput)> _examples = new List<(string InputFilePath, string ExpectedOutput)>();

        private Stopwatch _stopWatch = new Stopwatch();

        protected void AddExample(string inputFilePath, string expectedOutput)
        {
            _examples.Add((inputFilePath, expectedOutput));
        }
        protected void AddMainInput(string inputFilePath)
        {
            _mainInputFile = inputFilePath;
        }

        protected abstract void AddInputFiles();
        protected abstract object Solve(Shared.Input input);
        protected void LogTime(string id)
        {
            Console.WriteLine($"Time at '{id}': {_stopWatch.Elapsed}");
        }

        public void RunExamples()
        {
            AddInputFiles();
            var i = 1;
            foreach (var (InputFilePath, ExpectedOutput) in _examples)
            {
                var inputString = File.ReadAllText(InputFilePath);
                var input = new Input(inputString);
                WriteExampleHeader(i);
                _stopWatch.Restart();
                var result = Solve(input);
                _stopWatch.Stop();
                var resultAsString = $"{result}";
                if (resultAsString != ExpectedOutput)
                    WriteExampleFail(resultAsString, ExpectedOutput);
                else
                    WriteExampleSuccess(_stopWatch.Elapsed);

                i++;
            }
        }

        public void RunMain()
        {
            AddInputFiles();
            var inputString = File.ReadAllText(_mainInputFile);
            var input = new Input(inputString) { IsMain = true };

            WriteMainHeader();
            _stopWatch.Restart();
            var result = Solve(input);
            _stopWatch.Stop();
            WriteMainFinished($"{result}", _stopWatch.Elapsed);
        }

        private void WriteExampleHeader(int exampleNumber)
        {
            var head = $"   Solving example {exampleNumber}!   ";
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(head);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
        }

        private void WriteExampleFail(string result, string expected)
        {
            Console.WriteLine();
            Console.WriteLine($"Example failed. Expected {expected}, result was {result}");
            Console.WriteLine();
        }

        private void WriteExampleSuccess(TimeSpan elapsed)
        {
            Console.WriteLine();
            Console.WriteLine($"Example successful after {elapsed}");
            Console.WriteLine();
        }


        private void WriteMainHeader()
        {
            var head = $"   Solving main problem!   ";
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(head);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
        }

        private void WriteMainFinished(string result, TimeSpan elapsed)
        {
            Console.WriteLine();
            Console.WriteLine($"Got result after {elapsed}");
            Console.WriteLine($"Result: {result}");
            Console.WriteLine();
        }
    }
}
