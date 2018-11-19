using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Producto
    {
        public int id { get; set; }
        public int codProducto { get; set; }
        public string tipoProducto { get; set; }
        public int saldoMinimo { get; set; }
        public int estado { get; set; }
    }
}
