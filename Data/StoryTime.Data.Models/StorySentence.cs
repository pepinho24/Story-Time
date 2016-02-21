using StoryTime.Data.Common.Models;

namespace StoryTime.Data.Models
{
    public class StorySentence : BaseModel<int>
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public int StoryId { get; set; }

        public virtual Story Story { get; set; }
    }
}
