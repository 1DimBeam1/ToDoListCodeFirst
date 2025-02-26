using System.ComponentModel.DataAnnotations;

namespace ToDoListCodeFirst.DTOs
{
    public class ToDoDTO
    {
        [Required]
        [MaxLength(100)]
        public string taskName { get; set; }

        [MaxLength(1000)]
        public string taskDescription { get; set; }

        public string taskStatus { get; set; }
    }
}