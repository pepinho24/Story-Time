namespace StoryTime.Web.ViewModels.TemplateStories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Stories;
    using StoryTime.Data.Models;
    using StoryTime.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    public class TemplateStoryViewModel : IMapFrom<TemplateStory>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Narrator { get; set; }

        public string CharacterInTurn { get; set; }

        public virtual ICollection<StoryCharacter> Characters { get; set; }

        [UIHint("TemplateSentences")]
        public virtual ICollection<TemplateSentenceViewModel> Sentences { get; set; }

        public bool IsStoryFinished { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<TemplateStory, TemplateStoryViewModel>()
                .ForMember(x => x.Sentences, opt => opt.MapFrom(x => x.TemplateSentences)); 
            // .ForMember(x => x.Sentences, opt => opt.MapFrom(x => x.Sentences.AsQueryable().To<ICollection<SentenceViewModel>>()));
        }
    }
}