using Angular_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Angular_test.DomainServices
{
    public class CategoryCRUD : ICategoryCRUD
    {
        private readonly AppDbContext context;

        public CategoryCRUD(AppDbContext context)
        {
            this.context = context;
        }

        public CategoryModel Add(CategoryModel model)
        {
            var category = new Category
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            context.Categories.Add(category);
            context.SaveChanges();
            return categoryToModel(category);
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            context.Categories.Remove(modelToCategory(category));
            context.SaveChanges();
        }

    

        public List<CategoryModel> GetAll()
        {
            var cList = context.Categories.ToList();
            List<CategoryModel> models = new List<CategoryModel>();
            foreach (var category in cList)
            {
                models.Add(categoryToModel(category));
            }
            return models;
        }

        public CategoryModel GetById(int id)
        {
            return categoryToModel(context.Categories.Find(id));
        }

        private CategoryModel categoryToModel(Category category)
        {
            CategoryModel model = new CategoryModel
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
            };
            return model;
        }
        private Category modelToCategory(CategoryModel model)
        {
            Category category = new Category
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
            };
            return category;
        }

        public CategoryModel Update(CategoryModel model)
        {
            var category = context.Categories.Find(model.Id);
            category.Title = model.Title;
            category.Description = model.Description;
            category.ModifiedOn = DateTime.Now;
            context.Categories.Update(category);
            context.SaveChanges();
            model.Id = category.Id;
            return model;
        }
    }
}
