using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class Monkey
    {
        public int Id;
        public Queue<ulong> Items = new();
        public Func<ulong, ulong> Operation = null!;
        public Func<ulong, int> NextTest = null!;
        public ulong Tester;

        public ulong Inspections = 0;

        public override string ToString()
        {
            return "Inspections: " + Inspections.ToString();
        }
    }
}
