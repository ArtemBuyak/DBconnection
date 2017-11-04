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
        [Required(ErrorMessage = "Пожалуйста, введите корректно название курса.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно продолжительность курса.")]
        [RegularExpression("[1-9]", ErrorMessage = "Вы ввели некорректую продолжительность курса, она может быть от 1 до 9 лет.")]
        public int continuance { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно количество людей на курсах.")]
        [RegularExpression("[1-2][0-9]", ErrorMessage = "Вы ввели некорректое количество людей, оно может быть от 10 до 29 лет.")]
        public int count_people { get; set; }

        public int? id_teacher { get; set; }
        public Teacher Teacher { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите хотя бы минимальное описание курса.")]
        public string description { get; set; }


    }
}