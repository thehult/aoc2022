using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Part1Inputs/Main.txt");
            AddExample("Part1Inputs/Example1.txt", "2");
        }

        protected override object Solve(Input input)
        {
            var sum = 0;

            foreach(var line in input)
            {
                var a1 = line.ReadToken<int>('-');
                var a2 = line.ReadToken<int>(',');
                var b1 = line.ReadToken<int>('-');
                var b2 = line.ReadToken<int>();

                if (a1 >= b1 && a2 <= b2)
                    sum++;
                else if (b1 >= a1 && b2 <= a2)
                    sum++;
            }


            return sum;
        }
    }
}
