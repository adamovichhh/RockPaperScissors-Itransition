using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace Task3
{
    class HelpTable
    {
        public static void PrintHelpTable(string[] parameters)
        {
            ConsoleTable table = new ConsoleTable("User \\ PC");
            for (int i = 0; i < parameters.Length; i++)
            {
                table.Columns.Add(parameters[i]);
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                string[] row = new string[parameters.Length + 1];
                row[0] = parameters[i];
                for (int j = 0; j < parameters.Length; j++)
                    row[j + 1] = GameLogic.GameResult(parameters,parameters[j],i);
                table.Rows.Add(row);
            }
            table.Write(Format.Alternative);
        }

    }
}
