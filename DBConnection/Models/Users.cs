using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PgDemo.Models
{
    [Table("User", Schema = "public")]
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите login корректо")]
        public string login { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно пароль")]
        public string password { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно роль пользователя")]
        public string role { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public User()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }
    }
}