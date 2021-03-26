using CarDealer.Dtos.PartialDtos;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class CarInputDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }
        [XmlArray("parts")]
        public CarPartDTO[] CarPartsIds { get; set; }
    }
}
