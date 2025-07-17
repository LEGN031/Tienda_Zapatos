using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using lib_aplicaciones.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class CuentaEmpleadosAplicacion : ICuentaEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public CuentaEmpleadosAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public CuentaEmpleados? Borrar(CuentaEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Borrar", Tabla = "CuentaEmpleados", Fecha = DateTime.Now }
                );

            this.IConexion!.CuentaEmpleados!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public CuentaEmpleados? Guardar(CuentaEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Guardar", Tabla = "CuentaEmpleados", Fecha = DateTime.Now }
                );

            this.IConexion!.CuentaEmpleados!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<CuentaEmpleados> Listar()
        {
            this.IConexion!.Auditorias!.Add(
                 new Auditorias() { Accion = "Listar", Tabla = "CuentaEmpleados", Fecha = DateTime.Now }
                 );
            this.IConexion!.SaveChanges();

            return this.IConexion!.CuentaEmpleados!.Take(20).ToList();
        }

        public List<CuentaEmpleados> PorCorreo(CuentaEmpleados? entidad)
        {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Correo))
                throw new Exception("lbFaltaInformacion");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Buscar por Correo", Tabla = "CuentaEmpleados", Fecha = DateTime.Now }
                );
            this.IConexion!.SaveChanges();

            return this.IConexion!.CuentaEmpleados!.Where(x => x.Correo!.Contains(entidad!.Correo!)).ToList();
        }

        public CuentaEmpleados? Modificar(CuentaEmpleados? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Modificar", Tabla = "CuentaEmpleados", Fecha = DateTime.Now }
                );

            var entry = this.IConexion!.Entry<CuentaEmpleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
