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
    internal class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");

            Detail detail1 = new Detail
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            Detail detail2 = new Detail
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail3 = new Detail
            {
                Id = 3,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };

            builder.HasData(detail1,detail2, detail3);
        }
    }
}
