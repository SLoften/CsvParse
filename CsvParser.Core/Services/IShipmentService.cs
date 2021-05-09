using CsvParser.Core.Entities;
using System.Collections.Generic;

namespace CsvParser.Core.Services
{
    public interface IShipmentService
    {
        List<Shipment> GetFutureShipments(List<Shipment> shipments);
        Dictionary<string, List<Shipment>> GroupByReceiverCountry(List<Shipment> shipments);
    }
}