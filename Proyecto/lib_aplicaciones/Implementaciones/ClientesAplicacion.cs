using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_aplicaciones.Interfaces;

namespace lib_aplicaciones.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public Clientes? Borrar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Borrar", Tabla = "Clientes", Fecha = DateTime.Now }
                );

            this.IConexion!.Clientes!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Guardar", Tabla = "Clientes", Fecha = DateTime.Now }
                );

            this.IConexion!.Clientes!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<Clientes> Listar()
        {
            this.IConexion!.Auditorias!.Add(
                 new Auditorias() { Accion = "Listar", Tabla = "Clientes", Fecha = DateTime.Now }
                 );
            this.IConexion!.SaveChanges();

            return this.IConexion!.Clientes!.Take(20).ToList();
        }

        public List<Clientes> PorCedula(Clientes? entidad)
        {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Cedula))
                throw new Exception("lbFaltaInformacion");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Buscar por Cedula", Tabla = "Clientes", Fecha = DateTime.Now }
                );
            this.IConexion!.SaveChanges();

            return this.IConexion!.Clientes!.Where(x => x.Cedula!.Contains(entidad!.Cedula!)).ToList();
        }

        public Clientes? Modificar(Clientes? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Modificar", Tabla = "Clientes", Fecha = DateTime.Now }
                );

            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
