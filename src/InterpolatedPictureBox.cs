using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Chip8_GUI.src
{
    class InterpolatedPictureBox : PictureBox
    {
        // Credit for this graphics showing up fuzzy to sharper display fix to: http://stackoverflow.com/a/13484101/25124
        public InterpolationMode InterpolationMode { get; set; }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(paintEventArgs);
        }
    }
}
