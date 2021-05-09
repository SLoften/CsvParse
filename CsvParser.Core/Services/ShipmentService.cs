using CsvParser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvParser.Core.Services
{
    public class ShipmentService : IShipmentService
    {
        public List<Shipment> GetFutureShipments(List<Shipment> shipments)
        {
            return shipments.Where(x => x.ShipDate >= DateTime.UtcNow).ToList();
        }

        public Dictionary<string, List<Shipment>> GroupByReceiverCountry(List<Shipment> shipments)
        {
            return shipments.GroupBy(x => x.Receiver.ReceiverCountry).ToDictionary(g => g.Key, g => g.ToList()); // Gruppera shipment på ReceiverCountry (key = ReceiverCountry, g = Value/Shipments)
        }
    }
}
