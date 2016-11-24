using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class eventMap : EntityTypeConfiguration<evente>
    {
        public eventMap()
        {
            // Primary Key
            this.HasKey(t => t.idEvent);

            // Properties
            this.Property(t => t.localisation)
                .HasMaxLength(255);

            this.Property(t => t.nameEvent)
                .HasMaxLength(255);

            this.Property(t => t.theme)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("events");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.avaibility).HasColumnName("avaibility");
            
            this.Property(t => t.dateEvent).HasColumnName("dateEvent");
            this.Property(t => t.localisation).HasColumnName("localisation");
            this.Property(t => t.nameEvent).HasColumnName("nameEvent");
            this.Property(t => t.theme).HasColumnName("theme");
            this.Property(t => t.MyCategory_id).HasColumnName("MyCategory_id");
            //this.Property(t => t.MyOrganization_id1).HasColumnName("MyOrganization_id1");
            this.Property(t => t.MyRegistrationForm_id).HasColumnName("MyRegistrationForm_id");
            this.Property(t => t.nombreParticipant).HasColumnName("nombreParticipant");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.lapti).HasColumnName("lapti");
            this.Property(t => t.longi).HasColumnName("longi");

            // Relationships
            this.HasMany(t => t.users)
                .WithMany(t => t.events)
                .Map(m =>
                    {
                        m.ToTable("events_users");
                        m.MapLeftKey("listeE_idEvent");
                        m.MapRightKey("listeP_idUser");
                    });

            this.HasOptional(t => t.category)
                .WithMany(t => t.events)
                .HasForeignKey(d => d.MyCategory_id);
            this.HasOptional(t => t.registrationform)
                .WithMany(t => t.events)
                .HasForeignKey(d => d.MyRegistrationForm_id);
            //this.HasOptional(t => t.organization)
            //    .WithMany(t => t.events)
            //    .HasForeignKey(d => d.MyOrganization_id1);

        }
    }
}
