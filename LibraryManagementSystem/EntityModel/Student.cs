using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.EntityModel
{
    public class Student:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudentId { get; set; }
        public string Department { get; set; }
        public string PhotoUrl { get; set; }
        public string DateOfBirth { get; set; }
    }
}
