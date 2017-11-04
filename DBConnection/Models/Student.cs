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
        [RegularExpression("[2-9][0-9]", ErrorMessage = "Вы ввели некорректный возраст, не в диапазон от 20 до 99.")]
        public string f_name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно фамилию")]
        public string l_name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно возраст")]
        [RegularExpression("[2-9][0-9]", ErrorMessage = "Вы ввели некорректный возраст, не в диапазон от 20 до 99.")]
        public int age { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите корректно курс")]
        [RegularExpression("[1-5]", ErrorMessage = "Вы ввели некорректный номер курса, он должен быть в диапазоне от 1 до 5.")]
        public int course { get; set; }

        [ForeignKey("User")]
        public int? id_user { get; set; }
        public User User { get; set; }

    }
}