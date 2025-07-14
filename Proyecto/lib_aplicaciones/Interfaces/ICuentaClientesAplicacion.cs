using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ICuentaClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<CuentaClientes> PorCorreo(CuentaClientes? entidad);
        List<CuentaClientes> Listar();
        CuentaClientes? Guardar(CuentaClientes? entidad);
        CuentaClientes? Modificar(CuentaClientes? entidad);
        CuentaClientes? Borrar(CuentaClientes? entidad);
    }
}