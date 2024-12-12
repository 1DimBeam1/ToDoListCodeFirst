using System.ComponentModel.DataAnnotations;

namespace ToDoListCodeFirst.Model
{
    public class ToDoList
    {
        [Key]
        [Required]
        public int listID { get; set; }

        public int userID { get; set; }
        public int taskID { get; set; }

    }
}
