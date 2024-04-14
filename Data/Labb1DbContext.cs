using Labb1Theres.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Labb1Theres.Data
{
    public class Labb1DbContext : IdentityDbContext
    {
        public Labb1DbContext(DbContextOptions<Labb1DbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees {get; set;}
        public DbSet<AbstinenceType> AbstinenceTypes { get; set; }
        public DbSet<AbstinenceList> AbstinenceLists { get; set; }


        public void Seed()
        {
            bool employeesExist = Employees.Any();
            bool abstinenceTypesExist = AbstinenceTypes.Any();
            bool abstinenceListsExist = AbstinenceLists.Any();

            if (!employeesExist)
            {
                Employees.AddRange(
                    new Employee { EmployeeName = "Kassandra Lardy" },
                    new Employee { EmployeeName = "Kimmie Smitdth" },
                    new Employee { EmployeeName = "Larry Gergich" },
                    new Employee { EmployeeName = "Sammie Tork" }
                );
            }

            if (!abstinenceTypesExist)
            {
                AbstinenceTypes.AddRange(
                    new AbstinenceType { AbstinenceName = "Sick leave" },
                    new AbstinenceType { AbstinenceName = "Care of sick child" },
                    new AbstinenceType { AbstinenceName = "Vacation time" },
                    new AbstinenceType { AbstinenceName = "Flex time" }
                );
            }


            SaveChanges();
        }
    }
}
