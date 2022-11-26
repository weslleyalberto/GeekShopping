using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _productRepository.FindAll();
            if (product is null) return NotFound("Não há produtos com o cadastrados");
            return Ok(product);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product is null) return NotFound($"Não há produtos com id {id} informado!");
            return Ok(product);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody]ProductVO productVO)
        {
            if (productVO is null)
                return BadRequest("Não há dados");
            var product = await _productRepository.Create(productVO);
            return Ok(product);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO productVO)
        {
            if (productVO is null)
                return BadRequest("Não há dados na requisição");
            var product = await _productRepository.Update(productVO);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status)
                return NotFound("Não há id com produto informado");
           
            return Ok(status);
        }

    }
}
