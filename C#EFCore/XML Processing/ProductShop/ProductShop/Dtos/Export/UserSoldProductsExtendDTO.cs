using ProductShop.Dtos.Export.PartialDtos;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserSoldProductsExtendDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }

        public SoldProductDTO SoldProducts { get; set; }
    }
}
