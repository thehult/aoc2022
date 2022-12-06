using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day1/Main.txt");
            AddExample("Day1/Example1.txt", "5");
        }

        protected override object Solve(Input input)
        {
            int current = 0;
            var list = new List<int>();

            foreach (var line in input)
            {
                if (line.IsBlank())
                {
                    list.Add(current);
                    current = 0;
                    continue;
                }
                current += line;
            }
            list.Add(current);
            var ordered = list.OrderByDescending(x => x).ToArray();

            return ordered[0] + ordered[1] + ordered[2];
        }
    }
}
