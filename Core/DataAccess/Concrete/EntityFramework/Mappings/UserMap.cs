using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Core.DataAccess.Concrete.EntityFramework.Mappings
{
    //EntityFramework 6.0.8
    //EntityFramework Relational 6.0.8
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.FirstName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(u => u.LastName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("varchar(250)").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnType("varbinary(500)").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("varbinary(500)").IsRequired();
            builder.Property(u => u.Status).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.Deleted).IsRequired();


            //tablo
            builder.ToTable("Users");

        }
    }
}
