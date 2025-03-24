using System.ComponentModel.DataAnnotations;
using ToDoApi.Entity.Enums;

namespace ToDoApi.Entity
{
    public class Task
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
