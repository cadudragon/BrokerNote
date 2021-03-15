using BrokerNote.Core.Utils;
using BrokerNote.Model.Constants.Sinacor;
using BrokerNote.Model.DTOs;
using BrokerNote.Model.Interfaces;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BrokerNote.Core.Processors
{
    public class SinacorNoteProcessor : INoteProcessor
    {
        public SinacorNoteProcessor(Stream fileSource)
        {
            FileSource = fileSource;
            _pdfDocument = new PdfDocument(new PdfReader(FileSource));
        }
        public Stream FileSource { get; set; }
        private PdfDocument _pdfDocument { get; set; }

        public string GetBrokerName()
        {
            var addressRect = SinacorNotePositions.GetRectangle(SinacorNotePositions.BrokerNameRectangle);
            PdfPage page = _pdfDocument.GetPage(1);
            return ReaderExtensions.ExtractText(page, addressRect).FirstOrDefault();
        }

        public List<Negotiation> GetNegotiations()
        {
            throw new NotImplementedException();
        }
    }
}
