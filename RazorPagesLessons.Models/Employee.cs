using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPagesLessons.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле імені не може бути порожнім. Будь ласка, введіть ім’я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле імені не може бути порожнім. Будь ласка, введіть email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Будь лаcка, введіть валідний email (формат: example@exem.com)")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}
