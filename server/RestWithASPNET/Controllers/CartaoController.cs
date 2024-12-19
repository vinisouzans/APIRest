using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CartaoController : ControllerBase
    {

        private readonly ILogger<CartaoController> _logger;

        // Declaration of the service used
        private ICartaoBusiness _cartaoBusiness;

        // Injection of an instance of IBookService
        // when creating an instance of BookController
        public CartaoController(ILogger<CartaoController> logger, ICartaoBusiness cartaoBusiness)
        {
            _logger = logger;
            _cartaoBusiness = cartaoBusiness;
        }

        // Maps GET requests to https://localhost:{port}/api/cartao
        // Get no parameters for FindAll -> Search All
        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<CartaoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAll(
            [FromQuery] string nome,
            string sortDirection,
            int pageSize,
            int page)
        {
            return Ok(_cartaoBusiness.FindWithPagedSearch(nome, sortDirection, pageSize, page));
        }

        // Maps GET requests to https://localhost:{port}/api/cartao/{id}
        // receiving an ID as in the Request Path
        // Get with parameters for FindById -> Search by ID
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(CartaoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var cartao = _cartaoBusiness.FindByID(id);
            if (cartao == null) return NotFound();
            return Ok(cartao);
        }

        // Maps POST requests to https://localhost:{port}/api/cartao/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(CartaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] CartaoVO cartao)
        {
            if (cartao == null) return BadRequest();
            return Ok(_cartaoBusiness.Create(cartao));
        }

        // Maps PUT requests to https://localhost:{port}/api/cartao/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(CartaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] CartaoVO cartao)
        {
            if (cartao == null) return BadRequest();
            return Ok(_cartaoBusiness.Update(cartao));
        }

        // Maps DELETE requests to https://localhost:{port}/api/cartao/{id}
        // receiving an ID as in the Request Path
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _cartaoBusiness.Delete(id);
            return NoContent();
        }

        [HttpGet("busca-id-cartao-por-id-person/")]
        [ProducesResponseType((200), Type = typeof(CartaoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult BuscaIdCartaoPorIdPerson([FromBody] CartaoVO cartao)
        {
            var idStr = cartao.IdPerson;
            var cartao1 = _cartaoBusiness.BuscaIdCartaoPorIdPerson(idStr);
            if (cartao == null) return NotFound();
            return Ok(cartao.ToString());
        }
    }
}
