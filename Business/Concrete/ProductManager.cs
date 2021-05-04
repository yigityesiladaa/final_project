using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.DataResults;
using Core.Utilities.Results.Concrete.VoidResults;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

		[ValidationAspect(typeof(ProductValidator))]
		public IResult Add(Product product)
		{
			_productDal.Add(product);
			return new Result(true, Messages.ProductAddedMessage);
		}

		public IDataResult<List<Product>> GetAll()
		{
			if(DateTime.Now.Hour == 22)
			{
				return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
		}

		public IDataResult<List<Product>> GetAllByCategoryId(int id)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
		}

		public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min));
		}

		public IDataResult<Product> GetById(int productId)
		{
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
		}

		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			if (DateTime.Now.Hour == 20)
			{
				return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
		}
	}
}
