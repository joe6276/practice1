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
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly IMapper _mapper;
        public ProductController(IProduct product, IMapper Mapper)
        {
            _mapper = Mapper;
            _product = product;
        }

        [HttpPost]
        public async Task<ActionResult<string>> addProduct(AddProduct newProduct)
        {
            try
            {
                var response = await _product.addProduct(_mapper.Map<Product>(newProduct));
                return Created("", response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var response = await _product.GetAllProducts();
            return Ok( response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Product>> getProduct(Guid id)
        {
            var response = await _product.GetProductById(id);
            if (response == null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(response);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<string>> updateProduct(Guid id, AddProduct updatedProduct)
        {
            var response = await _product.GetProductById(id);
            if(response == null)
            {
                return NotFound("Product Not Found");
            }
            _mapper.Map(updatedProduct, response);
            await _product.updateProduct(response);
            return NoContent();
        }



        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<string>> deleteProduct(Guid id)
        {
            var response = await _product.GetProductById(id);
            if (response == null)
            {
                return NotFound("Product Not Found");
            }
            await _product.removeProduct(response);
            return NoContent();
        }
    }
}
