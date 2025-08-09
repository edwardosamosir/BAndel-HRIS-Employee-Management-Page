using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementMvc.Models
{
    public enum Gender { P, L }
    public enum MaritalStatus { Single, Married, Divorced }

    public class Employee
    {
        [Required]
        [Display(Name = "NIK/Employee ID")]
        [StringLength(32, MinimumLength = 3)]
        public string Id { get; set; } = string.Empty;

        [Required, StringLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required, Display(Name = "Place of Birth"), StringLength(80)]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [Required, Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required, Range(0, 1_000_000_000), Display(Name = "Basic Salary")]
        public decimal BasicSalary { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required, Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }
    }
}