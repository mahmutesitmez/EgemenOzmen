using Angular_test.Models;
using System.Collections.Generic;

namespace Angular_test.DomainServices
{
    public interface IUserCRUD
    {
        LoginReturnModel Login(string email, string password);
        RegisterReturnModel Register(RegisterModel user);
        User Update(User user);
        void Delete(int id);

        User GetById(int id);
        User GetByEmail(string email);

        List<User> GetAll();
    }
}
