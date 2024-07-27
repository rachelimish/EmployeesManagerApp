using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DAL.Models
{
    public partial class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public int StartOfWorkYear { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string RoleInCompany { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
