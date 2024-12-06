using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ToDoListCodeFirst.DataModel
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        public string UserName { get; set; }

    }
}
