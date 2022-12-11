using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day9/Main.txt");
            AddExample("Day9/Example1.txt", "13");
        }

        protected override object Solve(Input input)
        {
            var visited = new Dictionary<(int x, int y), byte>();
            (int x, int y) headPos = (0, 0);
            (int x, int y) tailPos = (0, 0);

            visited.Add(tailPos, 0);

            foreach(var line in input)
            {
                (int x, int y) dir = line.ReadToken() switch
                {
                    "R" => (1, 0),
                    "L" => (-1, 0),
                    "U" => (0, 1),
                    "D" => (0, -1),
                    _ => (0, 0)
                };
                var steps = line.ReadToken<int>();
                for (var i = 0; i < steps; i++)
                {
                    headPos.x += dir.x;
                    headPos.y += dir.y;
                    var dx = Math.Abs(headPos.x - tailPos.x);
                    var dy = Math.Abs(headPos.y - tailPos.y);
                    if (dx > 1 || dy > 1 || dx + dy > 2)
                    {
                        tailPos.x = headPos.x - dir.x;
                        tailPos.y = headPos.y - dir.y;
                        visited.TryAdd(tailPos, 0);
                    }
                }
            }

            return visited.Count;
        }
    }
}
