using System;

namespace Lab02_UnitTesting
{
    public class Program
    {
        //starting balance
        public static double balance = 500.32;
        //initialize "receipt" string
        public static string receipt = $"***Your Receipt***\nBeginning Balance: ${balance}\n";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Generic Bank's ATM");
            MainMenu();
        }

        /// <summary>
        /// Display ATM Main Menu
        /// </summary>
        static void MainMenu()
        {
            Console.WriteLine("Make a Selction From the Following Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Make a Withdrawal");
            Console.WriteLine("3. Make a Deposit");
            Console.WriteLine("4. Exit");
            string userInput = Console.ReadLine();
            double selection = CheckValidNumbers(userInput);
            
            switch (selection)
            {
                case 1:
                    Console.WriteLine($"Your current balance is ${balance}");
                    AnotherTransaction();
                    break;
                case 2:
                    Console.Write("Enter amount to withdraw: ");
                    string enteredWithdrawal = Console.ReadLine();
                    double withdrawal = CheckValidNumbers(enteredWithdrawal);
                    balance = MakeWithdrawal(balance, withdrawal);
                    Console.WriteLine($"Your current balance is ${balance}");
                    AnotherTransaction();
                    break;
                case 3:
                    Console.Write("Enter deposit amount: ");
                    string enteredDeposit = Console.ReadLine();
                    double deposit = CheckValidNumbers(enteredDeposit);
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

        /// <summary>
        /// Take a string as input and determine if it contains valid numbers.
        /// Returns 0 if invalid
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>number</returns>
        public static double CheckValidNumbers(string input)
        {
            double number = 0;
            try
            {
                number = Convert.ToDouble(input);
            }
            catch (Exception)
            {
                return 0;
            }
            return number;
        }

        /// <summary>
        /// Ask user to make another transaction.
        /// Y Returns to Main Menu, N prints receipt and exits
        /// </summary>
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

        /// <summary>
        /// Make a "deposit" into the account
        /// Does not allow negatives or deposits > 5000
        /// </summary>
        /// <param name="balance">current balance</param>
        /// <param name="amount">amount of deposit</param>
        /// <returns>new balance</returns>
        public static double MakeDeposit(double balance, double amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("***Please enter positive numbers only***");
                return balance;
            }
            if(amount > 5000)
            {
                Console.WriteLine("***Please visit a branch for deposits over $5000***");
                return balance;
            }
            receipt += $"Deposit: ${amount}\n";
            return balance + amount;
        }

        /// <summary>
        /// Make a "withdrawal" from the account
        /// Does not allow negatives, withdrawals > 5000, or overdrafts
        /// </summary>
        /// <param name="balance">current balance</param>
        /// <param name="amount">amout of withdrawal</param>
        /// <returns>new balance</returns>
        public static double MakeWithdrawal(double balance, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("***Please enter positive numbers only***");
                return balance;
            }
            if (amount > 5000)
            {
                Console.WriteLine("***Please visit a branch for withdrawals over $5000***");
                return balance;
            }
            if (balance - amount < 0)
            {
                Console.WriteLine("***Insufficient Funds***");
                return balance;
            }
            receipt += $"Withdraw: ${amount}\n";
            return balance - amount;
        }

        /// <summary>
        /// Displays a "receipt" of beginning balance, list of
        /// transactions, and ending balance
        /// </summary>
        static void PrintReceipt()
        {
            Console.Clear();
            receipt += $"Ending Balance: ${balance}";
            Console.WriteLine($"{receipt}\n\nPress any key to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
