using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TaskStatusEnum Status { get; set; }

        public TaskItem(string titulo, string descricao, DateTime data, TaskStatusEnum status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Data = data;
            Status = status;
        }
    }
}
