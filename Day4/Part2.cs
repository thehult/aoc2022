using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Part2Inputs/Main.txt");
            AddExample("Part2Inputs/Example1.txt", "4");
        }

        protected override object Solve(Input input)
        {
            var sum = 0;

            foreach (var line in input)
            {
                var a1 = line.ReadToken<int>('-');
                var a2 = line.ReadToken<int>(',');
                var b1 = line.ReadToken<int>('-');
                var b2 = line.ReadToken<int>(' ');

                if (a2 >= b1 && b2 >= a1)
                    sum++;
            }


            return sum;
        }
    }
}
