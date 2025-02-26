using System.ComponentModel.DataAnnotations;

namespace ToDoListCodeFirst.DTOs
{
    public class UserDTO
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
    }
}