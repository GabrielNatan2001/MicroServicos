using MicroServicos.CartAPI.Data.ValueObjects;
using MicroServicos.CartAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicos.CartAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }


        [HttpGet("find-cart/{id}")]
        public async Task<IActionResult> FindById(string userId)
        {
            var cart = await _repository.FindCartByUserId(userId);
            if (cart == null)
                return NotFound();
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null)
                return NotFound();
            return Ok(cart);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null)
                return NotFound();
            return Ok(cart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCart(int id)
        {
            var result = await _repository.RemoveFromCart(id);
            if (!result)
                return NotFound();
            return Ok();
        }

    }
}
