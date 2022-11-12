using Microsoft.AspNetCore.Mvc;
using TuplesAsDto.API.Data.Repositories;

namespace TuplesAsDto.API.Controllers;

[Produces("application/json")]
[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // GET: api/products
    /// <summary>
    /// Obtêm os produtos
    /// </summary>
    /// <returns>Coleção de objetos da classe Produto</returns>                
    /// <response code="200">Lista dos produtos</response>        
    /// <response code="400">Falha na requisição</response>         
    /// <response code="404">Nenhum produto foi localizado</response>         
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        //var products = await _productRepository.GetAllTupleAsync();
        // var products = await _productRepository.GetAllTupleImplicitAsync();
        // var products = await _productRepository.GetInactivesAsync();
        var products = await _productRepository.GetInactiveEfValueTupleAsync();
        // var products = await _productRepository.GetInactiveEfAnonymousAsync();               
        return Ok(products.Select(p => new { p.Item1, p.Item2 }));
    }

}
