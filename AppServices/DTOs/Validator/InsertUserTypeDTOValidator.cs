using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.Validator
{
    public class InsertUserTypeDTOValidator : AbstractValidator<InsertUserTypeDTO>
    {
        public InsertUserTypeDTOValidator()
        {
            RuleFor(x => x.Cod)
                .NotEmpty()
                .NotNull()
                .WithMessage("Codigo deve ser informado!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição deve ser informado!");
        }
    }
}
