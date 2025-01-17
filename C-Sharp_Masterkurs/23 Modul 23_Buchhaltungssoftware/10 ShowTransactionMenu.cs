﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Masterkurs.Modul23_Buchhaltungssoftware
{
    public class ShowTransactionsMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Gebe den Zeitraum ein");
            Console.WriteLine("---------------------");

            DateTime startDate = InputStartDate();
            DateTime endDate = InputEndDate(startDate);
            Console.WriteLine( );
            Console.WriteLine("---------------------");
            PrintTrasactionsFromTo(startDate, endDate);
            Console.WriteLine("---------------------");

            Console.WriteLine("Drücke eine Taste um zum Hauptmenü zurückzukehren");
            Console.ReadKey();
        }

        private DateTime InputStartDate()
        {
            DateTime input;

            while (true)
            {
                bool correctInput = true;
                Console.Write("Startdatum (TT.MM.JJJJ: ");

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput = false;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ungültiges Startdatum!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (correctInput)
                    break;
            }

            return input;
        }

        private DateTime InputEndDate(DateTime startDate)
        {
            DateTime input;

            while (true)
            {
                bool correctInput = true;
                Console.Write("Enddatum (TT.MM.JJJJ: ");

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input) || input < startDate )
                {
                    correctInput = false;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ungültiges Enddatum!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (correctInput)
                    break;
            }

            return input;
        }

        private void PrintTrasactionsFromTo(DateTime startDate, DateTime endDate)
        {
            foreach(Transaction transaction in ProfileManager.CurrentProfile.Transactions)
            {
                if (transaction.Date >= startDate && transaction.Date < endDate)
                {
                    if(transaction.Amount < 0)
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                    Console.WriteLine(transaction.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
