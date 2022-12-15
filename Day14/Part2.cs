using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day14/Main.txt");
            AddExample("Day14/Example1.txt", "93");
        }


        record struct Pos(int x, int y);


        Pos start = new(500, 0);
        int bottom = 0;
        Dictionary<Pos, byte> occupied = new();



        bool Move(Pos from, out Pos newPos)
        {
            newPos = Move(from);
            return newPos != new Pos(-1, -1);
        }

        Pos Move(Pos from)
        {
            if (from.y == bottom - 1)
                return from;

            if (!occupied.ContainsKey(new(from.x, from.y + 1)))
                return Move(new(from.x, from.y + 1));

            if (!occupied.ContainsKey(new(from.x - 1, from.y + 1)))
                return Move(new(from.x - 1, from.y + 1));

            if (!occupied.ContainsKey(new(from.x + 1, from.y + 1)))
                return Move(new(from.x + 1, from.y + 1));

            if (from == start)
                return new Pos(-1, -1);

            return from;
        }


        protected override object Solve(Input input)
        {

            foreach (var line in input)
            {
                var coords = line.ReadTokens<int>(new char[] { ',', ' ', '-', '>' });

                for (var i = 0; i < coords.Length - 3; i += 2)
                {
                    var fx = coords[i];
                    var fy = coords[i + 1];
                    var tx = coords[i + 2];
                    var ty = coords[i + 3];
                    var dx = Math.Sign(tx - fx);
                    var dy = Math.Sign(ty - fy);

                    bottom = Math.Max(fy, Math.Max(ty, bottom));

                    while (tx != fx || ty != fy)
                    {
                        occupied.TryAdd(new(fx, fy), 0);
                        fx += dx;
                        fy += dy;
                    }
                    occupied.TryAdd(new(fx, fy), 0);
                }
            }

            bottom += 2;

            var res = 0;
            while (Move(start, out var newPos))
            {
                occupied.Add(newPos, 0);
                res++;
            }
            res++;

            return res;
        }
    }
}
