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
            var input = await Util.GetInput("day2");

            int validGames = 0;
            var validGameIds = new List<int>();
            int result = 0;

            int maxRed = 12;
            int maxGreen = 13;
            int maxBlue = 14;

            foreach (var line in input)
            {
                //Console.WriteLine(line);

                var colorDictionary = new Dictionary<string, int>()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                //Console.WriteLine("colorDictionary before");
                //foreach (var key in colorDictionary)
                //{
                //    Console.WriteLine(key);
                //}

                // Split line
                Regex regex = new Regex(@"(Game \d+: ).*");
                Match match = regex.Match(line);
                if (!match.Success)
                {
                    Console.WriteLine("No match found for regular expression");
                }

                var game = match.Groups[1].Value;
                //Console.WriteLine("GAME: " + game);
                var gameId = int.Parse(new Regex(@"(\d+)").Match(game).Groups[1].Value);
                //Console.WriteLine("gameid: " + gameId);

                var gameString = line.Split(game)[1];
                //Console.WriteLine(gameString);

                string[] reveals = gameString.Split("; ");

                foreach (var reveal in reveals)
                {
                    //Console.WriteLine("reveal: "+reveal);

                    string[] revealColors = reveal.Split(", ");

                    foreach (var revealColorString in revealColors)
                    {
                        //Console.WriteLine("reveal colors: [" + revealColorString + "]");

                        int revealAmount = int.Parse(revealColorString.Split(" ")[0]);
                        string revealColor = revealColorString.Split(" ")[1];

                        // If the value is larger than the already found largest
                        if (colorDictionary[revealColor] < revealAmount)
                            colorDictionary[revealColor] = revealAmount;
                    }

                }

                //Console.WriteLine("colorDictionary after");
                //foreach (var key in colorDictionary)
                //{
                //    Console.WriteLine(key);
                //}

                // Check validity
                bool valid = false;

                if (colorDictionary["red"] <= maxRed && colorDictionary["green"] <= maxGreen && colorDictionary["blue"] <= maxBlue)
                {
                    valid = true;
                    validGames++;
                    validGameIds.Add(gameId);
                }

                //Console.BackgroundColor = ConsoleColor.Blue;
                //Console.WriteLine("Valid: " + valid);
                //Console.ResetColor();

                //break;
            }

            int sumOfValidGameIds = 0;
            foreach (var id in validGameIds)
            {
                sumOfValidGameIds += id;
            }
            //validGameIds.Select(i => sumOfValidGameIds += i);

            Console.WriteLine("day2 part one result: " + sumOfValidGameIds);
        }
    }
}