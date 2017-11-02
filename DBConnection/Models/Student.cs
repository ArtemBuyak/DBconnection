using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PgDemo.Models
{
    [Table("Student", Schema = "public")]
    public class Student
    {
        [Key]
        public int id_student { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public int age { get; set; }
        public int course { get; set; }

        public int? user_id { get; set; }
        public User User { get; set; }

        public ICollection<List> Lists { get; set; }
        public Student()
        {
            Lists = new List<List>();
        }
    }
}