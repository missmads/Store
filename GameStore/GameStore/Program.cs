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
                
                Console.WriteLine("How may i help you?");
                Console.WriteLine("Would you like to buy/add/remove/quit?:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "buy":
                        Console.WriteLine("What Would you like to buy?");
                        Console.WriteLine("Game or DLC?");
                        string buyinput = Console.ReadLine();
                        switch (buyinput)
                        {
                            case "game":
                                Console.WriteLine("Which Game?");
                                store.PrintShowcase();
                                string buygameinput = Console.ReadLine();
                                int gameN = int.Parse(buygameinput);
                                if (store.IsValidGame(gameN))
                                {
                                    store.Sell(gameN, user);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Game!");
                                }
                                break;
                            case "dlc":
                                Console.WriteLine("Which DLC?");
                                store.PrintDLCShowcase();
                                string buydlcinput = Console.ReadLine();
                                int dlcD = int.Parse(buydlcinput);
                                if (store.IsValidDLC(dlcD))
                                {
                                    store.SellDLC(dlcD, user);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid DLC!");
                                }
                                break;
                        }
                        break;
                        

                    case "add":
                        Console.WriteLine("What will you add?");
                        Console.WriteLine("Game or DLC?");
                        string addinput = Console.ReadLine();
                        switch (addinput)
                        {
                            case "game":
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
                            case "dlc":
                                Console.WriteLine(" What is the Name of the DLC?");
                                string DLCname = Console.ReadLine();
                                Console.WriteLine(" What is the Price of the DLC?");
                                string DLCprice = Console.ReadLine();
                                float DLCfloatprice = float.Parse(DLCprice);
                                Console.WriteLine(" What is the Description of the DLC?");
                                string DLCdescription = Console.ReadLine();
                                Console.WriteLine(" What is the Genre of the DLC?");
                                string DLCgenre = Console.ReadLine();
                                store.AddDLC(new DLC(DLCname, DLCfloatprice, DLCdescription, DLCgenre,false));
                                break;
                        }
                        break;

                    case "remove":
                        Console.WriteLine("What would you like to Remove?");
                        Console.WriteLine("Game or DLC?");
                        string removeinput = Console.ReadLine();
                        switch (removeinput)
                        {
                            case "game":
                                Console.WriteLine("Which Game?");
                                store.PrintShowcase();
                                string removegameinput = Console.ReadLine();
                                int gameR = int.Parse(removegameinput);
                                if (store.IsValidGame(gameR))
                                {
                                    store.RemoveGameFunc(gameR, user);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Game!");
                                }
                                break;
                            case "dlc":
                                Console.WriteLine("Which DLC?");
                                store.PrintDLCShowcase();
                                string removedlcinput = Console.ReadLine();
                                int dlcR = int.Parse(removedlcinput);
                                if (store.IsValidGame(dlcR))
                                {
                                    store.RemoveDLCFunc(dlcR, user);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Game!");
                                }
                                break;
                        }
                        
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
