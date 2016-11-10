using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.idUser);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.adress)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.fName)
                .HasMaxLength(255);

            this.Property(t => t.image)
                .HasMaxLength(255);

            this.Property(t => t.lName)
                .HasMaxLength(255);

            this.Property(t => t.login)
                .HasMaxLength(255);

            this.Property(t => t.pwd)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("users");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.AccountState).HasColumnName("AccountState");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.age).HasColumnName("age");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.fName).HasColumnName("fName");
            this.Property(t => t.image).HasColumnName("image");
            this.Property(t => t.lName).HasColumnName("lName");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.pwd).HasColumnName("pwd");
            this.Property(t => t.attachement_file).HasColumnName("attachement_file");
            this.Property(t => t.MyOrganization_id).HasColumnName("MyOrganization_id");

            // Relationships
            this.HasOptional(t => t.organization)
                .WithMany(t => t.users)
                .HasForeignKey(d => d.MyOrganization_id);

        }
    }
}
