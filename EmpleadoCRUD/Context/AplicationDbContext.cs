using EmpleadoCRUD.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoCRUD.Context
{
    public class AplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Aqui se pone cadena de produccion
            optionsBuilder.UseMySQL("server=localhost; database=EmpleadoCRUD; user=root; password=;");
        }

        public DbSet<Empleado> Empleados { get; set; }

    }
}
