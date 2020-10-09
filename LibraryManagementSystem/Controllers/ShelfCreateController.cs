using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.RepositoryPattern.Interfaces.IUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfCreateController : ControllerBase
    {
        private readonly IUnitOfWork context;
        public ShelfCreateController(IUnitOfWork unitOfWork)
        {
            context = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelfCreate>>> GetShelfCreate()
        {
            var result = await context.ShelfCreate.GetAll();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShelfCreate>> GetShelfCreate(int id)
        {
            var result = await context.ShelfCreate.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ShelfCreate>> UpdateShelfCreate(int id, ShelfCreate shelfCreate)
        {
            var result = await context.ShelfCreate.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();

            result.ShelfNumber = shelfCreate.ShelfNumber;
            result.Description = shelfCreate.Description;
            result.UpdatedDate = System.DateTime.Now;
            await context.Save();
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ShelfCreate>> DeleteShelfCreate(int id)
        {
            var result = await context.ShelfCreate.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return BadRequest();
            context.ShelfCreate.Remove(result);
            await context.Save();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ShelfCreate>> PostShelfCreate(ShelfCreate shelfCreate)
        {
            if (shelfCreate == null)
                return BadRequest();
            shelfCreate.CreatedDate = System.DateTime.Now;
            context.ShelfCreate.Save(shelfCreate);
            await context.Save();
            return shelfCreate;
        }
    }
}
