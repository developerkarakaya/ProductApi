using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommandRequest>
    {

        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithName("Ürün Adı")
                .MaximumLength(150);

            RuleFor(x => x.Description)
         .NotEmpty().WithName("Açıklama")
         .MaximumLength(500);

            RuleFor(x => x.BrandId)
                .NotEmpty().WithName("Marka ")
                .GreaterThan(0);
            RuleFor(x => x.Price)
                .NotEmpty().WithName("Fiyat")
                .GreaterThan(0);

            RuleFor(x => x.CategoryIds)
                .NotEmpty().WithName("Kategoriler");


        }
    }
}
