using BrokerNote.Core.Processors;
using BrokerNote.Model.DTOs;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BrokerNote.Core.Test
{
    [TestFixture]
    public class SinacorNoteRequestProcessorTest
    {
        private const string _baseFilePath = "./Resources/";
        private string _buyNote => $"{_baseFilePath}SinacorNotes/sinacor-buy-note.pdf";
        private string _sellNote => $"{_baseFilePath}SinacorNotes/sinacor-sell-note.pdf";
        private List<Negotiation> _negotiations;

        [OneTimeSetUp]
        public void Setup()
        {
            using (StreamReader sr = new StreamReader(_buyNote))
            {
                var processor = new SinacorNoteProcessor(sr.BaseStream);
                _negotiations = processor.GetNegotiations();
            }
        }

        [Test]
        public void Should_Return_BrokersNote_With_values_From_PDF()
        {
            Assert.True(_negotiations.All(x => x.BrokerName.Contains("CLEAR CORRETORA")));
            Assert.True(_negotiations.Sum(x => x.TotalValue) == 106624);
        }
    }
}
