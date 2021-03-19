using iText.Kernel.Geom;

namespace BrokerNote.Model.DTOs
{
    public class RectanglePosition
    {
        private float AxisX { get; set; }
        private float AxisY { get; set; }
        private float Width { get; set; }
        private float Height { get; set; }
        public RectanglePosition(float axisX, float axisY, float width, float height)
        {
            AxisX = axisX;
            AxisY = axisY;
            Width = width;
            Height = height;
        }

        public static Rectangle GetRectangle(RectanglePosition rectanglePositions)
        {
            var rec = new Rectangle(rectanglePositions.AxisX, rectanglePositions.AxisY, rectanglePositions.Width, rectanglePositions.Height);
            return rec;
        }
    }
}
