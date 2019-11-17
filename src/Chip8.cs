using System;
using System.Collections.Generic;
using System.Linq;
using chip8;

namespace CHIP_8_Emulator
{
    public class Chip8
    {
        // CHIP-8 Components
        private ushort _addressRegister;
        private readonly byte[] _registers;
        private ushort _programCounter;
        private ushort[] _stackPointer;
        private readonly byte[] _ram;
        // Timers
        private byte _delayTimer;
        private byte _soundTimer;
        private Action<int> _beep;
        // opCodes
        private Dictionary<byte, Action<OpCode>> _opCodes;
        private readonly HashSet<byte> _pressedKeys;
        private Random _random;
        // Constructor for the Chip class
        public Chip8(/*Action<bool[,]> pixels, Action<int> beep*/)
        {
            // CHIP-8 Components
            _registers = new byte[16];
            _programCounter = 0x200;
            _stackPointer = new ushort[16];
            _ram = new byte[0x1000];
            // Timers
            //this._beep = beep;
            // opCodes
            _pressedKeys = new HashSet<byte>();
            _random = new Random();
        }
        
        // TODO: Load the ROM in here
        public void load_ROM(byte[] data) =>
            // Loads the data from the rom into memory @ the program counter.
            Array.Copy(data, 0, _ram, 0x200, data.Length); // TODO: Swap out 0x200 with a constant representing it, since it is the program counter?

        // TODO: Set up fonts?

        // Stores the current rom's font style in memory
        private void set_up_font()
        {
            var offset = 0x0;
            load_font_char(5 * offset++, Font.D0);
            load_font_char(5 * offset++, Font.D1);
            load_font_char(5 * offset++, Font.D2);
            load_font_char(5 * offset++, Font.D3);
            load_font_char(5 * offset++, Font.D4);
            load_font_char(5 * offset++, Font.D5);
            load_font_char(5 * offset++, Font.D6);
            load_font_char(5 * offset++, Font.D7);
            load_font_char(5 * offset++, Font.D8);
            load_font_char(5 * offset++, Font.D9);
            load_font_char(5 * offset++, Font.DA);
            load_font_char(5 * offset++, Font.DB);
            load_font_char(5 * offset++, Font.DC);
            load_font_char(5 * offset++, Font.DD);
            load_font_char(5 * offset++, Font.DE);
            load_font_char(5 * offset++, Font.DF);
        }

        // Loads a single font char into memory.
        private void load_font_char(int address, long fontData)
        {
            _ram[address + 0] = (byte)((fontData & 0xF000000000) >> (8 * 4));
            _ram[address + 1] = (byte)((fontData & 0x00F0000000) >> (8 * 3));
            _ram[address + 2] = (byte)((fontData & 0x0000F00000) >> (8 * 2));
            _ram[address + 3] = (byte)((fontData & 0x000000F000) >> (8 * 1));
            _ram[address + 4] = (byte)((fontData & 0x00000000F0) >> (8 * 0));
        }

        // TODO: Step through current process
        // NOTE: Will need to be slowed down, if it runs at the normal processor speed, we will have issues.

        // Hanlde generic inputs to the chip 8 interpreter?
        public void keyDown(byte key)
        {
            _pressedKeys.Add(key);
        }

        public void keyUp(byte key)
        {
            _pressedKeys.Remove(key);
        }

        public void Tick()
        {
            if (_delayTimer > 0)
            {
                _delayTimer--;
                // TODO: Add logic for sound timer (Maybe here? Not 100% sure where it goes yet.)
            }
        }
        
        public void Process_OpCode()
        {
            // Read Opcode in and split it up to class format
            var opCode = (ushort)(_ram[_programCounter++] << 8 | _ram[_programCounter++]);

            var code = new OpCode(
                opCode,
                (ushort)((opCode & 0x0F00) >> 8),
                (ushort)((opCode & 0x00F0) >> 4),
                (ushort)((opCode & 0x000F)),
                (ushort)((opCode & 0x00FF)),
                (ushort)((opCode & 0x0FFF))
            );

            _opCodes[(byte)(opCode >> 12)](code);
        }

        // TODO: Set up oppcode functions equivalents in C#.
        // NOTE: This is a relatively large, but simple task. We're just defining the opcodes as C# instructions.

        // Activate Miscilanious Opcode
        private void run_misc_op(OpCode data)
        {
            switch (data.NN)
            {
                case 0x07:
                    get_delay(data);
                    break;
                case 0x0A:
                    get_key(data);
                    break;
                case 0x15:
                    set_delay_timer(data);
                    break;
                case 0x18:
                    set_sound_timer(data);
                    break;
                case 0x1E:
                    add_x_to_address_register(data);
                    break;
                case 0x29:
                    set_address_register_for_char(data);
                    break;
                case 0x33:
                    set_BCD(data);
                    break;
                case 0x55:
                    reg_dump(data);
                    break;
                case 0x65:
                    reg_load(data);
                    break;
                default:
                    Console.WriteLine((string) ("ERROR: NO MISC OP_CODE FOR:" + data));
                    break;
            }
        }

        /*
         MISC OPERATIONS:
        */

        // Sets register to current value of the delay timer
        private void get_delay(OpCode data)
        {
            _registers[data.X] = _delayTimer;
        }

        // Will be called repeatedly by the game loop until the desired key is pressed to progress the program counter.
        private void get_key(OpCode data)
        {
            if (_pressedKeys.Count > 0)
            {
                _registers[data.X] = _pressedKeys.First();
            }
            else
            {
                _programCounter -= 2;
            }
        }

        private void set_delay_timer(OpCode data)
        {
            _delayTimer = _registers[data.X];
        }

        private void set_sound_timer(OpCode data)
        {
            // TODO: Update this to reflect the proper beeping procedure.
            // beep((int)(registers[data.X] * (1000f / 60)));   #Alternative way of playing it for X seconds?

            // TODO: When this sound_timer is non-zero, play the sound effect in game loop.
            _soundTimer = (byte) data.X;
        }

        private void add_x_to_address_register(OpCode data) { _addressRegister += _registers[data.X]; }

        // Sets the address register to the current location of the 'font' sprite for the sepcified character.
        private  void set_address_register_for_char(OpCode data) { _addressRegister = (ushort)(_registers[data.X] * 5); }

        // Stores a binary decimal into ram
        private void set_BCD(OpCode data)
        {
            _ram[_addressRegister] = (byte)((_registers[data.X]/100)%10);
            _ram[_addressRegister+1] = (byte)((_registers[data.X]/10)%10);
            _ram[_addressRegister+2] = (byte)((_registers[data.X])%10);
        }

        // Saves all registers to the address register.
        private void reg_dump(OpCode data)
        {
            for(var i=0; i<= data.X; i++)
            {
                _ram[_addressRegister + i] = _registers[i];
            }
        }

        // Loads all registers from the address register.
        private void reg_load(OpCode data)
        {
            for(var i = 0; i <= data.X; i++)
            {
                _registers[i] = _ram[_addressRegister + i];
            }
        }
        
        // Initialize Chip8.cs object
        public void Run()
        {
            Console.WriteLine("Starting CHIP-8 Emulator");
            // TODO:  Set up graphics here

            // TODO: Ensure the font is written out

            // Map Chip-8 opcodes to C# functions that are their equivalent
//            _opCodes = new Dictionary<byte, Action<OpCode>>
//            {
//                {0x0, clear_or_return},
//                {0x1, },
//                {0x2, },
//                {0x3, },
//                {0x4, },
//                {0x5, },
//                {0x6, },
//                {0x7, },
//                {0x8, },
//                {0x9, },
//                {0xA, },
//                {0xB, },
//                {0xC, },
//                {0xD, },
//                {0xE, },
//                {0xF, run_misc_op}
//            };
        }
    }
}