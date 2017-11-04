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
        [Required(ErrorMessage = "Пожалуйста, введите корректно имя")]
        public string f_name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно фамилию")]
        public string l_name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно поле опыта")]
        [RegularExpression("[1-4]{0,1}[0-9]", ErrorMessage = "Вы ввели некорректный опыт работы, он может быть от 0 до 49 лет.")]
        public int Experience { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно возраст")]
        [RegularExpression("[2-9][0-9]", ErrorMessage = "Вы ввели некорректный возраст, не в диапазон от 20 до 99.")]
        public int age { get; set; }

        public int? id_user { get; set; }
        public User User { get; set; }

        public ICollection<Course> Courses { get; set; }
        public Teacher()
        {
            Courses = new List<Course>();
        }
    }
}