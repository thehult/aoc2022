using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day10/Main.txt");
            AddExample("Day10/Example1.txt", "13140");
        }

        protected override object Solve(Input input)
        {
            var res = 0;

            var X = 1;

            string? cmd = null;
            int arg = 0;
            int delay = 0;

            for(var i = 0; i < 220; i++)
            {
                if (cmd == null)
                {
                    var line = input.GetLine();
                    cmd = line.ReadToken();
                    if (cmd == "addx")
                    {
                        arg = line.ReadToken<int>();
                        delay = 1;
                    }
                }

                if ((i - 19) % 40 == 0)
                    res += (i + 1) * X;

                if (delay == 0)
                {
                    if (cmd == "addx")
                        X += arg;
                    cmd = null;
                } else delay--;


            }

            return res;
        }
    }
}
