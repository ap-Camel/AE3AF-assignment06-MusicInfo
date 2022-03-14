using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using MusicApp.Models;

namespace MusicApp.Models
{
    public class OpensearchQuery
    {

        [JsonProperty("#text")]
        public string Text { get; set; }
        public string role { get; set; }
        public string searchTerms { get; set; }
        public string startPage { get; set; }

    }
}
