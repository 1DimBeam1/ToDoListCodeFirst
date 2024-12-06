using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ToDoListCodeFirst.DataModel
{
    public class ToDoList
    {
        [Key]
        public int listId { get; set; }

        public int user { get; set; }
        public List<ToDo> tasks { get; set; }

    }
}
