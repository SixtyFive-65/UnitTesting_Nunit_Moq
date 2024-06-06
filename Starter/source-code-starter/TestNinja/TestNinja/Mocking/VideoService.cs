using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader fileReader;
        private readonly IVideoRepository videoRepository;

        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null)
        {
            
            this.fileReader = fileReader ?? new VideoService_FileReader();
            this.videoRepository = videoRepository;
        }
        public string ReadVideoTitle()
        {
            var str = fileReader.Read("video.txt");

            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = videoRepository.GetUnporocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }
}