using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_Two
{
    class Test
    {
        private void TestNumberConvert()
        {
            if (Program.stringToInt("120", "Exception Testing") == 120) {
                Console.WriteLine("NUMBERTEST: #1: Successful");
            } else {
                Console.WriteLine("NUMBERTEST: #1: Failed"); 
            }

            if (Program.stringToInt("35.5", "Exception Testing") == 0) {
                Console.WriteLine("NUMBERTEST: #1: Successful");
            } else {
                Console.WriteLine("NUMBERTEST: #1: Failed");
            }
        }

        private void DiceTest()
        {
            SixDie dieOne = new SixDie();
            TwelveDie dieTwo = new TwelveDie();

            int[] testOne = dieOne.diceRollFive();
            int[] testTwo = dieOne.diceRollFive();
            int[] testThree = dieTwo.diceRollFive();
            int[] testFour = dieTwo.diceRollFive();

            if (testOne.Length == 5)
            {
                Console.WriteLine("DICETEST: #1: Successful");
            } else
            {
                Console.WriteLine("DICETEST: #1: Failed");
            }

            if (testOne != testTwo)
            {
                Console.WriteLine("DICETEST: #2: Successful");
            }
            else
            {
                Console.WriteLine("DICETEST: #2: Failed");
            }

            if (testThree.Length == 5)
            {
                Console.WriteLine("DICETEST: #3: Successful");
            }
            else
            {
                Console.WriteLine("DICETEST: #3: Failed");
            }

            if (testThree != testFour)
            {
                Console.WriteLine("DICETEST: #4: Successful");
            }
            else
            {
                Console.WriteLine("DICETEST: #4: Failed");
            }
        }

        public void runTest()
        {
            TestNumberConvert();
            DiceTest();
        }
    }
}
