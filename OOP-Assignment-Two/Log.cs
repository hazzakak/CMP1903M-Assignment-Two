using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_Two
{
    class Log
    {
        public void logStats(Game game)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"/25768493Logs";
            System.IO.Directory.CreateDirectory(path);

            System.IO.File.WriteAllText(path+"/logs"+ DateTime.Now.ToString("yyyy-MM-ddHHmmss")+".txt", $"Players: {game.PlayerList}\nRounds: {game.round}\nTarget Score: {game.targetScore}");

        }
    }
}
