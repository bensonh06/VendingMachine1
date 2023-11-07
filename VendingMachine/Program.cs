using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cashInserted = 0;

            List<string> stockNameList = new List<string>
            {
                "Skittles",
                "Pringles",
                "Pepsi",
                "Fanta",
                "Water",
                "Snickers",
                "Twix",
                "Wotsits",
                "Doritos",
                "Kitkat",
                "Mars",
                "Bounty"
            };

            List<double> stockPriceList = new List<double>
            {
                1.50, //skittles
                2.00, //pringles
                1.20, //pepsi
                1.20, //fanta
                1.00, //water
                1.35, //snickers
                1.50, //malteasers
                2.00, //wotsits
                2.00, //doritos
                1.35, //kitkat
                1.20, //starburst
                1.00  //bounty
            };

            while (true) { 
                Console.Clear();

                writeMenu(stockNameList, stockPriceList);

                Console.WriteLine("Total Credit: £" + cashInserted);

                Console.WriteLine("\nPlease choose an option: \n1. Insert Coins\n2. Select Product\n3. Exit");

                int choice = 0;

                try
                {
                    choice = int.Parse(Console.ReadLine());

                }
                catch
                {
                    choice = 4;
                }

                switch (choice)
                {
                    case 1:
                        insertCash(ref cashInserted);
                        break;
                    case 2:
                        pickProduct(ref cashInserted, stockNameList, stockPriceList);
                        break;
                    case 3:
                        exitMachine(ref cashInserted);
                        break;
                    default:
                        break;
                }
            }
            
        }

        static void pickProduct(ref double cashInserted, List<string> stock, List<double> price)
        {
            while (true) { 
                Console.Clear();

                

                Console.Write("\n");

                writeMenu(stock, price);

                Console.WriteLine("Total Credit: £" + cashInserted);

                Console.WriteLine("\nPlease make a selection from 1 - " + stock.Count + ": ");

                int item = 99;

                try
                {
                    item = (int.Parse(Console.ReadLine()) - 1);
                }
                catch
                {
                    item = 99;
                }

                if (item > -1 && item < 12)
                {
                    if (cashInserted >= price[item])
                    {
                        Console.WriteLine("\nDispensing one " + stock[item]);
                        cashInserted = cashInserted - price[item];
                    }
                    else
                    {
                        Console.WriteLine("\nSorry, you haven't inserted enough credit for this item.");
                    }
                }
                else
                {
                    Console.WriteLine("\nSorry, this item isn't on the menu.");
                }

                Console.WriteLine("\nWould you like to make another selection? (y/n)");
                if (Console.ReadLine().ToLower() == "n")
                {
                    break;
                }
            }
        }

        static void exitMachine(ref double moneyInserted)
        {
            Console.Clear();
            if (moneyInserted > 0)
            {
                Console.WriteLine("Refunding the remaining credit..");
                Task.Delay(5000).Wait();
                Console.WriteLine("£" + moneyInserted + " has been dispensed.");
            }
            Console.WriteLine("\nGoodbye, have a nice day.");
            Task.Delay(5000).Wait();
            Environment.Exit(0);
        }
        static void insertCash(ref double moneyInserted)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("The machine only accepts the following coins: 5p, 10p, 20p, 50p, £1, and £2.");

                Console.WriteLine("\nTotal Credit: £" + moneyInserted);

                Console.WriteLine("\nPlease insert a coin: (for example, 5p would be 0.05, 20p would be 0.20)");

                double coin;

                try
                {
                    coin = double.Parse(Console.ReadLine());
                }
                catch
                {
                    coin = 3;
                }

                switch (coin)
                {
                    case 0.05:
                        Console.WriteLine("\n5p inserted.");
                        moneyInserted = moneyInserted + 0.05;
                        break;
                    case 0.1:
                        Console.WriteLine("\n10p inserted.");
                        moneyInserted = moneyInserted + 0.1;
                        break;
                    case 0.2:
                        Console.WriteLine("\n20p inserted.");
                        moneyInserted = moneyInserted + 0.2;
                        break;
                    case 0.5:
                        Console.WriteLine("\n50p inserted.");
                        moneyInserted = moneyInserted + 0.5;
                        break;
                    case 1:
                        Console.WriteLine("\n£1 inserted.");
                        moneyInserted = moneyInserted + 1;
                        break;
                    case 2:
                        Console.WriteLine("\n£2 inserted.");
                        moneyInserted = moneyInserted + 2;
                        break;
                    default:
                        Console.WriteLine("\nThat coin isn't accepted, ejecting..");
                        break;
                }

                Console.WriteLine("\nWould you like to insert another coin? (y/n)");

                if (Console.ReadLine().ToLower() == "n")
                {
                    break;
                }
            }
        }
        static void writeMenu(List<string> stock, List<double> price)
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("                   \n ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" VENDING MACHINE ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(" \n                   ");

            for (int i = 0; i < stock.Count; i++)
            {
                Console.Write("\n ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" " + stock[i] + " - £" + price[i] + " ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                Console.SetCursorPosition(18, (i+2));
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(' ');
                Console.SetCursorPosition(0, (i + 3));
                
            }

            Console.SetCursorPosition(18 ,Console.CursorTop);
            Console.WriteLine(" \n                   \n");
            Console.BackgroundColor= ConsoleColor.Black;
            
           
        }
    }
}
