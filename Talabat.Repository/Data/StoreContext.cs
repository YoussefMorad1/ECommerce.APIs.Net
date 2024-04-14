﻿using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;

namespace Talabat.Repository.Data;

public class StoreContext : DbContext
{
	public StoreContext(DbContextOptions<StoreContext> options) : base(options) {	}
	DbSet<Product> Products { get; set; }
	DbSet<ProductType> ProductTypes { get; set; }
	DbSet<ProductBrand> ProductBrands { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
