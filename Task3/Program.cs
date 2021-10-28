using System;
using System.Text;
using System.Linq;
using ConsoleTables;

namespace Task3
{
    class Program
    {  
        static bool CheckInput(string[] parameters)
        {
            static void PrintExample()
            {
                Console.WriteLine("Example 1: >start Task3.exe rock paper scissors");
                Console.WriteLine("Example 1: >start Task3.exe 1 2 3 4 5");
                Console.WriteLine("Press any button to continue...");
                Console.ReadLine();
            }

            if (parameters.Length < 3)
            {
                Console.WriteLine("The number of parameters must be at least 3!");
                PrintExample();
                return false;
            }
            else
            {
                if (parameters.Length % 2 != 1)
                {
                    Console.WriteLine("The number of parameters must be odd!");
                    PrintExample();
                    return false;
                }
                else
                {
                    if (parameters.Distinct().Count() != parameters.Count())
                    {
                        Console.WriteLine("There are the same parameters!");
                        PrintExample();
                        return false;
                    }
                    else return true;
                }
            }
        }

        static void PrintMenu(string[] parameters)
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < parameters.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {parameters[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
        }

        static void Main(string[] args)
        {

            string[] parameters = new string[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                parameters[i] = args[i];
            }

            const int keySize = 16;
            
            if (CheckInput(parameters))
            {
                while(true)
                {
                    Console.Clear();
                    string ComputerChoiche = GameLogic.ComputerMove(parameters);
                    HMAC hmac = new HMAC(Encoding.Default.GetBytes(ComputerChoiche), keySize);
                    hmac.OutputHMAC();
                    PrintMenu(parameters);
                    string Choiche = Console.ReadLine();
               
                    if (Choiche == "?")
                    {
                        HelpTable.PrintHelpTable(parameters);
                        Console.WriteLine("Press any button to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        int UserChoice = int.Parse(Choiche);
                        if (UserChoice == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Your move: {parameters[UserChoice - 1]}");
                            Console.WriteLine($"Computer move: {ComputerChoiche}");
                            GameLogic.FindWinner(parameters, ComputerChoiche, UserChoice - 1);
                            hmac.OutputKey();
                            Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                        }
                    }

                }
            }
        }
    }
}
