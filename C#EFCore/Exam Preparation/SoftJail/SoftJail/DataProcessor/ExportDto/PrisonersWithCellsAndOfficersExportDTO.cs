using System.Collections.Generic;

namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonersWithCellsAndOfficersExportDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int CellNumber { get; set; }

        public List<OfficersExportDTO> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }

    public class OfficersExportDTO
    {
        public string OfficerName { get; set; }

        public string Department { get; set; }
    }
}
