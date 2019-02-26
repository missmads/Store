using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    class Store
    {
        int maxGames = 5;
        int maxDLC = 5;
        List<Game> showcase = new List<Game>();
        List<DLC> DLCshowcase = new List<DLC>();

        public Store()
        {
            showcase.Add(new Game("Daddy simulator", 10f, "How to dad", "real life"));
            showcase.Add(new Game("Half Life", 100f, "Best Game Ever", "Sci-Fi"));
            showcase.Add(new Game("Hat in Time", 20f, "Super Cute", "3D"));
            showcase.Add(new Game("Borderlands", 40f, "Hardcore", "FPS"));
            showcase.Add(new Game("Borderlands2", 40f, "Hardcore", "FPS"));
            DLCshowcase.Add(new DLC("Borderlands-CTRR", 10f, "hardcore", "FPS",false));
            DLCshowcase.Add(new DLC("Borderlands-GEN", 10f, "hardcore", "FPS", false));
            DLCshowcase.Add(new DLC("Borderlands2-HammerLock", 10f, "hardcore", "FPS", false));
            DLCshowcase.Add(new DLC("Borderlands-Moxxi", 10f, "hardcore", "FPS", false));
        }

        public bool IsValidGame(int n)
        {
            if (n < showcase.Count && n >= 0)
                return true;
            else
                return false;
        }

        public bool IsValidDLC(int d)
        {
            if (d < DLCshowcase.Count && d >= 0)
                return true;
            else
                return false;
        }

        public void PrintShowcase()
        {
            foreach (Game g in showcase)
            {
                Console.WriteLine("\t [" + showcase.IndexOf(g) + "]" + g.name + "," + g.price);
            }
        }

        public void PrintDLCShowcase()
        {
            foreach (DLC d in DLCshowcase)
            {
                Console.WriteLine("\t [" + DLCshowcase.IndexOf(d) + "]" + d.name + "," + d.price);
            }
        }

        public void AddGame(Game game)
        {/*
            if (showcase.Count < maxGames)
                showcase.Add(game);*/
            showcase.Add(game);
        }

        public void AddDLC(DLC dlc)
        {
            DLCshowcase.Add(dlc);
        }

        public void RemoveGameFunc(int game, User user)
        {
            RemoveGameFunc(showcase[game], user);
        }

        public void RemoveGameFunc(Game game, User user)
        {
            RemoveGame(game);
        }

        public void RemoveGame(Game game)
        {
            if (showcase.Contains(game))
                showcase.Remove(game);
        }

        public void RemoveDLCFunc(int dlc, User user)
        {
            RemoveDLCFunc(DLCshowcase[dlc], user);
        }
        public void RemoveDLCFunc(DLC dlc, User user)
        {
            RemoveDLC(dlc);
        }
        public void RemoveDLC(DLC dlc)
        {
            if (DLCshowcase.Contains(dlc))
                DLCshowcase.Remove(dlc);
        }

        public void Sell(int game, User user)
        {
            Sell(showcase[game], user);
        }

        public void Sell(Game game, User user)
        {
            if (user.wallet >= game.price)
            {
                user.wallet -= user.wallet - game.price;
                user.library.Add(game);
                RemoveGame(game);
            }
            else
                Console.WriteLine("Not Enough Money");
        }

        public void SellDLC(int dlc, User user)
        {
            SellDLC(DLCshowcase[dlc], user);
        }

        public void SellDLC(DLC dlc, User user)
        {
            if (user.wallet >= dlc.price)
            {
                user.wallet -= user.wallet - dlc.price;
                user.DLClibrary.Add(dlc);
                RemoveDLC(dlc);
            }
        }
    }
    class User
    {
        public float wallet = 0f;
        public List<Game> library = new List<Game>();
        public List<DLC> DLClibrary = new List<DLC>();

        public User(float walletFunds)
        {
            wallet = walletFunds;
        }
    }

    class Game
    {
        public string genre;
        public string name;
        public float price;
        public string description;

        public Game(string name, float price, string description, string genre)
        {
            this.name = name;
            this.genre = genre;
            this.price = price;
            this.description = description;
        }
    }

    class DLC
    {
        public string connectedGame;
        public string name;
        public float price;
        public string description;
        public bool hasGame;

        public DLC(string name, float price, string description, string connectedGame, bool hasGame)
        {
            this.name = name;
            this.connectedGame = connectedGame;
            this.price = price;
            this.description = description;

            this.hasGame = hasGame;
        }
    }
    
}