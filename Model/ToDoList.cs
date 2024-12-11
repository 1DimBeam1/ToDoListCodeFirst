using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ToDoListCodeFirst.Model
{
    public class ToDoList
    {
        [Key]
        public int listID { get; set; }

        public int user { get; set; }
        public List<ToDo> tasks { get; set; }

    }
}
