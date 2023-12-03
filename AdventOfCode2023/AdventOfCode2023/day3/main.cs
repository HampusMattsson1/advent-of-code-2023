using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.day3
{
    static internal class day3
    {
        public static async Task PartOne()
        {
            var input = await Util.GetInput("day3", 1);

            foreach (var line in input)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("day3 part one result: ");
        }
    }
}