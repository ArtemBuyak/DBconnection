using PgDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace DBConnection.Controllers
{
    public class HomeController : Controller
    {
        PGDbContext _context;
        public HomeController()
        {
            _context = new PGDbContext();
        }
        public ViewResult Users()
        {
            return View("Users", _context.Usr.ToList());
        }
        public ViewResult Index()
        {
            var students = _context.Stud.Include(path => path.User);
            return View(students.ToList());
        }
        public ViewResult Teachers()
        {
            var teachers = _context.Teach.Include(path => path.User);
            return View("Teachers", teachers.ToList());
        }
        public ViewResult Courses()
        {
            var cour = _context.Course.Include(path => path.Teacher);
            return View("Courses", cour.ToList());
        }


        // Методы для работы со таблицей Student
        [HttpGet]
        public ActionResult EditingStudent(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Student student = _context.Stud.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ViewResult EditingStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Student stud = _context.Stud.Find(student.id_student);
                stud.f_name = student.f_name;
                stud.l_name = student.l_name;
                stud.age = student.age;
                stud.course = student.course;
                _context.SaveChanges();
                ViewData["Success"] = "Студент успешно отредактирован!";
                return View("Index", _context.Stud.Include(path => path.User));

            }
            else
            {
                Student stud = _context.Stud.Find(student.id_student);
                return View(stud);
            }
        }

        // Методы для работы с таблицей User
        [HttpGet]
        public ActionResult EditingUser(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User user = _context.Usr.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ViewResult EditingUser(User user)
        {
            if (ModelState.IsValid)
            {
                User us = _context.Usr.Find(user.id_user);
                us.login = user.login;
                us.password = user.password;
                us.role = user.role;
                _context.SaveChanges();
                ViewData["Success"] = "Пользователь успешно отредактирован!";
                return View("Users", _context.Usr.ToList());

            }
            else
            {
                User us = _context.Usr.Find(user.id_user);
                return View(us);
            }
        }

        // Методы для работы со таблицей Teacher
        [HttpGet]
        public ActionResult EditingTeacher(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Teacher teacher = _context.Teach.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public ViewResult EditingTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher teache = _context.Teach.Find(teacher.id_teacher);
                teache.f_name = teacher.f_name;
                teache.l_name = teacher.l_name;
                teache.Experience = teacher.Experience;
                teache.age = teacher.age;
                _context.SaveChanges();
                ViewData["Success"] = "Преподаватель успешно отредактирован!";
                return View("Teachers", _context.Teach.Include(path => path.User));
            }
            else
            {
                Teacher teache = _context.Teach.Find(teacher.id_teacher);
                return View(teache);
            }
        }

        // Методы для работы с таблицей Course
        [HttpGet]
        public ActionResult EditingCourse(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Course course = _context.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        public ViewResult EditingCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                Course cour = _context.Course.Find(course.id_teacher);
                cour.name = course.name;
                cour.continuance = course.continuance;
                cour.count_people = course.count_people;
                cour.description = course.description;
                _context.SaveChanges();
                ViewData["Success"] = "Курс успешно отредактирован!";
                return View("Courses", _context.Course.Include(path => path.Teacher));
            }
            else
            {
                Course cour = _context.Course.Find(course.id_course);
                return View(cour);
            }
        }


        public ActionResult DeleteTeacher(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Teacher teacher = _context.Teach.Where(c => c.id_teacher == id).FirstOrDefault();
            if (teacher == null)
            {
                return HttpNotFound();
            }
            var cou = _context.Course.Where(c => c.id_teacher == id);
            foreach (Course i in cou)
            {
                _context.Course.Remove(i);
            }
            _context.Teach.Remove(teacher);
            _context.SaveChanges();
            ViewData["Success"] = "Преподаватель успешно удален из списка!";
            return View("Teachers", _context.Teach.Include(path => path.User));
        }


        public ActionResult DeleteCourse(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Course cour = _context.Course.Where(c => c.id_course == id).FirstOrDefault();
            if (cour == null)
            {
                return HttpNotFound();
            }
            _context.Course.Remove(cour);
            _context.SaveChanges();
            ViewData["Success"] = "Курс успешно удален!";
            return View("Courses", _context.Course.Include(path => path.Teacher));
        }

        public ActionResult DeleteStudent(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Student stud = _context.Stud.Where(c => c.id_student == id).FirstOrDefault();
            if (stud == null)
            {
                return HttpNotFound();
            }
            _context.Stud.Remove(stud);
            _context.SaveChanges();
            ViewData["Success"] = "Студент успешно удален из списка!";
            return View("Index", _context.Stud.Include(path => path.User));
        }


        [HttpGet]
        public ActionResult CreateStudent()
        {
            Student st = new Student();
            var us = _context.Usr.Where(c => c.role == "1" );
            ViewBag.Li = new List<User> ();
            List<User> li = new List<User>();
            foreach (User i in us)
            {
                li.Add(i);
            }
            ViewBag.Li = li;
            return View(st);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Student st = new Student
                {
                    f_name  = student.f_name,
                    l_name = student.l_name,
                    age = student.age,
                    course = student.course,
                    id_user = student.id_user

                };
                _context.Stud.Add(st);
                _context.SaveChanges();
                ViewData["Success"] = "Студент успешно добавлен с список!";
                return View("Index", _context.Stud.Include(path => path.User));

            }
            else
            {
                User us = new User();
                return View(us);
            }
        }


        [HttpGet]
        public ActionResult CreateTeacher()
        {
            Teacher tch = new Teacher();
            var us = _context.Usr.Where(c => c.role == "2");
            ViewBag.Li = new List<User>();
            List<User> li = new List<User>();
            foreach (User i in us)
            {
                li.Add(i);
            }
            ViewBag.Li = li;
            return View(tch);
        }

        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher tch = new Teacher
                {
                    f_name = teacher.f_name,
                    l_name = teacher.l_name,
                    age = teacher.age,
                    Experience = teacher.Experience,
                    id_user = teacher.id_user

                };
                _context.Teach.Add(tch);
                _context.SaveChanges();
                ViewData["Success"] = "Преподаватель успешно добавлен в список!";
                return View("Teachers", _context.Teach.Include(path => path.User));

            }
            else
            {
                User us = new User();
                return View(us);
            }
        }


        [HttpGet]
        public ActionResult CreateUser()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                User us = new User
                {
                    login = user.login,
                    password = user.password,
                    role = user.role
                };
                _context.Usr.Add(us);
                _context.SaveChanges();
                ViewData["Success"] = "Пользователь успешно добавлен!";
                return View("Users", _context.Usr.ToList());

            }
            else
            {
                User us = new User();
                return View(us);
            }
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            Course cour = new Course();
            var us = _context.Teach.ToList();
            ViewBag.Li = new List<Teacher>();
            List<Teacher> li = new List<Teacher>();
            foreach (Teacher i in us)
            {
                li.Add(i);
            }
            ViewBag.Li = li;
            return View(cour);
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                Course cour = new Course
                {
                    name = course.name,
                    continuance = course.continuance,
                    count_people = course.count_people,
                    id_teacher = course.id_teacher,
                    description = course.description                   

                };
                _context.Course.Add(cour);
                _context.SaveChanges();
                ViewData["Success"] = "Курс успешно добавлен в список!";
                return View("Index", _context.Stud.Include(path => path.User));

            }
            else
            {
                User us = new User();
                return View(us);
            }
        }

    }
}