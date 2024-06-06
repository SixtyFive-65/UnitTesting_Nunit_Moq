using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string Read(string path);
        string GetUnprocessedVideosAsCsv();
    }

    public class VideoService_FileReader : IFileReader
    {
        public string Read(string path)
        {
            var str = File.ReadAllText(path);

            return str;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
        }
    }
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }


    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
