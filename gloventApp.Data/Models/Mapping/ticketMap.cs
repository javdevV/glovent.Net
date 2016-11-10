using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class ticketMap : EntityTypeConfiguration<ticket>
    {
        public ticketMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ticket");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.discount).HasColumnName("discount");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.MyEvent_idEvent).HasColumnName("MyEvent_idEvent");
            this.Property(t => t.MyPatricipant_idUser).HasColumnName("MyPatricipant_idUser");

            // Relationships
            this.HasOptional(t => t.evente)
                .WithMany(t => t.tickets)
                .HasForeignKey(d => d.MyEvent_idEvent);
            this.HasOptional(t => t.user)
                .WithMany(t => t.tickets)
                .HasForeignKey(d => d.MyPatricipant_idUser);

        }
    }
}
