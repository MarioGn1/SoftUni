using System.Xml.Serialization;

namespace CarDealer.Dtos.PartialDtos
{
    [XmlType("car")]
    public class CarOutputAttributesDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
