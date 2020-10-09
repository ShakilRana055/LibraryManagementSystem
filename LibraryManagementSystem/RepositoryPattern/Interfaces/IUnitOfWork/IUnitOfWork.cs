using LibraryManagementSystem.RepositoryPattern.Interfaces.GeneralInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.RepositoryPattern.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> Save();
        IBookRepository Book { get; }
        IUserRepository User { get; }
        IStudentRepository Student { get; }
    }
}
