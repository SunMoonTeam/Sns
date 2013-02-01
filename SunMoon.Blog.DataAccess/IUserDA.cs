using SunMoon.Blog.Models.DataModel;

namespace SunMoon.Blog.DataAccess {
    public interface IUserDA : IOprator {
        //void Add(User user);

        //void Update(User user);

        //void Delete(User user);

        User Get(string userID);
    }
}