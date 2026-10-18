namespace EliteResort.API.Models
{
    public class EmriFemije
    {
        public int Id { get; set; }
        public string Detaji { get; set; }

        // Foreign Key (Celesi i huaj) - KRITIKE PER PROVIM
        public int EmriPrindId { get; set; }
        public EmriPrind? EmriPrind { get; set; }
    }
}