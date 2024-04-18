using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.DomainLayer.Entities;
using Talabat.DomainLayer.Repositories;
using Talabat.DomainLayer.Specifications;

namespace Talabat.APIs.Controllers;

public class ProductsController : APIBaseController
{
	private readonly IGenericRepository<Product> productsRepo;
	public ProductsController(IGenericRepository<Product> productsRepo)
	{
		this.productsRepo = productsRepo;
	}
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
	{
		return Ok(await productsRepo.GetAllWithSpecAsync(new ProductWithBrandAndTypeSpecifications()));
	}
	[HttpGet("{id}")]
	public async Task<ActionResult<Product>> GetProductById(int id)
	{
		var product = await productsRepo.GetByIdAsyncWithSpecAsync(new ProductWithBrandAndTypeSpecifications(id));
		if (product == null)
			return NotFound();
		return Ok(product);
	}
}
