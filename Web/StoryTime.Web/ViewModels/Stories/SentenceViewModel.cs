namespace StoryTime.Web.ViewModels.Stories
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class SentenceViewModel : IMapFrom<StorySentence>
    {
        public string Content { get; set; }
    }
}