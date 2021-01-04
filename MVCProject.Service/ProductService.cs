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
        public ProductService(BaseDbContext db, RepositoryWrapper repository) : base(db, repository)
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
                var product = new ProductsModel();
                product.ProductID = 0;
                product.ProductID = instance.ProductID;
                product.ProductName = instance.ProductName;
                product.SupplierID = instance.SupplierID;
                product.CategoryID = instance.CategoryID;
                product.QuantityPerUnit = instance.QuantityPerUnit;
                product.UnitPrice = instance.UnitPrice;
                product.UnitsInStock = instance.UnitsInStock;
                product.UnitsOnOrder = instance.UnitsOnOrder;
                product.ReorderLevel = instance.ReorderLevel;
                product.Discontinued = instance.Discontinued;

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
                var product = new ProductsModel();
                product.ProductID = instance.ProductID;
                product.ProductName = instance.ProductName;
                product.SupplierID = instance.SupplierID;
                product.CategoryID = instance.CategoryID;
                product.QuantityPerUnit = instance.QuantityPerUnit;
                product.UnitPrice = instance.UnitPrice;
                product.UnitsInStock = instance.UnitsInStock;
                product.UnitsOnOrder = instance.UnitsOnOrder;
                product.ReorderLevel = instance.ReorderLevel;
                product.Discontinued = instance.Discontinued;

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
            var result = new ProductsViewModel();
            result.ProductID = product.ProductID;
            result.ProductName = product.ProductName;
            result.SupplierID = product.SupplierID;
            result.CategoryID = product.CategoryID;
            tmp.CategoryName = item.Category.CategoryName;
            result.QuantityPerUnit = product.QuantityPerUnit;
            result.UnitPrice = product.UnitPrice;
            result.UnitsInStock = product.UnitsInStock;
            result.UnitsOnOrder = product.UnitsOnOrder;
            result.ReorderLevel = product.ReorderLevel;
            result.Discontinued = product.Discontinued;

            return result;
        }

        public IEnumerable<ProductsViewModel> GetAll()
        {
            var products = _repository.products.GetAllInclude("Category");
            var result = new List<ProductsViewModel>();
            foreach (var item in products)
            {
                var tmp = new ProductsViewModel();
                tmp.ProductID = item.ProductID;
                tmp.ProductName = item.ProductName;
                tmp.SupplierID = item.SupplierID;
                tmp.CategoryID = item.CategoryID;
                tmp.CategoryName = item.Category.CategoryName;
                tmp.QuantityPerUnit = item.QuantityPerUnit;
                tmp.UnitPrice = item.UnitPrice;
                tmp.UnitsInStock = item.UnitsInStock;
                tmp.UnitsOnOrder = item.UnitsOnOrder;
                tmp.ReorderLevel = item.ReorderLevel;
                tmp.Discontinued = item.Discontinued;
                result.Add(tmp);
            }
            return result;
        }
    }
}
