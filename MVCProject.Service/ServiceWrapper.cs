using AutoMapper;
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
        protected readonly IMapper _mapper;
        private ICategoryService _categoryService;
        private IProductService _productService;

        public ServiceWrapper(BaseDbContext db, RepositoryWrapper repository, IMapper mapper)
        {
            this._db = db;
            this._repository = repository;
            this._mapper = mapper;
        }
        public ICategoryService categoryService => _categoryService = _categoryService ?? new CategoryService(_db, _repository, _mapper);
        public IProductService productService => _productService = _productService ?? new ProductService(_db, _repository, _mapper);
    }
}
