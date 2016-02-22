namespace StoryTime.Data.Models
{
    using StoryTime.Data.Common.Models;

    public class StoryWriter : BaseModel<int>
    {
        public string Name { get; set; }

        public int StoryId { get; set; }

        public virtual Story Story { get; set; }
    }
}
