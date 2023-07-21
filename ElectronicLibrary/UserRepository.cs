using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary
{
    public class UserRepository
    {
        public User FindById(int id)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user is null) throw new NotFoundException();
                return user;
            }
        }
        public List<User> FindByAllUser()
        {
            using (var db = new AppContext())
            {
                var user = db.Users.ToList();
                return user;
            }
        }
        public void Create(User user)
        {
            using (var db = new AppContext())
            {
                var isUser = db.Users.Contains(user);
                if (!isUser)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
        }
        public void Delete(User user)
        {
            using (var db = new AppContext())
            {
                var isUser = db.Users.Contains(user);
                if (isUser)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
        public void Update(User user, int id)
        {
            using (var db = new AppContext())
            {
                var userId = db.Users.FirstOrDefault(u => u.Id == id);
                if (userId != null)
                {
                    userId.Name = user.Name;
                    userId.Email = user.Email;
                    db.Users.Update(userId);
                    db.SaveChanges();
                }

            }
        }
    }
}
