using System;

namespace Lab02_UnitTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            double balance = 5000;
            Console.WriteLine("Welcome to Generic Bank's ATM");
            MainMenu(balance);
        }

        static void MainMenu(double balance)
        {
            Console.WriteLine("Make a Selction From the Following Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Make a Withdrawal");
            Console.WriteLine("3. Make a Deposit");
            Console.WriteLine("4. Exit");
            string userInput = Console.ReadLine();
            double selection = CheckForNumbers(userInput, balance);
            
            switch (selection)
            {
                case 1:
                    Console.WriteLine($"Your current balance is ${balance}");
                    AnotherTransaction(balance);
                    break;
                case 2:
                    AnotherTransaction(balance);
                    break;
                case 3:
                    Console.Write("Enter deposit amount: ");
                    string amount = Console.ReadLine();
                    double deposit = CheckForNumbers(amount, balance);
                    balance = MakeDeposit(balance, deposit);
                    AnotherTransaction(balance);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("***Please make a valid selection.***");
                    MainMenu(balance);
                    break;
            }
        }

        static double CheckForNumbers(string input, double balance)
        {
            double number = 0;
            try
            {
                number = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                Console.WriteLine("***An error has occurred. Please try again***");
                MainMenu(balance);
            }
            return number;
        }

        static void AnotherTransaction(double balance)
        {
            Console.WriteLine("Would you like to make another transaction? Y/N");
            string selection = Console.ReadLine();
            if (selection.ToUpper() == "Y")
            {
                MainMenu(balance);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static double MakeDeposit(double balance, double deposit)
        {
            if(deposit < 0)
            {
                Console.WriteLine("***Please enter positive numbers only");
                return balance;
            }
            return balance + deposit;
        }
    }
}
