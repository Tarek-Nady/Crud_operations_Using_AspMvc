using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace PresentationLayer.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        [MinLength(5)]

        public string Name { get; set; }
        [Range(22, 30, ErrorMessage = "Age Must be between 22 and 30")]
        public int? Age { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        [Range(5000, 10000, ErrorMessage = "Salary Must be between 5000 and 10000")]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        public IFormFile Image { get; set; }

        public string ImageName { get; set; }
    }
}
