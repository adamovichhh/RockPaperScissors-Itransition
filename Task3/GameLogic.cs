using System;
using System.Security.Cryptography;

namespace Task3
{
    class GameLogic
    {
        public static string ComputerMove(string[] parametres)
        {
            return parametres[RandomNumberGenerator.GetInt32(parametres.Length)];
        }

        public static string GameResult(string[] parametres, string ComputerParametr, int UserChoiche)
        {
            int compuretIndex = UserChoiche;
            string yourState = "win";

            if (parametres[UserChoiche] == ComputerParametr)
            {
                return"draw";
            }
            else
            {
                for (int i = 0; i < parametres.Length / 2; i++)
                {
                    if (++compuretIndex == parametres.Length)
                    {
                        compuretIndex = 0;
                    }

                    if (ComputerParametr == parametres[compuretIndex])
                    {
                        return "lose";
                    }
                }

                return "win";
            }
        }
        public static void FindWinner(string[] parametres, string ComputerParametr, int UserChoiche)
        {
            string yourState = GameResult(parametres,ComputerParametr,UserChoiche);
            if (yourState == "win")
            {
                Console.WriteLine("You win!");
            }
            else
            {
                if (yourState == "lose")
                {
                    Console.WriteLine("Computer win!");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }
        }
     


    }
}
