using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PgDemo.Models
{
    [Table("List", Schema = "public")]
    public class List
    {
        [Key]
        public int id_list { get; set; }
        public int? id_course { get; set; }
        public Course Course { get; set; }

        public int? id_student { get; set; }
        public Student Student { get; set; }


    }
}