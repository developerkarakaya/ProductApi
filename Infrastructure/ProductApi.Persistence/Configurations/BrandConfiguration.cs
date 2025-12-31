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
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(ss => ss.Name).HasMaxLength(256);

            Faker faker = new("tr");

            var brands = Enumerable.Range(1, 10).Select(i =>
                new Brand(faker.Company.CompanyName())
                {
                    Id = i,
                    CreatedDate = DateTime.Now,
                    IsDeleted=false,
                    Name = faker.Commerce.Department(),
                }).ToList();

            builder.HasData(brands);
        }
    }
}
