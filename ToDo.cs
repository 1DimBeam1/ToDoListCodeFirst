using System.Data.Entity;

namespace ToDoListCodeFirst
{
    public class ToDo
    {
        public int idTask { get; set; }

        public string nameTask { get; set; }

        public string descriptionTask { get; set; }

        public string statusTask { get; set; }

        public User user { get; set; }
    }
}
