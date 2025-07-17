using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class DetallesComprasPrueba
    {
        private readonly IConexion? iConexion;
        private List<DetallesCompras>? lista;
        private DetallesCompras? entidad;

        private Zapatos? zapatos;
        private Compras? compras;

        public DetallesComprasPrueba()
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
            this.lista = this.iConexion!.DetallesCompras!.ToList();
            return lista.Count > 0;
        }

        public void Consultar()
        {
            entidad!._Zapato = zapatos!;
            entidad!.Zapato = this.iConexion!.Zapatos!.FirstOrDefault(x => x.Codigo == zapatos!.Codigo)!.Id;
            entidad!._Compra = compras!;
            entidad!.Compra = this.iConexion!.Compras!.FirstOrDefault(x => x.Codigo == compras!.Codigo)!.Id;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.DetallesCompras()!;
            this.iConexion!.DetallesCompras!.Add(this.entidad);

            this.zapatos = EntidadesNucleo.Zapatos();
            this.iConexion!.Zapatos!.Add(this.zapatos!);
            this.compras = EntidadesNucleo.Compras();
            this.iConexion!.Compras!.Add(this.compras!);

            this.lista = this.iConexion!.DetallesCompras!.ToList();
            this.iConexion.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            Consultar();

            this.entidad!._Zapato!.Codigo = "Codigo zapato Modificar";
            this.entidad!._Compra!.Codigo = "Codigo compra Modificar";

            this.entidad!.Codigo = "Codigo Modificar";
            this.entidad!.Cantidad = 10;
            this.entidad!.CalculoSubtotal();

            var entry = this.iConexion!.Entry<DetallesCompras>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.DetallesCompras!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            return true;
        }
    }
}