using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPIDB.Models;
using ProductAPIDB.Models.DTOS;
using ProductAPIDB.Services.IServices;

namespace ProductAPIDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategory _category;
        private readonly IMapper _mapper;
        public CategoryController(ICategory category, IMapper mapper)
        {
            _mapper = mapper;
            _category = category;
        }
        [HttpPost]
        public async Task<ActionResult<string>> addCategory(AddCategory newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            var response = await _category.addCategory(category);
            return Created("", response);
        }

        [HttpGet]

        public async Task<ActionResult<List<Category>>> getCategories()
        {
           var response = await _category.listCategories();
            return Ok(response);
        }

    }
}
