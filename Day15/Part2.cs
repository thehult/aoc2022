using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day15/Main.txt");
            AddExample("Day15/Example1.txt", "56000011");
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

            foreach (var line in input)
            {
                var tokens = line.ReadTokens<int>(new char[] { '=', ',', ':' });
                var s = new Pos(tokens[0], tokens[1]);
                var b = new Pos(tokens[2], tokens[3]);

                sensors.Add(new Sensor(s, Distance(s, b)));
            }
            var limit = input.IsMain ? 4_000_000 : 20;


            bool CheckClearance(Pos pos)
            {
                if (pos.x < 0 || pos.y < 0 || pos.x > limit || pos.y > limit)
                    return false;
                foreach(var sensor in sensors)
                {
                    if (Distance(sensor.pos, pos) <= sensor.clearance)
                        return false;
                }
                return true;
            }

            Pos FindDistressBeacon()
            {
                foreach(var sensor in sensors)
                {
                    var ringOffset = sensor.clearance + 1;
                    for(var i = 0; i <= ringOffset; i++)
                    {
                        var p1 = new Pos(ringOffset + sensor.pos.x - i, sensor.pos.y + i);
                        var p2 = new Pos(ringOffset + sensor.pos.x - i, sensor.pos.y - i);
                        var p3 = new Pos(-ringOffset + sensor.pos.x + i, sensor.pos.y + i);
                        var p4 = new Pos(-ringOffset + sensor.pos.x + i, sensor.pos.y - i);
                        if (CheckClearance(p1))
                            return p1;
                        if (CheckClearance(p2))
                            return p2;
                        if (CheckClearance(p3))
                            return p3;
                        if (CheckClearance(p4))
                            return p4;
                    }
                }
                return new Pos(-1, -1);
            }

            var pos = FindDistressBeacon();

            ulong res = (ulong)pos.x * (ulong)4_000_000 + (ulong)pos.y;
            return res;
        }
    }
}
