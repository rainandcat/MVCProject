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
        public ServiceWrapper(BaseDbContext db, RepositoryWrapper repository)
        {
            this._db = db;
            this._repository = repository;
        }
        public ICategoryService categoryService => _categoryService = _categoryService ?? new CategoryService(_db, _repository);
    }
}
