using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Assignment_Two
{
    class Game
    {
        private static List<Player> players;

        public List<Player> PlayerList
        {
            get { return players; }
            set { players = value; }
        }

        public int round { get; set; }
        public int maxRound { get; set; }

        public int targetScore { get; set; }
        public bool gameState { get; set; } = false;
        
        public static Player NextTurn(Player currentTurn)
        {
            if (players[players.Count-1] == currentTurn) {
                return players[0]; 
            }
            return players[players.IndexOf(currentTurn) + 1];
        }
    }

    class Output
    {
        public static string getResponse()
        {
            return Console.ReadLine();
        }
    }

    class GameOutput : Output
    {
        public static void StartingGameOutput()
        {
            Console.Clear();
            string message = @"
  _________ __                 __  .__                 ________  .__                 ________                       
 /   _____//  |______ ________/  |_|__| ____    ____   \______ \ |__| ____  ____    /  _____/_____    _____   ____  
 \_____  \\   __\__  \\_  __ \   __\  |/    \  / ___\   |    |  \|  |/ ___\/ __ \  /   \  ___\__  \  /     \_/ __ \ 
 /        \|  |  / __ \|  | \/|  | |  |   |  \/ /_/  >  |    `   \  \  \__\  ___/  \    \_\  \/ __ \|  Y Y  \  ___/ 
/_______  /|__| (____  /__|   |__| |__|___|  /\___  /  /_______  /__|\___  >___  >  \______  (____  /__|_|  /\___  >
        \/           \/                    \//_____/           \/        \/    \/          \/     \/      \/     \/ ";
        Console.WriteLine(message);
        return;
        }

        public static void LeaderboardOutput(List<Player> players) 
        {

            var orderedPlayers = players.OrderBy(p => p.Score);

            Console.WriteLine("\nPlayer: Score");
            Console.WriteLine("--------------------");
            foreach (Player player in orderedPlayers)
            {
                Console.WriteLine(player.Name + ": " + player.Score );
            }

        }


    }
}
