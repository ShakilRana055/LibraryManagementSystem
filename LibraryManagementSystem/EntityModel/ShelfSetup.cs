using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.EntityModel
{
    public class ShelfSetup:BaseClass
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
        public int? ShelfCreateId { get; set; }
        public virtual ShelfCreate ShelfCreate { get; set; }
    }
}
