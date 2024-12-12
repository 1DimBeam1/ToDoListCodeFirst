using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToDoListCodeFirst.Model
{
    public class User
    {
        [Key]
        [Required]
        public int userID { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; }

    }
}
