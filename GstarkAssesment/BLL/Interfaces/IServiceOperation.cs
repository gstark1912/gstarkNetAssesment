using BLL.DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Interfaces
{
    public interface IServiceOperation
    {
        decimal GetBalance(long cardNumber);
        DTOWithdrawResult WithDraw(long v, decimal amount);
        DTOOperationsReport GetAllOperations(long v);
    }
}
