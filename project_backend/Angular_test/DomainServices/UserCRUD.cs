using Angular_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Angular_test.DomainServices
{
    public class UserCRUD : IUserCRUD
    {
        private readonly AppDbContext context;
      

        public UserCRUD(AppDbContext context)
        {
            this.context = context;
        }

        public User Add(User user)
        {
         
            var newuser = new User
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            context.Users.Add(newuser);          //database'e göndereceklerimizi yazıyoruz
            context.SaveChanges();                 // kaydediyoruz
            return newuser;                        //buna bir bakacağım?
        }

        public void Delete(int id)
        {
            var user = GetById(id);             // id'yi çağrıp, değişkeni tanımlıyoruz
            context.Users.Remove(user);     // database içeriside contex.Categories ile ulaşıp category'i siliyoruz
            context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public User Login(string email, string password, User user)
        {

            
            var login = context.Users.Where(d => d.Email == email && d.Password == password).FirstOrDefault();

            return login;

        }

     

        public User Update(User user)
        {
            var updateuser = context.Users.Find(user.Id);           //Find(model.Id) diyerek object ulaşıyoruz
            updateuser.Firstname = user.Firstname;                               //Add'deki tanımlama yaparak yazıyoruz
            updateuser.Lastname= user.Lastname;
            updateuser.Email = user.Email;
            updateuser.Password = user.Password;
            context.Users.Update(updateuser);                          //Update ile gönderiyoruz
            context.SaveChanges();
            user.Id = updateuser.Id;                                //kaydediyoruz
            return user;
        }
    }
}
