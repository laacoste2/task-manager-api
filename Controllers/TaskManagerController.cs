using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Context;
using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public ValuesController(TaskManagerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var entity = _context.TaskItems.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, PutTaskDto task)
        {
            var entity = _context.TaskItems.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Titulo = task.Titulo;
            entity.Descricao = task.Descricao;
            entity.Data = task.Data;
            entity.Status = task.Status;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var entity = _context.TaskItems.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(entity);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var entities = _context.TaskItems.ToList();

            if (entities.Count < 1)
            {
                return NotFound();
            }

            return Ok(entities);
        }

        [HttpGet("Title")]
        public IActionResult GetTaskByTitle(string Title)
        {
            var entities = _context.TaskItems.Where(t => t.Titulo == Title);

            if (entities == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("Date")]
        public IActionResult GetTaskByDate(DateTime data)
        {
            var entities = _context.TaskItems.Where(t => t.Data == data);

            if (entities == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("Status")]
        public IActionResult GetTaskByStatus(TaskStatusEnum status)
        {
            var entities = _context.TaskItems.Where(t => t.Status == status);

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities);
        }

        [HttpPost]
        public IActionResult PostTask(PostTaskDto task)
        {
            var item = new TaskItem(
                task.Titulo,
                task.Descricao,
                DateTime.Now,
                TaskStatusEnum.Pending);

            _context.TaskItems.Add(item);
            _context.SaveChanges();

            int itemId = item.Id;

            return CreatedAtAction(nameof(GetTaskById), new { id = itemId }, task);
        }
    }
}
