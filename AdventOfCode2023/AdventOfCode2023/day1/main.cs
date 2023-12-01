using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.day1
{
    static internal class day1
    {
        public static async Task PartOne()
        {
            var input = await Util.GetInput("day1", true);

            foreach (var line in input)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("day1 part one");
        }
    }
}