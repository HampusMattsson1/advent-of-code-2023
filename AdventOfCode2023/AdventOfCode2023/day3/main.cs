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
            var input = await Util.GetInput("day3", 2);

            //var validNumbers = new List<int>();

            string? previousLine = null;
            string? nextLine = null;

            // each line
            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];

                if (i != 0)
                    previousLine = input[i-1];

                if (i+1 != input.Length)
                    nextLine = input[i+1];

                var numbers = new List<int>();

                var regex = new Regex(@"(\d+)").Matches(line);

                //Console.WriteLine(regex.Count.ToString());
                foreach (Match match in regex)
                {
                    Console.WriteLine($"Number: {match.Value} at Position: {match.Index}");
                }

                Console.WriteLine(input[i]);
                break;
            }

            //foreach (var line in input)
            //{
            //    Console.WriteLine(line);

            //    //string[] foundNumbers;
            //}

            //Console.WriteLine("day3 part one result: ");
        }
    }
}