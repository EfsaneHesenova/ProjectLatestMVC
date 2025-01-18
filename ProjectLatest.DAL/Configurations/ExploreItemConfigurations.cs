using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.DAL.Configurations
{
    public class ExploreItemConfigurations : IEntityTypeConfiguration<ExploreItem>
    {

        public void Configure(EntityTypeBuilder<ExploreItem> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.ExploreItems)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
               .IsRequired()
               .HasMaxLength(50);
        }
    }
}
