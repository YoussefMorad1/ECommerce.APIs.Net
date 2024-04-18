using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.DomainLayer.Entities;
using Talabat.DomainLayer.Repositories;
using Talabat.DomainLayer.Specifications;

namespace Talabat.APIs.Controllers;

public class ProductsController : APIBaseController
{
	private readonly IGenericRepository<Product> productsRepo;
	private readonly IMapper mapper;
	public ProductsController(IGenericRepository<Product> productsRepo, IMapper mapper)
	{
		this.productsRepo = productsRepo;
		this.mapper = mapper;
	}
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
	{
		var products = await productsRepo.GetAllWithSpecAsync(new ProductWithBrandAndTypeSpecifications());
		var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDTO>>(products);
		return Ok(mappedProducts);
	}
	[HttpGet("{id}")]
	public async Task<ActionResult<Product>> GetProductById(int id)
	{
		var product = await productsRepo.GetByIdAsyncWithSpecAsync(new ProductWithBrandAndTypeSpecifications(id));
		if (product == null)
			return NotFound();
		return Ok(mapper.Map<Product, ProductToReturnDTO>(product));
	}
}
