using Shared;
using Shared.AoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day13/Main.txt");
            AddExample("Day13/Example1.txt", "13");
        }

        bool IsRightOrder(string left, string right)
        {
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
            var res = 0;
            var i = 0;
            while (input.HasMoreLines)
            {
                i++;
                var packet1 = input.ReadLine();
                var packet2 = input.ReadLine();
                if(input.HasMoreLines)
                    input.ReadLine();

                // Det här tog tid att felsöka...
                packet1 = packet1.Replace("10", "A");
                packet2 = packet2.Replace("10", "A");


                packet1 = packet1.Replace(",", "");
                packet2 = packet2.Replace(",", "");



                if (IsRightOrder(packet1, packet2))
                    res += i;
            }

            return res;
        }
    }
}
