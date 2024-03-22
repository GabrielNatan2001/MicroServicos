using MicroServicos.CartAPI.Data.ValueObjects;
using MicroServicos.CartAPI.Messages;
using MicroServicos.CartAPI.RabbitMQSender;
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
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public CartController(ICartRepository repository, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _rabbitMQMessageSender = rabbitMQMessageSender ?? throw new ArgumentException(nameof(rabbitMQMessageSender));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);
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

        [HttpPost("apply-coupon")]
        public async Task<IActionResult> ApplyCoupon(CartVO vo)
        {
            var result = await _repository.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);
            if (!result)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<IActionResult> RemoveCoupon(string userId)
        {
            var result = await _repository.RemoveCoupon(userId);
            if (!result)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkou(CheckouHeaderVO vo)
        {
            if(vo?.UserId == null)
                return BadRequest();

            var cart = await _repository.FindCartByUserId(vo.UserId);
            if (cart == null)
                return NotFound();
            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            //Task RabbitMQ 
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            await _repository.ClearCart(vo.UserId);

            return Ok(vo);
        }
    }
}
