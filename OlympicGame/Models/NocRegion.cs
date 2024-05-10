namespace OlympicGame.Models
{
    public class NocRegion
    {
        public int id { get; set; }
        public string noc { get; set; }
        public string region_name { get; set; }
        public ICollection<PersonRegion> personRegions { get; set; }
    }
}
