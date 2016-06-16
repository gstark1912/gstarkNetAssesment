using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using Entities.Entities;

namespace BLL.Services
{
    public class ServiceLogin : IServiceLogin
    {
        IRepositoryUserCard _repositoryUserCard;
        IRepositoryOperationCode _repositoryOperationCode;
        public ServiceLogin(IRepositoryUserCard repositoryUserCard, IRepositoryOperationCode repositoryOperationCode)
        {
            _repositoryUserCard = repositoryUserCard;
            _repositoryOperationCode = repositoryOperationCode;
        }

        public DTOLoginResult IsCardNumberInvalidOrBlocked(long cardNumber)
        {
            FirstTimeCheck();
            var entity = _repositoryUserCard.GetByCardNumber(cardNumber);
            if (entity == null)
                return new DTOLoginResult { Sucess = false, Message = "Inexisting Card Number" };
            else
            {
                if (entity.Blocked)
                    return new DTOLoginResult { Sucess = false, Blocked = true };
                else
                    return new DTOLoginResult { Sucess = true };
            }
        }

        private void FirstTimeCheck()
        {
            var users = _repositoryUserCard.GetAll();
            if (users.Count() == 0)
            {
                _repositoryUserCard.Insert(new UserCard { Balance = 100, CardNumber = 1111111111111111, LoginAttempts = 0, Blocked = false, Password = 1234 });
                _repositoryUserCard.Insert(new UserCard { Balance = 0, CardNumber = 1111111111111112, LoginAttempts = 0, Blocked = false, Password = 1234 });
                _repositoryUserCard.Insert(new UserCard { Balance = 200, CardNumber = 1111111111111113, LoginAttempts = 0, Blocked = false, Password = 1234 });
                _repositoryUserCard.SaveChanges();
            }
            var codes = _repositoryOperationCode.GetAll();
            if (codes.Count() == 0)
            {
                _repositoryOperationCode.Insert(new OperationCode { Description = "Balance" });
                _repositoryOperationCode.Insert(new OperationCode { Description = "Withdraw" });
                _repositoryOperationCode.SaveChanges();
            }
        }

        public DTOLoginResult Login(long cardNumber, int password)
        {
            var entity = _repositoryUserCard.GetByCardNumber(cardNumber);
            if (entity == null)
                return new DTOLoginResult { Sucess = false };
            else
            {
                if (entity.Blocked) return new DTOLoginResult { Sucess = false, Blocked = true };

                if (entity.Password == password)
                {
                    entity.LoginAttempts = 0;
                    _repositoryUserCard.Update(entity);
                    _repositoryUserCard.SaveChanges();
                    return new DTOLoginResult { Sucess = true, CardNumber = entity.CardNumber };
                }
                else
                {
                    entity.LoginAttempts++;
                    entity.Blocked = entity.LoginAttempts >= 4;
                    _repositoryUserCard.Update(entity);
                    _repositoryUserCard.SaveChanges();
                    return new DTOLoginResult { Sucess = false, Blocked = entity.Blocked, Message = "Wrong password. Please try again." };
                }
            }
        }
    }
}
