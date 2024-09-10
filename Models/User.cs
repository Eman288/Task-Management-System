using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class User
    {

        [Key]
        [Display(Name = "User Email")]
        [Column(TypeName = "varchar(250)")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)$", ErrorMessage = "Invalid Email Address.")]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar(250)")]
        [RegularExpression(@"^[a-z' 'A-Z]+$", ErrorMessage = "Invalid name!")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$", ErrorMessage = "The password must contain at least one lowercase letter, one uppercase letter, and one digit.")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; } = string.Empty;


        [Display(Name = "Pomodoro")]
        [Column(TypeName = "int")]
        public int? Pomodoro { get; set; } = 25;

        [Display(Name = "Short Break")]
        [Column(TypeName = "int")]
        public int? ShortBreak { get; set; } = 5;

        [Display(Name = "Long Break")]
        [Column(TypeName = "int")]
        public int? LongBreak { get; set; } = 15;

        [Display(Name = "Rounds")]
        [Column(TypeName = "int")]
        public int? Rounds { get; set; } = 4;

        [Display(Name = "Total Focus Time")] // in minutes
        [Column(TypeName = "int")]
        public int? TotalFocusTime { get; set; } = 0;

        //relations

        public ICollection<Task>? Tasks { get; set; } = null;

        public ICollection<Project>? Projects { get; set; } = null;
    }
}
