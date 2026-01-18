using MediatR;
using ProductApi.Application.Features.Products.Rules;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
    {
        public IUnitOfWork UnitOfWork { get; }
        public ProductRules ProductRules { get; }

        public CreateProductCommandHandler(IUnitOfWork unitOfWork,ProductRules productRules)
        {
            UnitOfWork = unitOfWork;
            ProductRules = productRules;
        }


        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            IList<Product> products = await UnitOfWork.GetReadRepository<Product>()
                .GetAllAsync();
            await ProductRules.ProductTitleMustNotBeSame(products,request.Title);



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

            return Unit.Value;
        }
    }
}
