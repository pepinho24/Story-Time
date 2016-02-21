namespace StoryTime.Data.Models
{
    public class StoryWriter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StoryId { get; set; }

        public virtual Story Story { get; set; }
    }
}
