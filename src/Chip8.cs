using System;
using System.Collections.Generic;
using System.Linq;

namespace Chip8_GUI.src
{
    struct OpCodeStruct
    {
        public ushort OpCode;
        public ushort NNN;
        public byte NN, X, Y, N;
    }

    public class Chip8
    {
        // CHIP-8 VM Components
        private ushort _addressCounter;
        private readonly byte[] _registers;
        private ushort _programCounter;
        private byte _stackPointer;
        private ushort[] _stack = new ushort[16];
        private readonly byte[] _ram;

        // Timers
        private byte _delayTimer;
        private byte _soundTimer;
        private Action<int> _beep;

        // opCodes
        private Dictionary<byte, Action<OpCodeStruct>> _opCodes;
        private readonly HashSet<byte> _pressedKeys;
        private Random _random;

        const int _screenWidth = 64, _screenHeight = 32;
        private Screen _screen;

        // Constructor for the Chip class
        public Chip8(Screen screen/*, Action<int> beep*/)
        {
            // CHIP-8 Components
            _registers = new byte[16];
            _programCounter = 0x200;
            _addressCounter = 0x200;
            _stack = new ushort[16];
            _stackPointer = 0;
            _ram = new byte[0x1000];

            _screen = screen;
            // Timers
            //this._beep = beep;

            _pressedKeys = new HashSet<byte>();
            _random = new Random();

            // Define Opcode Dict.
            _opCodes = new Dictionary<byte, Action<OpCodeStruct>>
            {
               {0x0, clear_or_return},
               {0x1, jump_to_NNN},
               {0x2, call_subroutine_NNN},
               {0x3, skip_if_X_equals_NN},
               {0x4, skip_if_X_not_equal_NN},
               {0x5, skip_if_X_equals_Y},
               {0x6, set_X},
               {0x7, add_X},
               {0x8, math_operation},
               {0x9, skip_if_X_not_equals_Y},
               {0xA, set_adress_counter},
               {0xB, jump_offset_by_NNN},
               {0xC, set_X_rand},
               {0xD, draw_sprite},
               {0xE, skip_on_key},
               {0xF, run_misc_op}
            };

            // Loads the Fonts from the rom into memory
            set_up_font();

           Console.WriteLine("CHIP-8 Emulator Initialized");
        }
        public void load_ROM(byte[] data) =>
            // Loads the data from the rom into memory @ the program counter.
            Array.Copy(data, 0, _ram, 0x200, data.Length);

        // Stack Functions:

        private void push(ushort value) {
            _stack[_stackPointer++] = value;
        }

        private ushort pop()
        {
            return _stack[--_stackPointer];
        }


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

        // Hanlde generic inputs to the chip 8 interpreter?
        public void keyDown(byte key)
        {
            _pressedKeys.Add(key);
        }

        public void keyUp(byte key)
        {
            _pressedKeys.Remove(key);
        }

        // Advances the timers
        public void Tick()
        {
            if (_delayTimer > 0)
            {
                _delayTimer--;
                // TODO: Add logic for sound timer (Maybe here? Not 100% sure where it goes yet.)
            }

            if (_soundTimer > 0)
            {
                // TODO: Signal sound to continue playing/start playing
                _soundTimer--;
                // TODO: Check if sound is 0 or less, then signal sound to cease
            }
        }
        
        public void Process_OpCode()
        {
            // Fetches OpCode
            var opCode = (ushort)(_ram[_programCounter++] << 8 | _ram[_programCounter++]);

            // Decodes the OpCode
            var code = new OpCodeStruct()
            {
                OpCode = opCode,
                NNN = (ushort)(opCode & 0x0FFF),
                NN = (byte)(opCode & 0x00FF),
                N = (byte)(opCode & 0x000F),
                X = (byte)((opCode & 0x0F00) >> 8),
                Y = (byte)((opCode & 0x00F0) >> 4),
            };

            // Excecutes the OpCode
            _opCodes[(byte)(opCode >> 12)](code);
        }

        // Activate Miscilanious Opcode
        private void run_misc_op(OpCodeStruct data)
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
        private void get_delay(OpCodeStruct data)
        {
            _registers[data.X] = _delayTimer;
        }

        // Will be called repeatedly by the game loop until the desired key is pressed to progress the program counter.
        private void get_key(OpCodeStruct data)
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

        private void set_delay_timer(OpCodeStruct data)
        {
            _delayTimer = _registers[data.X];
        }

        private void set_sound_timer(OpCodeStruct data)
        {
            // TODO: Update this to reflect the proper beeping procedure.
            // beep((int)(registers[data.X] * (1000f / 60)));   #Alternative way of playing it for X seconds?

            // TODO: When this sound_timer is non-zero, play the sound effect in game loop.
            _soundTimer = (byte) data.X;
        }

        private void add_x_to_address_register(OpCodeStruct data) { _addressCounter += _registers[data.X]; }

        // Sets the address register to the current location of the 'font' sprite for the sepcified character.
        private  void set_address_register_for_char(OpCodeStruct data) { _addressCounter = (ushort)(_registers[data.X] * 5); }

        // Stores a binary decimal into ram
        private void set_BCD(OpCodeStruct data)
        {
            _ram[_addressCounter] = (byte)((_registers[data.X]/100)%10);
            _ram[_addressCounter+1] = (byte)((_registers[data.X]/10)%10);
            _ram[_addressCounter+2] = (byte)((_registers[data.X])%10);
        }

        // Saves all registers to the address register.
        private void reg_dump(OpCodeStruct data)
        {
            for(var i=0; i<= data.X; i++)
            {
                _ram[_addressCounter + i] = _registers[i];
            }
        }

        // Loads all registers from the address register.
        private void reg_load(OpCodeStruct data)
        {
            for(var i = 0; i <= data.X; i++)
            {
                _registers[i] = _ram[_addressCounter + i];
            }
        }

        /*
         OPCODE FUNCTIONS:
             */

        private void clear_or_return(OpCodeStruct data){
            // Clears screen
            if (data.NN == 0xE0){
                _screen.clear();
            }
            // Returns subroutine from the stack
            else if(data.NN == 0xEE){
                _programCounter = pop();
            }
        }

        // Jumps to the localtion specified in the current OpCode's nnn byte.
        private void jump_to_NNN(OpCodeStruct data){
            _programCounter = data.NNN;
        }

        // Jumps to the subroutine
        private void call_subroutine_NNN(OpCodeStruct data){
            // Push the current Program counter onto the stack

            push(_programCounter);
            // Changes program counter to target the subroutine.
            _programCounter = data.NNN;
            Console.WriteLine("Data Value: {0}", data.NNN);
        }

        private void skip_if_X_equals_NN(OpCodeStruct data){
            if(_registers[data.X] == data.NN)
            {
                skip_instruction();
            }
        }

        private void skip_if_X_not_equal_NN(OpCodeStruct data){
            if(_registers[data.X] != data.NN)
            {
                skip_instruction();
            }
        }

        private void skip_if_X_equals_Y(OpCodeStruct data){
            if (_registers[data.X] == _registers[data.Y])
            {   
                skip_instruction();
            }
        }

        private void set_X(OpCodeStruct data){
            _registers[data.X] = data.NN;
        }

        private void add_X(OpCodeStruct data){
            try
            {
                _registers[data.X] += data.NN;
            }
            catch(OverflowException)
            {
                Console.WriteLine("OVERFLOW EXCEPTION: {0} > Size of Register space allocated.", data.X);
            }
        }

        private void math_operation(OpCodeStruct data){
            // Use the opcode's N byte to determine which mathematic operation to perform with X & Y.
            switch (data.N)
            {
                case 0x0:   //Assign: Set X to Y
                    _registers[data.X] = _registers[data.Y];
                    break;
                case 0x1:   // BitOp: Set X = X | Y (bitwise OR)
                    _registers[data.X] |= _registers[data.Y];
                    break;
                case 0x2:   // BitOp: Sets X = X & Y (bitwise AND)
                    _registers[data.X] &= _registers[data.Y];
                    break;
                case 0x3:   // BitOP: Sets X = X xor Y
                    _registers[data.X] ^= _registers[data.Y];
                    break;
                case 0x4:   // Math: Sets X += Y
                    _registers[0xF] = (byte)(_registers[data.X] + _registers[data.Y] > 0xFF ? 1 : 0);
                    _registers[data.X] += _registers[data.Y];
                    break;
                case 0x5:   // Math: X -= Y
                    _registers[0xF] = (byte)(_registers[data.X] > _registers[data.Y] ? 1 : 0);
                    _registers[data.X] -= _registers[data.Y];
                    break;
                case 0x6:   // BitOp: Stores the least significant bit of the value of register position X at position 0xF in ram, then shifts value of register @ position X to the right by 1. 
                    _registers[0xF] = (byte)((_registers[data.X] & 0x1) != 0 ? 1 : 0);
                    _registers[data.X] /= 2; // Bit shift right.
                    break;
                case 0x7:   //Math: X = Y - X
                    _registers[0xF] = (byte)(_registers[data.Y] > _registers[data.X] ? 1 : 0);
                    _registers[data.Y] -= _registers[data.X];
                    break;
                case 0xE:   // BitOp: Stores the least significant bit of the value of register position X at position 0xF in ram, then shifts value of register @ position X to the left by 1. 
                    _registers[0xF] = (byte)((_registers[data.X] & 0xF) != 0 ? 1 : 0);
                    _registers[data.X] *= 2; // Bit shift left.
                    break;
                default:
                    Console.WriteLine("ERROR: No valid Math Operation for case: {0}", data.N);
                    break;
            }
        }

        private void skip_if_X_not_equals_Y(OpCodeStruct data){
            if (_registers[data.X] != _registers[data.Y])
            {
                skip_instruction();
            }
        }

        private void set_adress_counter(OpCodeStruct data){
            _addressCounter = data.NNN;
        }

        // Just to the value in the register offset by NNN value 
        private void jump_offset_by_NNN(OpCodeStruct data){
            _programCounter = (ushort)(_registers[0] + data.NNN);
        }

        // &s a random integer between 0 and 256with NN
        private void set_X_rand(OpCodeStruct data){
            _registers[data.X] = (byte)(_random.Next(0, 256) & data.NN);
        }

        // Draws a specified sprite to the 'Screen' Object.
        private void draw_sprite(OpCodeStruct data){
            var spriteX = _registers[data.X];
            var spriteY = _registers[data.Y];

            // Write any pending clears
            _screen.writePendingClears();

            // Clears the significant bit storage register.
            _registers[0xF] = 0;

            for (int i = 0; i < data.N; i++)
            {
                // Selects line of the sprite to render
                var spriteLine = _ram[_addressCounter + i];

                for (var bit = 0; bit < 8; bit++)
                {
                    int x_axis = (spriteX + bit) % _screenWidth;
                    int y_axis = (spriteY + i) % _screenHeight;

                    var spriteBit = ((spriteLine >> (7 - bit)) & 1);
                    var oldBit = _screen.getPixel(x_axis, y_axis) ? 1 : 0;

                    if (oldBit != spriteBit)
                        _screen.setUpdateNeeded();

                    // New bit is XOR of existing and new.
                    var newBit = oldBit ^ spriteBit;

                    if (newBit != 0)
                        _screen.setPixel(x_axis, y_axis);
                    else // Otherwise write a pending clear
                        _screen.setPendingClear(x_axis, y_axis);

                    // If we wiped out a pixel, set flag for collission.
                    if (oldBit != 0 && newBit == 0)
                        _registers[0xF] = 1;
                }
            }
        }

        // Skips the next instruction if a certain key is pressed.
        private void skip_on_key(OpCodeStruct data){
            if ((if_key_pressed(data) && _pressedKeys.Contains(_registers[data.X])) || (!if_key_pressed(data) && !_pressedKeys.Contains(_registers[data.X])))
            {
                skip_instruction();
            }
        }

        private bool if_key_pressed(OpCodeStruct data)
        {
            bool key_pressed;
            if (data.NN == 0x9E)
            {
                key_pressed = true;
            }
            else if(data.NN == 0xA1)
            {
                key_pressed = false;
            }
            else
            {
                key_pressed = false;
                Console.WriteLine("ERROR: Key not pressed, but received unexpected value.");
            }

            return key_pressed;
        }

        private void skip_instruction()
        {
            _programCounter += 2;
        }

        /*
         Getters for Visualization
         */

        public byte[] get_ram()
        {
            return _ram;
        }

        public byte[] get_registers()
        {
            return _registers;
        }

        public ushort get_pc()
        {
            return _programCounter;
        }

        public ushort get_address_counter()
        {
            return _addressCounter;
        }

        public byte get_stack_pointer()
        {
            return _stackPointer;
        }

        public ushort[] get_stack()
        {
            return _stack;
        }
    }
}