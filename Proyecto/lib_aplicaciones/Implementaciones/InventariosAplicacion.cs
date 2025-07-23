using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using lib_aplicaciones.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class InventariosAplicacion : IInventariosAplicacion
    {
        private IConexion? IConexion = null;

        public InventariosAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public Inventarios? Borrar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Borrar", Tabla = "Inventarios", Fecha = DateTime.Now }
                );

            this.IConexion!.Inventarios!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public Inventarios? Guardar(Inventarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Guardar", Tabla = "Inventarios", Fecha = DateTime.Now }
                );

            var ultimoInventarioCodigo = this.IConexion!.Inventarios!.OrderByDescending(x => x.Id).FirstOrDefault()!.Codigo!.Split('-');

            var numero = int.Parse(ultimoInventarioCodigo[1]) + 1;

            entidad.Codigo = ultimoInventarioCodigo[0] + "-" + numero.ToString("D4");

            this.IConexion!.Inventarios!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<Inventarios> Listar()
        {
            this.IConexion!.Auditorias!.Add(
                 new Auditorias() { Accion = "Listar", Tabla = "Inventarios", Fecha = DateTime.Now }
                 );
            this.IConexion!.SaveChanges();

            return this.IConexion!.Inventarios!.Take(20).ToList();
        }

        public List<Inventarios> PorCodigo(Inventarios? entidad)
        {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Codigo))
                throw new Exception("lbFaltaInformacion");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Buscar por codigo", Tabla = "Inventarios", Fecha = DateTime.Now }
                );
            this.IConexion!.SaveChanges();

            return this.IConexion!.Inventarios!.Where(x => x.Codigo!.Contains(entidad!.Codigo!)).ToList();
        }

        public Inventarios? Modificar(Inventarios? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Modificar", Tabla = "Inventarios", Fecha = DateTime.Now }
                );

            var entry = this.IConexion!.Entry<Inventarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
