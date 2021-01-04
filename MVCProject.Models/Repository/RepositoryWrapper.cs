using MVCProject.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Models.Repository
{
    public class RepositoryWrapper
    {
        private readonly BaseDbContext _db;
        private IRepository<CategoriesModel> _categories;
        private IRepository<ProductsModel> _products;

        public RepositoryWrapper(BaseDbContext db)
        {
            this._db = db;
        }

        public IRepository<CategoriesModel> categories => _categories = _categories ?? new GenericRepository<CategoriesModel>(_db);
        public IRepository<ProductsModel> products => _products = _products ?? new GenericRepository<ProductsModel>(_db);
    }
}
