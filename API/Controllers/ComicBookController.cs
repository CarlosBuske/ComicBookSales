using AppServices.DTO;
using AppServices.DTOs;
using AppServices.Services.Interface;
using AppServices.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicBookController : ControllerBase
    {
        private readonly IComicBookService _comicBookServices;
        private const int REGISTERS_DEFAULT = 1;
        private const int PAGE_DEFAULT = 1;

        public ComicBookController(IComicBookService comicBookService)
        {
            _comicBookServices = comicBookService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ListAll")]
        public async Task<ResultServices<ResultListComicBookDTO>> ListAll(int Page = PAGE_DEFAULT, int Registers = REGISTERS_DEFAULT)
        {
            var ListComicBook = await _comicBookServices.ListAll(Registers, Page);
            return ListComicBook;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("CreateOrUpdate")]
        public async Task<ResultServices<ComicBookDTO>> CreateOrUpdateAsync(InsertComicBookDTO comicBook)
        {
            var comicbook = await _comicBookServices.CreateOrUpdateAsync(comicBook);
            return comicbook;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Details")]
        public async Task<ResultServices<ComicBookDTO>> Details(int IdComicBook)
        {
            var ComicBook = await _comicBookServices.ComicBookDetails(IdComicBook);
            return ComicBook;
        }
    }
}
