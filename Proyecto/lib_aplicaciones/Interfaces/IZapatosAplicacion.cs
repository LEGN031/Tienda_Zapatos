using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IZapatosAplicacion
    {
        void Configurar(string StringConexion);
        List<Zapatos> PorCodigo(Zapatos? entidad);
        List<Zapatos> Listar();
        Zapatos? Guardar(Zapatos? entidad);
        Zapatos? Modificar(Zapatos? entidad);
        Zapatos? Borrar(Zapatos? entidad);
    }
}