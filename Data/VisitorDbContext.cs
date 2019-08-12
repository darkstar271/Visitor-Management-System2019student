using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Visitor_Management_System2019student.Models;

namespace Visitor_Management_System2019student.Data
{
    public class visitorDBcontext : DbContext
    {// here we add in the tables that we are using
        public DbSet<StaffNames> StaffNames { get; set; }
        public DbSet<Visitors> Visitors { get; set; }



        public visitorDBcontext(DbContextOptions<visitorDBcontext> options)
            : base(options)
        {
        }

        public visitorDBcontext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
