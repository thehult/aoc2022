using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day7/Main.txt");
            AddExample("Day7/Example1.txt", "24933642");
        }

        protected override object Solve(Input input)
        {
            var root = Node.CreateTreeFromInput(input);

            var filesystem = 70_000_000;
            var update = 30_000_000;

            var required = update - (filesystem - root.Size);

            var res = root.Find(n => n.IsDir && n.Size > required).OrderBy(n => n.Size).First().Size;

            return res;
        }
    }
}
