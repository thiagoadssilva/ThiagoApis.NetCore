using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiDotNet6.Application.DTOs.Validations
{
    // Classe responsável por toda validação dos campos
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name deve ser informado");
            RuleFor(x => x.Document).NotEmpty().NotNull().WithMessage("Document deve ser informado");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("Phone deve ser informado");
        }
    }
}
