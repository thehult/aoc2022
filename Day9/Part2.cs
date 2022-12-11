using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day9/Main.txt");
            AddExample("Day9/Example1.txt", "1");
            AddExample("Day9/Example2.txt", "36");
        }

        class Node
        {
            public int x = 0;
            public int y = 0;
            public Node? next;
            public char name;

            public Node(char name)
            {
                this.name = name;
            }

            public (int, int) Move(int movex, int movey)
            {
                x += movex;
                y += movey;
                if (next == null)
                    return (x, y);
                var dx = x - next.x;
                var dy = y - next.y;
                if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
                {
                    movex = dx == 0 ? 0 : dx / Math.Abs(dx);
                    movey = dy == 0 ? 0 : dy / Math.Abs(dy);
                    return next.Move(movex, movey);
                }
                return next.Move(0, 0);
            }

            
        }

        protected override object Solve(Input input)
        {
            var visited = new Dictionary<(int x, int y), byte>();
            var head = new Node('H');

            var cur = head;
            for (var i = 0; i < 9; i++)
            {
                var n = new Node(char.Parse((i+1).ToString()));
                cur.next = n;
                cur = n;
            }

            visited.Add((0, 0), 0);

            foreach (var line in input)
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
                    visited.TryAdd(head.Move(dir.x, dir.y), 0);
                }

            }

            return visited.Count;
        }
    }
}
