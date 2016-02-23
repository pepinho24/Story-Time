namespace StoryTime.Web.ViewModels.TemplateStories
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class TemplateSentenceViewModel : IMapFrom<TemplateStorySentence>
    {
        public string Content { get; set; }
    }
}
