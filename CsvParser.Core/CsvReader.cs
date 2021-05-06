using CsvParser.Core.CsvDtos;
using CsvParser.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsvParser.Core
{
    public static class CsvReader
    {
        public static List<Shipment> ReadShipments(string filePath) // Metod som hämtar data från textfilen och skapar objekt
        { 
            var shipments = new List<ShipmentCsvDto>();
            using (var reader = new StreamReader(filePath))
            {
                var headers = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var shipment = CreateShipment(reader.ReadLine());
                    shipments.Add(shipment);
                }
            }
                
            return shipments.Select(x => x.ToShipmentEntity()).ToList();
        }

        private static ShipmentCsvDto CreateShipment(string shipmentCsvLine)
        {
            string[] info = shipmentCsvLine.Split(new char[] { '\t' });
            return new ShipmentCsvDto
            {
                SequenceNo = long.TryParse(info[0], out var sequenceNo) ? sequenceNo : throw new ArgumentException("Invalid SequenceNo"),
                SenderName = info[1],
                SenderAddress = info[2],
                SenderCountry = info[3],
                SenderCity = info[4],
                SenderZipCode = info[5],
                ReceiverName = info[6],
                ReceiverAddress = info[7],
                ReceiverCountry = info[8],
                ReceiverCity = info[9],
                ReceiverZipCode = info[10],
                ShipDate = DateTime.TryParse(info[11], out var shipDate) ? shipDate : throw new ArgumentException("Invalid ShipDate"),
                Length = double.TryParse(info[12], out var length) ? length : throw new ArgumentException("Invalid length"),
                Width = double.TryParse(info[13], out var width) ? width : throw new ArgumentException("Invalid width"),
                Height = double.TryParse(info[14], out var height) ? height : throw new ArgumentException("Invalid height"),
                Weight = double.TryParse(info[15], out var weight) ? weight : throw new ArgumentException("Invalid weight")
            };
        }
    }
}
