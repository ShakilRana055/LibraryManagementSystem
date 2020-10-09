using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.RepositoryPattern.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.RepositoryPattern.Interfaces.GeneralInterface
{
    public interface IBookRepository:IBaseRepository<Book>
    {

    }
}
