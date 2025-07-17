
using System.ComponentModel.DataAnnotations.Schema;


namespace lib_dominio.Entidades
{
    public class CuentaEmpleados
    {
        public int Id { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }

        public int Empleado { get; set; }
        [ForeignKey("Empleado")] public Empleados? Empleado_ { get; set; }
    }
}