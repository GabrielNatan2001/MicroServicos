using MicroServicos.CouponAPI.Data.ValueObjects;

namespace MicroServicos.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string CouponCode);
    }
}
