namespace OlympicGame.Models
{
    public class PersonRegion
    {
        public int person_id { get; set; }
        public int region_id { get; set; }
        public Person person { get; set; }

        public NocRegion nocRegion { get; set; }
    }
}
