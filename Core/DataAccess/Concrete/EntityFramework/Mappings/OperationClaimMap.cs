using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Core.DataAccess.Concrete.EntityFramework.Mappings
{
    
    //EntityFramework 6.0.8
    //EntityFramework Relational 6.0.8
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.Name).HasColumnType("varchar(50)").IsRequired();;

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.Deleted).IsRequired();


            //tablo
            builder.ToTable("OperationClaims");
        }
    }
}
