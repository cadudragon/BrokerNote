using BrokerNote.Model.DTOs;
using iText.Kernel.Geom;

namespace BrokerNote.Model.Constants.Sinacor
{
    public static class SinacorNotePositions
    {
        public static RectanglePositions BrokerNameRectangle =>
         new RectanglePositions { AxisX = 1, AxisY = 750, Width = 800, Height = 20 };

        public static Rectangle GetRectangle(RectanglePositions rectanglePositions)
        {
            var rec = new Rectangle(rectanglePositions.AxisX, rectanglePositions.AxisY, rectanglePositions.Width, rectanglePositions.Height);
            return rec;
        }
    }
}
