using BLL.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceOperation : IServiceOperation
    {
        private readonly IRepositoryOperation _repository;
        public ServiceOperation(IRepositoryOperation repository)
        {
            _repository = repository;
        }
        
    }
}
