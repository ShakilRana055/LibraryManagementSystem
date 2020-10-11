using LibraryManagementSystem.Data;
using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.RepositoryPattern.Interfaces.GeneralInterface;
using LibraryManagementSystem.RepositoryPattern.Interfaces.IUnitOfWork;
using LibraryManagementSystem.RepositoryPattern.Repositories.GeneralRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.RepositoryPattern.Repositories.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            context = appDbContext;
            Book = new BookRepository(context);
            User = new UserRepository(context);
            Student = new StudentRepository(context);
            ShelfCreate = new ShelfCreateRepository(context);
            ShelfSetup = new ShelfSetupRepository(context);
        }

        #region Base Method
        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.DisposeAsync();
        }
        #endregion

        #region Implementation
        public IBookRepository Book { get; private set; }
        public IUserRepository User { get; private set; }
        public IStudentRepository Student { get; private set; }
        public IShelfCreateRepository ShelfCreate { get; private set; }
        public IShelfSetupRepository ShelfSetup { get; private set; }
        #endregion
    }
}
