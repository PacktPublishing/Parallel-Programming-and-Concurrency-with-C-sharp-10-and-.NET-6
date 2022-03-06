namespace AsyncSamples
{
    [Serializable]
    public class JournalEntry
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryText { get; set; }
    }
}
