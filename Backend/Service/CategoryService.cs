using Backend.Data;
using Backend.Interface;
using Backend.Model;

namespace Backend.Service
{
    public class CategoryService : ICategory
    {
        private readonly ConcertifyContext _context;
        public CategoryService(ConcertifyContext context)
        {
            _context = context;
        }
        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _context.Categories.Remove(GetCategoryById(id));
            _context.SaveChanges();
        }

        public ICollection<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Where(x => x.Id == id).FirstOrDefault()!;
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
