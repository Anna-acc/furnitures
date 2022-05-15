using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FurnitureBy.Data.Entities;
using FurnitureBy.Data.Interfaces;
using FurnitureBy.Services.Interfaces;
using FurnitureBy.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureBy.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _products;
        private readonly IBaseRepository<Category> _categories;
        private readonly IBaseRepository<ProductCategories> _productCategories;
        private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> products, IBaseRepository<Category> categories, IBaseRepository<ProductCategories> productCategories, IMapper mapper)
        {
            _products = products;
            _categories = categories;
            _productCategories = productCategories;
            _mapper = mapper;
        }

        public async Task<IList<ProductDto>> GetAllProducts()
        {
            var include = new Func<IQueryable<Product>, IQueryable<Product>>[]
                {
                    x => x.Include(y => y.Categories).ThenInclude(y => y.Category)
                };
            return _mapper.Map<IList<ProductDto>>(await _products.GetFilter(includes: include));
        }

        public async Task<IList<CategoryDto>> GetAllCategories()
        {
            return _mapper.Map<IList<CategoryDto>>(await _categories.GetFilter());
        }

        public async Task<ProductDto> Get(string code)
        {
            var product = _mapper.Map<ProductDto>(await _products.Get(code));
            product.CategoryIds = (await _productCategories.GetFilter(filter: x => x.CodeProduct == code)).Select(x => x.CategoryId).ToList();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task AddProduct(ProductDto productDto)
        {
            using (var transaction = await _products.BeginTransaction())
            {
                var product = _mapper.Map<Product>(productDto);
                foreach (var categoryId in productDto.CategoryIds)
                {
                    product.Categories.Add(new ProductCategories() { CategoryId = categoryId });
                }

                await _products.Add(product);

                await transaction.CommitAsync();
            }
        }

        public async Task EditProduct(ProductDto productDto)
        {
            using (var transaction = await _products.BeginTransaction())
            {
                var product = _mapper.Map<Product>(productDto);

                var categories = new List<ProductCategories>();
                foreach (var categoryId in productDto.CategoryIds)
                {
                    categories.Add(new ProductCategories() { CategoryId = categoryId, CodeProduct = productDto.Code });
                }

                var oldCategories = (await _productCategories.GetFilter(filter: x => x.CodeProduct == productDto.Code)).ToList();

                await _productCategories.RemoveRange(oldCategories);
                await _productCategories.AddRange(categories);

                await _products.Update(product);

                await transaction.CommitAsync();
            }
        }

        public async Task<IList<CategoryDto>> GetCategoriesFromMainCategory(int mainCategoryId)
        {
            return _mapper.Map<IList<CategoryDto>>(await _categories.GetFilter(filter: x => x.ParentId == mainCategoryId && x.IsShow));
        }

        public async Task<IList<ProductDto>> GetProductsByCategory(string categoryId)
        {
            return _mapper.Map<IList<ProductDto>>(await _products.GetFilter(filter: x => x.Categories.Any(y => y.CategoryId == categoryId) && x.IsActive));
        }
    }
}
