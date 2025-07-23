using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_aplicaciones.Interfaces;

namespace lib_aplicaciones.Implementaciones
{
    public class ZapatosAplicacion : IZapatosAplicacion
    {
        private IConexion? IConexion = null;

        public ZapatosAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }



        public Zapatos? Guardar(Zapatos? entidad) { 
            if(entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Guardar", Tabla = "Zapatos", Fecha = DateTime.Now }
                );

            var ultimoZapatoCodigo = this.IConexion!.Zapatos!.OrderByDescending(x => x.Id).FirstOrDefault()!.Codigo!.Split('-');

            var numero = int.Parse(ultimoZapatoCodigo[1]) + 1;

            entidad.Codigo = ultimoZapatoCodigo[0] + "-" + numero.ToString("D4");

            this.IConexion!.Zapatos!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<Zapatos> Listar() {
           this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Listar", Tabla = "Zapatos", Fecha = DateTime.Now }
                );
           this.IConexion!.SaveChanges();

            return this.IConexion!.Zapatos!.Take(20).ToList();
        }

        public List<Zapatos> PorCodigo(Zapatos? entidad) {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Codigo))
                throw new Exception("lbFaltaInformacion");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Buscar por codigo", Tabla = "Zapatos", Fecha = DateTime.Now }
                );
            this.IConexion!.SaveChanges();

           return this.IConexion!.Zapatos!.Where(x => x.Codigo!.Contains(entidad!.Codigo!)).ToList();
        }

        public Zapatos? Modificar (Zapatos? entidad) { 
            
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Modificar", Tabla = "Zapatos", Fecha = DateTime.Now }
                );

            var entry = this.IConexion!.Entry<Zapatos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Zapatos? Borrar(Zapatos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Add(
                new Auditorias() { Accion = "Borrar", Tabla = "Zapatos", Fecha = DateTime.Now }
                );

            this.IConexion!.Zapatos!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

    }
}
