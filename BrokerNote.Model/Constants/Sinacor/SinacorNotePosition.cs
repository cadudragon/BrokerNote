using BrokerNote.Model.DTOs;
using iText.Kernel.Geom;

namespace BrokerNote.Model.Constants.Sinacor
{
    public static class SinacorNotePosition
    {
        /// <summary>
        ///  Rectangle equivalent to broker name
        /// </summary>
        public static RectanglePosition BrokerNameRectangle =>
         new RectanglePosition(1, 750, 800, 20);

        /// <summary>
        ///  Rectangle equivalent to date that negotiation ocorrud
        /// </summary>
        public static RectanglePosition NegotiationDate =>
            new RectanglePosition(500, 760, 490, 20);

        public static Rectangle GetRectangle(RectanglePosition rectanglePositions)
        {
            var rec = RectanglePosition.GetRectangle(rectanglePositions);
            return rec;
        }

        public sealed class NegotiationColumnsPosition
        {
            public static RectanglePosition OperationTypeColumn =>
                new RectanglePosition(100, 385, 7, 200);
            public static RectanglePosition StockNameColumn =>
                new RectanglePosition(195, 385, 100, 200);
            public static RectanglePosition StockAmountColumn =>
                 new RectanglePosition(320, 385, 100, 200);
            public static RectanglePosition StockPriceColumn =>
                 new RectanglePosition(380, 385, 100, 200);

        }
    }
}
