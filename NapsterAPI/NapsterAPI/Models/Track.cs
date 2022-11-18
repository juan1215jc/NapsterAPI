using Newtonsoft.Json;

namespace NapsterAPI.Models
{
    public class Track
    {
        public string id { get; set; }
        public string name { get; set; }
        public string disc { get; set; }
        public Artista artist { get; set; }
        public Album album { get; set; }
        public Genre genre { get; set; }
        public string sample { get; set; }
        public string duration { get; set; }

    }
}
