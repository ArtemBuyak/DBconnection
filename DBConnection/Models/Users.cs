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
        public string login { get; set; }
        public string password { get; set; }
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