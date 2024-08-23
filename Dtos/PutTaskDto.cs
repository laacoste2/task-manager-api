using TaskManager.Models;

namespace TaskManager.Dtos
{
    public record PutTaskDto(string Titulo, string Descricao, DateTime Data, TaskStatusEnum Status);
    
}
