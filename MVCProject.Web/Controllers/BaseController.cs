using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public readonly BaseDbContext db;

        protected BaseController(BaseDbContext db)
        {
            this.db = db;
        }
    }
}
