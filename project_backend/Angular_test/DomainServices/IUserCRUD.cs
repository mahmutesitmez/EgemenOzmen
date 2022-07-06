using Angular_test.Models;
using System.Collections.Generic;

namespace Angular_test.DomainServices
{
    public interface IUserCRUD
    {
        User Login(string email, string password, User user);
        User Add(User user);
        User Update(User user);
        void Delete(int id);

        User GetById(int id);

        List<User> GetAll();
        object Login(User user);
    }
}
