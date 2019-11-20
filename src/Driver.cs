using System.Windows.Forms;
using Chip8_GUI.src;

namespace Chip8_GUI.src
{
    public static class Driver
    {
        public static void Main(string[] args)
        {
            PathManager pm = new PathManager();
            ///Screen screen = new Screen();
            //Chip8 emulator = new Chip8(screen);
            //emulator.Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());
        }
    }
}