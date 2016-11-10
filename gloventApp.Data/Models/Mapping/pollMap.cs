using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class pollMap : EntityTypeConfiguration<poll>
    {
        public pollMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Subject)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("poll");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.MyPresident_idUser).HasColumnName("MyPresident_idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.polls)
                .HasForeignKey(d => d.MyPresident_idUser);

        }
    }
}
