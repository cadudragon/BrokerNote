using BrokerNote.Core.Processors;
using BrokerNote.Model.DTOs;
using BrokerNote.Model.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace BrokerNote.Core.Test
{
    public class SinacorNoteRequestProcessorTest
    {
        private const string _baseFilePath = "./Resources/";

        public SinacorNoteRequestProcessorTest()
        {

        }

        [Fact]
        public void Should_Return_Brokers_Name()
        {
            //Arrange
            var buyNoteFile = $"{_baseFilePath}SinacorNotes/sinacor-buy-note.pdf";
            string result = null;

            //Act
            using (StreamReader sr = new StreamReader(buyNoteFile))
            {
                var processor = new SinacorNoteProcessor(sr.BaseStream);
                result = processor.GetBrokerName();
            }

            // Assert
            Assert.NotNull(result);
            Assert.Contains("CLEAR CORRETORA", result);
        }
    }
}
