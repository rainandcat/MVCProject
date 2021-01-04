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

        public ActionResult Edit(int id)
        {
            var result = _service.productService.GetByID(id);
            this.CategoeriesList();
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(ProductsViewModel item)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ResultMessage = "輸入資料錯誤";
                return View(item);
            }

            var result = _service.productService.Update(item);
            if (result.Success) TempData["ResultMessage"] = String.Format("[{0}]成功修改", item.ProductName);
            else TempData["ResultMessage"] = String.Format("[{0}]失敗修改", item.ProductName);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = _service.productService.Delete(id);

            if (result.Success) TempData["ResultMessage"] = String.Format("成功刪除");
            else TempData["ResultMessage"] = String.Format("失敗刪除");

            return RedirectToAction("Index");
        }
    }
}
