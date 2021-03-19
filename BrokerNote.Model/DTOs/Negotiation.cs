using BrokerNote.Model.Enums;
using System;

namespace BrokerNote.Model.DTOs
{
    public class Negotiation
    {
        public string StockName { get; set; }
        public string BrokerName { get; set; }
        public int Amount { get; set; }
        public OperationType OperationType { get; set; }
        public decimal UnitaryPrice { get; set; }
        public DateTime NegotiationDate { get; set; }
        public decimal TotalValue
        {
            get
            {
                return UnitaryPrice * Amount;
            }
        }
    }
}
