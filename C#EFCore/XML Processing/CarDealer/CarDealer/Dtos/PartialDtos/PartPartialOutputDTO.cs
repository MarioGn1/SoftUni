using System.Xml.Serialization;

namespace CarDealer.Dtos.PartialDtos
{
    [XmlType("part")]
    public class PartPartialOutputDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
