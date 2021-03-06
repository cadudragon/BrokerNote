using BrokerNote.Model.DTOs;
using System.Collections.Generic;
using System.IO;

namespace BrokerNote.Model.Interfaces
{
    public interface INoteProcessor
    {
        Stream FileSource { get; set; }
        List<Negotiation> GetNegotiations();
    }
}
