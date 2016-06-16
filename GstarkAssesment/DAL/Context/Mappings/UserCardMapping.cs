using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Mappings
{
    public class UserCardMapping : EntityTypeConfiguration<UserCard>
    {
        public UserCardMapping()
        {
            this.ToTable("UserCard");
            this.HasKey(x => x.IDUserCard);
            this.Property(e => e.IDUserCard).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(e => e.CardNumber)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));
            this.Property(e => e.Password).IsRequired();
            this.Property(e => e.LoginAttempts).IsRequired();
            this.Property(e => e.Blocked).IsRequired();
            this.Property(e => e.Balance).IsRequired();
        }
    }
}
