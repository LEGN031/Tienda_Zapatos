using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using lib_aplicaciones.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
    {
        private IConexion? IConexion = null;

        public ComprasAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public Compras? Borrar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Borrar", Tabla = "Compras", Fecha = DateTime.Now }
                );

            this.IConexion!.Compras!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public Compras? Guardar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Guardar", Tabla = "Compras", Fecha = DateTime.Now }
                );

            var ultimoZapatoCodigo = this.IConexion!.Compras!.OrderByDescending(x => x.Id).FirstOrDefault()!.Codigo!.Split('-');

            var numero = int.Parse(ultimoZapatoCodigo[1]) + 1;

            entidad.Codigo = ultimoZapatoCodigo[0] + "-" + numero.ToString("D4");

            this.IConexion!.Compras!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<Compras> Listar()
        {
            this.IConexion!.Auditorias!.Add(
                 new Auditorias() { Accion = "Listar", Tabla = "Compras", Fecha = DateTime.Now }
                 );
            this.IConexion!.SaveChanges();

            return this.IConexion!.Compras!.Take(20).ToList();
        }

        public List<Compras> PorCodigo(Compras? entidad)
        {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Codigo))
                throw new Exception("lbFaltaInformacion");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Buscar por codigo", Tabla = "Compras", Fecha = DateTime.Now }
                );
            this.IConexion!.SaveChanges();

            return this.IConexion!.Compras!.Where(x => x.Codigo!.Contains(entidad!.Codigo!)).ToList();
        }

        public Compras? Modificar(Compras? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Modificar", Tabla = "Compras", Fecha = DateTime.Now }
                );

            var entry = this.IConexion!.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
