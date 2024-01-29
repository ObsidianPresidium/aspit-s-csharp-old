// See https://aka.ms/new-console-template for more information

using System.Data.Common;
using aspit_s_csharp;

namespace aspit_s_csharp
{
    internal class Program
    {
        static DoubleNumber doubleNumber = new DoubleNumber();
        static Factorial factorial = new Factorial();
        static PrintPattern printPattern = new PrintPattern();
        static GameOfLuck gameOfLuck = new GameOfLuck();
        
        static string[] solutions =
        {
            "Program",
            "doubleNumber",
            "factorial",
            "printPattern",
            "gameOfLuck"
        }; 
        
        static void Main(string[] args)
        {
            int numSolutions = solutions.Length;

            Console.WriteLine("Vælg en løsning, hvis indhold skal eksekveres");
            for (int i=1; i<numSolutions; i++)
            {
                Console.WriteLine($"Løsning {solutions[i]}: {i}");
            }

            string input = "";
            bool valid = ushort.TryParse(input, out ushort inputInt); 
            while (!valid)
            {
                Console.Write(": ");
                input = Console.ReadLine();
                try
                {
                    inputInt = ushort.Parse(input);
                    if (inputInt > numSolutions || inputInt == 0)
                    {
                        throw new FormatException("Out of range.");
                    }

                    valid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Udenfor range eller ugyldig.");
                }
            }
            switch (inputInt)
            {
                case 1:
                    doubleNumber.Main();
                    break;
                case 2:
                    factorial.Main();
                    break;
                case 3:
                    printPattern.Main();
                    break;
                case 4:
                    gameOfLuck.Main();
                    break;
                default:
                    Console.WriteLine("Uhåndteret fejl :/");
                    break;
            }
        }
    }
}