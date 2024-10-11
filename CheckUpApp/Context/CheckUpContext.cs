using CheckUpApp.Model;
using CheckUpApp.Model.BaseModel;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CheckUpApp.Context
{
    public class CheckUpContext : DbContext
    {
        public CheckUpContext(DbContextOptions<CheckUpContext> options) : base(options)
        {
        }

        public DbSet<Doctor> doctors {  get; set; }
        public DbSet<Patient> patients { get; set; }

    }

   
}
