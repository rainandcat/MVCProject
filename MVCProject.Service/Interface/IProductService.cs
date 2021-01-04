using MVCProject.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service.Interface
{
    public interface IProductService
    {
        IResult Create(ProductsViewModel instance);

        IResult Update(ProductsViewModel instance);

        IResult Delete(int categoryID);

        bool IsExists(int categoryID);

        ProductsViewModel GetByID(int categoryID);

        IEnumerable<ProductsViewModel> GetAll();
    }
}
