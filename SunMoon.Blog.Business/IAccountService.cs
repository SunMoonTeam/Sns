using SunMoon.Blog.Models.DataModel;

namespace SunMoon.Blog.Business {
    public interface IAccountService {

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user"></param>
        void Add(User user);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        void Update(User user);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="user"></param>
        void Delete(User user);

        /// <summary>
        /// Get a user instance
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        User Get(string userID);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        User Login(User loginUser);

        /// <summary>
        /// Get user lists
        /// </summary>
        /// <returns></returns>
        //List<User> GetUsers(int currentPageIndex, int pageSize);
    }
}