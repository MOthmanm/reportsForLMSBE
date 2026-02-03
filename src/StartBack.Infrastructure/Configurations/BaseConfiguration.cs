using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.BaseTables;
using Entities.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models.BaseConfiguration
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
     where TEntity : BaseTable
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(b => b.InsertUserCode)
                  .HasMaxLength(100);

            builder.Property(b => b.InsertDate)
                .HasDefaultValueSql("NOW()").IsRequired()
                .HasComment("تاريخ الإنشاء");

            builder.Property(b => b.UpdateUserCode)
                .HasMaxLength(100);

            builder.Property(b => b.LastUpdate)
                .HasComment("تاريخ التحديث");

            builder.Property(b => b.IsDeleted)
                .IsRequired();
            //builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(b => b.DeleteUserCode)
                .HasMaxLength(100);

            builder.Property(b => b.DeleteDate)
               .HasComment("تاريخ الحذف");



        }

    }
}
