using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryProductDal : IProductDal
	{

		List<Product> _products;

		public InMemoryProductDal()
		{
			_products = new List<Product> {

				new Product{ProductId = 1, CategoryId = 1, ProductName = "Glass", UnitPrice = 15, UnitsInStock = 1874},
				new Product{ProductId = 2, CategoryId = 1, ProductName = "Lamb", UnitPrice = 9, UnitsInStock = 568},
				new Product{ProductId = 3, CategoryId = 2, ProductName = "Camera", UnitPrice = 1250, UnitsInStock = 14},
				new Product{ProductId = 4, CategoryId = 2, ProductName = "Telephone", UnitPrice = 4000, UnitsInStock = 85},
				new Product{ProductId = 5, CategoryId = 2, ProductName = "Keyboard", UnitPrice = 99, UnitsInStock = 128},
				new Product{ProductId = 6, CategoryId = 2, ProductName = "Mouse", UnitPrice = 75, UnitsInStock = 1},
			};
		}


		public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(Product product)
		{
			Product productToDelete = productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
			_products.Remove(productToDelete);
		}

		public List<Product> GetAll()
		{
			return _products;
		}

		public void Update(Product product)
		{
			Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
			productToUpdate.CategoryId = product.CategoryId;
			productToUpdate.ProductName = product.ProductName;
			productToUpdate.UnitPrice = product.UnitPrice;
			productToUpdate.UnitsInStock = product.UnitsInStock;
		}

		public List<Product> GetProductsByCategory(int categoryId)
		{
			return _products.Where(p => p.CategoryId == categoryId).ToList();
		}

		public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Product Get(Expression<Func<Product, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
