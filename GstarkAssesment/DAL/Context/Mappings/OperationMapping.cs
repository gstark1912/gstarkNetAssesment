using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Mappings
{
    public class OperationMapping : EntityTypeConfiguration<Operation>
    {
        public OperationMapping()
        {
            this.ToTable("Operation");
            this.HasKey(x => x.IDOperation);
            this.Property(e => e.IDOperation).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(e => e.IDOperationCode).IsRequired();
            this.Property(e => e.IDCard).IsRequired();
            this.Property(e => e.Amount).IsOptional();
            this.Property(e => e.TimeStamp).IsRequired();
        }
    }
}
