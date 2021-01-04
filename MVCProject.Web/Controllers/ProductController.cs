using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Service;


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
            return View(result);
        }
    }
}
