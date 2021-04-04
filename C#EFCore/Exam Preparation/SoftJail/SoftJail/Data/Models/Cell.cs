using System.Collections.Generic;

namespace SoftJail.Data.Models
{
    public class Cell
    {
        public int Id { get; set; }

        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Prisoner> Prisoners { get; set; }
    }
}
