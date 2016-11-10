using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class taskMap : EntityTypeConfiguration<task>
    {
        public taskMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("task");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.MyEvent_idEvent).HasColumnName("MyEvent_idEvent");
            this.Property(t => t.MyOrganizer_idUser).HasColumnName("MyOrganizer_idUser");

            // Relationships
            this.HasOptional(t => t.evente)
                .WithMany(t => t.tasks)
                .HasForeignKey(d => d.MyEvent_idEvent);
            this.HasOptional(t => t.user)
                .WithMany(t => t.tasks)
                .HasForeignKey(d => d.MyOrganizer_idUser);

        }
    }
}
