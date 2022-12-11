using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day8/Main.txt");
            AddExample("Day8/Example1.txt", "8");
        }

        protected override object Solve(Input input)
        {

            int Trees(int x, int y, int heightLimit, int dx = 0, int dy = 0)
            {
                if (x + dx < 0 || x + dx >= input[0].Length || y + dy < 0 || y + dy >= input.NumberOfLines)
                    return 0;
                if (input[y + dy][x + dx] >= heightLimit)
                    return 1;
                return 1 + Trees(x + dx, y + dy, heightLimit, dx, dy);
            }

            var res = -1;
            for(var y = 0; y < input.NumberOfLines; y++)
            {
                for(var x = 0; x < input[y].Length; x++)
                {
                    var score =
                        Trees(x, y, input[y][x], -1, 0) *
                        Trees(x, y, input[y][x], 1, 0) *
                        Trees(x, y, input[y][x], 0, -1) *
                        Trees(x, y, input[y][x], 0, 1);
                    if(score > res)
                        res = score;
                }
            }

            return res;
        }
    }
}
