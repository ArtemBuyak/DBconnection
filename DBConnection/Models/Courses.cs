using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PgDemo.Models
{
    [Table("Courses", Schema = "public")]
    public class Course
    {
        [Key]
        public int id_course { get; set; }
        public string name { get; set; }
        public int continuance { get; set; }
        public int count_people { get; set; }

        public int? id_teacher { get; set; }
        public Teacher Teacher { get; set; }

        public string description { get; set; }

        public ICollection<List> Lists { get; set; }
        public Course()
        {
           Lists = new List<List>();
        }


    }
}