using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day3/Main.txt");
            AddExample("Day3/Example1.txt", "157");
        }

        int Priority(char c)
        {
            int priority = 1 + c - 'a';
            if (priority < 0)
                priority = 27 + c - 'A';
            return priority;
        }

        protected override object Solve(Input input)
        {
            var sum = 0;
            foreach(var line in input)
            {
                var half = line.Length / 2;
                var x = line.Substring(0, half);
                var y = line.Substring(half);

                for(var i = 0; i < x.Length; i++)
                {
                    if(y.Contains(x[i]))
                    {
                        sum += Priority(x[i]);
                        break;
                    }
                }
            }
            return sum;
        }
    }
}
