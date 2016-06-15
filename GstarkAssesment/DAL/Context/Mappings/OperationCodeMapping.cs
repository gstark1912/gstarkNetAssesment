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
    public class OperationCodeMapping : EntityTypeConfiguration<OperationCode>
    {
        public OperationCodeMapping()
        {
            this.ToTable("OperationCode");
            this.HasKey(x => x.IDOperationCode);
            this.Property(e => e.IDOperationCode).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(e => e.Description).HasMaxLength(50).IsRequired();
        }
    }
}
