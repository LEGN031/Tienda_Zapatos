using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Compras>? Compras { get; set; }
        DbSet<DetallesCompras>? DetallesCompras { get; set; }
        DbSet<Zapatos>? Zapatos { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<CuentaEmpleados>? CuentaEmpleados { get; set; }
        DbSet<CuentaClientes>? CuentaClientes { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
