using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;

using Newtonsoft.Json;
using Xamarin.Essentials;

using MusicApp.Models;

namespace MusicApp.Services
{
    public class MusicInfoServices
    {

        public async static Task<List<Album>> GetAlbums(string search)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string key = "d43d6ba61672f77fc775b74aef49ffd7";
                string url = $"http://ws.audioscrobbler.com/2.0/?method=album.search&album={search}&api_key={key}&format=json";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Root info = JsonConvert.DeserializeObject<Root>(json);
                    return info.results.albummatches.album;
                }
            }

            return new List<Album>();
        }

        public async static Task<List<Track>> GetAlbumInfo(string artist, string album)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string key = "d43d6ba61672f77fc775b74aef49ffd7";
                string url = $"http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key={key}&artist={artist}&album={album}&format=json";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Root info = JsonConvert.DeserializeObject<Root>(json);
                    return info.album.tracks.track;
                }
            }

            return new List<Track>();
        }

    }
}
