
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Class1
    {
        DBConnection db;
        public Class1(string connection)
        {
            db = new DBConnection(connection);
        }

        public List<Employee> GetAllEmployees()
        {
            return db.GetAllEmployees();
        }
        public List<Interview> GetAllInterviews()
        {
            return db.GetAllInterviews();
        }
        public List<Candidate> GetAllCandidates()
        {
            return db.GetAllCandidates();
        }
        public HashSet<string> GetRole()
        {

            return db.GetRole();
        }
        public List<Employee> GetCategoryRole(string role)
        {
            return db.GetCategoryRole(role);
        }
        public void Add(Employee employee)
        {
            db.Add(employee);
        }
        public List<dynamic> GetNameCandidencies()
        {
            return db.GetAllCandidates().Select(c => new { Id = c.Id, Name = c.FirstName + " " + c.LastName }).ToList<dynamic>();
        }
        

            public Dictionary<int, List<dynamic>> GetInterviewsDetails()
            {
                var interviewDetails = from i in db.GetAllInterviews()
                                       join c in db.GetAllCandidates() on i.CandidateId equals c.Id
                                       join e in db.GetAllEmployees() on i.InterviewerId equals e.Id
                                       orderby i.InterviewDate descending
                                       select new
                                       {
                                           CandidateId = c.Id,
                                           InterviewNumber = i.InterviewNumber,
                                           RoleInCompany = i.RoleInCompany,
                                           InterviewDate = i.InterviewDate,
                                           InterviewerName = e.FirstName + " " + e.LastName,
                                           InterviewerPhone = e.PhoneNumber
                                       };

                var interviewDictionary = interviewDetails.AsEnumerable().GroupBy(i => (int)i.CandidateId)
                .ToDictionary(g => g.Key, g => g.OrderBy(d => d.InterviewDate).ToList<dynamic>());

                return interviewDictionary;
            }

    }
}