using iText.Kernel.Geom;

namespace BrokerNote.Model.DTOs
{
    public class RectanglePositions
    {
        public float AxisX { get; set; }
        public float AxisY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public static Rectangle GetRectangle(RectanglePositions rectanglePositions)
        {
            var rec = new Rectangle(rectanglePositions.AxisX, rectanglePositions.AxisY, rectanglePositions.Width, rectanglePositions.Height);
            return rec;
        }
    }
}
