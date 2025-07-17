using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    public class ComprasPrueba
    {
        private readonly IConexion? iConexion;
        public List<Compras>? lista;
        public Compras? entidad;

        public Empleados? empleados;
        public Clientes? clientes;
        public DetallesCompras? detallesCompras;
        public Zapatos? zapatos;

        public ComprasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

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
            entidad!.Cliente = this.iConexion!.Clientes!.FirstOrDefault(x => x.Nombre == clientes!.Nombre)!.Id;
            entidad!.Empleado_ = empleados;
            entidad!.Empleado = this.iConexion!.Empleados!.FirstOrDefault(x => x.Nombre == empleados!.Nombre)!.Id;

            detallesCompras!._Zapato = zapatos;
            detallesCompras!.Zapato = this.iConexion!.Zapatos!.FirstOrDefault(x => x.Nombre == zapatos!.Nombre)!.Id;

            entidad!.DetallesCompra = [detallesCompras!];
        }

        public bool Listar()
        {
            this.lista= this.iConexion!.Compras!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Compras()!;
            this.iConexion!.Compras!.Add(this.entidad!);

            this.empleados = EntidadesNucleo.Empleados();
            this.iConexion!.Empleados!.Add(this.empleados!);
            
            this.detallesCompras = EntidadesNucleo.DetallesCompras()!;
            this.iConexion!.DetallesCompras!.Add(this.detallesCompras!);

            this.clientes = EntidadesNucleo.Clientes();
            this.iConexion!.Clientes!.Add(this.clientes!);

            this.zapatos = EntidadesNucleo.Zapatos();
            this.iConexion!.Zapatos!.Add(this.zapatos!);

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Fecha = DateTime.Now;
            this.entidad!.MetodoPago = "Tarjeta Modificar";
            this.entidad!.Codigo = "C00M";
            this.entidad!.Total = 100.0m;
            var entry = this.iConexion!.Entry<Compras>(this.entidad!);
            entry.State = EntityState.Modified;
            Consultar();
            this.iConexion.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Compras!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            return true;
        }

    }
}
