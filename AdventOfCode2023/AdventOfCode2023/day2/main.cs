using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.day2
{
    static internal class day2
    {
        public static async Task PartOne()
        {
            var input = await Util.GetInput("day2", 1);

            int result = 0;

            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;

            foreach (var line in input)
            {
                Console.WriteLine(line);

                // regex test to get data more easily
                string pattern = @"(Game \d+: ).*";

                Regex regex = new Regex(pattern);
                Match match = regex.Match(line);

                if (match.Success)
                {

                    string[] matchArray = new string[match.Groups.Count];
                    for (int i = 0; i < match.Groups.Count; i++)
                    {
                        Console.WriteLine("match: " + match.Groups[i].Value);
                    }

                }

                var regexArray = Regex.Split(line, pattern);
                Console.WriteLine(regexArray);

                foreach (var i in regexArray)
                {
                    Console.WriteLine("i: " + i);
                }

                break;
            }

            Console.WriteLine("day2 part one result: " + result);
        }
    }
}