using AutoMapper;
using Microsoft.AspNetCore.Components;
using Talabat.APIs.DTOs;
using Talabat.DomainLayer.Entities;

namespace Talabat.APIs.Mappers
{
	public class MappingProfiles : Profile
	{

		public MappingProfiles()
		{

			CreateMap<Product, ProductToReturnDTO>()
				.ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
				.ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
				.ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());
		}
	}
}
