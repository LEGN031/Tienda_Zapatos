using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class CuentaClientesPrueba
    {
        private readonly IConexion? iConexion;
        private List<CuentaClientes>? lista;
        private CuentaClientes? entidad;
        private Clientes? clientes;

        public CuentaClientesPrueba()
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
        public void Consultar()
        {
            entidad!.Cliente_ = clientes;
            entidad!.Cliente = this.iConexion!.Clientes!.FirstOrDefault(x => x.Cedula == clientes!.Cedula)!.Id;

        }

        public bool Listar()
        {
            this.lista = this.iConexion!.CuentaClientes!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.CuentaClientes()!;
            this.iConexion!.CuentaClientes!.Add(this.entidad!);

            this.clientes = EntidadesNucleo.Clientes();
            this.iConexion!.Clientes!.Add(this.clientes!);

            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Correo = "Correo Modificar";
            this.entidad!.Contrasena = "Contrasena Modificar";
            var entry = this.iConexion!.Entry<CuentaClientes>(this.entidad!);
            entry.State = EntityState.Modified;
            Consultar();

            this.iConexion.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.CuentaClientes!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            return true;
        }

    }
}
