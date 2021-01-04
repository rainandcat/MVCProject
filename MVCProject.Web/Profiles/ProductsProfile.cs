using AutoMapper;
using MVCProject.Models;
using MVCProject.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service.Profiles
{
    public class ProductsProfile: Profile
    {
        public ProductsProfile() 
        {
            CreateMap<ProductsModel, ProductsViewModel>()
                .ForMember(a => a.ProductID, a => a.MapFrom(b => b.ProductID))
                .ForMember(a => a.ProductName, a => a.MapFrom(b => b.ProductName))
                .ForMember(a => a.SupplierID, a => a.MapFrom(b => b.SupplierID))
                .ForMember(a => a.CategoryID, a => a.MapFrom(b => b.CategoryID))
                .ForMember(a => a.QuantityPerUnit, a => a.MapFrom(b => b.QuantityPerUnit))
                .ForMember(a => a.UnitPrice, a => a.MapFrom(b => b.UnitPrice))
                .ForMember(a => a.UnitsInStock, a => a.MapFrom(b => b.UnitsInStock))
                .ForMember(a => a.UnitsOnOrder, a => a.MapFrom(b => b.UnitsOnOrder))
                .ForMember(a => a.ReorderLevel, a => a.MapFrom(b => b.ReorderLevel))
                .ForMember(a => a.Discontinued, a => a.MapFrom(b => b.Discontinued))
                .ForMember(a => a.CategoryName, a => a.Ignore());

            CreateMap<ProductsViewModel, ProductsModel>()
                .ForMember(a => a.ProductID, a => a.MapFrom(b => b.ProductID))
                .ForMember(a => a.ProductName, a => a.MapFrom(b => b.ProductName))
                .ForMember(a => a.SupplierID, a => a.MapFrom(b => b.SupplierID))
                .ForMember(a => a.CategoryID, a => a.MapFrom(b => b.CategoryID))
                .ForMember(a => a.QuantityPerUnit, a => a.MapFrom(b => b.QuantityPerUnit))
                .ForMember(a => a.UnitPrice, a => a.MapFrom(b => b.UnitPrice))
                .ForMember(a => a.UnitsInStock, a => a.MapFrom(b => b.UnitsInStock))
                .ForMember(a => a.UnitsOnOrder, a => a.MapFrom(b => b.UnitsOnOrder))
                .ForMember(a => a.ReorderLevel, a => a.MapFrom(b => b.ReorderLevel))
                .ForMember(a => a.Discontinued, a => a.MapFrom(b => b.Discontinued));
        }
    }
}
