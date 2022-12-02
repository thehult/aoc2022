using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AoC
{
    public static class AoCSolutionRunner
    {
        public static void Run(int day, int part, AoCInput what)
        {
            if (what == AoCInput.Examples)
                RunExamples(day, part);
            else if (what == AoCInput.Main)
                RunMain(day, part);
            else
            {
                var solution = GetSolution(day, part);
                solution.RunExamples();
                solution.RunMain();
            }
        }

        public static void RunExamples(int day, int part)
        {
            var solution = GetSolution(day, part);
            solution.RunExamples();
        }

        public static void RunMain(int day, int part)
        {
            var solution = GetSolution(day, part);
            solution.RunMain();
        }

        private static AoCSolution GetSolution(int day, int part)
        {
            var ns = "ExampleDay";
            if (day > 0 && day < 25)
                ns = $"Day{day}";

            var pt = "Part1";
            if (part == 2)
                pt = "Part2";

            var typeName = $"{ns}.{pt}";
            var ass = Assembly.Load(ns);
            var type = ass.GetType(typeName, true, true);

            if (type == null)
                throw new Exception("Solution not found!");

            if (!type.IsSubclassOf(typeof(AoCSolution)))
                throw new Exception("Found class is not derived from base class AoCSolution");

            var solution = Activator.CreateInstance(type) as AoCSolution;
            if (solution == null)
                throw new Exception("An instance of solution could not be created.");
            return solution;
        }
    }

    public enum AoCInput
    {
        Examples,
        Main,
        Both
    }
}
