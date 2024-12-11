using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ToDoListCodeFirst.Model
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        public string UserName { get; set; }

    }
}
