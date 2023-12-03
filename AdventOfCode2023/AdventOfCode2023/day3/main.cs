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
                Console.WriteLine(line);

                if (i != 0)
                    previousLine = input[i-1];

                if (i+1 != input.Length)
                    nextLine = input[i+1];

                var numbers = new List<int>();

                var lineNumbers = new Regex(@"(\d+)").Matches(line);

                //Console.WriteLine(regex.Count.ToString());
                foreach (Match foundNumber in lineNumbers)
                {
                    Console.WriteLine($"Number: {foundNumber.Value} at Position: {foundNumber.Index} with Length: {foundNumber.Length}");
                    int leftIndexCheck = foundNumber.Index - 1;
                    int rightIndexCheck = foundNumber.Index + foundNumber.Length;

                    // what counts as a symbol

                    
                    // check this line


                    // check previous line


                    // check next line


                }

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