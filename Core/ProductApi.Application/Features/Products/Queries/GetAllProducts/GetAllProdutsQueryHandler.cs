using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApi.Application.DTOs;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProdutsQueryHandler : IRequestHandler<GetAllProdutsQueryRequest, IList<GetAllProdutsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllProdutsQueryHandler(IUnitOfWork _unitOfWork,IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<IList<GetAllProdutsQueryResponse>> Handle(GetAllProdutsQueryRequest request, CancellationToken cancellationToken)
        {
            var products =await unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x=>x.Include(b=>b.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());

             var map = mapper.Map<GetAllProdutsQueryResponse, Product>(products);
            
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);


            return map;
         }
    }
}
