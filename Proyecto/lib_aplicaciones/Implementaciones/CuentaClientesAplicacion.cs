using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class CuentaClientesAplicacion
    {
        private IConexion? IConexion = null;

        public CuentaClientesAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public CuentaClientes? Borrar(CuentaClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Borrar", Tabla = "CuentaClientes", Fecha = DateTime.Now }
                );

            this.IConexion!.CuentaClientes!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public CuentaClientes? Guardar(CuentaClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Guardar", Tabla = "CuentaClientes", Fecha = DateTime.Now }
                );

            this.IConexion!.CuentaClientes!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<CuentaClientes> Listar()
        {
            this.IConexion!.Auditorias!.Add(
                 new Auditorias() { Accion = "Listar", Tabla = "CuentaClientes", Fecha = DateTime.Now }
                 );
            this.IConexion!.SaveChanges();

            return this.IConexion!.CuentaClientes!.Take(20).ToList();
        }

        public List<CuentaClientes> porCorreo(CuentaClientes? entidad)
        {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Correo))
                throw new Exception("lbFaltaInformacion");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Buscar por Correo", Tabla = "CuentaClientes", Fecha = DateTime.Now }
                );
            this.IConexion!.SaveChanges();

            return this.IConexion!.CuentaClientes!.Where(x => x.Correo!.Contains(entidad!.Correo!)).ToList();
        }

        public CuentaClientes? Modificar(CuentaClientes? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Modificar", Tabla = "CuentaClientes", Fecha = DateTime.Now }
                );

            var entry = this.IConexion!.Entry<CuentaClientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
