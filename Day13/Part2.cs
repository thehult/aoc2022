using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day13/Main.txt");
            AddExample("Day13/Example1.txt", "140");
        }

        bool IsRightOrder(string left, string right)
        {
            if (left.Length == 0)
                return true;
            if (right.Length == 0)
                return false;

            if (left[0] == right[0])
                return IsRightOrder(left.Substring(1), right.Substring(1));

            if (left[0] == ']')
                return true;

            if (right[0] == ']')
                return false;

            if (left[0] == '[')
                return IsRightOrder(left, "[" + right[0] + "]" + right.Substring(1));

            if (right[0] == '[')
                return IsRightOrder("[" + left[0] + "]" + left.Substring(1), right);

            if (left[0] < right[0])
                return true;

            if (left[0] > right[0])
                return false;

            return false;
        }

        protected override object Solve(Input input)
        {
            List<string> packets = new()
            {
                "[[2]]",
                "[[6]]"
            };

            while (input.HasMoreLines)
            {
                var packet = input.ReadLine();
                if (string.IsNullOrEmpty(packet))
                    continue;

                packet = packet.Replace("10", "A");
                packet = packet.Replace(",", "");

                packets.Add(packet);
            }

            packets.Sort((a, b) => IsRightOrder(a, b) ? -1 : 1);
            var p2 = packets.FindIndex(s => s == "[[2]]") + 1;
            var p6 = packets.FindIndex(s => s == "[[6]]") + 1;
            return p2 * p6;
        }
    }
}
