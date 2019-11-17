namespace CHIP_8_Emulator
{
    public static class Driver
    {
        public static void Main(string[] args)
        {
            Chip8 emulator = new Chip8();
            emulator.Run();
        }
    }
}