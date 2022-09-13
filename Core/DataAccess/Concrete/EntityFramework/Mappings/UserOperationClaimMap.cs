using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.DataAccess.Concrete.EntityFramework.Mappings
{
    //EntityFramework 6.0.8
    //EntityFramework Relational 6.0.8
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.Deleted).IsRequired();

            //ilişki
            builder.HasOne<User>(uo => uo.User).WithMany(u => u.UserOperationClaims).HasForeignKey(uo => uo.UserId);
            builder.HasOne<OperationClaim>(uo => uo.OperationClaim).WithMany(u => u.UserOperationClaims).HasForeignKey(uo => uo.OperationClaimId);

            //tablo
            builder.ToTable("UserOperationClaims");

        }
    }
}
