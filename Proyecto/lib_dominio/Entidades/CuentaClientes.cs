using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class CuentaClientes
    {
        public int Id { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }

        public int Cliente { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
    }
}
