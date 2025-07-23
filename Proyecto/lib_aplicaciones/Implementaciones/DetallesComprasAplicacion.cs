using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using lib_aplicaciones.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class DetallesComprasAplicacion : IDetallesComprasAplicacion
    {
        private IConexion? IConexion = null;

        public DetallesComprasAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public DetallesCompras? Borrar(DetallesCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Borrar", Tabla = "DetallesCompras", Fecha = DateTime.Now }
                );

            this.IConexion!.DetallesCompras!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public DetallesCompras? Guardar(DetallesCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Guardar", Tabla = "DetallesCompras", Fecha = DateTime.Now }
                );

            var ultimoZapatoCodigo = this.IConexion!.DetallesCompras!.OrderByDescending(x => x.Id).FirstOrDefault()!.Codigo!.Split('-');

            var numero = int.Parse(ultimoZapatoCodigo[1]) + 1;

            entidad.Codigo = ultimoZapatoCodigo[0] + "-" + numero.ToString("D4");

            this.IConexion!.DetallesCompras!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<DetallesCompras> Listar()
        {
            this.IConexion!.Auditorias!.Add(
                 new Auditorias() { Accion = "Listar", Tabla = "DetallesCompras", Fecha = DateTime.Now }
                 );
            this.IConexion!.SaveChanges();

            return this.IConexion!.DetallesCompras!.Take(20).ToList();
        }

        public List<DetallesCompras> PorCodigo(DetallesCompras? entidad)
        {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Codigo))
                throw new Exception("lbFaltaInformacion");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Buscar por codigo", Tabla = "DetallesCompras", Fecha = DateTime.Now }
                );
            this.IConexion!.SaveChanges();

            return this.IConexion!.DetallesCompras!.Where(x => x.Codigo!.Contains(entidad!.Codigo!)).ToList();
        }

        public DetallesCompras? Modificar(DetallesCompras? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Modificar", Tabla = "DetallesCompras", Fecha = DateTime.Now }
                );

            var entry = this.IConexion!.Entry<DetallesCompras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
