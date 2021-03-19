using BrokerNote.Core.Utils;
using BrokerNote.Model.Constants.Sinacor;
using BrokerNote.Model.DTOs;
using BrokerNote.Model.Enums;
using BrokerNote.Model.Interfaces;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public List<Negotiation> GetNegotiations()
        {
            int numberOfPages = _pdfDocument.GetNumberOfPages();
            string brokerName = "";
            DateTime? negotiationDate = null;
            List<OperationType> operationsColumn = null;
            List<string> stocksNameColumn = null;
            List<int> stocksAmountColumn = null;
            List<decimal> stocksPriceColumn = null;
            List<Negotiation> negotiations = new List<Negotiation>();


            for (int i = 1; i <= numberOfPages; i++)
            {
                PdfPage page = _pdfDocument.GetPage(i);
                brokerName = i == 1 ? GetBrokerName(page) : brokerName;
                negotiationDate = GetNegotiationDate(page);
                operationsColumn = ProcessOperationTypeColumn(page);
                stocksNameColumn = ProcessStockNameColumn(page);
                stocksAmountColumn = ProcessStockAmountColumn(page);
                stocksPriceColumn = ProcessStockPriceColumn(page);
            }

            for (int i = 0; i < operationsColumn.Count; i++)
            {
                negotiations.Add(new Negotiation
                {
                    BrokerName = brokerName,
                    Amount = stocksAmountColumn[i],
                    NegotiationDate = (DateTime)negotiationDate,
                    OperationType = operationsColumn[i],
                    StockName = stocksNameColumn[i],
                    UnitaryPrice = stocksPriceColumn[i]
                });
            }

            return negotiations;
        }

        private string GetBrokerName(PdfPage page)
        {
            var addressRect = SinacorNotePosition.GetRectangle(SinacorNotePosition.BrokerNameRectangle);
            return ReaderExtensions.ExtractText(page, addressRect).FirstOrDefault();
        }

        private DateTime GetNegotiationDate(PdfPage page)
        {

            var addressRect = SinacorNotePosition.GetRectangle(SinacorNotePosition.NegotiationDate);
            var ret = ReaderExtensions.ExtractText(page, addressRect).FirstOrDefault();
            return DateTime.ParseExact(ret, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private List<OperationType> ProcessOperationTypeColumn(PdfPage page)
        {
            var addressRect = SinacorNotePosition
                .GetRectangle(SinacorNotePosition.NegotiationColumnsPosition.OperationTypeColumn);

            var operationTypeCells = ReaderExtensions.ExtractText(page, addressRect).First()
                .Split(Environment.NewLine.ToCharArray()).Select(x => x == "C" ? OperationType.Buy : OperationType.Sell);

            return operationTypeCells.ToList();
        }

        private List<string> ProcessStockNameColumn(PdfPage page)
        {
            var addressRect = SinacorNotePosition
                .GetRectangle(SinacorNotePosition.NegotiationColumnsPosition.StockNameColumn);

            var ret = ReaderExtensions.ExtractText(page, addressRect)
                .First().Split(Environment.NewLine.ToCharArray());

            //Removing stock's specifications like ordinárias (ON) ou preferenciais (PN), 
            //this usually occurs after two consecultive spaces after stock's name
            var stockNameCells = ret.Select(X => X.Split(new string[] { "  " }, StringSplitOptions.None)[0]).ToList();
            return stockNameCells;
        }

        private List<int> ProcessStockAmountColumn(PdfPage page)
        {
            var addressRect = SinacorNotePosition
                .GetRectangle(SinacorNotePosition.NegotiationColumnsPosition.StockAmountColumn);

            var stockAmountCells = ReaderExtensions.ExtractText(page, addressRect)
                .First().Split(Environment.NewLine.ToCharArray()).Select(x => int.Parse(x));

            return stockAmountCells.ToList();
        }

        private List<decimal> ProcessStockPriceColumn(PdfPage page)
        {
            var addressRect = SinacorNotePosition
                .GetRectangle(SinacorNotePosition.NegotiationColumnsPosition.StockPriceColumn);

            var stockAmountCells = ReaderExtensions.ExtractText(page, addressRect)
                .First().Split(Environment.NewLine.ToCharArray()).Select(x => decimal.Parse(x));

            return stockAmountCells.ToList();
        }

    }
}
