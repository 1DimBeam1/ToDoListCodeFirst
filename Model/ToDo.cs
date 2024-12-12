using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoListCodeFirst.Model
{
    public class ToDo
    {
        [Key]
        [Required]
        public int taskID { get; set; }

        [MaxLength(100)]
        public string taskName { get; set; }

        [MaxLength(1000)]
        public string taskDescription { get; set; }

        [DefaultValue(false)]
        public string taskStatus { get; set; }

    }
}
