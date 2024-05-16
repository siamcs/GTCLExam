using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTCLExam.Models
{
    public class EmployeeInfo
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
         public string ID { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        
        [Required,Range(20000,50000)]
        public decimal GrossSalary { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime  JoinDate { get; set; }
        [ForeignKey(nameof(Designation))]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
