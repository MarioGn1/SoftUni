using System.Collections.Generic;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class AllGamesByGenreExportDTO
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public List<GamesExportDTO> Games { get; set; }

        public int TotalPlayers { get; set; }
    }

    public class GamesExportDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Tags { get; set; }

        public int Players { get; set; }
    }
}
