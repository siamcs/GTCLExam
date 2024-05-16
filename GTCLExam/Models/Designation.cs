using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTCLExam.Models
{
    public class Designation
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int DesignationId {  get; set; }

        [Required,StringLength(30)]
        public string DesignationName { get; set; }=string.Empty;
        public IList<EmployeeInfo> EmployeeInfos { get; set; }=new List<EmployeeInfo>();
    }
}
