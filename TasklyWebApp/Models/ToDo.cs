using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TasklyWebApp.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Task Name")]
        public string TaskName { get; set; } = string.Empty;

        [DisplayName("Task Description")]
        public string TaskDescription { get; set; } = string.Empty;

        [DisplayName("Priority")]
        public int TaskPriority  { get; set; }

        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [DisplayName("Description")]
        public string ExtraNotes {  get; set; } = string.Empty;

        public bool IsDone { get; set; }
    }
}
    