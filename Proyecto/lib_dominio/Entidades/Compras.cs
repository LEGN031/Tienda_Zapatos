using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Compras
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? MetodoPago { get; set; }
        public decimal Total { get; set; }
        public string? Codigo { get; set; }

        public int Empleado { get; set; }
        [ForeignKey("Empleado")] public Empleados? Empleado_ { get; set; }

        public int Cliente { get; set; }
        [ForeignKey("Cliente")] public Clientes? Cliente_ { get; set; }

        public List<DetallesCompras>? DetallesCompras { get; set; }

        public void CalculoTotal()
        {
            Total = DetallesCompras!.Sum(x => x.Subtotal);
        }
    }
}
