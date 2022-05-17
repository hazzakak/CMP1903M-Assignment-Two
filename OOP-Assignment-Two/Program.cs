using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_Two
{
    public class IncorrectInput : Exception
    {
        public IncorrectInput()
        {
        }

        public IncorrectInput(string message)
            : base(message)
        {
        }

        public IncorrectInput(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    class Program
    {
        static string inputReceive(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();
        }   
        
        static Game endGame(Game game)
        {
            GameOutput.LeaderboardOutput(game.PlayerList);
            while (true)
            {
                try
                {
                    Console.WriteLine("\nGame has ended\nWould you like to [P]lay again or [Q]uit?");
                    string response = Console.ReadLine();
                    if (response == "P")
                    {
                        foreach (Player player in game.PlayerList) { player.Score = 0; }
                        game.gameState = true;
                        game.round = 0;
                        break;
                    }
                    else if (response == "Q")
                    {
                        Environment.Exit(0);
                        return game;
                    }
                    else
                    {
                        throw new IncorrectInput("Incorrect Input");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Input is incorrect.");
                }
            }
            return game;
        }

        public static int stringToInt(string input, string exceptingString)
        {
            try
            {
                int returnInt = Int32.Parse(input);
                return returnInt;
            }
            catch (FormatException)
            {
                Console.WriteLine(exceptingString);
                return 0;
            }
        }

        public static int numberConvert(string input, string exceptingString)
        {
            string stringInput = inputReceive(input);
            return stringToInt(stringInput, exceptingString);


        }

        public static int numberConvert(string input)
        {
            try
            {
                string stringInput = inputReceive(input);
                int returnInt = Int32.Parse(stringInput);
                return returnInt;
            }
            catch (FormatException)
            {
                Console.WriteLine("Input must be a number.");
                return 0;
            }
        }

        public static void playGame(Game game)
        {
            SixDie die = new SixDie();
            GameOutput output = new GameOutput();

            while (game.gameState)
            {
                // foreach round:
                for (; game.round < game.maxRound; game.round++)
                {
                    Console.WriteLine($"\n--------------------\nRound {game.round + 1} out of {game.maxRound}\n--------------------\n");
                    // foreach player:
                    for (int j = 0; j < game.PlayerList.Count; j++)
                    {
                        Player player = game.PlayerList[j];
                        Console.WriteLine($"Player: {player.Name}\nPlease press ENTER to begin dice throw.");
                        Console.ReadLine();

                        int[] rolls = { 0, 0, 0, 0, 0 };
                        rolls = die.diceRollFive(rolls);
                        bool twoKind = false;
                        int twoKindNumber = 0;

                        foreach (var number in rolls.GroupBy(x => x))
                        {
                            if (number.Count() == 2)
                            {
                                twoKind = true;
                                twoKindNumber = number.Key;
                            }
                            else if (number.Count() == 3 || number.Count() == 4 || number.Count() == 5)
                            {
                                twoKind = false;
                            }
                        }

                        if (twoKind)
                        {
                            Console.WriteLine("You have a two of a kind ;( Press ENTER to rethrow the remaining dice!");
                            output.getResponse();
                            int[] rollsTwoKind = { 0, 0, 0, 0, 0 };
                            for (int k = 0; k < rolls.Length; k++)
                            {
                                if (rolls[k] == twoKindNumber) { rollsTwoKind[k] = twoKindNumber; }
                            }
                            rolls = die.diceRollFive(rollsTwoKind);
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
                            game = endGame(game);
                            playGame(game);
                        }
                    }
                }
                endGame(game);
            }
        }

        static void Main(string[] args)
        {
            GameOutput.StartingGameOutput();
            Game game = new Game();
            // Clear Chat (after 5s)
            System.Threading.Thread.Sleep(1500);
            Console.Clear();

            // Ask how many rounds they have before auto-close.
            int rounds = 0;
            while (rounds < 1 || rounds > 15)
            {
                rounds = numberConvert("How many rounds would you like to play? 1-15", "Rounds must be a number.");
            }

            // Ask what the target score is.
            int targetScore = 0;
            while (targetScore < 1 || targetScore > 200)
            {
                targetScore = numberConvert("What is the target score of the game? 1-200", "Target score must be a number.");
            }

            game.targetScore = targetScore;
            game.maxRound = rounds;

            // Get who's playing (for loop)
            List<Player> playerList = new List<Player>();

            Console.WriteLine("Please list the name of each player and press enter. After you've finished the final player, enter 'exit'. MUST BE MORE THAN TWO PLAYERS.");

            Player playerInit = new Player(Console.ReadLine());
            playerList.Add(playerInit);

            if (playerList.Count > 0)
            {
                while (playerList.Count < 10)
                {
                    string name = Console.ReadLine();
                    if (name == "exit" && playerList.Count > 1) { break; }
                    Player player = new Player(name);
                    playerList.Add(player);
                }
            }

            if (playerList[0].Name == "developer")
            {
                Test test = new Test();
                test.runTest();
                System.Threading.Thread.Sleep(15000);
            }

            // sync the game object
            game.PlayerList = playerList;

            // Start Game
            game.gameState = true;
            Console.Clear();

            playGame(game);
        }
    }
}
