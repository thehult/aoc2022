using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day8/Main.txt");
            AddExample("Day8/Example1.txt", "21");
        }

        protected override object Solve(Input input)
        {
            Dictionary<(int, int), byte> trees = new();

            for (var i = 0; i < input.NumberOfLines; i++)
            {
                var s = input[i].Read();
                var currentHeight = ' ';
                for(var c = 0; c < s.Length; c++)
                {
                    if (s[c] > currentHeight)
                    {
                        currentHeight = s[c];
                        trees.TryAdd((i, c), 0);
                    }
                }
                currentHeight = ' ';
                for (var c = s.Length - 1; c >= 0; c--)
                {
                    if (s[c] > currentHeight)
                    {
                        currentHeight = s[c];
                        trees.TryAdd((i, c), 0);
                    }
                }
            }

            for(var i = 0; i < input[0].Length; i++)
            {
                var s = input.Select(line => line.ReadChar(i)).ToArray();
                var currentHeight = ' ';
                for (var c = 0; c < s.Length; c++)
                {
                    if (s[c] > currentHeight)
                    {
                        currentHeight = s[c];
                        trees.TryAdd((c, i), 0);
                    }
                }
                currentHeight = ' ';
                for (var c = s.Length - 1; c >= 0; c--)
                {
                    if (s[c] > currentHeight)
                    {
                        currentHeight = s[c];
                        trees.TryAdd((c, i), 0);
                    }
                }
            }

            return trees.Count;
        }
    }
}
