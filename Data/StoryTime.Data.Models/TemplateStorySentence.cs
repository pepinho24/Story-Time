using StoryTime.Data.Common.Models;

namespace StoryTime.Data.Models
{
    public class TemplateStorySentence : BaseModel<int>
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public int TemplateStoryId { get; set; }

        public virtual TemplateStory TemplateStory { get; set; }
    }
}
