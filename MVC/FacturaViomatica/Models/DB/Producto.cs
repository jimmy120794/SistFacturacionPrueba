using System;
using System.Collections.Generic;

namespace FacturaViomatica.Models.DB
{
    public partial class Producto
    {
        public Producto()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double? Precio { get; set; }

        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
