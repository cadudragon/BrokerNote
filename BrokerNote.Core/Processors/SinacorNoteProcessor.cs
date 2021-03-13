using BrokerNote.Model.DTOs;
using BrokerNote.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace BrokerNote.Core.Processors
{
    public class SinacorNoteProcessor : INoteProcessor
    {
        public SinacorNoteProcessor(Stream fileSource)
        {
            FileSource = fileSource;
        }
        public Stream FileSource { get; set; }

        public List<Negotiation> GetNegotiations()
        {
            throw new NotImplementedException();
        }
    }
}
