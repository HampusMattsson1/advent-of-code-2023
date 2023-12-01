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
        public static async Task<string[]> GetInput(string day, int demo = 0)
        {
            var path = $"..\\..\\..\\{day}\\";

            if (demo == 1)
                return await File.ReadAllLinesAsync(path + "input_demo.txt");
            else if (demo == 2)
                return await File.ReadAllLinesAsync(path + "input_demo2.txt");

            return await File.ReadAllLinesAsync(path + "input.txt");
        }
    }
}
