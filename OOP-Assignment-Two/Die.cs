using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_Two
{
    public interface IDie
    {
        int[] diceRollFive(int[] rolls);
    }
    class SixDie : IDie
    {
        private static readonly int max_dice_number = 6;

        public int[] diceRollFive(int[] rolls)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.Clear(); Console.WriteLine($"Rolling... {(rolls[0] == 0 ? rnd.Next(1, max_dice_number+1) : rolls[0])}, {(rolls[1] == 0 ? rnd.Next(1, max_dice_number + 1): rolls[1])}, {(rolls[2] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[2])}, {(rolls[3] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[3])}, {(rolls[4] == 0 ? rnd.Next(1, max_dice_number + 1): rolls[4])}"); System.Threading.Thread.Sleep(400);
            }
            rolls[0] = rolls[0] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[0];
            rolls[1] = rolls[1] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[1];
            rolls[2] = rolls[2] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[2];
            rolls[3] = rolls[3] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[3];
            rolls[4] = rolls[4] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[4];
            Console.Clear(); Console.WriteLine($"Dice landed at... {(rolls[0])}, {(rolls[1])}, {(rolls[2])}, {(rolls[3])}, {(rolls[4])}"); System.Threading.Thread.Sleep(400);
            return rolls;
        }

        public int[] diceRollFive()
        {
            Random rnd = new Random();
            int[] rolls = { rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1) };
            return rolls;
        }

    }

    class TwelveDie : IDie
    {
        private static readonly int max_dice_number = 12;

        public int[] diceRollFive()
        {
            Random rnd = new Random();
            int[] rolls = { rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1), rnd.Next(1, max_dice_number + 1) };
            return rolls;
        }
        public int[] diceRollFive(int[] rolls)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.Clear(); Console.WriteLine($"Rolling... {(rolls[0] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[0])}, {(rolls[1] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[1])}, {(rolls[2] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[2])}, {(rolls[3] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[3])}, {(rolls[4] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[4])}"); System.Threading.Thread.Sleep(400);
            }
            rolls[0] = rolls[0] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[0];
            rolls[1] = rolls[1] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[1];
            rolls[2] = rolls[2] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[2];
            rolls[3] = rolls[3] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[3];
            rolls[4] = rolls[4] == 0 ? rnd.Next(1, max_dice_number + 1) : rolls[4];
            Console.Clear(); Console.WriteLine($"Dice landed at... {(rolls[0])}, {(rolls[1])}, {(rolls[2])}, {(rolls[3])}, {(rolls[4])}"); System.Threading.Thread.Sleep(400);
            return rolls;
        }

    }
}
