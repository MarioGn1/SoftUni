using ProductShop.Models;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.PartialDtos
{
    [XmlType("SoldProduct")]
    public class SoldProductDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public List<ExportProductDTO> Products { get; set; }
    }
}
