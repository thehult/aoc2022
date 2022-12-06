using Shared;
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
            AddMainInput("ExampleDay/Main.txt");
            AddExample("ExampleDay/Example1.txt", "7");
        }

        protected override object Solve(Input input)
        {
            var res = 0;            
            for(var i = 1; i < input.NumberOfLines; i++)
            {
                if (input[i] > input[i - 1])
                    res++;
            }
            return res;
        }
    }
}
