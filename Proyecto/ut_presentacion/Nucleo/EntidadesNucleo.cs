using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Nombre = "Prueba Cliente";
            entidad.Direccion = "Calle 14";
            entidad.Cedula = "C006-P";
            entidad.Telefono = "1234-p";

            return entidad;
        }

        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Nombre = "Prueba Empleado";
            entidad.Cedula = "C009-p";
            entidad.Salario = 800.0m;
            entidad.Telefono = "1478-p";

            return entidad;
        }


        public static Zapatos? Zapatos()
        {
            var entidad = new Zapatos();
            entidad.Nombre = "Prueba Videojuego";
            entidad.Precio = 120.0m;
            entidad.Talla = "Talla p";
            entidad.Marca = "Marca p";
            entidad.Codigo = "VJ00P";
            entidad.Descripcion = "Descripcion prueba";

            return entidad;
        }

        public static Compras? Compras()
        {
            var entidad = new Compras();
            entidad.MetodoPago = "Tarjeta prueba";
            entidad.Fecha = DateTime.Now;
            entidad.Total = 12.0m;
            entidad.Cliente = 1;
            entidad.Empleado = 1;
            entidad.Codigo = "C00P";

            return entidad;
        }
        public static DetallesCompras? DetallesCompras()
        {
            var entidad = new DetallesCompras();
            entidad.Cantidad = 3;
            entidad.Zapato = 1;
            entidad.Compra = 1;
            entidad.Codigo = "DC00P";
            entidad.Cantidad = 3;
            entidad.Subtotal = 360.0m; // Asignar un subtotal de ejemplo

            return entidad;
        }

        public static Inventarios? Inventarios()
        {
            var entidad = new Inventarios();
            entidad.Cantidad = 15;
            entidad.Zapato = 2;
            entidad.Codigo = "INV00P";

            return entidad;
        }

        public static CuentaClientes? CuentaClientes()
        {
            var entidad = new CuentaClientes();
            entidad.Correo = "sdas@prueba1";
            entidad.Contrasena = "contraseña";
            entidad.Cliente = 1; // Asignar un ID de cliente existente

            return entidad;
        }

        public static CuentaEmpleados? CuentaEmpleados()
        {
            var entidad = new CuentaEmpleados();
            entidad.Correo = "sdas@prueba2";
            entidad.Contrasena = "contraseña";
            entidad.Empleado = 1; // Asignar un ID de empleado existente
            return entidad;
        }

        /*public static Auditorias? Auditorias()
        {
            var entidad = new Auditorias();
            entidad.Accion = "Prueba";
            entidad.Tabla = "Tabla prueba";
            entidad.Fecha = DateTime.Now;
            return entidad;
        }*/
    }
}