using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> CouponList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(CouponList);
               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        

        [HttpGet("{id}", Name ="GetCouponById")]
        public ResponseDto GetCouponById (int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(u => u.CouponId == id);

                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response; 
        }
/*        [HttpGet("{id}", Name = "GetCouponById")]
        public ActionResult<Coupon> GetCouponById(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(u => u.CouponId == id);
                if (coupon == null)
                {
                    return NotFound();
                }
                return Ok(coupon);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }*/
        /*public object Get(int id)
     {
         try
         {
             Coupon CouponList = _db.Coupons.First(u=>u.CouponId == id);
            // Coupon object = _db.Coupons.Find(id);
             // var product = _productRepo.GetQueryable(p => p.UserId.ToString() == userId.ToString()).OrderBy(i => i.ProductId);

             return CouponList;
         }
         catch (Exception ex)
         {

         }
         return null;*/
    }


    /* [HttpGet]
     public object Get()
     {
         try
         {
             IEnumerable<Coupon> CouponList = _db.Coupons.ToList();
             return CouponList;
         }
         catch (Exception ex)
         {

         }
         return null;
     }

     [HttpGet]
     [Route("{id: int}")]
     
     }*/

}

