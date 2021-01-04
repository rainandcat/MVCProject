using MVCProject.Models;
using MVCProject.Models.Repository;
using MVCProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service
{
    public class ServiceWrapper
    {
        private readonly BaseDbContext _db;
        private RepositoryWrapper _repository;
        private ICategoryService _categoryService;
        private IProductService _productService;

        public ServiceWrapper(BaseDbContext db, RepositoryWrapper repository)
        {
            this._db = db;
            this._repository = repository;
        }
        public ICategoryService categoryService => _categoryService = _categoryService ?? new CategoryService(_db, _repository);
        public IProductService productService => _productService = _productService ?? new ProductService(_db, _repository);
    }
}
