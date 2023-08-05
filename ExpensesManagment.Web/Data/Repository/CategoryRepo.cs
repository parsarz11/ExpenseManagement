using ExpensesManagment.Web.Data.Context;
using ExpensesManagment.Web.Data.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExpensesManagment.Web.Data.Repository
{
    public class CategoryRepo
    {

        private readonly DatabaseContext _databaseContext;
        public CategoryRepo (DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public List<Category> categoryList()
        {
            return _databaseContext.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _databaseContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public string GetColor(int id) 
        {
            var Color = _databaseContext.Categories.FirstOrDefault(x=>x.Id == id).Color;
            return Color;
        }

        public void AddCategory(Category category)
        {
            var AddCategory = _databaseContext.Categories.Add(category);
            _databaseContext.SaveChanges();
        }

        public void RemoveCategory(int id)
        {
            var RemoveCategory = _databaseContext.Categories.FirstOrDefault(y => y.Id == id);
            _databaseContext.Categories.Remove(RemoveCategory);
        }
    }
}
