﻿using Core.Entities;
using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecifcation<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
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
