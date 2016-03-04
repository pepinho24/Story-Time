namespace StoryTime.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StoryTime.Data.Common.Models;

    public class Story : BaseModel<int>
    {
        public Story()
        {
            this.Sentences = new HashSet<StorySentence>();
            this.Writers = new HashSet<StoryWriter>();
        }

        public virtual ApplicationUser User { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public virtual ICollection<StoryWriter> Writers { get; set; }

        public virtual ICollection<StorySentence> Sentences { get; set; }

        public int WriterInTurn { get; set; }

        public bool IsStoryFinished { get; set; }
    }
}
