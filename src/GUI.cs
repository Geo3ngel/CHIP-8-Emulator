﻿using System;
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
        private int stepper_break;
        private PathManager pathManager;

        // For Background/Foreground colors
        byte foreground_color_r;
        byte foreground_color_g;
        byte foreground_color_b;

        byte background_color_r;
        byte background_color_g;
        byte background_color_b;

        // For timing..
        Stopwatch stopWatch = Stopwatch.StartNew();
        static long tps_mod = (long)1;
        TimeSpan targetElapsedTime60Hz = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60);
        TimeSpan targetElapsedTime = TimeSpan.FromTicks((TimeSpan.TicksPerSecond * tps_mod )/ 1000);
        TimeSpan lastTime;

        // Game loop instance
        Task run_game;
        CancellationTokenSource token_source;
        CancellationToken cancel_token;

        public GUI()
        {
            InitializeComponent();
            display = new Bitmap(64, 32);
            display_screen.Image = display;

            screen = new Screen();
            chip8 = new Chip8(screen, displayOpCodeTranslation, updateAddressCounter, updateStackCounter, updateProgramCounter, updateStack, updateRegisters, updateRam);

            // Sets up pathing manager
            pathManager = new PathManager();

            // Load Roms from the games directory
            load_roms();

            KeyDown += SetKeyDown;
            KeyUp += SetKeyUp;

            stepper_break = 0;
            initMemoryDisplay();
            init_colors();

            // Sets up GUI compoent's intial states for loading ROMs.
            start_rom.Enabled = false;
            quit_rom.Enabled = false;
        }

        private void init_colors()
        {
            foreground_color_r = 0x0;
            foreground_color_g = 0x64;
            foreground_color_b = 0x0;

            background_color_r = 0x0;
            background_color_g = 0x0;
            background_color_b = 0x0;
        }

        // Loads the roms from the games directory into the romSelect ComboBox as options.
        private void load_roms()
        {
            foreach(string gameName in pathManager.get_games())
            {
                romSelect.Items.Add(gameName);
            }
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

                        pointer[0] = pixels[x, y] ? foreground_color_b : background_color_b;   // Blue
                        pointer[1] = pixels[x, y] ? foreground_color_g : background_color_g;   // Green
                        pointer[2] = pixels[x, y] ? foreground_color_r : background_color_r;   // Red
                        pointer[3] = 255;                                   // Alpha Channel

                        pointer += 4; // 4 bytes per pixel
                    }
                }
            }

            display.UnlockBits(bits);
        }

        /*
         Keypad/Input
         */

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
            { Keys.V, 0xF }
        };

        void SetKeyDown(object sender, KeyEventArgs e)
        {
            if (keyMapping.ContainsKey(e.KeyCode))
            {
                chip8.keyDown(keyMapping[e.KeyCode]);
                setKeypad(e, false);
            }
        }

        void SetKeyUp(object sender, KeyEventArgs e)
        {
            if (keyMapping.ContainsKey(e.KeyCode))
            {
                chip8.keyUp(keyMapping[e.KeyCode]);
                setKeypad(e, true);
            }
        }

        // Sets the relevant keypad to disabled/enabled to show it is being pressed.
        private void setKeypad(KeyEventArgs e, bool enable)
        {
            switch (keyMapping[e.KeyCode])
            {
                case 0x0:
                    keypad0.Enabled = enable;
                    break;
                case 0x1:
                    keypad1.Enabled = enable;
                    break;
                case 0x2:
                    keypad2.Enabled = enable;
                    break;
                case 0x3:
                    keypad3.Enabled = enable;
                    break;
                case 0x4:
                    keypad4.Enabled = enable;
                    break;
                case 0x5:
                    keypad5.Enabled = enable;
                    break;
                case 0x6:
                    keypad6.Enabled = enable;
                    break;
                case 0x7:
                    keypad7.Enabled = enable;
                    break;
                case 0x8:
                    keypad8.Enabled = enable;
                    break;
                case 0x9:
                    keypad9.Enabled = enable;
                    break;
                case 0xA:
                    keypadA.Enabled = enable;
                    break;
                case 0xB:
                    keypadB.Enabled = enable;
                    break;
                case 0xC:
                    keypadC.Enabled = enable;
                    break;
                case 0xD:
                    keypadD.Enabled = enable;
                    break;
                case 0xE:
                    keypadE.Enabled = enable;
                    break;
                case 0xF:
                    keypadF.Enabled = enable;
                    break;
            }
        }

        /*
         Game Looping Logic
         */

        void StartGameLoop()
        {
            token_source = new CancellationTokenSource();
            cancel_token = token_source.Token;
            run_game = Task.Factory.StartNew(Run_Loop, cancel_token);
        }

        Task Run_Loop()
        {
            // Cancelation token for cleaning up the Task when quiting a game.
            var capturedToken = cancel_token;

            while (!cancel_token.IsCancellationRequested)
            {
                while (stepperMode.Checked)
                {
                    // Waits for more steps
                    if (stepper_break > 0)
                    {
                        stepper_break--;
                        break;
                    }
                        
                }

                var elapsedTime = stopWatch.Elapsed - lastTime;

                while (elapsedTime >= targetElapsedTime60Hz)
                {
                    this.Invoke((Action)rom_tick);
                    elapsedTime -= targetElapsedTime60Hz;
                    lastTime += targetElapsedTime60Hz;
                }

                this.Invoke((Action)load_next_OpCode); 

                Thread.Sleep(targetElapsedTime);
            }

            return null;
        }

        void load_next_OpCode() => chip8.Process_OpCode();
        
        void rom_tick()
        {
            // Count for game timers
            chip8.Tick();

            // Update Graphics here based on "Screen"
            if (screen.needUpdate())
            {
                WriteToDisplay(screen.getDisplay());
                display_screen.Refresh();
            }
            
        }


        // Sets up the Memory Display with the proper amount of items.
        private void initMemoryDisplay()
        {
            // Sets up the ram list box.
            for(int i = 0; i < chip8.get_ram_length(); i++)
                RamView.Items.Add(i+": 0x0");

            // Sets up view for registers.
            for (int i = 0; i < chip8.get_registers_length(); i++)
                RegistersView.Items.Add(i + ": 0x0");

            // Initialize program counter
            ProgramCounterView.Items.Add("0");

            // Initialize address counter
            AddressCounterView.Items.Add("0");

            // Initialize Stack
            for (int i = 0; i < chip8.get_stack_length(); i++)
                StackView.Items.Add(i + ": 0x0");

            // Initialize Stack Pointer
            StackPointerView.Items.Add("0");

        }

        // Updates the address counter display
        public void updateAddressCounter(ushort address_counter)
        {
            Invoke(new Action(() => {
                AddressCounterView.Items[0] = address_counter.ToString();
            }));
        }

        public void updateStackCounter(byte stack_pointer)
        {
            // Update Stack Pointer Display
            // TODO: Just make it highlight the currently selected index of the stack?
            Invoke(new Action(() => {
                StackPointerView.Items[0] = stack_pointer.ToString("x");
            }));
        }

        public void updateProgramCounter(ushort program_counter)
        {
            // Updates Program Counter View Display
            Invoke(new Action(() => {
                ProgramCounterView.Items[0] = program_counter.ToString();
            }));
        }

        public void updateStack(int index, ushort val)
        {
            //Update Stack
            Invoke(new Action(() => {
                StackView.Items[index] = index + ": 0x" + val.ToString();
            }));
        }

        public void updateRegisters(int index, byte val)
        {
            // Updates Register display
            Invoke(new Action(() => {
                RegistersView.Items[index] = index + ": 0x" + val.ToString("x");
            }));
        }

        public void updateRam(int index, byte val)
        {
            // Updates Ram Display
            Invoke(new Action(() => {
                RamView.Items[index] = index + ": 0x" + val.ToString("x");
            }));
        }

        // Outputs the current Opcode data, and the function it has been translated to.
        public void displayOpCodeTranslation(OpCodeStruct data, string translation)
        {
            if (displayTranslation.Checked)
            {
                Invoke(new Action(() => { TranslationOutput.Items.Add(data.ToString() + " => " + translation); }));
            }
           
        }

            /*
             Stepper Button functions
             */

        private void Step1_Click(object sender, EventArgs e)
        {
            stepper_break += 1;
        }

        private void Step5_Click(object sender, EventArgs e)
        {
            stepper_break += 5;
        }

        private void Step10_Click(object sender, EventArgs e)
        {
            stepper_break += 10;
        }

        private void Step100_Click(object sender, EventArgs e)
        {
            stepper_break += 100;
        }

        private void Step1000_Click(object sender, EventArgs e)
        {
            stepper_break += 1000;
        }

        private void StepperMode_CheckedChanged(object sender, EventArgs e)
        {
            if (stepperMode.Checked)
            {
                // Enable the Stepper buttons
                step1.Enabled = true;
                step5.Enabled = true;
                step10.Enabled = true;
                step100.Enabled = true;
                step1000.Enabled = true;
            }
            else
            {
                // Disable the Stepper buttons
                step1.Enabled = false;
                step5.Enabled = false;
                step10.Enabled = false;
                step100.Enabled = false;
                step1000.Enabled = false;
            }
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            tps_mod = speedBar.Value/1000;
            // The amount of time that passes for each tick to occur
            targetElapsedTime = TimeSpan.FromTicks((TimeSpan.TicksPerSecond * tps_mod) / 1000);
        }

        // Loads the Rom & starts the game
        private void RomSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable Start Button
            start_rom.Enabled = true;
        }

        private void Foreground_btn_Click(object sender, EventArgs e)
        {
            foreground_color_dialog.ShowDialog();
            foreground_color_tb.BackColor = foreground_color_dialog.Color;

            foreground_color_r = foreground_color_dialog.Color.R;
            foreground_color_g = foreground_color_dialog.Color.G;
            foreground_color_b = foreground_color_dialog.Color.B;
        }

        private void Background_btn_Click(object sender, EventArgs e)
        {
            background_color_dialog.ShowDialog();
            background_color_tb.BackColor = background_color_dialog.Color;

            background_color_r = background_color_dialog.Color.R;
            background_color_g = background_color_dialog.Color.G;
            background_color_b = background_color_dialog.Color.B;
        }

        private void Start_rom_Click(object sender, EventArgs e)
        {
            string romPath = pathManager.get_game_path(romSelect.SelectedItem.ToString());
            chip8.load_ROM(File.ReadAllBytes(romPath));

            // Deselect Combo box
            romSelect.Enabled = false;
            start_rom.Enabled = false;
            quit_rom.Enabled = true;

            // Start the Emulator
            StartGameLoop();
        }

        private void Quit_rom_Click(object sender, EventArgs e)
        {
            quit_rom.Enabled = false;
            romSelect.Enabled = true;
            start_rom.Enabled = true;

            token_source.Cancel();

            token_source.Dispose();

            // Resets the Screen
            screen.clear();
            screen = new Screen();

            TranslationOutput.Items.Clear();

            chip8 = new Chip8(screen, displayOpCodeTranslation, updateAddressCounter, updateStackCounter, updateProgramCounter, updateStack, updateRegisters, updateRam);

            WriteToDisplay(screen.getDisplay());

            System.GC.Collect();
            // TODO: Clean up timers?
        }
    }
}
