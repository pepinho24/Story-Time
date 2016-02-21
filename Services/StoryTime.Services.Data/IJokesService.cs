namespace StoryTime.Services.Data
{
    using System.Linq;

    using StoryTime.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
