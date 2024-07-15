using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_System.Models
{
    public class Task
    {
        [Key]
        [Display(Name = "Task ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        [Column(TypeName = "varchar(250)")]
        public string TaskName { get; set; } = string.Empty;

        [Display(Name = "Task Color")]
        [Column(TypeName = "varchar(10)")]
        public string TaskColor = "#000";

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
        public DateTime? TaskStartDate { get; set; } // set manually to the created date if the user didn't enter it

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? TaskEndDate { get; set; } = null;

        [Display(Name = "Task Total Time")]
        [DataType(DataType.Date)]
        public int TaskTotalTime { get; set; } = 0;
    }
}
