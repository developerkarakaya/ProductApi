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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            Faker faker = new("tr");

            Product product1 = new Product
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Discount = faker.Random.Decimal(1, 10),
                BrandId = 1,
                Price = Convert.ToDecimal(faker.Commerce.Price(100, 1000)),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Brand = null!
            };

            Product product2 = new Product
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Discount = faker.Random.Decimal(1, 10),
                BrandId = 3,
                Price = Convert.ToDecimal(faker.Commerce.Price(100, 1000)),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Brand = null!
            };

            builder.HasData(product1, product2);
        }
    }
}
