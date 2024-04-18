using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;

namespace Talabat.DomainLayer.Specifications;

public interface ISpecifications <T> where T : EntityBase
{
	Expression<Func<T, bool>> Criteria { get; set; }
	List<Expression<Func<T, object>>> Includes { get; set; }
}
