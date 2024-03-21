using MicroServicos.CouponAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicos.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet("{couponCode}")]
        public async Task<IActionResult> GetCouponByCouponCode(string couponCode)
        {
            var product = await _repository.GetCouponByCouponCode(couponCode);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}
