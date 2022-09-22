using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AB_Api.Models.Repositories.DB;
using AB_Api.Models;
using AB_Api.Models.FactoryModels;
using AB_Api.Dto;
using AutoMapper;

namespace AB_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ProductRepoDb _productRepoDb ;

        private readonly IMapper _mapper;

        public ValuesController(ProductRepoDb productRepoDb, IMapper mapper)
        {
            _productRepoDb = productRepoDb;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetOrders()
        {
            var products = _productRepoDb.List();
            var pro = _mapper.Map<IEnumerable<ProductDto>>(products);
            return  Ok(pro);
        }
    }
}
