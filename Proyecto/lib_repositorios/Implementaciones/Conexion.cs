using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion: DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<DetallesCompras>? DetallesCompras { get; set; }
        public DbSet<Zapatos>? Zapatos { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<CuentaEmpleados>? CuentaEmpleados { get; set; }
        public DbSet<CuentaClientes>? CuentaClientes { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }

        
        
    }
}
