using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Day3
    {
        public int RunPart1()
        {
            var value = 0;
            var input = File.ReadAllLines("C:/Projects/Advent of Code 2022/UI/Day3.txt");
            foreach (var line in input)
            {
                var leftCompartment = line.Take(line.Length / 2).Select(x => (int)(x))
                    .Select(x => (x >= 97 && x <= 122) ? x - 96 : x - 38);
                var rightCompartment = line.Skip(line.Length / 2).Take(line.Length / 2).Select(x => (int)(x))
                    .Select(x => (x >= 97 && x <= 122) ? x - 96 : x - 38);
                var commonPriorities = leftCompartment.Intersect(rightCompartment).Sum();
                value += commonPriorities;
            }
            return value;

        }
    }
}
