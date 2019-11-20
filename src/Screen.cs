using System;

namespace CHIP_8_Emulator
{
    public class Screen
    {
        // Initalizes Screen Size variables of the chip 8 device.
        const int _screenWidth = 64, _screenHeight = 32;

        // Array of pixels (Defined as booleans as Chip-8 only uses 2 colors)
        Action<bool[,]> _pixels;

        public Screen()
        {
            _pixels = new bool[_screenWidth, _screenHeight];
        }

        public updatePixel(int x_axis, int y_axis, bool pixel)
        {
            _pixels[x_axis, y_axis] = pixel;
        }
    }
}