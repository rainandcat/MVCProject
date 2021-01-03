using MVCProject.Models;
using MVCProject.Models.Repository;
using MVCProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service
{
    public class CategoryService: BaseService,ICategoryService
    {
        public CategoryService(BaseDbContext db, RepositoryWrapper repository) : base(db, repository)
        {
        }
        public IResult Create(CategoriesModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                instance.CategoryID = 0;
                _repository.categories.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(CategoriesModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                _repository.categories.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int categoryID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(categoryID))
            {
                result.Message = "資料不存在";
            }

            try
            {
                var instance = this.GetByID(categoryID);
                _repository.categories.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int categoryID)
        {
            return _repository.categories.GetAll().Any(x => x.CategoryID == categoryID);
        }

        public CategoriesModel GetByID(int categoryID)
        {
            return _repository.categories.Get(x => x.CategoryID == categoryID);
        }

        public IEnumerable<CategoriesModel> GetAll()
        {
            return _repository.categories.GetAll();
        }
    }
}
