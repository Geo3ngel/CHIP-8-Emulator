using System;

namespace Chip8_GUI.src
{
    public class Screen
    {
        // Initalizes Screen Size variables of the chip 8 device.
        const int _screenWidth = 64, _screenHeight = 32;

        // Array of pixels (Defined as booleans as Chip-8 only uses 2 colors)
        private bool[,] _pixels;
        
        // Used to help prevent flickering by delaying clearing pixels by a single frame.
        private bool[,] _toClearBuffer;

        private bool update;

        public Screen()
        {
            _pixels = new bool[_screenWidth, _screenHeight];
            _toClearBuffer = new bool[_screenWidth, _screenHeight];
            update = true;
        }

        public void updatePixel(int x_axis, int y_axis, bool pixel)
        {
            _pixels[x_axis, y_axis] = pixel;
        }

        public void clear()
        {
            for (var x_axis = 0; x_axis < _screenWidth; x_axis++)
            {
                for (int y_axis = 0; y_axis < _screenHeight; y_axis++)
                {
                    // "Cleared" screen refers to an array of all false values.
                    _pixels[x_axis, y_axis] = false;
                }
            }
        }

        // Clears specific pixels from the clear buffer.
        public void writePendingClears()
        {
            for (var x_axis = 0; x_axis < _screenWidth; x_axis++)
            {
                for (int y_axis = 0; y_axis < _screenHeight; y_axis++)
                {
                    if (_toClearBuffer[x_axis, y_axis])
                    {
                        update = true;
                    }

                    _toClearBuffer[x_axis, y_axis] = false;
                    _pixels[x_axis, y_axis] = false;
                }
            }
        }

        public void setPixel(int x_axis, int y_axis)
        {
            _pixels[x_axis, y_axis] = true;
        }

        public void setPendingClear(int x_axis, int y_axis)
        {
            _toClearBuffer[x_axis, y_axis] = true;
        }

        public bool getPixel(int x_axis, int y_axis)
        {
            return _pixels[x_axis, y_axis];
        }

        public void setUpdateNeeded()
        {
            update = true;
        }

        public bool[,] getDisplay()
        {
            return _pixels;
        }
    }
}