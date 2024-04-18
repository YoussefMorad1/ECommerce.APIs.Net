using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;

namespace Talabat.DomainLayer.Specifications
{
	public class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product>
	{
		public ProductWithBrandAndTypeSpecifications()
		{
			Includes.Add(x => x.ProductBrand);
			Includes.Add(x => x.ProductType);
		}

		public ProductWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
		{
			Includes.Add(x => x.ProductBrand);
			Includes.Add(x => x.ProductType);
		}
	}
}
