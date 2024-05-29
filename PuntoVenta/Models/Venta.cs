using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime FechaHora { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<Detalleventa> Detalleventa { get; set; } = new List<Detalleventa>();
}
