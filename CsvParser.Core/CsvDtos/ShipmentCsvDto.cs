using CsvParser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvParser.Core.CsvDtos
{
    public class ShipmentCsvDto
    {
        public long SequenceNo { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string SenderCountry { get; set; }
        public string SenderCity { get; set; }
        public string SenderZipCode { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverZipCode { get; set; }
        public DateTime  ShipDate { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Shipment ToShipmentEntity()
        {
            return new Shipment
            {
                SequenceNo = this.SequenceNo,
                ShipDate = this.ShipDate,
                Height = this.Height,
                Width = this.Width,
                Length = this.Length,
                WeightLbs = this.Weight,
                Sender = new Sender
                {
                    SenderCountry = this.SenderCountry,
                    SenderName = this.SenderName,
                    SenderCity = this.SenderCity,
                    SenderZipCode = this.SenderZipCode,
                    SenderAddress = this.SenderAddress
                },
                Receiver = new Receiver
                {
                    ReceiverCountry = this.ReceiverCountry,
                    ReceiverName = this.ReceiverName,
                    ReceiverCity = this.ReceiverCity,
                    ReceiverZipCode = this.ReceiverZipCode,
                    ReceiverAddress = this.ReceiverAddress
                },
            };
        }
    }
}
