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

       public User add(User user)
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
            LoginReturnModel xyz = new LoginReturnModel() { IsLogin = false }; //xyz olarak yerel değişken tanımlıyoruz
            var user = GetByEmail(email); //email'i çekip user olarak tanımlıyoruz

            if (user != null)       
            {
                if (user.Password != password)
                {
                    xyz.Message = "Kullanıcı emaili ya da şifresi yanlıştır!";
                    xyz.IsLogin = false;
                }
                else //LoginReturnModel'e göre tanımlanmış olanları çekiyoruz
                {
                    xyz.Name = user.Firstname + " " + user.Lastname;
                    xyz.Email = user.Email;
                    xyz.Message = "ok";
                    xyz.LoginDate = DateTime.Now;
                    xyz.IsLogin = true;
                }
            }

            return xyz;
        }



        public User Update(RegisterModel user)
        {
            var updateuser = GetByPassword(user.Password);
            if (updateuser != null)
            {
                updateuser.Firstname = user.Firstname;                               //Add'deki tanımlama yaparak yazıyoruz
                updateuser.Lastname = user.Lastname;
                updateuser.Email = user.Email;
                updateuser.Password = user.Password;
                
                context.Users.Update(updateuser);                          //Update ile gönderiyoruz
                context.SaveChanges();
            }
            
            //user.Password = updateuser.Password;                            
            user.Password = updateuser.Password;                            
            return updateuser;
        }

        public RegisterReturnModel Register(RegisterModel user)
        {
            RegisterReturnModel asd = new RegisterReturnModel()     //asd olarak yerel değişken tanımlıyoruz
            {
                IsRegistered = false, 
                Message = ""
            }; 
            var userDb = GetByEmail(user.Email);           //Email'e ulaşıyoruz 
            if (userDb != null)  
            {
                asd.Message = "Bu Kayıt daha önce yaratılmış!";
                return asd;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                asd.Message = "Şifre geçersiz!";
                return asd;

            }
            if (user.Password != user.Password2)
            {
                asd.Message = "Şifre tekrarı geçersiz!";
                return asd;
            }
            // TODO diğer validations (email adres mi,ad soyad var mı)
            userDb = new User()
            {
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Password = user.Password
                
            };
            userDb = add(userDb);
            if (userDb != null && userDb.Id > 0)
            {
                asd.Message = "ok";
                asd.IsRegistered = true;
                asd.Email = user.Email;
                asd.Name = user.Firstname + " " + user.Lastname;
            }
            return asd;
        }

        public User GetByEmail(string email) //burada email çekiyoruz
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
        }
        public User GetByPassword(string password) 
        {
            return context.Users.Where(x => x.Password == password).FirstOrDefault();
        }
    }
}