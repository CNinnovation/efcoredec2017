using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ModelsSample.MenuDefinitions;

namespace ModelsSample
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {           
            builder.Property(m => m.Title).HasField(TitleField);
            builder.Property(m => m.Subtitle).HasMaxLength(60).IsRequired(false);
        }
    }
}
