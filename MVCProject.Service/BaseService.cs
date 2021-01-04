using AutoMapper;
using MVCProject.Models;
using MVCProject.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service
{
    public abstract class BaseService
    {
        protected readonly BaseDbContext _db;
        protected readonly RepositoryWrapper _repository;
        protected readonly IMapper _mapper;

        public BaseService(BaseDbContext db, RepositoryWrapper repository, IMapper mapper)
        {
            this._db = db;
            this._repository = repository;
            this._mapper = mapper;
        }
    }
}
