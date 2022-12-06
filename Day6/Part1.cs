using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day6/Main.txt");
            AddExample("Day6/Example1.txt", "7");
            AddExample("Day6/Example2.txt", "5");
            AddExample("Day6/Example3.txt", "6");
            AddExample("Day6/Example4.txt", "10");
            AddExample("Day6/Example5.txt", "11");
        }

        protected override object Solve(Input input)
        {
            bool IsStartOfPacket(char[] chars)
            {
                for (var i = 0; i < chars.Length - 1; i++)
                    for (var j = i + 1; j < chars.Length; j++)
                        if (chars[i] == chars[j])
                            return false;
                return true;
            }

            var queue = new Queue<char>();

            var pos = 4;

            for (var i = 0; i < pos - 1; i++)
                queue.Enqueue(input[0].ReadChar());

            while (input[0].HasNextChar())
            {
                queue.Enqueue(input[0].ReadChar());
                if (IsStartOfPacket(queue.ToArray()))
                    break;
                queue.Dequeue();

                pos++;
            }

            return pos;
        }
    }
}
