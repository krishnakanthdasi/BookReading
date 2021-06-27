using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Data
{
    public class UserData
    {
        private BookReadingDBContext db;
        public UserData()
        {
            db = new BookReadingDBContext();
        }
        public IEnumerable<User> getUserData()
        {
            var output = db.Users.ToList().Where(d => d.UserRole == "U");
            return output;
        }
        public bool addUser(User us)
        {
            if (us == null)
            {
                return false;
            }
            db.Users.Add(us);
            db.SaveChanges();
            return true;
        }
        public List<User> getUser()
        {
            var output = db.Users.ToList();
            return output;
        }

        public string[] UserIds(int userId)
        {

            var output = db.Users.Where(d => d.UserId != userId).ToList();
            string[] listUser = new string[2 * output.Count];
            var i = 0;
            foreach (var user in output)
            {
                listUser[i] = "" + user.UserId;
                listUser[i + 1] = user.UserName;
                i = i + 2;
            }
            return listUser;
        }
        public string getRole(int userId)
        {
            var result = db.Users.Single(d => d.UserId == userId);
            return result.UserRole;
        }
        public int checkUser(string useremail, string password)
        {
            int userId = 0;
            if (useremail == null && useremail == "" && password == null && password == "")
            {
                return 0;
            }
            var userData = db.Users.ToList().Where(d => d.UserEmail == useremail && d.UserPassword == password);
            
            foreach (var item in userData)
            {
                userId = item.UserId;
            
            }
            
            if (userData != null)
            {
                return userId;
            }
            else
            {
                return 0;
            }
        }
    }
}
