using DAL.Context.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RepositoryOperation : Repository<Operation>, IRepositoryOperation
    {
        public RepositoryOperation(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }        
    }
}
