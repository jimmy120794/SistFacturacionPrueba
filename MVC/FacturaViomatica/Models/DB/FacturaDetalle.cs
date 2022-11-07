using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturaViomatica.Models.DB
{
    public partial class FacturaDetalle
    {
        public int Id { get; set; }
        public int IdFactCab { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        //public decimal Precio { get; set; }

        public virtual FacturaCabecera IdFactCabNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
