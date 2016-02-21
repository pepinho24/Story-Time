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
        }

        public string Title { get; set; }

        public virtual ICollection<StorySentence> Sentences { get; set; }
    }
}
