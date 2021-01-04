using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using MVCProject.Service;
using MVCProject.Service.ViewModels;

namespace MVCProject.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(BaseDbContext db, ServiceWrapper service) : base(db, service)
        {
        }

        public ActionResult Index()
        {
            var result = _service.productService.GetAll();
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View(result);
        }

        public ActionResult Create()
        {
            this.CategoeriesList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductsViewModel item)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ResultMessage = "輸入資料錯誤";
                return View(item);
            }
            _service.productService.Create(item);
            TempData["ResultMessage"] = String.Format("[{0}]成功建立", item.ProductName);
            return RedirectToAction("Index");
        }

        public void CategoeriesList() {
            var categories = _service.categoryService.GetAll();
            var selectList = new List<SelectListItem>();
            foreach (var item in categories) {
                var tmp = new SelectListItem { Text = item.CategoryName, Value = item.CategoryID.ToString() };
                selectList.Add(tmp);
            }

            ViewBag.SelectList = selectList;
        }
    }
}
