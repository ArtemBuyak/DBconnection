using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PgDemo.Models
{
    [Table("Teacher", Schema = "public")]
    public class Teacher
    {
        [Key]
        public int id_teacher { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public int Experience { get; set; }
        public int age { get; set; }

        public int? user_id { get; set; }
        public User User { get; set; }

        public ICollection<Course> Courses { get; set; }
        public Teacher()
        {
            Courses = new List<Course>();
        }
    }
}