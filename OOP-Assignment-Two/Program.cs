using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_Two
{
    internal class Program
    {
        static string inputReceive(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }   
        
        static void endGame(Game game)
        {
            GameOutput.LeaderboardOutput(game.PlayerList);
            Console.WriteLine("\nGame has ended\n");
            System.Threading.Thread.Sleep(50000);
            return;
        }
        static int numberConvert(string input, string exceptingString)
        {
            try
            {
                string stringInput = inputReceive(input);
                int returnInt = Int32.Parse(stringInput);
                return returnInt;
            }
            catch (FormatException)
            {
                Console.WriteLine(exceptingString);
                return 0;
            }
        }

        static void Main(string[] args)
        {
            GameOutput.StartingGameOutput();
            Game game = new Game();
            // Clear Chat (after 5s)
            System.Threading.Thread.Sleep(5000);
            Console.Clear();

            // Ask how many rounds they have before auto-close.
            int rounds = 0;
            while (rounds < 1 || rounds > 15)
            {
                rounds = numberConvert("How many rounds would you like to play?", "Rounds must be a number.");
            }

            // Ask what the target score is.
            int targetScore = 0;
            while (targetScore < 1 || targetScore > 200)
            {
                targetScore = numberConvert("What is the target score of the game?", "Target score must be a number.");
            }

            game.targetScore = targetScore;
            game.maxRound = rounds;

            // Get who's playing (for loop)
            List<Player> playerList = new List<Player>();

            Console.WriteLine("Please list the name of each player and press enter. After you've finished the final player, enter 'exit'.");

            Player playerInit = new Player(Console.ReadLine());
            playerList.Add(playerInit);

            if (playerList.Count > 0)
            {
                while (playerList[playerList.Count - 1].Name != "exit")
                {
                    Player player = new Player(Console.ReadLine());
                    playerList.Add(player);
                }
            }

            // remove the "exit player"
            playerList.RemoveAt(playerList.Count - 1);

            // sync the game object
            game.PlayerList = playerList;

            // Start Game
            game.gameState = true;
            Console.Clear();
            Die die = new Die();
            while (game.gameState)
            {
                // foreach round:
                for (int i = 0; i < game.maxRound; i++)
                {
                    Console.WriteLine($"\n--------------------\nRound {i+1} out of {game.maxRound}\n--------------------\n");
                    // foreach player:
                    for (int j = 0; j < playerList.Count; j++)
                    {
                        Player player = playerList[j];
                        Console.WriteLine($"Player: {player.Name}\nPlease press ENTER to begin dice throw.");
                        Console.ReadLine();

                        int[] rolls = {0,0,0,0,0};
                        rolls = Die.diceRollFive(rolls);
                        bool twoKind = false;
                        int twoKindNumber = 0;

                        foreach (var number in rolls.GroupBy(x => x))
                        {
                            if (number.Count() == 2)
                            {
                                twoKind = true;
                                twoKindNumber = number.Key;
                            } else if (number.Count() == 3 || number.Count() == 4 || number.Count() == 5)
                            {
                                twoKind = false;
                            }
                        }

                        if (twoKind)
                        {
                            Console.WriteLine("You have a two of a kind ;( Press ENTER to rethrow the remaining dice!");
                            GameOutput.getResponse();
                            int[] rollsTwoKind = {0, 0, 0, 0, 0};
                            for (int k = 0; k < rolls.Length; k++)
                            {
                                if (rolls[k] == twoKindNumber) { rollsTwoKind[k] = twoKindNumber; }
                            }
                            rolls = Die.diceRollFive(rollsTwoKind);
                        }

                        foreach (var number in rolls.GroupBy(x => x))
                        {
                            if (number.Count() == 3) 
                            {
                                player.Score += 3;
                                Console.Write("You scored 3 points!");
                                break;
                            } 
                            else if (number.Count() == 4) 
                            {
                                player.Score += 6;
                                Console.Write("You scored 6 points!");
                                break;
                            }
                            else if (number.Count() == 5) 
                            {
                                player.Score += 12;
                                Console.Write("You scored 12 points!");
                                break;
                            }
                        }
                        if (player.Score >= game.targetScore)
                        {
                            Console.WriteLine("You have won for reaching the target score!");
                            game.gameState = false;
                            endGame(game);
                            return;
                        }
                    }
                }
                game.gameState = false;
            }
            endGame(game);
        }
    }
}
