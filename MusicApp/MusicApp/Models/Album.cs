using System;
using System.Collections.Generic;
using System.Text;
using MusicApp.Models;

namespace MusicApp.Models
{
    public class Album
    {
        public string name { get; set; }
        public string artist { get; set; }
        public List<Image> image { get; set; }
        public string ImgUrl { get; set; }
        public Tracks tracks { get; set; }
    }
}
