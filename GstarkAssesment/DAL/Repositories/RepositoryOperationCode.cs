using System;
using System.Collections.Generic;
using DAL.Context.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class RepositoryOperationCode : Repository<OperationCode>, IRepositoryOperationCode
    {
        public RepositoryOperationCode(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
