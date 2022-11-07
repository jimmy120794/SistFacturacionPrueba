using MessagePack;
using System;
using System.Collections.Generic;

namespace FacturaViomatica.Models.DB
{
    public partial class Cliente
    {
        public Cliente()
        {
            FacturaCabeceras = new HashSet<FacturaCabecera>();
        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Empresa { get; set; }
        public string? DirEmpresa { get; set; }
        public string? TelEmpresa { get; set; }
        //public DateTime? Fecha_nac { get; set; }

        public virtual ICollection<FacturaCabecera> FacturaCabeceras { get; set; }
    }
}
