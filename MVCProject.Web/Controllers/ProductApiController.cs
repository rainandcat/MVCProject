using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Service;
using MVCProject.Service.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCProject.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductApiController : BaseController
    {
        public ProductApiController(BaseDbContext db, ServiceWrapper service) : base(db, service)
        {
        }

        [HttpGet]
        public IEnumerable<ProductsViewModel> Get()
        {
            return _service.productService.GetAll();
        }

        [HttpGet("{id}")]
        public ProductsViewModel Get(int id)
        {
            return _service.productService.GetByID(id); ;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductsViewModel instance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result= _service.productService.Create(instance);
            if (!result.Success)
            {
                string ErrorMsg = "新增失敗";
                ModelState.AddModelError("msg", ErrorMsg);
                return BadRequest(ModelState);
            }

            return Ok(new { msg = "新增成功" });
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProductsViewModel instance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _service.productService.Update(instance);
            if (!result.Success)
            {
                string ErrorMsg = "修改失敗";
                ModelState.AddModelError("msg", ErrorMsg);
                return BadRequest(ModelState);
            }
            return Ok(new { msg = "修改成功" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var result = _service.productService.Delete(id);
            if (!result.Success)
            {
                string ErrorMsg = "刪除錯誤";
                ModelState.AddModelError("msg", ErrorMsg);
                return BadRequest(ModelState);
            }

            return Ok(new { msg = "刪除成功" });
        }
    }
}
