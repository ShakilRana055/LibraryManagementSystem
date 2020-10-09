using LibraryManagementSystem.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext>option):base(option)
        {
                
        }
        public DbSet<User>User { get; set; }
        public DbSet<Book>Book { get; set; }
        public DbSet<BorrowRecord>BorrowRecord { get; set; }
        public DbSet<ShelfCreate> ShelfCreate { get; set; }
        public DbSet<ShelfSetup> ShelfSetup { get; set; }
        public DbSet<Student> Student { get; set; }

    }
}
