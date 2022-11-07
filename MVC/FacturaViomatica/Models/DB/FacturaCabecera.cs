using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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

        //[Display(Name = "Fecha Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //[Display(Name = "FechaVence Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime FechaVence { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
