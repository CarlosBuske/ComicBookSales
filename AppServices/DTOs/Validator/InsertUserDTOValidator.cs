using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.Validator
{
    public class InsertUserDTOValidator : AbstractValidator<InsertUserDTO>
    {
        public InsertUserDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Senha deve ser informada!");

            RuleFor(x => x.IdUserType)
                .NotEmpty()
                .NotNull()
                .WithMessage("Tipo usuario deve ser informada!");
        }
    }
}
