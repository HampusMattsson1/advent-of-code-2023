using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2023
{
    public static class Util
    {
        public static async Task<string[]> GetInput(string day, bool demo = false)
        {
            var path = $"..\\..\\..\\{day}\\";

            if (demo)
                return await File.ReadAllLinesAsync(path + "input_demo.txt");

            return await File.ReadAllLinesAsync(path + "input.txt");
        }
    }
}
