using Microsoft.AspNetCore.Http;
using NetCoreFrameworkWorkShop.Business.Abstract;
using NetCoreFrameworkWorkShop.Business.Constants;
using NetCoreFrameworkWorkShop.Business.ValidationRules.FluentValidation;
using NetCoreFrameworkWorkShop.Core.Aspects;
using NetCoreFrameworkWorkShop.Core.Aspects.Autofac.Caching;
using NetCoreFrameworkWorkShop.Core.Aspects.Autofac.Exception;
using NetCoreFrameworkWorkShop.Core.Aspects.Autofac.Logging;
using NetCoreFrameworkWorkShop.Core.Aspects.Autofac.Validation;
using NetCoreFrameworkWorkShop.Core.Aspects.Transaction;
using NetCoreFrameworkWorkShop.Core.CrossCuttingConcerns.Logging.Log4Net;
using NetCoreFrameworkWorkShop.Core.Utilities.Results;
using NetCoreFrameworkWorkShop.DataAccess.Abstract;
using NetCoreFrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator), Priorty = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(message: Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(message: Messages.ProductDeleted);
        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(message: Messages.ProductUpdated);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.FirstOrDefault(p => p.ProductID == productId));
        }

       // [SecuredOpeartion(new string[]{ "Product.List" })]
        [PerformanceAspect(5)]
        public IDataResult<IList<Product>> GetList()
        {
            return new SuccessDataResult<IList<Product>>(_productDal.GetList().ToList());
        }

       // [CacheAspect(duration:10)]
        [LogAspect(typeof(FileLogger))]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<IList<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
