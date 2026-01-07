using MediatR;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await UnitOfWork.GetReadRepository<Product>().GetAsync(s => s.Id == request.Id && !s.IsDeleted);
            product.IsDeleted = true;

            await UnitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await UnitOfWork.SaveAsync();
        }
    }
}
