using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PresentationLayer.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max Length Name is 50 Chars")]
        public string Name { get; set; }


        public DateTime DateOfCreation { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}
