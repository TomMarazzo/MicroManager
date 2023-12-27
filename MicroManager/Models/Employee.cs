using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Employee
    {
        [Display(Name = "Employee No.")]
        public Guid EmployeeId { get; set; } //PK
        [Display(Name = "Company Role")]
        public Guid Role_Id { get; set; } //FK
        [Display(Name = "Employee No.")]
        public int EmployeeNumber { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; } 
       
        public string City { get; set; }    
        public string Region { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }

        [ForeignKey(nameof(Role_Id))]
        //[ValidateNever]
        public virtual Role? Roles { get; set; }

    }
}
