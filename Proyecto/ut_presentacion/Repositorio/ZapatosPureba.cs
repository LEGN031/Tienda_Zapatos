using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class ZapatosPureba
    {
        private readonly IConexion? iConexion;
        private List<Zapatos>? lista;
        private Zapatos? entidad;

        public ZapatosPureba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Zapatos!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Zapatos()!;
            this.iConexion!.Zapatos!.Add(this.entidad);
            this.iConexion.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Nombre = "Nombre Modificar";
            this.entidad!.Marca = "Marca Modificar";
            this.entidad!.Talla = "Talla Modificar";
            this.entidad!.Precio = 100.0m;
            this.entidad!.Codigo = "Codigo Modificar";
            var entry = this.iConexion!.Entry<Zapatos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Zapatos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            return true;
        }


    }
}
