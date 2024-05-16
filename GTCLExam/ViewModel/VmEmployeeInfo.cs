using GTCLExam.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTCLExam.ViewModel
{
    public class VmEmployeeInfo
    {
        public int EmployeeId { get; set; }
        [Required,Range(3000,5000,ErrorMessage =" Salary must be between 30000 to 50000")]
        public decimal GrossSalary { get; set; }
        [Required,MaxLength(50)]
        public string? Name { get; set; } = string.Empty;
        public string ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }

        public int DesignationId { get; set; }
        [Required, MaxLength(50)]
        public string DesignationName { get; set; } = string.Empty;

    }

   
}
