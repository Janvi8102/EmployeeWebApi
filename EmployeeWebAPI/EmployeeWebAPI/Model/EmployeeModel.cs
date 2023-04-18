using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Model
{
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Employee_PK { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int EmpCode { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        public int Salary { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        public DateTime? ResignDate { get; set; }
    }
}
