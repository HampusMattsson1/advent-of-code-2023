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
            var input = await Util.GetInput("day3");

            var validNumbers = new List<int>();

            string? previousLine = null;
            string? nextLine = null;

            // each line
            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                //Console.WriteLine(line);

                if (i != 0)
                    previousLine = input[i-1];

                if (i+1 != input.Length)
                    nextLine = input[i+1];

                var numbers = new List<int>();

                var lineNumbers = new Regex(@"(\d+)").Matches(line);

                //Console.WriteLine(regex.Count.ToString());
                foreach (Match foundNumber in lineNumbers)
                {
                    //Console.WriteLine($"Number: {foundNumber.Value} at Position: {foundNumber.Index} with Length: {foundNumber.Length}");
                    int leftIndexCheck = foundNumber.Index - 1;
                    int rightIndexCheck = foundNumber.Index + foundNumber.Length;

                    var charsToValidate = new List<char>();

                    // check this line
                    if (leftIndexCheck > 0)
                        charsToValidate.Add(line[leftIndexCheck]);

                    if (rightIndexCheck < line.Length)
                        charsToValidate.Add(line[rightIndexCheck]);

                    // check previous line & next line
                    for (int j = leftIndexCheck; j <= rightIndexCheck; j++)
                    {

                        if (previousLine != null)
                        {
                            if (0 <= j && j < previousLine.Length)
                                charsToValidate.Add(previousLine[j]);
                        }

                        if (nextLine != null)
                        {
                            if (0 <= j && j < nextLine.Length)
                                charsToValidate.Add(nextLine[j]);
                        }
                        
                    }

                    //Console.WriteLine("leftIndexCheck: " + leftIndexCheck);
                    //Console.WriteLine("rightIndexCheck: " + rightIndexCheck);

                    foreach (var toValidate in charsToValidate)
                    {
                        //Console.WriteLine(toValidate.ToString());
                        if (IsSymbol(toValidate))
                        {
                            validNumbers.Add(int.Parse(foundNumber.Value));
                        }
                    }

                }

                Console.WriteLine("valid numbers: "+validNumbers.Count);
                //break;
            }

            //foreach (var line in input)
            //{
            //    Console.WriteLine(line);

            //    //string[] foundNumbers;
            //}

            int sum = 0;

            // get the sum of all valid numbers
            foreach (var validNumber in validNumbers)
            {
                sum += validNumber;
            }

            Console.WriteLine("day3 part one result: " + sum);
        }

        private static bool IsSymbol(char input)
        {
            if (input == '.')
                return false;

            bool isNumber = int.TryParse(input.ToString(), out int result);

            if (isNumber)
                return false;

            return true;
        }

        public static async Task PartTwo()
        {
            var input = await Util.GetInput("day3", 2);

            var validNumbers = new List<int>();

            var gearLocationList = new List<Tuple<int, int, List<int>>>();

            string? previousLine = null;
            string? nextLine = null;

            // each line
            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                //Console.WriteLine(line);

                if (i != 0)
                    previousLine = input[i - 1];

                if (i + 1 != input.Length)
                    nextLine = input[i + 1];

                var lineNumbers = new Regex(@"(\d+)").Matches(line);

                //Console.WriteLine(regex.Count.ToString());
                foreach (Match foundNumber in lineNumbers)
                {
                    //Console.WriteLine($"Number: {foundNumber.Value} at Position: {foundNumber.Index} with Length: {foundNumber.Length}");
                    int leftIndexCheck = foundNumber.Index - 1;
                    int rightIndexCheck = foundNumber.Index + foundNumber.Length;

                    var charsToValidate = new List<char>();

                    // check this line
                    if (leftIndexCheck > 0)
                        charsToValidate.Add(line[leftIndexCheck]);

                    if (rightIndexCheck < line.Length)
                        charsToValidate.Add(line[rightIndexCheck]);

                    // check previous line & next line
                    for (int j = leftIndexCheck; j <= rightIndexCheck; j++)
                    {
                        if (previousLine != null)
                        {
                            if (0 <= j && j < previousLine.Length)
                                charsToValidate.Add(previousLine[j]);
                        }

                        if (nextLine != null)
                        {
                            if (0 <= j && j < nextLine.Length)
                                charsToValidate.Add(nextLine[j]);
                        }
                    }

                    //Console.WriteLine("leftIndexCheck: " + leftIndexCheck);
                    //Console.WriteLine("rightIndexCheck: " + rightIndexCheck);

                    foreach (var toValidate in charsToValidate)
                    {
                        //Console.WriteLine(toValidate.ToString());
                        if (IsSymbol(toValidate))
                        {
                            validNumbers.Add(int.Parse(foundNumber.Value));
                        }

                        if (IsGear(toValidate))
                        {
                            // check if gear exists
                            //var a = gearLocationList.Any(g => g.Item1 == i && g.Item2 == j);


                            gearLocationList.Add(new Tuple<int, int, List<int>>(2, 2, new List<int>() { int.Parse(foundNumber.Value) }));
                        }
                    }

                }

                Console.WriteLine("valid numbers: " + validNumbers.Count);
                //break;
            }

            //foreach (var line in input)
            //{
            //    Console.WriteLine(line);

            //    //string[] foundNumbers;
            //}

            int sum = 0;

            // get the sum of all valid numbers
            //foreach (var validNumber in validNumbers)
            //{
            //    sum += validNumber;
            //}

            //Console.WriteLine("day3 part two result: " + sum);
        }

        private static bool IsGear(char c)
        {
            if (c == '*')
                return true;

            return false;
        }
    }
}