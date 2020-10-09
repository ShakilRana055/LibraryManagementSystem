using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.EntityModel
{
    public class ShelfCreate:BaseClass
    {
        public int Id { get; set; }
        public string ShelfNumber { get; set; }
        public string Description { get; set; }
    }
}
