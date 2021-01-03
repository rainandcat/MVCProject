using MVCProject.Models;
using MVCProject.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service.Interface
{
    public interface ICategoryService
    {
        IResult Create(CategoriesViewModel instance);

        IResult Update(CategoriesViewModel instance);

        IResult Delete(int categoryID);

        bool IsExists(int categoryID);

        CategoriesViewModel GetByID(int categoryID);

        IEnumerable<CategoriesViewModel> GetAll();
    }
}
