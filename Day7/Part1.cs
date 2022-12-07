using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day7/Main.txt");
            AddExample("Day7/Example1.txt", "95437");
        }

        protected override object Solve(Input input)
        {
            var root = Node.CreateTreeFromInput(input);

            var res = root.Find(n => n.IsDir && n.Size <= 100_000).Sum(n => n.Size);

            return res;
        }
    }
}
