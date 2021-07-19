using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Queries;
using Module.Catalog.Core.Register;
using System.Threading.Tasks;

namespace Module.Catalog.Controllers
{
    /// <summary>
    /// Adicionando essa controller para ter certeza de que o projeto da API estará habilitado para detectar a controller em Module Project
    /// </summary>
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class BrandsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(brands);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterBrandCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
