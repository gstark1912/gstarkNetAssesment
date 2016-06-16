using BLL.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Entities.Enums;

namespace BLL.Services
{
    public class ServiceOperation : IServiceOperation
    {
        private readonly IRepositoryOperation _repositoryOperation;
        private readonly IRepositoryUserCard _repositoryUserCard;
        public ServiceOperation(IRepositoryOperation repositoryOperation, IRepositoryUserCard repositoryUserCard)
        {
            _repositoryOperation = repositoryOperation;
            _repositoryUserCard = repositoryUserCard;
        }

        public DTOOperationsReport GetAllOperations(long cardNumber)
        {
            var user = _repositoryUserCard.GetByCardNumber(cardNumber);
            return new DTOOperationsReport
            {
                results = _repositoryOperation.GetAllFromUser(cardNumber),
                UserCard = user
            };
        }

        public decimal GetBalance(long cardNumber)
        {
            var user = _repositoryUserCard.GetByCardNumber(cardNumber);
            Operation operation = new Operation { IDCard = user.IDUserCard, IDOperationCode = Convert.ToInt32(EntitiesEnums.OperationCode.Balance) };
            _repositoryOperation.Insert(operation);
            _repositoryOperation.SaveChanges();
            return user.Balance;
        }

        public DTOWithdrawResult WithDraw(long cardNumber, decimal amount)
        {
            var user = _repositoryUserCard.GetByCardNumber(cardNumber);
            if (user.Balance < amount)
                return new DTOWithdrawResult { Success = false, Message = "Your account balance is lower than " + amount };
            else
            {
                user.Balance -= amount;
                _repositoryUserCard.Update(user);
                _repositoryUserCard.SaveChanges();

                Operation operation = new Operation { IDCard = user.IDUserCard, IDOperationCode = Convert.ToInt32(EntitiesEnums.OperationCode.Withdraw), Amount = amount };
                _repositoryOperation.Insert(operation);
                _repositoryOperation.SaveChanges();
                return new DTOWithdrawResult { Success = true };
            }
        }
    }
}
