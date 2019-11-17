using System;
using System.Collections.Generic;

namespace CHIP_8_Emulator
{
    public class Chip8
    {
        //Initialization for Chip-8 VM Components

        byte[] registers = new byte[16];

        //Timers
        byte delay;
        byte sound;

        Action<int> beep;

        ushort[] stack_pointer = new ushort[16];

        byte[] ram = new byte[0x1000];

        //Opcodes
        Dictionary<byte, Action<OpCodeData>> opCodes;
        Dictionary<byte, Action<OpCodeData>> opCodesMisc; // TODO: Merge these together?

        HashSet<byte> keys_pressed = new HashSet<byte>();

        Random random = new Random();

        public Chip8(Action<bool[,]> pixels, Action<int> beep)
        {
        TODO: // Set up graphics here
            this.beep = beep;
        }
        
        // This is the runner function for the class 
        public static void Run() {
            Console.WriteLine("Starting CHIP-8 Emulator...");
            Console.WriteLine("Beep boop beep boop beep...");
        }
    }
}