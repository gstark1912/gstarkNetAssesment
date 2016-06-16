using System;
using DAL.Context.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class RepositoryUserCard : Repository<UserCard>, IRepositoryUserCard
    {
        public RepositoryUserCard(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public UserCard GetByCardNumber(long cardNumber)
        {
            return dbSet.Where(u => u.CardNumber == cardNumber).FirstOrDefault();
        }
    }
}
