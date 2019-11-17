namespace CHIP_8_Emulator
{
    public class OpCode
    {
        public ushort opCode;
        public ushort NNN;
        public ushort NN, X, Y, N;
        
        public OpCode(ushort opCode, ushort X,ushort N, ushort NN, ushort NNN, ushort Y)
        {
            this.opCode = opCode;
            this.X = X;
            this.N = N;
            this.NN = NN;
            this.NNN = NNN;
            this.Y = Y;
        }

        public override string ToString()
        {
            return $"{opCode:X4} (X: {X:X}, Y: {Y:X}, N: {N:X}, NN: {NN:X2}, NNN: {NNN:X3})";
        }
    }
}