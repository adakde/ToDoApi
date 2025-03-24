using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models.Dtos;
using ToDoApi.Entity;
using ToDoApi.Entity.Enums;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity.Task>>> GetAll([FromQuery] Entity.Enums.TaskStatus? status,
            [FromQuery] TaskPriority? priority,
            [FromQuery] string sortOrder = "newest")
        {
            var query = _context.Tasks.AsQueryable();

            if (status.HasValue)
            {
                query = query.Where(t => t.Status == status.Value);
            }
            if (priority.HasValue) {
                query = query.Where(t => t.Priority == priority.Value);
            }
            if (sortOrder.ToLower() == "oldest")
            {
                query = query.OrderBy(t => t.CreatedAt);
            }
            else
            {
                query = query.OrderByDescending(t => t.CreatedAt);
            }
            return await query.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Entity.Task>> GetById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            var taskDto = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
                Priority = task.Priority.ToString(), 
                CreatedAt = task.CreatedAt
            };
            return task;
        }
        [HttpPost]
        public async Task<ActionResult<Entity.Task>> CreateTask(CreateTaskDto createTaskDto)
        {
            var task = new Entity.Task
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                Priority = createTaskDto.Priority,
                Status = createTaskDto.Status
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, UpdateTaskDto updateTaskDto)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            task.Title = updateTaskDto.Title;
            task.Description = updateTaskDto.Description;
            task.Priority = updateTaskDto.Priority;
            task.Status = updateTaskDto.Status;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAllAsync()
        {
            _context.Tasks.RemoveRange(_context.Tasks);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
