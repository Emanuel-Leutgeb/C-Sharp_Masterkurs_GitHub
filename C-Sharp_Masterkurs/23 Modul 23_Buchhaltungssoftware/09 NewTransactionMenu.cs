﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Masterkurs.Modul23_Buchhaltungssoftware
{
    public class NewTransactionMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Neue Transaktion");
            Console.WriteLine("----------------");
            Console.WriteLine();

            string newTransaktionName = InputTransactionName();
            decimal newTransaktionAmount = InputTransactionAmount();
            DateTime newTransactionDate = InputTransactionDate();

            Transaction transaction = new Transaction(newTransaktionName, newTransaktionAmount, newTransactionDate);
            ProfileManager.CurrentProfile.AddTransaction(transaction);
            Console.WriteLine("Die folgende Transaktion wurde hinzugefügt");

            if (transaction.Amount < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }

            Console.WriteLine(transaction.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            Menu nextMenu = new MainMenu();
        }
    

        private string InputTransactionName()
        {
            Console.Write("Transaktions-Name: ");
            return Console.ReadLine();
        }

        private decimal InputTransactionAmount()
        {
            decimal input;

            while (true)
            {
                Console.Write("Euro-Betrag: ");
                bool correctInput = true;

                if (!decimal.TryParse(Console.ReadLine(), out input))
                {
                    correctInput = false;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ungültiger Eurobetrag!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (correctInput)
                    break;
            }

            return input;
        }

        private DateTime InputTransactionDate()
        {
            DateTime input;

            while(true)
            {
                Console.Write("Datum (TT.MM.JJJJ): ");
                bool correctInput = true;

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput = false;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ungültiges Datum!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (correctInput)
                    break;
            }

            return input;
        }
    }
}
