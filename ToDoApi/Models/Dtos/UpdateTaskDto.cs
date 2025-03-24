using System.ComponentModel.DataAnnotations;
using ToDoApi.Entity.Enums;

namespace ToDoApi.Models.Dtos
{
    public class UpdateTaskDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public Entity.Enums.TaskStatus Status { get; set; }
    }
}
