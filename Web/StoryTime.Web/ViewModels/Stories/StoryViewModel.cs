namespace StoryTime.Web.ViewModels.Stories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class StoryViewModel : IMapFrom<Story>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int WriterInTurn { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public bool IsStoryFinished { get; set; }

        public ICollection<SentenceViewModel> Sentences { get; set; }

        public ICollection<string> Writers { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Story, StoryViewModel>()
                .ForMember(x => x.Writers, opt => opt.MapFrom(x => x.Writers.Select(w => w.Name)));
        }
    }
}
