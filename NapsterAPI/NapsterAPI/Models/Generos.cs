namespace NapsterAPI.Models
{
    public class Generos
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Subgenres> subgenres { get; set; }
    }
}
