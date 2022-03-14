using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using MusicApp.Models;

namespace MusicApp.Models
{
    public class Image
    {

        [JsonProperty("#text")]
        public string Text { get; set; }
        public string size { get; set; }

    }
}
