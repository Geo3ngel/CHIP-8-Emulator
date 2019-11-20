using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chip8_GUI.src
{
    public partial class GUI : Form
    {
        Chip8 chip8;
        Bitmap display;
        Screen screen;

        // TODO: Add in pathing manager component here
        string rom = "C:\\Users\\GeoEn\\Desktop\\Coding\\CHIP-8-Emulator\\games\\Nim.ch8";

        // For timing..
        Stopwatch stopWatch = Stopwatch.StartNew();
        TimeSpan targetElapsedTime60Hz = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60);
        TimeSpan targetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 1000);
        TimeSpan lastTime;

        public GUI()
        {
            InitializeComponent();
            display = new Bitmap(64, 32);
            display_screen.Image = display;

            screen = new Screen();
            chip8 = new Chip8(screen);

            chip8.load_ROM(File.ReadAllBytes(rom));

            KeyDown += SetKeyDown;
            KeyUp += SetKeyUp;

            initMemoryDisplay();
        }

        protected override void OnLoad(EventArgs e)
        {
            StartGameLoop();
        }

        void WriteToDisplay(bool[,] pixels)
        {
            var bits = display.LockBits(new Rectangle(0, 0, display.Width, display.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* pointer = (byte*)bits.Scan0;

                for (var y = 0; y < display.Height; y++)
                {
                    for (var x = 0; x < display.Width; x++)
                    {

                        // TODO: Add color wheel for configuring color scheme?
                        pointer[0] = 0;                                     // Blue
                        pointer[1] = pixels[x, y] ? (byte)0x64 : (byte)0;   // Green
                        pointer[2] = 0;                                     // Red
                        pointer[3] = 255;                                   // Alpha Channel

                        pointer += 4; // 4 bytes per pixel
                    }
                }
            }

            display.UnlockBits(bits);
        }

        void Beep(int milliseconds)
        {
            Console.Beep(500, milliseconds);
        }

        Dictionary<Keys, byte> keyMapping = new Dictionary<Keys, byte>
        {
            { Keys.D1, 0x1 },
            { Keys.D2, 0x2 },
            { Keys.D3, 0x3 },
            { Keys.D4, 0xC },
            { Keys.Q, 0x4 },
            { Keys.W, 0x5 },
            { Keys.E, 0x6 },
            { Keys.R, 0xD },
            { Keys.A, 0x7 },
            { Keys.S, 0x8 },
            { Keys.D, 0x9 },
            { Keys.F, 0xE },
            { Keys.Z, 0xA },
            { Keys.X, 0x0 },
            { Keys.C, 0xB },
            { Keys.V, 0xF },
        };

        void SetKeyDown(object sender, KeyEventArgs e)
        {
            if (keyMapping.ContainsKey(e.KeyCode))
                chip8.keyDown(keyMapping[e.KeyCode]);
        }

        void SetKeyUp(object sender, KeyEventArgs e)
        {
            if (keyMapping.ContainsKey(e.KeyCode))
                chip8.keyUp(keyMapping[e.KeyCode]);
        }

        void StartGameLoop()
        {
            Task T = Task.Factory.StartNew(Run_Loop);
        }

        Task Run_Loop()
        {
            while (true)
            {
                var currentTime = stopWatch.Elapsed;
                var elapsedTime = currentTime - lastTime;

                while (elapsedTime >= targetElapsedTime60Hz)
                {
                    this.Invoke((Action)rom_tick);
                    elapsedTime -= targetElapsedTime60Hz;
                    lastTime += targetElapsedTime60Hz;
                }

                chip8.Process_OpCode();
                displayMemory();
                Thread.Sleep(targetElapsedTime);
            }
        }

        //void load_next_OpCode() => chip8.Process_OpCode();
        
        void rom_tick()
        {
            // Count for game timers
            chip8.Tick();

            // Update Graphics here based on "Screen"
            WriteToDisplay(screen.getDisplay());
            display_screen.Refresh();
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        // Sets up the Memory Display with the proper amount of items.
        private void initMemoryDisplay()
        {
            // Sets up the ram list box.
            for(int i = 0; i < chip8.get_ram().Length; i++)
                RamView.Items.Add("0x0");

            // Sets up view for registers.
            for (int i = 0; i < chip8.get_registers().Length; i++)
                RegistersView.Items.Add("0x0");
        }

        // Writes memory from current Chip8 instance to a visualized display.
        // TODO: Change to be an ON SIGNALED EVENT???
        private void displayMemory()
        {
            byte[] ram = chip8.get_ram();
            byte[] registers = chip8.get_registers();

            // Updates Ram Display
            Invoke(new Action(() => {
                for(int i = 0; i < ram.Length; i++)
                {
                    if (!Equals(RamView.Items[i], ram[i].ToString("x")))
                    {
                        RamView.Items[i] = ram[i].ToString("x");
                    }
                }
            }));

            // Updates Register display
            Invoke(new Action(() => {
                for (int i = 0; i < registers.Length; i++)
                {
                    if (Equals(RegistersView.Items[i], ram[i].ToString("x")))
                    {
                        RegistersView.Items[i] = ram[i].ToString("x");
                    }
                }
            }));

            // Updates Registers Display

            // Updates Program Counter Display

            // etc...

        }

    }
}
