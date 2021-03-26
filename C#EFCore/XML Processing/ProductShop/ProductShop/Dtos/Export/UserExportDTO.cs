using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UserExportDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public UserSoldProductsExtendDTO[] Users { get; set; }
    }
}
