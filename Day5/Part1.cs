using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day5/Main.txt");
            AddExample("Day5/Example1.txt", "CMZ");
        }

        protected override object Solve(Input input)
        {
            Dictionary<int, List<char>> stacks = new Dictionary<int, List<char>>();

            void AddToStack(int stack, char c)
            {
                stacks.TryAdd(stack, new List<char>(c));
                if(c != ' ')
                    stacks[stack].Add(c);
            }

            void Move(int num, int from, int to)
            {
                for (var n = 0; n < num; n++)
                {
                    var c = stacks[from][0];
                    stacks[from].RemoveAt(0);
                    stacks[to].Insert(0, c);
                }
            }


            var i = 0;
            for(i = 0; !input[i+1].IsBlank(); i++)
            {
                for(var s = 0; s < (1 + input[i].Length) / 4; s++)
                {
                    var c = input[i].ReadChar(s*4+1);
                    AddToStack(s+1, c);
                }
            }

            for(i = i + 2; i < input.NumberOfLines; i++)
            {
                var cmd = input[i].ReadTokens<int>();
                Move(cmd[0], cmd[1], cmd[2]);
            }

            var res = "";
            for(var s = 1; s <= stacks.Count; s++)
            {
                res += stacks[s][0];
            }

            return res;
        }
    }
}
