﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Zapatos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Talla { get; set; }
        public string? Marca { get; set; }

    }
}
