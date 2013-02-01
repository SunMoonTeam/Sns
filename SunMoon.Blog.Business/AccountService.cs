using System;

namespace SunMoon.Blog.Business {

    public class AccountService : IAccountService {
        #region IAccountService 成员

        public void Add(Models.DataModel.User user) {
            userDa.Add(user);
        }

        public void Update(Models.DataModel.User user) {
            userDa.Update(user);
        }

        public void Delete(Models.DataModel.User user) {
            userDa.Delete(user);
        }

        public Models.DataModel.User Get(string userID) {
            var user = userDa.Get(userID);

            if (user == null) {
                throw new Exception("User is null.");
            }

            return user;
        }

        public Models.DataModel.User Login(Models.DataModel.User loginUser) {
            var user = this.Get(loginUser.UserID);

            if (user.Password.Equals(loginUser.Password)) {
                return user;
            }

            throw new Exception("User ID or password error. ");
        }

        #endregion IAccountService 成员

        SunMoon.Blog.DataAccess.IUserDA userDa;
    }
}