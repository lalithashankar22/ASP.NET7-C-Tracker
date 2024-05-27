using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using tracker.api.Model;
using tracker.api.Model.domain;

namespace tracker.api.data
{
    public class trackerDbContext:DbContext
    {
        public trackerDbContext( DbContextOptions<trackerDbContext> DbContextOptions) : base(DbContextOptions)
        {
            
        }
        //Add-Migration "Tracker_one" -context "trackerDbContext"
        //Update-Database -context "trackerDbContext"
        //*******************************************************************************//
        //defining the columns for tables 
        public DbSet<employee> employees { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Work> work { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<dailyTracker> dailyTracker { get; set; }
        public DbSet<images> images { get; set; }
        //*******************************************************************************//
        //seeding data to the database 
        //directly adding data to the data base //default values 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //*******************************************************************************//
            //department table 
            var departments = new List<Department>()
            {
                new Department(){ dept_id = 3001,dept_name="iseries",archv_flag ='N' },
                new Department() { dept_id = 3002, dept_name = "Angular", archv_flag = 'N' }
            };

            var dept1 = new Department();
            dept1.dept_id = 3003;
            dept1.dept_name = "c#";
            dept1.archv_flag = 'N';
            departments.Add (dept1);

            //seeding department to the database 
            modelBuilder.Entity<Department>().HasData(departments);

            //*******************************************************************************//

            //work table 
            var works = new List<Work>()
            {
            new Work(){work_id = 5001 ,work_name = "Coading", start_dt =DateTime.ParseExact("2009-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss",null),end_dt =DateTime.Now,archv_flag='N',Department_id = 3001},
            new Work(){work_id = 5002 ,work_name = "Analysis", start_dt =DateTime.Now,archv_flag='N',Department_id =  3001},
            new Work(){work_id = 5003 ,work_name = "testing", start_dt =DateTime.Now,end_dt =DateTime.MaxValue,archv_flag='N',Department_id = 3001},
            new Work(){work_id = 6001 ,work_name = "Coading", start_dt =DateTime.ParseExact("2009-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss",null),end_dt =DateTime.Now,archv_flag='N',Department_id = 3002},
            new Work(){work_id = 6002 ,work_name = "Analysis", start_dt =DateTime.Now,archv_flag='N',Department_id = 3002},
            new Work(){work_id = 6003 ,work_name = "testing", start_dt =DateTime.Now,end_dt =DateTime.MaxValue,archv_flag='N',Department_id = 3002},
            new Work(){work_id = 7001 ,work_name = "Coading", start_dt =DateTime.ParseExact("2009-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss",null),end_dt =DateTime.Now,archv_flag='N',Department_id = 3003},
            new Work(){work_id = 7002 ,work_name = "Analysis", start_dt =DateTime.Now,archv_flag='N',Department_id = 3003},
            new Work(){work_id = 7003 ,work_name = "testing", start_dt =DateTime.Now,end_dt =DateTime.MaxValue,archv_flag='N',Department_id = 3003}
            };
            //seeding work to the database 
             modelBuilder.Entity<Work>().HasData(works);

            //*******************************************************************************//

            //product table 

            var Products = new List<Product>() 
            {
              new Product(){prod_id = 1001 ,prod_name = "NHL7", start_dt =DateTime.ParseExact("2009-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss",null),end_dt =DateTime.Now,archv_flag='N',Department_id = 3001},
            new Product(){prod_id = 1002 ,prod_name = "Pas", start_dt =DateTime.Now,archv_flag='N',Department_id = 3002},
            new Product(){prod_id = 1003 ,prod_name = "Limbs", start_dt =DateTime.Now,end_dt =DateTime.MaxValue,archv_flag='N',Department_id = 3003}
            };

            //seeding producr to the database 
            modelBuilder.Entity<Product>().HasData(Products);

            //*******************************************************************************//

            // employee table 
            var employees = new List<employee>() 
            {
                new employee(){ emp_id ="WRK-101",mail_id ="wrk-101@dedalus.com", admin = 'N' ,  master = 'N', archv_flag = 'N', Department_id = 3001,  password ="wrk"  },
                new employee(){ emp_id ="WRK-102",mail_id ="wrk-102@dedalus.com", admin = 'Y' ,  master = 'N', archv_flag = 'N', Department_id = 3001,  password ="wrk"  },
                new employee(){ emp_id ="WRK-103",mail_id ="wrk-103@dedalus.com", admin = 'Y' ,  master = 'Y', archv_flag = 'N', Department_id = 3001,  password ="wrk"  },
                new employee(){ emp_id ="WRK-104",mail_id ="wrk-104@dedalus.com", admin = 'N' ,  master = 'N', archv_flag = 'N', Department_id = 3002,  password ="wrk"  },
                new employee(){ emp_id ="WRK-105",mail_id ="wrk-105@dedalus.com", admin = 'Y' ,  master = 'N', archv_flag = 'N', Department_id = 3002,  password ="wrk"  },
                new employee(){ emp_id ="WRK-106",mail_id ="wrk-106@dedalus.com", admin = 'Y' ,  master = 'Y', archv_flag = 'N', Department_id = 3002,  password ="wrk"  },
                new employee(){ emp_id ="WRK-107",mail_id ="wrk-107@dedalus.com", admin = 'N' ,  master = 'N', archv_flag = 'N', Department_id = 3003,  password ="wrk"  },
                new employee(){ emp_id ="WRK-108",mail_id ="wrk-108@dedalus.com", admin = 'Y' ,  master = 'N', archv_flag = 'N', Department_id = 3003,  password ="wrk"  },
                new employee(){ emp_id ="WRK-109",mail_id ="wrk-109@dedalus.com", admin = 'Y' ,  master = 'Y', archv_flag = 'N', Department_id = 3003,  password ="wrk"  }
            };

            // SEEDING EMPLOYEE TO THE database 
            modelBuilder.Entity<employee>().HasData(employees);

            //*******************************************************************************//

            // dailytracker table

            var dailytracks = new List<dailyTracker>()
            { 
                new dailyTracker(){track_id = 7001, hours = 18.00 , start_dt = DateTime.Now , last_modif = DateTime.Now , archv_flag = 'N',comments = "spent 2 days",product = 1001,work =5001,employee_id ="WRK-101"},
                new dailyTracker(){track_id = 7002, hours = 18.00 , start_dt = DateTime.Now , last_modif = DateTime.Now , archv_flag = 'N',comments = "spent 2 days",product = 1002,work =6001,employee_id ="WRK-104"},
                new dailyTracker(){track_id = 7003, hours = 18.00 , start_dt = DateTime.Now , last_modif = DateTime.Now , archv_flag = 'N',comments = "spent 2 days",product = 1003,work =7001,employee_id ="WRK-107"}
            };

            // SEEDING dailytracker  TO THE database 

            modelBuilder.Entity<dailyTracker>().HasData(dailytracks);
        }
    }
}
