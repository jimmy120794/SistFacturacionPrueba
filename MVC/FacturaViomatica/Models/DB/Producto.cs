using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        //[DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        //[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999.99)]
        public decimal Precio { get; set; }

        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
