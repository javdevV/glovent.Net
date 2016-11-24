using gloventApp.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace gloventApp.Data.Models.Mapping
{
    public class organizationMap : EntityTypeConfiguration<organization>
    {
        public organizationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);
            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);
            this.Property(t => t.type)
                .HasMaxLength(255);
            this.Property(t => t.Location)
                .HasMaxLength(255);
            // Table & Column Mappings
            this.ToTable("organization");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.Location).HasColumnName("location");

            // Relationships
            this.HasMany(t => t.users1)
                .WithMany(t => t.organizations)
                .Map(m =>
                {
                    m.ToTable("organization_users");
                    m.MapLeftKey("listOrganization_id");
                    m.MapRightKey("listUsers_idUser");
                });
            this.HasOptional(e => e.President).WithOptionalPrincipal(f => f.myOrganization);
            this.HasMany(e => e.events).WithOptional(f => f.organization);
        }
    }
}