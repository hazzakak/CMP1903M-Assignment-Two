using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_Two
{
    class Player
    {
        private string name;
        public string Name {
            get { return name; } 
            set { name = value; }
        }

        int score;
        public int Score
        {
            get { return score; }
            set { score = score + value; }
        }

        public Player(string InputName)
        {
            name = InputName;
        }

        
    }
}
