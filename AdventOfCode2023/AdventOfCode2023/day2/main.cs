using System;
using System.Collections.Generic;
using System.ComponentModel;
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

                int maxFoundRed = 0;
                int maxFoundGreen = 0;
                int maxFoundBlue = 0;

                // Split line
                Regex regex = new Regex(@"(Game \d+: ).*");
                Match match = regex.Match(line);
                if (!match.Success)
                {
                    Console.WriteLine("No match found for regular expression");
                }

                var game = match.Groups[1].Value;
                var gameString = line.Split(game)[1];
                Console.WriteLine(gameString);

                string[] reveals = gameString.Split("; ");

                foreach (var reveal in reveals)
                {
                    Console.WriteLine("reveal: "+reveal);

                    string[] revealColors = reveal.Split(", ");

                    foreach (var revealColor in revealColors)
                    {
                        Console.WriteLine("reveal colors: [" + revealColor + "]");
                    }

                }

                break;
            }

            Console.WriteLine("day2 part one result: " + result);
        }
    }
}