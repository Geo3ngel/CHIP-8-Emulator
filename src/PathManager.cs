using System;
using System.IO;

namespace Chip8_GUI.src
{
    public class PathManager
    {
        private string root_project_path;
        private string games_path;

        public PathManager()
        {
            // Initializes the root path to the project directory.
            root_project_path = "..\\..\\";
            Console.WriteLine("ROOT: {0}", Path.GetFullPath(root_project_path));

            games_path = init_game_path();
            Console.WriteLine("Games dir: {0}", Path.GetFullPath(games_path));
        }

        private string init_game_path()
        {
            // TODO: Verify this path is still valid, if not, create a "games" directory
            return Path.Combine(root_project_path, "games");
        }

        public string[] get_games()
        {
            string[] games = Directory.GetFiles(games_path);
            string[] results = new string[games.Length];

            for(int i = 0; i < games.Length; i++)
            {
                results[i] = Path.GetFileName(games[i]);
            }

            return results;
        }

        public string get_game_path(string game)
        {
            return Path.Combine(games_path, game);
        }

    }
}