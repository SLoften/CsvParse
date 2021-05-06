using System;
using System.Collections.Generic;
using System.Text;

namespace CsvParser.Core.Entities
{
    public class Shipment
    {
        public long SequenceNo { get; set; }
        public DateTime ShipDate { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Sender Sender { get; set; }
        public Receiver Receiver { get; set; }
    }
}

