using Core.Entities;
using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecifcation<Product>
    {
     //public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
     //    : base(x => 
     //    (!brandId.HasValue || x.ProductBrandId == brandId) && 
     //    (!typeId.HasValue || x.ProductTypeId == typeId))
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
    : base(x =>
    (!productParams.BandId.HasValue || x.ProductBrandId == productParams.BandId) &&
    (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescendending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }

        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
