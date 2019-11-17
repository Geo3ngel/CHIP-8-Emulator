namespace src
{
    public class Screen
    {
        // Initalizes Screen Size variables of the chip 8 device.
        const int screen_wdith = 64, screen_height = 32;

        // Array of pixels (Defined as booleans as Chip-8 only uses 2 colors)
        Action<bool[,]> pixels;

        public Screen()
        {

        }
    }
}