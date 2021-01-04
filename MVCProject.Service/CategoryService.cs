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
    public class CategoryService: BaseService,ICategoryService
    {
        public CategoryService(BaseDbContext db, RepositoryWrapper repository, IMapper mapper) : base(db, repository, mapper)
        {
        }
        public IResult Create(CategoriesViewModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                var category = new CategoriesModel();
                category.CategoryID = 0;
                category.CategoryName = instance.CategoryName;
                category.Description = instance.Description;
                category.Picture = instance.Picture;

                _repository.categories.Create(category);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(CategoriesViewModel instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                var category = new CategoriesModel();
                category.CategoryID = instance.CategoryID;
                category.CategoryName = instance.CategoryName;
                category.Description = instance.Description;
                category.Picture = instance.Picture;

                _repository.categories.Update(category);
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
                var instance = _repository.categories.Get(x => x.CategoryID == categoryID);
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

        public CategoriesViewModel GetByID(int categoryID)
        {
            var category = _repository.categories.Get(x => x.CategoryID == categoryID);
            var result = new CategoriesViewModel();
            result.CategoryID = category.CategoryID;
            result.CategoryName = category.CategoryName;
            result.Description = category.Description;
            result.Picture = category.Picture;
            return result;
        }

        public IEnumerable<CategoriesViewModel> GetAll()
        {
            var categories= _repository.categories.GetAll();
            var result = new List<CategoriesViewModel>();
            foreach (var item in categories) {
                var tmp = new CategoriesViewModel();
                tmp.CategoryID = item.CategoryID;
                tmp.CategoryName = item.CategoryName;
                tmp.Description = item.Description;
                tmp.Picture = item.Picture;
                result.Add(tmp);
            }
            return result;
        }
    }
}
