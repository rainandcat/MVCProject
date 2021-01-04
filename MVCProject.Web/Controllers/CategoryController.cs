using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(BaseDbContext db, ServiceWrapper service) : base(db, service)
        {
        }

        public ActionResult Index()
        {
            var result = _service.categoryService.GetAll();
            return View(result);
        }

        public IActionResult GetImage(int id)
        {
            var category = _service.categoryService.GetByID(id);
            if (category != null && category.Picture != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    byte[] image = category.Picture;
                    ms.Write(image, 78, image.Length - 78);
                    return File(ms.ToArray(), "image/jpeg");
                }
            }
            return new EmptyResult();
        }
    }
}
