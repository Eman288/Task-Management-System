using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class Task
    {
        [Key]
        [Display(Name = "Task ID")]
        public int TaskID { get; set; } = 0;

        [Required]
        [Display(Name = "Task Name")]
        [Column(TypeName = "varchar(250)")]
        public string TaskName { get; set; } = string.Empty;

        [Display(Name = "Task Color")]
        [Column(TypeName = "varchar(10)")]
        public string TaskColor { get; set; } = "#000";

        [Column(TypeName = "int")]
        [Display(Name = "Task Priority")]
        public int TaskPriority { get; set; } = 0;

        [Display(Name = "Task Content")]
        [Column(TypeName = "varchar(250)")]
        public string TaskContent { get; set; } = string.Empty;

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime TaskCreatedDate { get; set; } = DateTime.Today;

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? TaskStartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? TaskEndDate { get; set; }

        [Display(Name = "Task Total Time")]
        public int TaskTotalTime { get; set; } = 0;
    }
}
