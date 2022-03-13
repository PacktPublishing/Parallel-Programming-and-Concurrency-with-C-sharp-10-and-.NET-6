namespace SyncAndAsyncSamples.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Medication>? Medications { get; set; }
        public Provider? PrimaryCareProvider { get; set; }
    }
}