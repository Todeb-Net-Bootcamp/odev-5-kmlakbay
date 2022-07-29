using Business.Constants;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductInsertDtoValidator : AbstractValidator<ProductInsertDto>
    {
        public ProductInsertDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(Messages.ProductNameNotEmpty);
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.GenderId).NotEmpty();

            RuleForEach(p => p.Details).ChildRules(child => child.RuleFor(x => x.UnitsInStock).GreaterThanOrEqualTo(0));
            RuleForEach(p => p.Details).ChildRules(child => child.RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0));
            RuleForEach(p => p.Details).ChildRules(child => child.RuleFor(x => x.SizeId).NotEmpty());

        }
    }
}
