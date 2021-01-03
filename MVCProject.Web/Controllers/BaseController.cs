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
    public abstract class BaseController : Controller
    {
        public readonly BaseDbContext db;
        public readonly ServiceWrapper _service;

        protected BaseController(BaseDbContext db, ServiceWrapper service)
        {
            this.db = db;
            this._service = service;
        }
    }
}
