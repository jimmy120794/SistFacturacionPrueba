using System;
using System.Collections.Generic;

namespace FacturaViomatica.Models.DB
{
    public partial class FacturaDetalle
    {
        public int Id { get; set; }
        public int IdFactCab { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }

        public virtual FacturaCabecera IdFactCabNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
