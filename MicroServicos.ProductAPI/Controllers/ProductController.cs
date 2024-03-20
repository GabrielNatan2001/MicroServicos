using MicroServicos.ProductAPI.Data.ValueObjects;
using MicroServicos.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicos.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }


        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var products = await _repository.FindAll();
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if(product == null)
                 return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVO vo)
        {
            if (vo == null)
                return NotFound();

            var product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductVO vo)
        {
            if (vo == null)
                return NotFound();

            var product = await _repository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _repository.Delete(id);
            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
