using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Persistence.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(ss => ss.Name).HasMaxLength(256);

            var now = new DateTime(2026, 01, 22);

            Category category1 = new Category
            {
                Id = 1,
                Name = "Elektronik",
                ParentId = 0,
                Priorty = 1,
                CreatedDate = now,
                IsDeleted = false,
            };

            Category category2 = new Category
            {
                Id = 2,
                Name = "Moda",
                ParentId = 0,
                Priorty = 2,
                CreatedDate = now,
                IsDeleted = false,
            };

            Category parent1 = new Category
            {
                Id = 3,
                Name = "Bilgisayar",
                ParentId = 1,
                Priorty = 1,
                CreatedDate = now,
                IsDeleted = false,
            };
            Category parent2 = new Category
            {
                Id = 4,
                Name = "Kadın",
                ParentId = 2,
                Priorty = 1,
                CreatedDate = now,
                IsDeleted = false,
            };
            builder.HasData(category1, category2, parent1, parent2);

        }
    }
}
