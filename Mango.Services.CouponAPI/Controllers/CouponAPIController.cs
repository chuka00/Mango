﻿using AutoMapper;
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


        [HttpGet("{id}", Name = "GetCouponById")]
        public ResponseDto GetCouponById(int id)
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

        //[HttpGet("code/{couponCode}", Name = "GetCouponByCode")]
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetCouponByCode(string code)
        {
            try
            {
                Coupon couponCode = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());

                _response.Result = _mapper.Map<CouponDto>(couponCode);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

            /*        [HttpGet("{id}", Name = "GetCouponById")]
                    public ActionResult<Coupon> GetCouponById(int id)
                    {
                        try
                        {
                            Coupon couponCode = _db.Coupons.FirstOrDefault(u => u.CouponId == id);
                            if (couponCode == null)
                            {
                                return NotFound();
                            }
                            return Ok(couponCode);
                        }
                        catch (Exception ex)
                        {
                            // Log the exception
                            return StatusCode(500, "Internal server error");
                        }
                    }*/
        }

    }
}
