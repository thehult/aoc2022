using Shared;
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
            AddMainInput("ExampleDay/Main.txt");
            AddExample("ExampleDay/Example1.txt", "5");
        }

        protected override object Solve(Input input)
        {
            var res = 0;
            for (var i = 1; i < input.NumberOfLines - 2; i++)
            {
                int a = input[i - 1] + input[i] + input[i + 1];
                int b = input[i] + input[i + 1] + input[i + 2];

                if (b > a)
                    res++;
            }
            return res;
        }
    }
}
