using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_Two
{
    internal class Die
    {
        private static readonly int max_dice_number = 6;

        public static int[] diceRollFive(int[] rolls)
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

    }
}
