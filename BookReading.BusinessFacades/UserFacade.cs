using BookReading.Business;
using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.BusinessFacades
{
   public class UserFacade
    {
        UserBusiness userBusiness;
        public UserFacade()
        {
            userBusiness = new UserBusiness();
        }

        public IEnumerable<User> getUserData()
        {
            return userBusiness.getUserData();
        }
        public bool addUser(User us)
        {
            return userBusiness.addUser(us);
        }
        public List<User> getUser()
        {
            return userBusiness.getUser();
        }

        public string[] UserIds(int userId)
        {

            return userBusiness.UserIds(userId);
        }
        public int checkUser(string useremail, string password)
        {
            return userBusiness.checkUser(useremail, password);
        }
        public string getRole(int userId)
        {
            return userBusiness.getRole(userId);
        }
    }
}
