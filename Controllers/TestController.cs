using AB_Api.Dto;
using AB_Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AB_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly Ab238_salesContext db;
        //   private Product NewProduct = new Product();

        
        public TestController(Ab238_salesContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
         var products = await db.Products.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
    }
    }
}
