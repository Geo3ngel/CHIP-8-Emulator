namespace CHIP_8_Emulator
{
    public class OpCodeData
    {
        public ushort OpCode;
        public ushort NNN;
        public byte NN, X, Y, N;

        public override string ToString()
        {
            return $"{OpCode:X4} (X: {X:X}, Y: {Y:X}, N: {N:X}, NN: {NN:X2}, NNN: {NNN:X3})";
        }
    }
}