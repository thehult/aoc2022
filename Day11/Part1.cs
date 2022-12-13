using Shared;
using Shared.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Part1 : AoCSolution
    {
        protected override void AddInputFiles()
        {
            AddMainInput("Day11/Main.txt");
            AddExample("Day11/Example1.txt", "10605");
        }

        Func<ulong, string, ulong> parseOpValue = (old, val) =>
        {
            if (val == "old")
                return old;
            return ulong.Parse(val);
        };

        protected override object Solve(Input input)
        {
            var monkeys = new List<Monkey>();

            while(input.HasMoreLines)
            {
                var monkey = new Monkey();
                while (input.GetLine().IsBlank()) ;

                monkey.Items = new Queue<ulong>(input.GetLine().ReadTokens<ulong>(new char[] { ' ', ',' }));

                var op = input.GetLine().ReadTokens();

                if (op[4] == "*")
                    monkey.Operation = old => old * parseOpValue(old, op[5]);
                else
                    monkey.Operation = old => old + parseOpValue(old, op[5]);

                var test = input.GetLine().ReadTokens<ulong>()[0];
                var m1 = input.GetLine().ReadTokens<int>()[0];
                var m2 = input.GetLine().ReadTokens<int>()[0];
                monkey.NextTest = worry => worry % test == 0 ? m1 : m2;

                monkey.Id = monkeys.Count;
                monkeys.Add(monkey);
            }


            for(var i = 0; i < 20; i++)
            {

                foreach(var monkey in monkeys)
                {
                    while(monkey.Items.TryDequeue(out var item))
                    {
                        var newWorry = monkey.Operation(item);
                        newWorry /= 3;
                        var nm = monkey.NextTest(newWorry);
                        monkeys[nm].Items.Enqueue(newWorry);
                        monkey.Inspections++;
                    }
                }

            }

            return monkeys.OrderByDescending(monkey => monkey.Inspections).Take(2).Aggregate((ulong)1, (acc, monkey) => acc * monkey.Inspections);
        }
    }
}
