using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class complaintMap : EntityTypeConfiguration<complaint>
    {
        public complaintMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Description)
                .HasMaxLength(255);


            this.Property(t => t.Subject)
                .HasMaxLength(255);

            this.Property(t => t.importanceLvl)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("complaint");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.importanceLvl).HasColumnName("Importance");
            this.Property(t => t.creationDate).HasColumnName("CreationDate");
            this.Property(t => t.MyUser_idUser).HasColumnName("MyUser_idUser");
            this.Property(t => t.gere).HasColumnName("Managed");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.complaints)
                .HasForeignKey(d => d.MyUser_idUser);

        }
    }
}
