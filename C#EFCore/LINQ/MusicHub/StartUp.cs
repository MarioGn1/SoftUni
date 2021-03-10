namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context.Producers
                .FirstOrDefault(a => a.Id == producerId)
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                    .Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        WriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.WriterName)
                    .ToList(),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            foreach (var album in albums)
            {
                int songCounter = 1;
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{songCounter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                    songCounter++;
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();
            TimeSpan criteria = new TimeSpan(0, 0, 0, duration);
            var songs = context.Songs
                .Where(song => song.Duration > criteria)
                .Select(song => new
                {
                    SongName = song.Name,
                    SongPerformer = song.SongPerformers
                    .Select(x => ($"{x.Performer.FirstName} {x.Performer.LastName}"))
                    .FirstOrDefault(),
                    WriterName = song.Writer.Name,
                    AlbumProducer = song.Album.Producer.Name,
                    Duration = song.Duration.ToString("c")
                })
                .ToList()
                .OrderBy(song => song.SongName)
                .ThenBy(song => song.WriterName)
                .ThenBy(song => song.SongPerformer);
                

            

            int counter = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}")
                .AppendLine($"---SongName: {song.SongName}")
                .AppendLine($"---Writer: {song.WriterName}")
                .AppendLine($"---Performer: {song.SongPerformer}")
                .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
