using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.day4
{
    static internal class day4
    {
        public static async Task PartOne()
        {
            var input = await Util.GetInput("day4", 0);

            int pointSum = 0;

            foreach (var line in input)
            {
                //Console.WriteLine(line);

                string cardString = new Regex(@"(Card\s+\d+: ).*").Match(line).Groups[1].Value;
                //Console.WriteLine($"{cardString}");
                string gameString = line.Split(cardString)[1];

                //Console.WriteLine(cardString);
                //Console.WriteLine(gameString);

                string winningNumberString = gameString.Split(" | ")[0];
                string playerNumberString = gameString.Split(" | ")[1];

                //Console.WriteLine(winningNumberString);
                //Console.WriteLine("playernumberstring: " + playerNumberString);

                int[] winningNumbers = new Regex(@"\d+").Matches(winningNumberString).Select(m => int.Parse(m.Value)).ToArray();
                int[] playerNumbers = new Regex(@"\d+").Matches(playerNumberString).Select(m => int.Parse(m.Value)).ToArray();
                //Console.WriteLine("HEJJJ: " + new Regex(@"\d+").Matches(playerNumberString).Count);
                //Console.WriteLine("AAAA: " + new Regex(@"\d+").Matches(playerNumberString)[2].Value);
                //Console.WriteLine(new Regex(@".*(\d+).*").Match(playerNumberString).Groups[1].Value);
                //string[] playerNumbers = new Regex(@".*(\d+).*").Match(playerNumberString).Groups.Count;

                int currentPoints = 0;

                //Console.WriteLine($"playerNumbers.Count {playerNumbers.Length}");

                foreach (var playerNumber in playerNumbers)
                {
                    if (winningNumbers.Contains(playerNumber))
                    {
                        if (currentPoints == 0)
                        {
                            currentPoints = 1;
                            continue;
                        }

                        currentPoints = currentPoints * 2;
                    }
                }

                pointSum += currentPoints;


                //break;
            }

            Console.WriteLine("day4 part one result: " + pointSum);
        }

        public static async Task PartTwo()
        {
            var input = await Util.GetInput("day4", 1);

            int totalScratchCards = 0;

            int lineIndex = 0;

            foreach (var line in input)
            {
                //Console.WriteLine(line);

                string cardString = new Regex(@"(Card\s+\d+: ).*").Match(line).Groups[1].Value;
                string gameString = line.Split(cardString)[1];

                string winningNumberString = gameString.Split(" | ")[0];
                string playerNumberString = gameString.Split(" | ")[1];

                int[] winningNumbers = new Regex(@"\d+").Matches(winningNumberString).Select(m => int.Parse(m.Value)).ToArray();
                int[] playerNumbers = new Regex(@"\d+").Matches(playerNumberString).Select(m => int.Parse(m.Value)).ToArray();
                //Console.WriteLine("HEJJJ: " + new Regex(@"\d+").Matches(playerNumberString).Count);
                //Console.WriteLine("AAAA: " + new Regex(@"\d+").Matches(playerNumberString)[2].Value);
                //Console.WriteLine(new Regex(@".*(\d+).*").Match(playerNumberString).Groups[1].Value);
                //string[] playerNumbers = new Regex(@".*(\d+).*").Match(playerNumberString).Groups.Count;

                int winCardIndex = 1;

                //var winCardIndexes = new List<int>();

                int nestedScrapCardWins = GetScrapCardWins(input, lineIndex);

                Console.WriteLine("nestedScrapCardWins: " + nestedScrapCardWins);

                Console.WriteLine("GetScrapCardWins: " + GetScrapCardWins(input, lineIndex));

                int wins = 0;

                foreach (var playerNumber in playerNumbers)
                {
                    // if win
                    if (winningNumbers.Contains(playerNumber))
                    {
                        wins++;
                        totalScratchCards += GetScrapCardWins(input, lineIndex + wins);
                    }
                }

                //foreach (var winCard in  winCardIndexes)
                //{
                //    Console.WriteLine(winCard+1);

                //    // get all scrapcard wins for this line
                //    totalScratchCards++;
                //}

                lineIndex++;
                break;
            }

            Console.WriteLine("totalScratchCards: " + totalScratchCards);
        }

        private static int GetScrapCardWins(string[] input, int lineIndex)
        {
            string line = input[lineIndex];

            string cardString = new Regex(@"(Card\s+\d+: ).*").Match(line).Groups[1].Value;
            string gameString = line.Split(cardString)[1];

            string winningNumberString = gameString.Split(" | ")[0];
            string playerNumberString = gameString.Split(" | ")[1];

            int[] winningNumbers = new Regex(@"\d+").Matches(winningNumberString).Select(m => int.Parse(m.Value)).ToArray();
            int[] playerNumbers = new Regex(@"\d+").Matches(playerNumberString).Select(m => int.Parse(m.Value)).ToArray();

            int wins = 0;
            int lineCount = lineIndex;

            foreach (var playerNumber in playerNumbers)
            {
                // if win
                if (winningNumbers.Contains(playerNumber))
                {
                    // if it's not outside of the input
                    if ((lineIndex + wins) != input.Length)
                    {
                        //wins++;
                        lineCount++;
                        wins += GetScrapCardWins(input, lineCount);
                    }
                }
            }

            return wins;
        }
    }
}