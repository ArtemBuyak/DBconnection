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
        [Required(ErrorMessage = "Пожалуйста, введите корректно имя")]
        public string f_name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно фамилию")]
        public string l_name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно возраст")]
        public int age { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно курс")]
        public int course { get; set; }

        [ForeignKey("User")]
        public int? id_user { get; set; }
        public User User { get; set; }

        public ICollection<List> Lists { get; set; }
        public Student()
        {
            Lists = new List<List>();
        }
    }
}