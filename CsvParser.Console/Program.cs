using CsvParser.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"ShipmentOrders\customer_csv");
            var shipments = CsvReader.ReadShipments(path);
            var json = JsonConvert.SerializeObject(shipments, new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});
            /*foreach (var item in shipments)
            {
                Console.WriteLine(item.SequenceNo);
            }
            */
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
