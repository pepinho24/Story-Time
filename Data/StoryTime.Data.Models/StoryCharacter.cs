namespace StoryTime.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StoryTime.Data.Common.Models;

    public class StoryCharacter : BaseModel<int>
    {
        public string Name { get; set; }

        public string RepresentedBy { get; set; }

        public int TemplateStoryId { get; set; }

        public virtual TemplateStory TemplateStory { get; set; }
    }
}
