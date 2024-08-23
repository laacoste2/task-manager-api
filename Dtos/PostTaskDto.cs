using TaskManager.Models;

namespace TaskManager.Dtos
{
    public record PostTaskDto(string Titulo, string Descricao, DateTime Data, TaskStatusEnum Status);
}
