using Angular_test.Models;
using System.Collections.Generic;

namespace Angular_test.DomainServices
{
    public interface IUserCRUD
    {
        LoginReturnModel Login(string email, string password);              
        RegisterReturnModel Register(RegisterModel register);               
        User Update(RegisterModel user);                 
        void Delete(int id);                    
                    
        User GetById(int id);                                                 
        User GetByEmail(string email);        
        
        User GetByPassword(string password);
        
                        
        List<User> GetAll();
     
    }
}
