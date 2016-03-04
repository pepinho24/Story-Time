namespace StoryTime.Services.Data
{
    using System.Linq;
    using StoryTime.Data.Models;

    public interface IUsersService
    {
        void Delete(string id);

        IQueryable<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);

        void Update();
    }
}