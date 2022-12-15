using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day15/Main.txt");
            AddExample("Day15/Example1.txt", "26");
        }

        record struct Pos(int x, int y);
        record struct Sensor(Pos pos, int clearance);

        int Distance(Pos p1, Pos p2)
        {
            return Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y);
        }

        protected override object Solve(Input input)
        {
            List<Sensor> sensors = new();

            foreach(var line in input)
            {
                var tokens = line.ReadTokens<int>(new char[] { '=', ',', ':' });
                var s = new Pos(tokens[0], tokens[1]);
                var b = new Pos(tokens[2], tokens[3]);

                sensors.Add(new Sensor(s, Distance(s, b)));
            }
            var y = input.IsMain ? 2_000_000 : 10;

            Dictionary<int, byte> noBeacon = new();
            foreach(var sensor in sensors)
            {
                var dy = Math.Abs(sensor.pos.y - y);
                if (dy > sensor.clearance)
                    continue;

                var xnum = 2 * (sensor.clearance - dy);
                var fromx = sensor.pos.x - xnum / 2;
                var tox = sensor.pos.x + xnum / 2;
                for (var x = fromx; x < tox; x++)
                    noBeacon.TryAdd(x, 0);

            }

            return noBeacon.Count;
        }
    }
}
