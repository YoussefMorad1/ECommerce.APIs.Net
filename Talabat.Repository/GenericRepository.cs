using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;
using Talabat.DomainLayer.Repositories;
using Talabat.DomainLayer.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
	{
		private readonly StoreContext dbContext;

		public GenericRepository(StoreContext context)
		{
			dbContext = context;
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			if (typeof(T) == typeof(Product))
				return (IEnumerable<T>)await dbContext.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).ToListAsync();
			return await dbContext.Set<T>().ToListAsync();
		}
		public async Task<T?> GetByIdAsync(int id)
		{
			return await dbContext.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}

		public async Task<T?> GetByIdAsyncWithSpecAsync(ISpecifications<T> spec)
		{
			return await ApplySpecification(spec).FirstOrDefaultAsync();
		}
		private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
		{
			return SpecificationQueryBuilder<T>.ApplySpecification(dbContext.Set<T>(), spec);
		}
	}
}
