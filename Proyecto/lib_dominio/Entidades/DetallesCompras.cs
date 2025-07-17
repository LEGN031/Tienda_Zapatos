using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class DetallesCompras
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public string? Codigo { get; set; }

        public int Zapato { get; set; }
        [ForeignKey("Zapato")] public Zapatos? _Zapato { get; set; }

        public int Compra { get; set; }
        [ForeignKey("Compra")] public Compras? _Compra { get; set; }

        public void CalculoSubtotal()
        {
            Subtotal = Cantidad * _Zapato!.Precio;
        }
    }
}
