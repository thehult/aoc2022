using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Part1Inputs/Main.txt");
            AddExample("Part1Inputs/Example1.txt", "24000");
        }

        protected override object Solve(Input input)
        {
            int max = -1;
            int current = 0;
            foreach(var line in input)
            {
                if(line.IsBlank())
                {
                    if (current > max)
                        max = current;
                    current = 0;
                    continue;
                }
                current += line;
            }
            return max;
        }
    }
}
