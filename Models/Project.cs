using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task_Management_System.Models
{
    public class Project
    {
        [Key]
        [Display(Name = "Project ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [Column(TypeName = "varchar(250)")]
        public string ProjectName { get; set; } = string.Empty;

        [Display(Name = "Project Color")]
        [Column(TypeName = "varchar(10)")]
        public string ProjectColor = "#000";

        public ICollection<Task>? Tasks { get; set; } = null;
    }
}
