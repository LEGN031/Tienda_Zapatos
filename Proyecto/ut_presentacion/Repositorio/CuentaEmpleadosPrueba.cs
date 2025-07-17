using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    public class CuentaEmpleadosPrueba
    {
        private readonly IConexion? iConexion;
        private List<CuentaEmpleados>? lista;
        private CuentaEmpleados? entidad;
        private Empleados? empleados;

        public CuentaEmpleadosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }


        public void Ejecutar ()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public void Consultar()
        {
            entidad!.Empleado_ = empleados!;
            entidad!.Empleado = this.iConexion!.Empleados!.FirstOrDefault(x => x.Cedula == empleados!.Cedula)!.Id;
            
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.CuentaEmpleados!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.CuentaEmpleados()!;
            this.iConexion!.CuentaEmpleados!.Add(this.entidad!);

            this.empleados = EntidadesNucleo.Empleados();
            this.iConexion!.Empleados!.Add(this.empleados!);

            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Correo = "Correo Modificar";
            this.entidad!.Contrasena = "Contrasena Modificar";
            var entry = this.iConexion!.Entry<CuentaEmpleados>(this.entidad!);
            entry.State = EntityState.Modified;
            Consultar();

            this.iConexion.SaveChanges();
            return true;
        }

        public bool Borrar ()
        {
            this.iConexion!.CuentaEmpleados!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            return true;
        }

    }
}
