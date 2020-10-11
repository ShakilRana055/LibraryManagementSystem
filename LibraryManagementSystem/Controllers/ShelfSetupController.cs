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
    public class ShelfSetupController : ControllerBase
    {
        private readonly IUnitOfWork context;
        public ShelfSetupController( IUnitOfWork unitOfWork )
        {
            context = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelfSetup>>> GetShelfSetup()
        {
            var result = await context.ShelfSetup.GetRelatedData();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShelfSetup>> GetShelfSetup(int id)
        {
            var result = await context.ShelfSetup.GetRelatedData(id);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ShelfSetup>> DeleteShelfSetup(int id)
        {
            var result = await context.ShelfSetup.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();
            context.ShelfSetup.Remove(result);
            await context.Save();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ShelfSetup>> UpdateShelfSetup(int id, ShelfSetup shelfSetup)
        {
            var result = await context.ShelfSetup.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();
            result.BookId = shelfSetup.BookId;
            result.ShelfCreateId = shelfSetup.ShelfCreateId;
            result.UpdatedDate = System.DateTime.Now;
            await context.Save();
            var returnObject = await context.ShelfSetup.GetRelatedData(id);
            return returnObject;
        }

        [HttpPost]
        public async Task<ActionResult<ShelfSetup>> PostShelfSetup(ShelfSetup shelfSetup )
        {
            if (shelfSetup == null)
                return BadRequest();
            shelfSetup.CreatedDate = System.DateTime.Now;
            context.ShelfSetup.Save(shelfSetup);
            await context.Save();
            var newlyAdded = await context.ShelfSetup.GetRelatedData(shelfSetup.Id);
            return newlyAdded;
        }
    }
}
