using System;
using System.Collections.Generic;

namespace FacturaViomatica.Models.DB
{
    public partial class FacturaCabecera
    {
        public FacturaCabecera()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaVence { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
