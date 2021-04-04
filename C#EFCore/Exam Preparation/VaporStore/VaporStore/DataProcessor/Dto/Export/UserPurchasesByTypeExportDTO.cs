using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserPurchasesByTypeExportDTO
    {
        [XmlAttribute("username")]
        public string Username { get; set; }
        [XmlArray("Purchases")]
        public List<PurchaseExportDTO> Purchases { get; set; }
        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }

    [XmlType("Purchase")]
    public class PurchaseExportDTO
    {
        [XmlElement("Card")]
        public string CardNumber { get; set; }
        [XmlElement("Cvc")]
        public string Cvc { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
        [XmlElement("Game")]
        public GameXmlExportDTO Game { get; set; }
    }

    [XmlType("Game")]
    public class GameXmlExportDTO
    {
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlElement("Genre")]
        public string GenreType { get; set; }
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
