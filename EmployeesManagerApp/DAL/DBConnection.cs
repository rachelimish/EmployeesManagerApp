using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection:DbContext
    {
        private InterviewsManagerContext _context;

        public DBConnection(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Models.InterviewsManagerContext>();
            optionsBuilder.UseSqlServer(connectionString);
            _context = new Models.InterviewsManagerContext(optionsBuilder.Options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id); // הגדרת המפתח הראשי

            base.OnModelCreating(modelBuilder);
        }
        public List<Employee> GetCategoryRole(string role)
        {
            var res = _context.Employees.Where(e => e.RoleInCompany == role).ToList();
            return res;
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public List<Candidate> GetAllCandidates()
        {
            return _context.Candidates.ToList();
        }
        public List<Interview> GetAllInterviews()
        {
            return _context.Interviews.ToList();
        }
        public HashSet<string> GetRole()
        {
            var res = _context.Employees
                    .Select(e => e.RoleInCompany)
                    .ToHashSet();
            return res;
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
       
    }
}