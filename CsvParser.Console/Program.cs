using CsvParser.Core;
using CsvParser.Core.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace CsvParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), @"ShipmentOrders\customer_csv");
            var shipments = CsvReader.ReadShipments(path);
            var json = JsonConvert.SerializeObject(shipments, new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});
            var shipmentService = new ShipmentService();
            var futureShipments = shipmentService.GetFutureShipments(shipments);
            var countryGroupedShipments = shipmentService.GroupByReceiverCountry(futureShipments);
            foreach (var item in futureShipments)
            {
                Console.WriteLine(item.ShipDate);
            }
            XmlPrinter.CreateXmlFile(countryGroupedShipments);
            
            //Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
