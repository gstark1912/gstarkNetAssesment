using DAL.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private AssesmentDbContext context;

        public AssesmentDbContext DbContext
        {
            get
            {
                if (context == null)
                {
                    context = new AssesmentDbContext();
                }
                return context;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
