using System;

namespace Lab02_UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Generic Bank's ATM");
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("Make a Selction From the Following Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Make a Withdrawal");
            Console.WriteLine("3. Make a Deposit");
            Console.WriteLine("4. Exit");
            string menuSelection = Console.ReadLine();
            int selection = Convert.ToInt32(menuSelection);

            switch (selection)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        static void AnotherTransaction()
        {
            Console.WriteLine("Would you like to make another transaction? Y/N");
            string selection = Console.ReadLine();
            if (selection == "Y")
            {
                MainMenu();
            }
        }
    }
}
