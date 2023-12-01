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
            var input = await Util.GetInput("day1");

            int result = 0;

            foreach (var line in input)
            {
                //Console.WriteLine(line);

                int? firstDigit = null;
                int? lastDigit = null;

                for (var i = 0; i < line.Length; i++)
                {
                    var isDigit = Int32.TryParse(line[i].ToString(), out int digit);
                    if (isDigit)
                    {
                        if (firstDigit == null)
                            firstDigit = digit;
                        else
                            lastDigit = digit;
                    }
                }

                // if there was only one number
                if (lastDigit == null)
                    lastDigit = firstDigit;

                int number = int.Parse(firstDigit.ToString() + lastDigit.ToString());

                result += number;

                //Console.WriteLine("firstDigit: " + firstDigit + " lastDigit: " + lastDigit);
            }

            Console.WriteLine("day1 part one result: " + result);
        }

        public static async Task PartTwo()
        {
            var input = await Util.GetInput("day1", 0);

            int result = 0;

            foreach (var line in input)
            {
                //Console.Write(line);

                int? firstDigit = null;
                int? lastDigit = null;

                string stringNumber = "";

                for (var i = 0; i < line.Length; i++)
                {
                    int? foundNumber = null;

                    var isDigit = Int32.TryParse(line[i].ToString(), out int digit);
                    if (isDigit)
                    {
                        foundNumber = digit;
                    }
                    else
                    {
                        stringNumber += line[i].ToString();

                        // kolla om stringnumber nu är ett nummer
                        foundNumber = GetStringNumber(stringNumber);

                        //Console.WriteLine(stringNumber);
                    }

                    if (foundNumber != null)
                    {
                        if (firstDigit == null)
                            firstDigit = foundNumber;
                        else
                            lastDigit = foundNumber;

                        stringNumber = "";

                        //Console.WriteLine("FOUND NUMBER: " + foundNumber);
                    }

                    
                    
                }

                // if there was only one number
                if (lastDigit == null)
                    lastDigit = firstDigit;

                // Fixa bugg på t.ex. "dnrrfklrpxstln57vqzkrxlqnmsvmgdbthreeoneightc" i slutet där det bör sluta på 8
                stringNumber = "";
                for (var i = line.Length-1; i >= 0; i--)
                {
                    stringNumber = line[i] + stringNumber;

                    int? foundNumber = GetStringNumber(stringNumber);

                    var isDigit = Int32.TryParse(line[i].ToString(), out int digit);
                    if (isDigit)
                    {
                        foundNumber = digit;
                    }

                    
                    if (foundNumber != null)
                    {
                        if (lastDigit != foundNumber)
                            lastDigit = foundNumber;
                        //Console.WriteLine(foundNumber);
                        break;
                    }
                }


                //Console.WriteLine($"   - hittade nummer: first: {firstDigit} last: {lastDigit}");
                //break;
                

                int number = int.Parse(firstDigit.ToString() + lastDigit.ToString());

                result += number;

                //Console.WriteLine("firstDigit: " + firstDigit + " lastDigit: " + lastDigit);
            }

            Console.WriteLine("day1 part two result: " + result);
        }

        private static int? GetStringNumber(string stringNumber)
        {
            int? foundNumber = null;

            var stringNumberDict = new Dictionary<string, int>()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            foreach (KeyValuePair<string, int> entry in stringNumberDict)
            {
                if (stringNumber.Contains(entry.Key))
                {
                    foundNumber = entry.Value;
                    break;
                }
            }

            return foundNumber;
        }
    }
}