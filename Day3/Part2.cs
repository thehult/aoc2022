using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day3/Main.txt");
            AddExample("Day3/Example1.txt", "70");
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

            for(var i = 0; i < input.NumberOfLines - 2; i += 3)
            {
                var a = input[i];
                var b = input[i + 1];
                var c = input[i + 2];

                List<char> items = new((string)a);
                foreach (var item in (string)a)
                {
                    if (!b.Contains(item))
                        items.RemoveAll(c => c == item);
                    else if(!c.Contains(item))
                        items.RemoveAll(c => c == item);
                }
                
                sum += Priority(items[0]);
            }

            return sum;
        }
    }
}
