using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service.Interface
{
    public interface ICategoryService
    {
        IResult Create(CategoriesModel instance);

        IResult Update(CategoriesModel instance);

        IResult Delete(int categoryID);

        bool IsExists(int categoryID);

        CategoriesModel GetByID(int categoryID);

        IEnumerable<CategoriesModel> GetAll();
    }
}
