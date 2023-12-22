using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.day8
{
    static internal class day8
    {
        public static async Task PartOne()
        {
            var input = await Util.GetInput("day8", 1);

            var commands = input[0];

            // dictionary
            var network = new Dictionary<string, string[]>();

            for (int i = 2; i < input.Length; i++)
            {
                //Console.WriteLine(input[i]);

                string[] splitLine = input[i].Split(" = (");

                string name = splitLine[0];

                string[] directionSplit = splitLine[1].Split(", ");

                string left = directionSplit[0];
                string right = directionSplit[1].Substring(0, directionSplit[1].Length -1);

                network.Add(name, new string[] { left, right });
            }


            var currentKey = network.First().Value;
            string currentCommand = "";
            int stepCount = 0;

            while (currentCommand != "ZZZ")
            {
                // loop through commands and traverse dictionary
                foreach (var command in commands)
                {
                    //Console.WriteLine(command);

                    if (currentCommand == "ZZZ")
                        break;

                    if (command == 'L')
                    {
                        currentCommand = currentKey[0];
                    }
                    else
                    {
                        currentCommand = currentKey[1];
                    }

                    currentKey = network[currentCommand];
                    stepCount++;


                    if (currentCommand == "ZZZ")
                        break;

                    //Console.WriteLine("nextcommand: " + currentCommand);
                }
                Console.WriteLine("stepcount: " + stepCount + " - command: " + currentCommand);
            }

            Console.WriteLine("currentCommand: " + currentCommand);

            Console.WriteLine("day8 part one result: " + stepCount);
        }

        private static void LoopCommands(Dictionary<string, string[]> network, string commands)
        {

        }

        public static async Task PartTwo()
        {

        }
    }
}