using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto> CreateCouponsAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> DeleteCouponsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType=SD.ApiType.GET,
                Url=SD.CouponApiBase+"/api/coupon"
            });
        }

        public async Task<ResponseDto> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "/api/coupon/GetByCode/"+couponCode
            });
        }

        public async Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> UpdateCouponsAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
