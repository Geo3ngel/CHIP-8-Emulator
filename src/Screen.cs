using System;

namespace CHIP_8_Emulator
{
    public class Screen
    {
        // Initalizes Screen Size
        int screen_wdith = 64, screen_height = 32;

        // Array of pixels (Defined as booleans as Chip-8 only uses 2 colors)
        Action<bool[,]> pixels;
    }
}