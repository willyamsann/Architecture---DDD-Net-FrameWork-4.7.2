using Arquitetura.Application.Modules.ProductManagement.Interfaces;
using Arquitetura.Application.Modules.ProductManagement.ViewModels;
using Arquitetura.Infra.Crosscuting.MvcFilters;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace Arquitetura.Service.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("api/products/GetAllProducts")]
        [ResponseType(typeof(ProductViewModel))]

        public IHttpActionResult GetAllProducts()
        {
            var products = _productAppService.GetAllActive();

            return Ok(products);
        
        }

        [HttpGet]
        [Route("api/products/Details/{id}")]
        [ResponseType(typeof(ProductViewModel))]
        public IHttpActionResult Details(Guid id)
        {
            var product = _productAppService.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

  

        [HttpPost]
        [Route("api/products/Create/")]
        public IHttpActionResult Create([FromBody] ProductViewModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _productAppService.Add(product);
            return Ok();
        }

        [HttpPost]
        [Route("api/products/edit/{id}")]

        public IHttpActionResult Update(Guid id, [FromBody] ProductViewModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }
 
            _productAppService.Update(product);
            return Ok();
        }


        [HttpPost]

        [Route("api/products/delete/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            _productAppService.Delete(id);

            return Ok();
        }
    }
}
