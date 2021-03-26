using System.Xml.Serialization;

namespace CarDealer.Dtos.PartialDtos
{
    [XmlType("partId")]
    public class CarPartDTO
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
