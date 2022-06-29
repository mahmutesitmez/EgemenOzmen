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

        private User add(User user)
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

        public LoginReturnModel Login(string email, string password)
        {
            LoginReturnModel model = new LoginReturnModel() { IsLogin = false };
            var user = GetByEmail(email);

            if (user != null)
            {
                if (user.Password != password)
                {
                    model.Message = "Kullanıcı emaili ya da şifresi yanlıştır!";
                    model.IsLogin = true;
                }
                else
                {
                    model.Name = user.Firstname + " " + user.Lastname;
                    model.Email = user.Email;
                    model.Message = "ok";
                    model.LoginDate = DateTime.Now;
                    model.IsLogin = true;
                }
            }

            return model;
        }



        public User Update(User user)
        {
            var updateuser = context.Users.Find(user.Id);           //Find(model.Id) diyerek object ulaşıyoruz
            updateuser.Firstname = user.Firstname;                               //Add'deki tanımlama yaparak yazıyoruz
            updateuser.Lastname = user.Lastname;
            updateuser.Email = user.Email;
            updateuser.Password = user.Password;
            context.Users.Update(updateuser);                          //Update ile gönderiyoruz
            context.SaveChanges();
            user.Id = updateuser.Id;                                //kaydediyoruz
            return user;
        }

        public RegisterReturnModel Register(RegisterModel register)
        {
            RegisterReturnModel registerReturnModel = new RegisterReturnModel()
            {
                IsRegistered = false,
                Message = ""
            };
            var userDb = GetByEmail(register.Email);
            if (userDb != null)
            {
                registerReturnModel.Message = "Bu Kayıt daha önce yaratılmış!";
                return registerReturnModel;
            }
            if (string.IsNullOrEmpty(register.Password) )
            {
                registerReturnModel.Message = "Şifre geçersiz!";
                return registerReturnModel;

            }
            if (register.Password != register.Password2)
            {
                registerReturnModel.Message = "Şifre tekrarı geçersiz!";
                return registerReturnModel;
            }
            // TODO diğer validations (email adres mi,ad soyad var mı)
            userDb = new User()
            {
                Email = register.Email,
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                Password = register.Password

            };
            userDb = add(userDb);
            if (userDb != null && userDb.Id > 0)
            {
                registerReturnModel.Message = "ok";
                registerReturnModel.IsRegistered = true;
                registerReturnModel.Email = register.Email;
                registerReturnModel.Name = register.Firstname + " " + register.Lastname;
            }
            return registerReturnModel;
        }

        public User GetByEmail(string email)
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
