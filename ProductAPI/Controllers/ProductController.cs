using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> products = new()
        {
            new()
            {
                Id=Guid.NewGuid(),
                Name="Laptop",
                Description="Lenovo Notebook",
                Price=1000
            }
        };
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("all")]
        public ActionResult getProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public ActionResult getaProduct(Guid id)
        {
            var product= products.Find(x => x.Id == id);
            //if null --product does not exist
            if(product == null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult addProduct(AddProduct newProduct)
        {
            //var product = new Product()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = newProduct.Name,
            //    Description = newProduct.Description,
            //    Price = newProduct.Price
            //};

            var product = _mapper.Map<Product>(newProduct);
            product.Id = Guid.NewGuid();
            products.Add(product);
            return Created($"https://localhost:7069/api/Product/{product.Id}", "Product Added Successfully!!");
        }

        [HttpPut("{id:guid}")]
        public ActionResult updateProduct(Guid id, AddProduct Updatedproduct)
        {
            var product = products.Find(x => x.Id == id);
            //if null --product does not exist
            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            //product.Price= Updatedproduct.Price;
            //product.Name= Updatedproduct.Name;
            //product.Description= Updatedproduct.Description;

            _mapper.Map(Updatedproduct, product);

            return NoContent();
        }


        [HttpDelete("{id:guid}")]
        public ActionResult deleteProduct(Guid id)
        {
            var product = products.Find(x => x.Id == id);
            //if null --product does not exist
            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            products.Remove(product);

            return NoContent();
        }

        }
}
