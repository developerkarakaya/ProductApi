using MediatR;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        public IUnitOfWork UnitOfWork { get; }

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);
            await UnitOfWork.GetWriteRepository<Product>().AddAsync(product);
            var result = await UnitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Product could not be created");
            }
            else
            {
                if (request.CategoryIds != null && request.CategoryIds.Any())
                {
                    foreach (var categoryId in request.CategoryIds)
                    {
                        ProductCategory productCategory = new()
                        {
                            ProductId = product.Id,
                            CategoryId = categoryId
                        };
                        await UnitOfWork.GetWriteRepository<ProductCategory>().AddAsync(productCategory);
                    }
                   await UnitOfWork.SaveAsync();
                }
            }
        }
    }
}
