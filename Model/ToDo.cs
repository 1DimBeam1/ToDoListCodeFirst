using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ToDoListCodeFirst.Model
{
    public class ToDo
    {
        [Key]
        public int taskID { get; set; }

        public string taskName { get; set; }

        public string taskDescription { get; set; }

        public string taskStatus { get; set; }

    }
}
