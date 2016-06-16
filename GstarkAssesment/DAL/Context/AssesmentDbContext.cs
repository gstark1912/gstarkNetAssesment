using DAL.Context.Interfaces;
using DAL.Context.Mappings;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AssesmentDbContext : DbContext
    {
        #region Properties

        public IDbSet<OperationCode> OperationCode { get; set; }
        public IDbSet<Operation> Operation { get; set; }
        public IDbSet<UserCard> UserCard { get; set; }

        #endregion

        #region Constructors

        public AssesmentDbContext()
            : base("name=DefaultConnection")
        {
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserCardMapping());
            modelBuilder.Configurations.Add(new OperationMapping());
            modelBuilder.Configurations.Add(new OperationCodeMapping());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
