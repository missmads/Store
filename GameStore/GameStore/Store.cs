using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    class Store
    {
        int maxGames = 4;
        List<Game> showcase = new List<Game>();

        public Store()
        {
            showcase.Add(new Game("Daddy simulator", 15f, "How to dad", "real life"));
            showcase.Add(new Game("Half Life", 1000f, "Best Game Ever", "Sci-Fi"));
            showcase.Add(new Game("Hat in Time", 20f, "Super Cute", "3D"));
        }

        public bool IsValidGame(int n)
        {
            if (n < showcase.Count && n >= 0)
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

        public void AddGame(Game game)
        {/*
            if (showcase.Count < maxGames)
                showcase.Add(game);*/
            showcase.Add(game);
        }

        public void RemoveGame(Game game)
        {
            if (showcase.Contains(game))
                showcase.Remove(game);
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
    }
    class User
    {
        public float wallet = 100f;
        public List<Game> library = new List<Game>();

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