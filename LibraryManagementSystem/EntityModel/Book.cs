using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.EntityModel
{
    public class Book:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int NumberOfCopies { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
