using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }
        [Display(Name = "Role Title")]
        public string RoleTitle { get; set; }

        public virtual List<Employee>? Employees { get; set; } //To get list of Employees 
    }
}
