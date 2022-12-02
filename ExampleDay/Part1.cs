using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDay
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Part1Inputs/Main.txt");
            AddExample("Part1Inputs/Example1.txt", "7");
        }

        protected override object Solve(string input)
        {
            var lines = input.Split(Environment.NewLine).Select(i => int.Parse(i)).ToArray();
            var res = 0;
            for(var i = 1; i < lines.Length; i++)
            {
                if (lines[i] > lines[i - 1])
                    res++;
            }
            return res;
        }
    }
}
