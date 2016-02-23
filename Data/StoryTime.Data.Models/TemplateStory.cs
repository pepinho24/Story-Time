namespace StoryTime.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StoryTime.Data.Common.Models;

    public class TemplateStory : BaseModel<int>
    {
        public TemplateStory()
        {
            this.TemplateSentences = new HashSet<TemplateStorySentence>();
            this.Characters = new HashSet<StoryCharacter>();
        }

        public string Title { get; set; }

        public string Narrator { get; set; }

        public string CharacterInTurn { get; set; }

        public virtual ICollection<StoryCharacter> Characters { get; set; }

        public virtual ICollection<TemplateStorySentence> TemplateSentences { get; set; }

        public bool IsStoryFinished { get; set; }
    }
}
