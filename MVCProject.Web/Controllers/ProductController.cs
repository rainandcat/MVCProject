using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCProject.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(BaseDbContext db, ServiceWrapper service) : base(db, service)
        {
        }

       
    }
}
