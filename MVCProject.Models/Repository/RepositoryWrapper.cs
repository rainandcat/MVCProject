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

        public RepositoryWrapper(BaseDbContext db)
        {
            this._db = db;
        }

        public IRepository<CategoriesModel> categories => _categories = _categories ?? new GenericRepository<CategoriesModel>(_db);
    }
}
