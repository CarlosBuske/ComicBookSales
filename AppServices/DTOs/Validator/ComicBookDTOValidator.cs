using AppServices.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.Validator
{
    public class ComicBookDTOValidator : AbstractValidator<ComicBookDTO>
    {
        public ComicBookDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Titulo deve ser informado!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição deve ser informado!");

            RuleFor(x => x.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("Autor deve ser informado!");

            RuleFor(x => x.PublicationDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data publicação deve ser informada!");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Preço deve ser informado!");
            
            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Estoque deve ser informado!");
        }
    }
}
