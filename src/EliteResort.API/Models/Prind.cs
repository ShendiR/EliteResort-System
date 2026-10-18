namespace EliteResort.API.Models
{
    public class EmriPrind
    {
        public int Id { get; set; }
        public string Emri { get; set; }
        public string Pershkrimi { get; set; }

        public ICollection<EmriFemije>? EmriFemijet { get; set; }
    }
}