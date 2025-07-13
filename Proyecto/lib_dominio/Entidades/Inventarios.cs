using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string? Codigo { get; set; }
        public int Zapato { get; set; }
        [ForeignKey("Zapato")] public Zapatos? Zapato_ { get; set; }

    }
}
