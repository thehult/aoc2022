using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Part2 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Part2Inputs/Main.txt");
            AddExample("Part2Inputs/Example1.txt", "12");
        }
        Dictionary<string, int> scores = new()
        {
            { "A A", 1 + 3 },
            { "A B", 2 + 6 },
            { "A C", 3 + 0 },
            { "B A", 1 + 0 },
            { "B B", 2 + 3 },
            { "B C", 3 + 6 },
            { "C A", 1 + 6 },
            { "C B", 2 + 0 },
            { "C C", 3 + 3 },
        };

        string Lose(string opp) => opp switch
        {
            "A" => "C",
            "B" => "A",
            "C" => "B",
            _ => ""
        };
        

        string Win(string opp) => opp switch
        {
            "A" => "B",
            "B" => "C",
            "C" => "A",
            _ => ""
        };

        protected override object Solve(Input input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                var opponent = line.ReadToken();
                var outcome = line.ReadToken();
                var you = "";
                if (outcome == "Y")
                    you = opponent;
                else if (outcome == "X")
                    you = Lose(opponent);
                else
                    you = Win(opponent);

                sum += scores[$"{opponent} {you}"];
            }
            return sum;
        }
    }
}
