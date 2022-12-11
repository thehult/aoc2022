using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day10/Main.txt");
            AddExample("Day10/Example1.txt", "0");
        }

        protected override object Solve(Input input)
        {
            var X = 1;

            string? cmd = null;
            int arg = 0;
            int delay = 0;

            for (var i = 0; i < 240; i++)
            {
                if (i % 40 == 0)
                    Console.WriteLine();

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

                Console.Write(Math.Abs((i % 40) - X) < 2 ? '#' : '.');

                if (delay == 0)
                {
                    if (cmd == "addx")
                        X += arg;
                    cmd = null;
                }
                else delay--;
            }

            return 0;
        }
    }
}
