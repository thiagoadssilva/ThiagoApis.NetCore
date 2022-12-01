using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiDotNet6.Application.DTOs.Validations
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(c => c.CodErp).NotEmpty().NotNull().WithMessage("CodErp deve ser informado");
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Nome deve ser informado");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("Valor deve ser maior que 0");
        }
    }
}
