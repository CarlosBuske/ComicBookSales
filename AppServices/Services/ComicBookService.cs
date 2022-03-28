using AppServices.DTO;
using AppServices.DTOs;
using AppServices.DTOs.Validator;
using AppServices.Services.Interface;
using AppServices.Utility;
using AutoMapper;
using Domain.Entities;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class ComicBookService : IComicBookService
    {
        private readonly IComicBookRepository _comicbookRepository;
        private readonly IMapper _mapper;

        public ComicBookService(IMapper mapper, IComicBookRepository comicbookRepository)
        {
            _comicbookRepository = comicbookRepository;
            _mapper = mapper;
        }
        public async Task<ResultServices<ComicBookDTO>> ComicBookDetails(int id)
        {
            var comicbook = await _comicbookRepository.GetById(id);
            if (comicbook == null)
                return ResultServices.Fail<ComicBookDTO>("Quadrinho não encontrado!");

            return ResultServices.Ok<ComicBookDTO>(_mapper.Map<ComicBookDTO>(comicbook));
        }

        public async Task<ResultServices<ComicBookDTO>> CreateOrUpdateAsync(InsertComicBookDTO comicbookDTO)
        {
            if (comicbookDTO == null)
                return ResultServices.Fail<ComicBookDTO>("Objeto deve ser informado!");

            var result = new InsertComicBookDTOValidator().Validate(comicbookDTO);
            if (!result.IsValid)
                return ResultServices.RequestError<ComicBookDTO>("Problemas na validação!", result);

            var comicbook = _mapper.Map<ComicBook>(comicbookDTO);
            await _comicbookRepository.CreateOrUpdateAsync(comicbook);

            return ResultServices.Ok<ComicBookDTO>(_mapper.Map<ComicBookDTO>(comicbook));
        }

        public async Task<ResultServices<ResultListComicBookDTO>> ListAll(int Registers, int Page)
        {
            var objResult = new ResultListComicBookDTO() { ListComicBook = new List<ComicBookDTO>() };
            switch (Registers)
            {
                case 1:
                    Registers = 5;
                    break;

                case 2:
                    Registers = 10;
                    break;

                case 3:
                    Registers = 20;
                    break;

                case 4:
                    Registers = 50;
                    break;

                case 5:
                    Registers = 100;
                    break;

                default:
                    Registers = 5;
                    break;
            }

            var listComicBook = await _comicbookRepository.ListAll();
            if (listComicBook.Any())
            {
                int Totalregisters = listComicBook.Count;

                objResult.ListComicBook = _mapper.Map<List<ComicBookDTO>>(listComicBook);

                objResult.ListComicBook = objResult.ListComicBook
                                   .Cast<ComicBookDTO>()
                                   .Skip((Page - 1) * Registers)
                                   .Take(Registers)
                                   .ToList();

                objResult.TotalRegisters = Totalregisters;
                decimal totalPages = Math.Ceiling((decimal)Totalregisters / Registers);
                objResult.TotalPages = (int)totalPages;
            }
            else
            {
                return ResultServices.Fail<ResultListComicBookDTO>("Nenhum registro encontrado!"); ;
            }
            

            return ResultServices.Ok<ResultListComicBookDTO>(objResult);
        }
    }
}
