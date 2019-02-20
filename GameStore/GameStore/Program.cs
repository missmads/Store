using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Store store = new Store();
            User user = new User(100);
            
            while (true)
            {
                store.PrintShowcase();
                Console.WriteLine("How may i help you?");
                Console.WriteLine("Would you like to buy/add/quit?:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "buy":
                        Console.WriteLine("Which Game");
                        string buyinput = Console.ReadLine();
                        int gameN = int.Parse(buyinput);
                        if(store.IsValidGame(gameN))
                        {
                            store.Sell(gameN, user);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Game!");
                        }
                        break;
                    case "add":
                        Console.WriteLine(" What is the Name of the Game?");
                        string name = Console.ReadLine();
                        Console.WriteLine(" What is the Price of the Game?");
                        string price = Console.ReadLine();
                        float floatprice = float.Parse(price);
                        Console.WriteLine(" What is the Description of the Game?");
                        string description = Console.ReadLine();
                        Console.WriteLine(" What is the Genre of the Game?");
                        string genre = Console.ReadLine();
                        store.AddGame(new Game(name, floatprice, description, genre));
                        break;
                    case "quit":
                        Console.WriteLine("Goodbye");
                        return;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
    }
}
