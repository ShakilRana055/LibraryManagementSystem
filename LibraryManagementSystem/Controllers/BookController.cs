using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.RepositoryPattern.Interfaces.IUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork context;
        public BookController(IUnitOfWork unitOfWork)
        {
            context = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            var result = await context.Book.GetAll();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var result = await context.Book.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, BookVm book)
        {
            var result = await context.Book.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();

            result.Name = book.Name;
            result.Code = book.Code;
            result.NumberOfCopies = Convert.ToInt32 (book.NumberOfCopies);
            result.Author = book.Author;
            result.Publication = book.Publication;
            result.Description = book.Description;
            result.UpdatedDate = System.DateTime.Now;
            await context.Save();
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var result = await context.Book.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return BadRequest();
            context.Book.Remove(result);
            await context.Save();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookVm bookVm)
        {
            if (bookVm == null)
                return BadRequest();

            Book book = new Book()
            {
                Name = bookVm.Name,
                Code = bookVm.Code,
                NumberOfCopies = Convert.ToInt32(bookVm.NumberOfCopies),
                Author = bookVm.Author,
                Publication = bookVm.Publication,
                Description = bookVm.Description,
                AvailableQuantity = Convert.ToInt32(bookVm.NumberOfCopies),
            };
            context.Book.Save(book);
            await context.Save();
            return book;
        }
    }
}
