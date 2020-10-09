using LibraryManagementSystem.Data;
using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.RepositoryPattern.Interfaces.GeneralInterface;
using LibraryManagementSystem.RepositoryPattern.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.RepositoryPattern.Repositories.GeneralRepository
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext):base(appDbContext)
        {

        }
    }
}
