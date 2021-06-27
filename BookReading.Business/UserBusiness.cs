using BookReading.Data;
using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business
{
    public class UserBusiness
    {
        UserData userData;
        public UserBusiness()
        {
            userData = new UserData();
        }

        public IEnumerable<User> getUserData()
        {
            return userData.getUserData();
        }
        public bool addUser(User us)
        {
            return userData.addUser(us);
        }
        public List<User> getUser()
        {
            return userData.getUser();
        }

        public string[] UserIds(int userId)
        {

            return userData.UserIds(userId);
        }
        public int checkUser(string useremail, string password)
        {
            return userData.checkUser(useremail, password);
        }
        public string getRole(int userId)
        {
            return userData.getRole(userId);
        }
    }
}
