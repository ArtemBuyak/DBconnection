﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PgDemo.Models
{
    public class PGDbContext : DbContext
    {
        public PGDbContext() : base(nameOrConnectionString: "DefaultConnectionString") { }
        public virtual DbSet<User> Usr { get; set; }
        public virtual DbSet<Student> Stud { get; set; }
        public virtual DbSet<Teacher> Teach { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<List> Li { get; set; }
    }
}