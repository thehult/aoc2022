using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Part1Inputs/Main.txt");
            AddExample("Part1Inputs/Example1.txt", "15");
        }

        Dictionary<string, int> scores = new()
        {
            { "A X", 1 + 3 },
            { "A Y", 2 + 6 },
            { "A Z", 3 + 0 },
            { "B X", 1 + 0 },
            { "B Y", 2 + 3 },
            { "B Z", 3 + 6 },
            { "C X", 1 + 6 },
            { "C Y", 2 + 0 },
            { "C Z", 3 + 3 },
        };


        protected override object Solve(Input input)
        {
            var sum = 0;
            foreach(var line in input)
            {
                sum += scores[(string)line];
            }

            return sum;
        }
    }
}
