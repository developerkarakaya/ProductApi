using MediatR;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,Unit>
    {
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await UnitOfWork.GetReadRepository<Product>().GetAsync(s=>s.Id == request.Id && !s.IsDeleted);
            var map = Mapper.Map<Product,UpdateProductCommandRequest>(request);
            var productCategories = await UnitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(s => s.ProductId == product.Id);
            await UnitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            {
                await UnitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = categoryId
                });
            }
            await UnitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await UnitOfWork.SaveAsync();

            return Unit.Value;
        }

    }
}
