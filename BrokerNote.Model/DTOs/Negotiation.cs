using BrokerNote.Model.Enums;

namespace BrokerNote.Model.DTOs
{
    public class Negotiation
    {
        public string StockName { get; set; }
        public string BrokerName { get; set; }
        public int Amount { get; set; }
        public NegotiationType NegotiationType { get; set; }
        public decimal UnitaryPrice { get; set; }
        public decimal TotalValue
        {
            get
            {
                return UnitaryPrice * Amount;
            }
        }
    }
}
