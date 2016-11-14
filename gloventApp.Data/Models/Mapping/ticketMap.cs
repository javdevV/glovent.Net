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
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.prix).HasColumnName("prix");

            // Relationships
            this.HasRequired(t => t.evente)
                .WithMany(t => t.tickets)
                .HasForeignKey(d => d.idEvent);
            this.HasOptional(t => t.event1)
                .WithMany(t => t.tickets1)
                .HasForeignKey(d => d.MyEvent_idEvent);
            this.HasOptional(t => t.user)
                .WithMany(t => t.tickets)
                .HasForeignKey(d => d.MyPatricipant_idUser);
            this.HasRequired(t => t.user1)
                .WithMany(t => t.tickets1)
                .HasForeignKey(d => d.idUser);

        }
    }
}
