using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookShop.DataProcessor.ExportDto
{
    public class MostCraziestAuthorsDTO
    {
        public string AuthorName { get; set; }
        public List<BookExportPartial> Books { get; set; }
    }

    public class BookExportPartial
    {
        public string BookName { get; set; }
        [JsonIgnore]
        public decimal RealPrice { get; set; }

        public string BookPrice { get; set; }
    }
}
