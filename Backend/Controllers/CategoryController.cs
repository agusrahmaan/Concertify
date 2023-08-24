using Backend.Dto;
using Backend.Interface;
using Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryRepo;
        public CategoryController(ICategory categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpPost("create")]
        public IActionResult CreateCategory([FromQuery] CategoryDto categoryDto)
        {
            var checkCategoryName = _categoryRepo.GetAllCategories().Where(x => x.CategoryName.ToLower() == categoryDto.CategoryName.ToLower()).FirstOrDefault();

            if (checkCategoryName != null) return BadRequest("CategoryName Alraedy Exist");

            var newCategory = new Model.Category
            {
                CategoryName = categoryDto.CategoryName,
                Kuota = categoryDto.Kuota,
                Price = categoryDto.Price,
            };

            _categoryRepo.CreateCategory(newCategory);
            return Ok("Create Success");
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryRepo.GetAllCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var categoryId = _categoryRepo.GetCategoryById(id);
            if (categoryId == null) return BadRequest("Id Not Found");
            return Ok(categoryId);
        }

        [HttpPut("update")]
        public IActionResult UpdateCategory(int id, CategoryDto categoryDto)
        {
            var categoryName = _categoryRepo.GetAllCategories().Where(x => x.CategoryName == categoryDto.CategoryName).FirstOrDefault();
            var categoryKuota = _categoryRepo.GetAllCategories().Where(x => x.Kuota == categoryDto.Kuota).FirstOrDefault();
            var categoryPrice = _categoryRepo.GetAllCategories().Where(x => x.Price == categoryDto.Price).FirstOrDefault();
            var categoryId = _categoryRepo.GetCategoryById(id);

            if (categoryId == null)
            {
                return BadRequest("Category Id not found");
            }
            else
            {
                if (categoryId.CategoryName != categoryDto.CategoryName && categoryName != null)
                {
                    return BadRequest("Category Name already exist");
                }
                categoryId.CategoryName = categoryDto.CategoryName;
                categoryId.Kuota = categoryDto.Kuota;
                categoryId.Price = categoryDto.Price;
                _categoryRepo.UpdateCategory(categoryId);

                return Ok("Update Success");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var categoryId = _categoryRepo.GetCategoryById(id);
            if(categoryId == null)
            {
                return BadRequest("Category Id not found");
            }

            _categoryRepo.DeleteCategory(id);
            return Ok("Delete Succes");
        }
    }
}
