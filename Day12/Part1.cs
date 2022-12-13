using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day12/Main.txt");
            AddExample("Day12/Example1.txt", "31");
        }

        public record struct Pos(int x, int y);
        protected override object Solve(Input input)
        {
            Pos start = new(0, 0);
            Pos end = new(0, 0);


            for(var y = 0; y < input.NumberOfLines; y++)
            {
                for(var x = 0; x < input[y].Length; x++)
                {
                    var c = input[y][x];
                    if (c == 'E')
                    {
                        end = new(x, y);
                    }
                    else if (c == 'S')
                        start = new(x, y);
                }
            }

            Dictionary<Pos, int> visited = new() { };
            Queue<(Pos pos, int steps)> positions = new();
            positions.Enqueue((start, 0));
            
            void TryEnqueue(Pos pos, Pos from, int steps)
            {
                if (visited.ContainsKey(pos))
                    return;

                if (pos.y < 0 || pos.x < 0 || pos.y >= input.NumberOfLines || pos.x >= input[pos.y].Length)
                    return;

                var height = (Pos p) => 
                {
                    if (input[p.y][p.x] == 'E') return 'z';
                    else if (input[p.y][p.x] == 'S') return 'a';
                    else return input[p.y][p.x];
                };

                if (height(pos) > height(from) + 1)
                    return;

                positions.Enqueue((pos, steps));
            }

            while(positions.Count > 0)
            {
                var current = positions.Dequeue();
                if (visited.ContainsKey(current.pos))
                    continue;

                visited.Add(current.pos, current.steps);

                if (current.pos == end)
                    break;


                TryEnqueue(new(current.pos.x - 1, current.pos.y), current.pos, current.steps + 1);
                TryEnqueue(new(current.pos.x + 1, current.pos.y), current.pos, current.steps + 1);
                TryEnqueue(new(current.pos.x, current.pos.y - 1), current.pos, current.steps + 1);
                TryEnqueue(new(current.pos.x, current.pos.y + 1), current.pos, current.steps + 1);
            }

            return visited[end];
        }
    }
}
