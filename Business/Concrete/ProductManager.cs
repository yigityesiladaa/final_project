using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}
		public List<Product> GetAll()
		{
			//Codes (For Example Check Authority)
			return _productDal.GetAll();
		}

		public List<Product> GetAllByCategoryId(int id)
		{
			return _productDal.GetAll(p=> p.CategoryId == id);
		}

		public List<Product> GetAllByUnitPrice(decimal min, decimal max)
		{
			return _productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min);
		}
	}
}
