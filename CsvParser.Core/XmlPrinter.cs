using CsvParser.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CsvParser.Core
{
    public static class XmlPrinter
    {
        public static void CreateXmlFile(string filePath, List<Shipment> shipments) // Metod för att spara ner objekt till en xml-fil
        {
            string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), @"ShipmentOrders\", filePath);
            using (var xw = XmlWriter.Create(savePath))
            {
                xw.WriteStartDocument();
                xw.WriteStartElement("Shipments");
                foreach (Shipment shipment in shipments)
                {
                    xw.WriteStartElement("Shipment");
                    xw.WriteElementString("SequenceNo", shipment.SequenceNo.ToString());
                    xw.WriteElementString("ShipDate", shipment.ShipDate.ToString());
                    xw.WriteElementString("ShipLength", shipment.Length.ToString());
                    xw.WriteElementString("ShipWidth", shipment.Width.ToString());
                    xw.WriteElementString("ShipHeight", shipment.Height.ToString());

                    xw.WriteStartElement("ShipWeigth");
                    xw.WriteAttributeString("Format", "Kg");
                    xw.WriteString(shipment.WeightKg.ToString());
                    xw.WriteEndElement();

                    xw.WriteStartElement("Sender");
                    xw.WriteElementString("SenderName", shipment.Sender.SenderName.ToString());
                    xw.WriteElementString("SenderAddress", shipment.Sender.SenderAddress.ToString());
                    xw.WriteElementString("SenderCountry", shipment.Sender.SenderCountry.ToString());
                    xw.WriteElementString("SenderCity", shipment.Sender.SenderCity.ToString());
                    xw.WriteElementString("SenderZipCode", shipment.Sender.SenderZipCode.ToString());
                    xw.WriteEndElement();

                    xw.WriteStartElement("Receiver");
                    xw.WriteElementString("ReceiverName", shipment.Receiver.ReceiverName.ToString());
                    xw.WriteElementString("ReceiverAddress", shipment.Receiver.ReceiverAddress.ToString());
                    xw.WriteElementString("ReceiverCountry", shipment.Receiver.ReceiverCountry.ToString());
                    xw.WriteElementString("ReceiverCity", shipment.Receiver.ReceiverCity.ToString());
                    xw.WriteElementString("ReceiverZipCode", shipment.Receiver.ReceiverZipCode.ToString());
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();
                xw.WriteEndDocument();
                
                xw.Flush();
                xw.Close();
            }
        }

        public static void CreateXmlFile(Dictionary<string, List<Shipment>> countryGroupedShipments)
        {
            foreach (var country in countryGroupedShipments.Keys)
            {
                CreateXmlFile($"Shipments-{country}-{DateTime.UtcNow.ToString("yyyy-MM-ddThh-mm")}.xml", countryGroupedShipments[country]); //Hämtar värde på country(key) och skapar en XML
            }
        }
    }
}
