using Escape_Mines.Business;
using Escape_Mines.Business.Enums;
using System;
using System.IO;

namespace Escape_Mines
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] fileLines = File.ReadAllLines("inputs.txt");
            var starter = new Starter(fileLines);
            var results = starter.Start();
            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
            Console.ReadKey();
        }

    }
}
