using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ICuentaEmpleadosAplicacion
    {
        void Configurar(string StringConexion);
        List<CuentaEmpleados> PorCorreo(CuentaEmpleados? entidad);
        List<CuentaEmpleados> Listar();
        CuentaEmpleados? Guardar(CuentaEmpleados? entidad);
        CuentaEmpleados? Modificar(CuentaEmpleados? entidad);
        CuentaEmpleados? Borrar(CuentaEmpleados? entidad);
    }
}