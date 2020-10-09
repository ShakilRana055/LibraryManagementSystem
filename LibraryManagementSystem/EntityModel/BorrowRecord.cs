using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.EntityModel
{
    public class BorrowRecord:BaseClass
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
