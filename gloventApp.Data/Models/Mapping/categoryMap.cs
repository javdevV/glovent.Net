using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class categoryMap : EntityTypeConfiguration<category>
    {
        public categoryMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

          


            this.Property(t => t.Libelle)
                .HasMaxLength(255);


            this.Property(t => t.image);




            // Table & Column Mappings
            this.ToTable("category");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Libelle).HasColumnName("Libelle");
            this.Property(t => t.image).HasColumnName("image");



        }
    }
}
