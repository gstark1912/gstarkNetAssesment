using System;
using System.Collections.Generic;
using DAL.Context.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class RepositoryOperation : Repository<Operation>, IRepositoryOperation
    {
        public RepositoryOperation(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<Operation> GetAllFromUser(long cardNumber)
        {
            return dbSet
                .Include("OperationCode")
                .Include("UserCard")
                .Where(o => o.UserCard.CardNumber == cardNumber)
                .ToList();
        }
    }
}
