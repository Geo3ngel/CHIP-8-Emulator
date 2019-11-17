using System;

namespace src
{
    // Define the opcode as a struct
    struct OpCodeData
    {
        public ushort OpCode;
        public ushort NNN;
        public byte NN, X, Y, N;

        public override string ToString()
        {
            return $"{OpCode:X4} (X: {X:X}, Y: {Y:X}, N: {N:X}, NN: {NN:X2}, NNN: {NNN:X3})";
        }
    }

    public class Chip8
    {
        //Initialization for Chip-8 VM Components

        byte[] registers = new byte[16];
        ushort Program_Counter = 0x200;
        ushort address_register;

        //Timers
        byte delay_timer;
        byte sound_timer;

        Action<int> beep;

        ushort stack_pointer = new ushort[16];

        byte[] ram = new byte[0x1000];

        //Opcodes
        Dictionary<byte, Action<OpCodeData>> opCodes;

        HashSet<byte> pressed_keys = new HashSet<byte>();

        Random random = new Random();

        // Initializes Chip8 Object
        public Chip_8(Action<bool[,]> pixels, Action<int> beep)
        {
            // TODO:  Set up graphics here
            this.beep = beep;

            // TODO: Ensure the font is written out

            // Map Chip-8 opcodes to C# functions that are their equivalent
            opCodes = new Dictionary<byte, Action<OpCodeData>>
            {
                {0x0, clear_or_return},
                {0x1, },
                {0x2, },
                {0x3, },
                {0x4, },
                {0x5, },
                {0x6, },
                {0x7, },
                {0x8, },
                {0x9, },
                {0xA, },
                {0xB, },
                {0xC, },
                {0xD, },
                {0xE, },
                {0xF, run_misc_op}
            };

        }

        // TODO: Load the ROM in here
        public void load_ROM(byte[] data) =>
            // Loads the data from the rom into memory @ the program counter.
            Array.Copy(data, 0, ram, 0x200, data.Length); // TODO: Swap out 0x200 with a constant representing it, since it is the program counter?

        // TODO: Set up fonts?

        // TODO: Step through current process
        // NOTE: Will need to be slowed down, if it runs at the normal processor speed, we will have issues.

        // Hanlde generic inputs to the chip 8 interpreter?
        public void keyDown(byte key)
        {
            pressed_keys.Add(key);
        }

        public void keyUp(byte key)
        {
            pressed_keys.Remove(key);
        }

        public void Tick()
        {
            if (delay_timer > 0)
            {
                delay_timer--;
                // TODO: Add logic for sound timer (Maybe here? Not 100% sure where it goes yet.)
            }


        }

        public void Process_OpCode()
        {
            // Read Opcode in and split it up to struct format
            var opCode = (ushort)(ram[Program_Counter++] << 8 | ram[Program_Counter++]);

            var op_struct = new OpCodeData()
            {
                OpCode = opCode,
                X = (ushort)((opCode & 0x0F00) >> 8),
                Y = (ushort)((opCode & 0x00F0) >> 4),
                N = (ushort)opCode & 0x000F,
                NN = (ushort)opCode & 0x00FF,
                NNN = (ushort)opCode & 0x0FFF,
            };

            opCodes[(byte)(opCode >> 12)](op_struct);
        }

        // TODO: Set up oppcode functions equivalents in C#.
        // NOTE: This is a relatively large, but simple task. We're just defining the opcodes as C# instructions.

        // Activate Miscilanious Opcode
        void run_misc_op(OpCodeData data)
        {
            switch (data.NN)
            {
                case 0x07:
                    set_x_to_delay(data);
                    break;
                case 0x0A:
                    wait_for_key(data);
                    break;
                case 0x15:
                    set_delay(data);
                    break;
                case 0x18:
                    set_sound(data);
                    break;
                case 0x1E:
                    add_x_to_address_register(data);
                    break;
                case 0x29:
                    set_address_register_for_char(data);
                    break;
                case 0x33:
                    binary_coded_demical(data);
                    break;
                case 0x55:
                    save_x(data);
                    break;
                case 0x65:
                    load_x(data);
                    break;

                default:
                    Console.log("ERROR: NO MISC OP_CODE FOR:" + data);
                    break;
            }
        }

        /*
         MISC OPERATIONS:
             */

        private void set_x_to_delay(OpCodeData data)
        {
            registers[data.X] = delay_timer;
        }

        // Will be called repeatedly by the game loop until the desired key is pressed to progress the program counter.
        private void wait_for_key(OpCodeData data)
        {
            if(pressed_keys.Count > 0)
            {
                registers[data.X] = pressed_keys.First();
            }
            else
            {
                Program_Counter -= 2;
            }
        }

        private void set_delay(OpCodeData data)
        {
            delay_timer = registers[data.X];
        }

        private void set_sound(OpCodeData data)
        {
            // TODO: Update this to reflect the proper beeping procedure.
            // beep((int)(registers[data.X] * (1000f / 60)));   #Alternative way of playing it for X seconds?

            // TODO: When this sound_timer is non-zero, play the sound effect in game loop.
            sound_timer = data.X;
        }

        private void add_x_to_address_register(OpCodeData data) { address_register += registers[data.X]; }

        // Sets the address register to the current location of the 'font' sprite for the sepcified character.
        private  void set_address_register_for_char(OpCodeData data) { address_register = (ushort)(registers[data.X] * 5); }

        // Stores a binary decimal into ram
        private void binary_coded_demical(OpCodeData data)
        {
            ram[address_register] = (byte)((registers[data.X]/100)%10);
            ram[address_register+1] = (byte)((registers[data.X]/10)%10);
            ram[address_register+2] = (byte)((registers[data.X])%10);
        }

        // Saves all registers to the address register.
        private void save_x(OpCodeData data)
        {
            for(var i=0; i<= data.X; i++)
            {
                ram[address_register + i] = registers[i];
            }
        }

        // Loads all registers from the address register.
        private void load_x(OpCodeData data)
        {
            for(var i=0; i <= data.X; i++)
            {
                registers[i] = ram[address_register + i];
            }
        }







}
}