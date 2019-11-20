using System;
using System.IO;

namespace CHIP_8_Emulator
{
    public class PathManager
    {
        private string root_project_path;

        public PathManager()
        {
            root_project_path = "";
            Console.WriteLine("ROOT: {0}", root_project_path);
        }

    }
}