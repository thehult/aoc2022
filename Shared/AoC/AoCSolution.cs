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

        public void RunExamples()
        {
            AddInputFiles();
            var i = 1;
            foreach (var (InputFilePath, ExpectedOutput) in _examples)
            {
                var inputString = File.ReadAllText(InputFilePath);
                var input = new Input(inputString);
                WriteExampleHeader(i);
                var stopWatch = Stopwatch.StartNew();
                var result = Solve(input);
                stopWatch.Stop();
                var resultAsString = $"{result}";
                if (resultAsString != ExpectedOutput)
                    WriteExampleFail(resultAsString, ExpectedOutput);
                else
                    WriteExampleSuccess(stopWatch.Elapsed);

                i++;
            }
        }

        public void RunMain()
        {
            AddInputFiles();
            var inputString = File.ReadAllText(_mainInputFile);
            var input = new Input(inputString);

            WriteMainHeader();
            var stopWatch = Stopwatch.StartNew();
            var result = Solve(input);
            stopWatch.Stop();
            WriteMainFinished($"{result}", stopWatch.Elapsed);
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
