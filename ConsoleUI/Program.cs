using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			ProductManager productManager = new ProductManager(new EfProductDal());

			foreach (var product in productManager.GetAllByUnitPrice(100, 300))
			{
				Console.WriteLine(product.ProductName);
			}
		}
	}
}
