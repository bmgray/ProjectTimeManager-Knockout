using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WebAppModels.API
{
    public class EmployeeModel
    {
        public int employeeId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The first name must be at least 3 characters")]
        [MaxLength(25, ErrorMessage = "The first name cannot exceed 25 characters")]
        public string firstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The last name must be at least 3 characters")]
        [MaxLength(25, ErrorMessage = "The last name cannot exceed 25 characters")]
        public string lastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "The email address cannot exceed 100 characters")]
        public string email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The first name must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "The position title cannot exceed 50 characters")]
        public string position { get; set; }
    }
}
