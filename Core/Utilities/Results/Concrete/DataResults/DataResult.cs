using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.VoidResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete.DataResults
{
	public class DataResult<T> : Result, IDataResult<T>
	{

		public DataResult(T data, bool success, string message):base(success,message)
		{
			Data = data;
		}

		public DataResult(T data, bool success) : base(success)
		{
			Data = data;
		}

		public T Data { get; }
	}
}
