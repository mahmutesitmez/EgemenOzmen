using Angular_test.Models;
using System.Collections.Generic;

namespace Angular_test.DomainServices
{
    public interface ICategoryCRUD
    {
        CategoryModel Add(CategoryModel model);    
        CategoryModel Update(CategoryModel model);
        void Delete(int id);
         
        CategoryModel GetById(int id);

        List<CategoryModel> GetAll();
    }
}
