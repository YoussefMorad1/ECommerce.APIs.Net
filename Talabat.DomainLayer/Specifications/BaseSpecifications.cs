using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;

namespace Talabat.DomainLayer.Specifications
{
	public class BaseSpecifications<T> : ISpecifications<T> where T : EntityBase
	{
		public Expression<Func<T, bool>>? Criteria { get; set; }
		public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

		public BaseSpecifications() { }
		public BaseSpecifications(Expression<Func<T, bool>> criteria)
		{
		 	Criteria = criteria;
		}
	}
}
