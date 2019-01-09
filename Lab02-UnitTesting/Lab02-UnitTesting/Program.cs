using System;

namespace Lab02_UnitTesting
{
    public class Program
    {
        public static double balance = 5000;
        public static string receipt = $"Your Receipt\nBeginning Balance: {balance}\n";

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
            string userInput = Console.ReadLine();
            double selection = CheckForNumbers(userInput);
            
            switch (selection)
            {
                case 1:
                    Console.WriteLine($"Your current balance is ${balance}");
                    AnotherTransaction();
                    break;
                case 2:
                    Console.Write("Enter amount to withdraw: ");
                    string enteredWithdrawal = Console.ReadLine();
                    double withdrawal = CheckForNumbers(enteredWithdrawal);
                    balance = MakeWithdrawal(balance, withdrawal);
                    Console.WriteLine($"Your current balance is ${balance}");
                    AnotherTransaction();
                    break;
                case 3:
                    Console.Write("Enter deposit amount: ");
                    string enteredDeposit = Console.ReadLine();
                    double deposit = CheckForNumbers(enteredDeposit);
                    balance = MakeDeposit(balance, deposit);
                    Console.WriteLine($"Your current balance is ${balance}");
                    AnotherTransaction();
                    break;
                case 4:
                    PrintReceipt();
                    break;
                default:
                    Console.WriteLine("***Please make a valid selection.***");
                    MainMenu();
                    break;
            }
        }

        static double CheckForNumbers(string input)
        {
            double number = 0;
            try
            {
                number = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                Console.WriteLine("***An error has occurred. Please try again***");
                AnotherTransaction();
            }
            return number;
        }

        static void AnotherTransaction()
        {
            Console.WriteLine("Would you like to make another transaction? Y/N");
            string selection = Console.ReadLine();
            if (selection.ToUpper() == "Y" || selection == "")
            {
                MainMenu();
            }
            else
            {
                PrintReceipt();
            }
        }

        public static double MakeDeposit(double balance, double amount)
        {
            if(amount < 0)
            {
                Console.WriteLine("***Please enter positive numbers only");
                return balance;
            }
            receipt += $"Deposit: {amount}\n";
            return balance + amount;
        }

        public static double MakeWithdrawal(double balance, double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("***Please enter positive numbers only");
                return balance;
            }
            if (balance - amount < 0)
            {
                Console.WriteLine("Insufficient Funds");
                return balance;
            }
            receipt += $"Withdraw: {amount}\n";
            return balance - amount;
        }

        static void PrintReceipt()
        {
            Console.Clear();
            receipt += $"Ending Balance: {balance}";
            Console.WriteLine($"{receipt}\n\nPress any key to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
