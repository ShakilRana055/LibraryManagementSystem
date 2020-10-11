using LibraryManagementSystem.Data;
using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.RepositoryPattern.Interfaces.GeneralInterface;
using LibraryManagementSystem.RepositoryPattern.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.RepositoryPattern.Repositories.GeneralRepository
{
    public class ShelfSetupRepository: BaseRepository<ShelfSetup>, IShelfSetupRepository
    {
        private readonly AppDbContext context;
        public ShelfSetupRepository( AppDbContext appDbContext):base(appDbContext)
        {
            context = appDbContext;
        }

        public async Task<IEnumerable<ShelfSetup>> GetRelatedData()
        {
            var result = await context.ShelfSetup
                        .Include(book => book.Book)
                        .Include(shelfCreate => shelfCreate.ShelfCreate)
                        .ToListAsync();
            return result;
        }

        public async Task<ShelfSetup> GetRelatedData(int id)
        {
            var result = await context.ShelfSetup
                        .Include(book => book.Book)
                        .Include(shelfCreate => shelfCreate.ShelfCreate)
                        .Where(item => item.Id == id)
                        .FirstOrDefaultAsync();
            return result;
        }
    }
}
