using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        AssesmentDbContext DbContext { get; }
        int Save();
    }
}
