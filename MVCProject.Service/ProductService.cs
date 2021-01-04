using AutoMapper;
using MVCProject.Models;
using MVCProject.Models.Repository;
using MVCProject.Service.Interface;
using MVCProject.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCProject.Service
{
    public class ProductService: BaseService, IProductService
    {
        public ProductService(BaseDbContext db, RepositoryWrapper repository, IMapper mapper) : base(db, repository, mapper)
        {
        }

        public IResult Create(ProductsViewModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                var product = _mapper.Map<ProductsViewModel, ProductsModel>(instance);
                product.ProductID = 0;

                _repository.products.Create(product);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(ProductsViewModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                var product = _mapper.Map<ProductsViewModel, ProductsModel>(instance);

                _repository.products.Update(product);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int productID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(productID))
            {
                result.Message = "資料不存在";
            }

            try
            {
                var instance = _repository.products.Get(x => x.ProductID == productID);
                _repository.products.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int productID)
        {
            return _repository.products.GetAll().Any(x => x.ProductID == productID);
        }

        public ProductsViewModel GetByID(int productID)
        {
            var product = _repository.products.Get(x => x.ProductID == productID);
            return _mapper.Map<ProductsModel, ProductsViewModel>(product);
        }

        public IEnumerable<ProductsViewModel> GetAll()
        {
            var products = _repository.products.GetAllInclude("Category");
            return _mapper.Map<IEnumerable<ProductsModel>, IEnumerable<ProductsViewModel>>(products);
        }
    }
}
