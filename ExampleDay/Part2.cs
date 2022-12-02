using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDay
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Part2Inputs/Main.txt");
            AddExample("Part2Inputs/Example1.txt", "5");
        }

        protected override object Solve(string input)
        {
            var lines = input.Split(Environment.NewLine).Select(i => int.Parse(i)).ToArray();
            var res = 0;
            for (var i = 1; i < lines.Length - 2; i++)
            {
                var a = lines[i - 1] + lines[i] + lines[i + 1];
                var b = lines[i] + lines[i + 1] + lines[i + 2];

                if (b > a)
                    res++;
            }
            return res;
        }
    }
}
