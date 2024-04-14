using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;

namespace Talabat.Repository.Data.Configurations
{
	internal class ProductTypeConfigurations : IEntityTypeConfiguration<ProductType>
	{
		public void Configure(EntityTypeBuilder<ProductType> builder)
		{
			builder.Property(pt => pt.Name).IsRequired().HasMaxLength(50);
		}
	
	}
}
